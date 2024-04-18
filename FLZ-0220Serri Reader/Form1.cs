using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json.Linq;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Diagnostics;

namespace FLZ_0220Serri_Reader
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Nếu true: Cho chương trình chạy
        /// Nếu false: Không cho chương trình chạy
        /// </summary>
        Boolean start = false;

        /// <summary>
        /// Nếu true: Tắt chương trình
        /// Nếu false: Tạm dừng chương trình
        /// </summary>
        Boolean end = false;

        // Danh sách serial Port,
        List<SerialPort> listSerialPort = new List<SerialPort>();

        //2000‐04‐01,15:17:01,00001,02,NG+ ,SData,+0001.,mL/min,+699.,kPa,+0.0000E+0,WORK2

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += MainForm_KeyDown;
            end = true;

        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Nếu người dùng nhấn tổ hợp phím Alt + F4, thì chương trình sẽ đóng lại
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                string tb = "Để tắt chương trình, nhấn vào nút KẾT THÚC";

                if (!end) tb = "Để tắt chương trình, nhấn 2 lần vào vị trí TẠM DỪNG";
                e.Handled = true;
                this.thongBao(tb, true, false);
            }
        }

        private string layVTLuuKQ()
        {
            string vt = this.layDuongDanLuuKQ();

            if (vt == "")
            {
                this.thongBao("Cần đặt vị trí lưu kết quả", true, false);
            }

            return vt;

        }

        private void setDsPortMay(string[] ports)
        {
            cbxPortMay.Items.Clear();
            cbxPortMay.Items.AddRange(ports);
            cbxPortMay.Text = ports[0];
        }

        public void thongBao(string tb, Boolean hienTB = true, Boolean xoaTB = true)
        {

            lbThongBaoLoi.Text = tb;

            if (hienTB) { MessageBox.Show(tb, "Thông Báo"); }
            if (xoaTB) { this.xoaThongBaoLoi(); }

        }

        static string[] layDSPortCoSan()
        {
            return SerialPort.GetPortNames();
        }

        private void btnChonNoiLuu_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdVtLuu = new FolderBrowserDialog();

            // Thiết lập các thuộc tính của FolderBrowserDialog nếu cần thiết
            fbdVtLuu.Description = "Chọn thư mục để lưu tệp";
            fbdVtLuu.ShowNewFolderButton = true;

            // Hiển thị hộp thoại và kiểm tra nếu người dùng đã chọn OK
            if (fbdVtLuu.ShowDialog() == DialogResult.OK)
            {
                // Lưu đường dẫn đã chọn vào biến hoặc thuộc tính phù hợp
                string selectedFolderPath = fbdVtLuu.SelectedPath;

                // Lưu chuỗi JSON vào setting ABC
                Properties.Settings.Default.vtLuuKQ = selectedFolderPath;

                // Lưu các thay đổi
                Properties.Settings.Default.Save();

                lbThuMucLuuKQ.Text = selectedFolderPath;

                this.thongBao("Đường dẫn lưu kết quả được update", false);
            }

        }

        private void btnDkiMay_Click(object sender, EventArgs e)
        {
            string tenMay = tbMayDo.Text;
            string portMay = cbxPortMay.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(tenMay))
            {
                this.thongBao("Chưa nhập Tên Máy");
                return;
            }

            ttInput inputObj = new ttInput(tenMay, portMay);

            bool exists = false;


            foreach (DataGridViewRow row in grvDSDki.Rows)
            {
                if (row.Cells["tenMay"].Value?.ToString() == inputObj.TenMay ||
                    row.Cells["tenPort"].Value?.ToString() == inputObj.TenPort)
                {
                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                grvDSDki.Rows.Add(inputObj.TenMay, inputObj.TenPort);
            }
            else
            {
                this.thongBao("Tên Máy hoặc Tên Port đã được khai báo");
            }
        }

        // Sau 3s xoá nội dung lỗi
        private async void xoaThongBaoLoi()
        {
            await Task.Delay(3000);
            lbThongBaoLoi.Text = "";
        }

        private void btnLuuDS_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn lưu dữ liệu không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Thực hiện lưu dữ liệu

                // Lấy danh sách từ DataGridView
                List<ttInput> dsPort = new List<ttInput>();

                if (grvDSDki.Rows.Count == 0)
                {
                    this.thongBao("Không có dữ liệu để lưu");
                    return;
                }

                foreach (DataGridViewRow row in grvDSDki.Rows)
                {
                    // Kiểm tra nếu dòng đó không phải là dòng trống
                    if (!row.IsNewRow)
                    {
                        // Lấy dữ liệu từ các cột của dòng
                        ttInput data = new ttInput(row.Cells["tenMay"].Value.ToString(), row.Cells["tenPort"].Value.ToString());

                        // Thêm dữ liệu vào danh sách
                        dsPort.Add(data);
                    }
                }

                this.saveSettingsTTInput(dsPort);
                this.updateDsMayDoHang(dsPort);
                this.updateDsTTMayDoHang(dsPort);
                this.thongBao("Lưu dữ liệu thành công");
            }

        }

        // Update danh sách máy đo hàng 
        private void updateDsMayDoHang(List<ttInput> dsPort)
        {
            cbxChonMayDo.DataSource = null;
            cbxChonMayDo.DataSource = dsPort;
            cbxChonMayDo.DisplayMember = "TenMay";

        }

        // Lưu thông tin vào Settings.setting
        private void saveSettingsTTInput(List<ttInput> ttInput)
        {
            string json = JsonConvert.SerializeObject(ttInput);

            // Lưu chuỗi JSON vào setting ABC
            Properties.Settings.Default.ttInput = json;

            // Lưu các thay đổi
            Properties.Settings.Default.Save();

        }

        // Xoá danh sách ttInput trong datagridview
        private void btnXoaDS_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xoá dữ liệu không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Xoá dữ liệu lưu trong Settings.setting
                this.xoaDLSetting();

                // Xoá dữ liệu trong datagridview danh sách đăng kí
                this.xoaDLDatagridView(grvDSDki);

                // Xoá dữ liệu trong datagridview trạng thái máy đo
                this.xoaDLDatagridView(grvDSMayDangHoatDong);

                // Xoá dữ liệu trong Chọn máy đo
                cbxChonMayDo.DataSource = null;               

                // Thông báo
                this.thongBao("Xoá dữ liệu thành công");
            }

        }

        // Xoá dữ liệu trong datagridview
        private void xoaDLDatagridView(DataGridView grv)
        {
            grv.Rows.Clear();
        }

        // Xoá dữ liệu trong Settings.setting
        private void xoaDLSetting()
        {
            // Gán giá trị của setting ABC thành null hoặc chuỗi rỗng
            Properties.Settings.Default.ttInput = null;

            // Lưu các thay đổi
            Properties.Settings.Default.Save();
        }

        // Lấy toàn bộ thông tin Input từ Settings.setting
        private List<ttInput> layDuLieuInput()
        {
            // Lấy chuỗi JSON từ setting ABC
            string json = Properties.Settings.Default.ttInput;
            List<ttInput> dsPort = new List<ttInput>();

            // Kiểm tra xem chuỗi JSON có tồn tại không
            if (!string.IsNullOrEmpty(json))
            {
                // Chuyển đổi chuỗi JSON thành danh sách dsPort
                dsPort = JsonConvert.DeserializeObject<List<ttInput>>(json);
            }
            return dsPort;
        }

        // Ứng dụng được build hoàn thiện
        private void Form1_Shown(object sender, EventArgs e)
        {

            // Lấy vị trí lưu
            string vtLuuFile = this.layVTLuuKQ();
            lbThuMucLuuKQ.Text = vtLuuFile;

            // Lấy danh sách các port có sẵn 
            string[] ports = layDSPortCoSan();

            if (ports.Length == 0)
            {
                this.thongBao("Không tìm thấy cổng COM nào trên máy tính.",true,true);
                return;
            }

            List<ttInput> dlInput = this.layDuLieuInput();

            // Ghi dữ liệu vào combobox Port Máy
            this.setDsPortMay(ports);

            if (dlInput.Count == 0 || vtLuuFile == "")
            {
                start = false;
                this.thongBao("Cần cập nhật danh sách máy kiểm tra", true, false);
                return;
            }

            // Hiển thị dữ liệu vào DANH SÁCH ĐĂNG KÍ MÁY ĐO
            this.ghiDLVaoDSDki(dlInput);
            // Hiển thị danh sách máy đo
            this.updateDsMayDoHang(dlInput);
            // Hiển thị danh sách các máy đo vào bảng TRANG THÁI MÁY ĐO
            this.updateDsTTMayDoHang(dlInput);
        }

        // Lưu dữ liệu vào danh sách đăng kí THÔNG TIN INPUT
        private void ghiDLVaoDSDki(List<ttInput> ttInput)
        {
            foreach (var item in ttInput)
            {
                int rowIndex = grvDSDki.Rows.Add();
                grvDSDki.Rows[rowIndex].Cells["TenMay"].Value = item.TenMay;
                grvDSDki.Rows[rowIndex].Cells["TenPort"].Value = item.TenPort;
            }
        }

        // Lưu dữ liệu vào danh sách chờ đo
        private void updateDsTTMayDoHang(List<ttInput> ttInput)
        {
            
            foreach (var item in ttInput)
            {
                int rowIndex = grvDSMayDangHoatDong.Rows.Add();
                grvDSMayDangHoatDong.Rows[rowIndex].Cells["tenMay_TT"].Value = item.TenMay;
                grvDSMayDangHoatDong.Rows[rowIndex].Cells["tenPort_TT"].Value = item.TenPort;
                grvDSMayDangHoatDong.Rows[rowIndex].Cells["QrInput_TT"].Value = "Không có dữ liệu";
                grvDSMayDangHoatDong.Rows[rowIndex].Cells["kq_TT"].Value = "Đang chờ ...";
                grvDSMayDangHoatDong.Rows[rowIndex].Cells["trangThai_TT"].Value = "Đang chờ ..."; 
            }
        }

        // Lấy dữ liệu đường dẫn lưu kết quả từ Settings.setting
        private string layDuongDanLuuKQ()
        {
            return Properties.Settings.Default.vtLuuKQ;
        }

        // Mở thư mục lưu kết quả
        private void btnMoThuMucLuuKQ_Click(object sender, EventArgs e)
        {
            #region Sau khi hoàn thành sẽ bỏ comment
            string path = this.layDuongDanLuuKQ();

            if (System.IO.Directory.Exists(path))
            {
                // Mở thư mục sử dụng Process.Start
                Process.Start("explorer.exe", path);
            }
            else
            {
                this.thongBao("Thư mục không tồn tại hoặc đã bị xoá", true, false);
            }
            #endregion
        }

        // Link tới facebook
        private void linklbAboutMe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/tuy.chon.921?locale=vi_VN");
        }

        // Link tới zalo
        private void llableZaloMe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://zalo.me/0589988998");
        }

        // Khởi động chương trình test
        private void btnBatDau_Click(object sender, EventArgs e)
        {
            string vtLuuFile = this.layDuongDanLuuKQ();
            List<ttInput> dlInput = this.layDuLieuInput();
            
            // Kiểm tra dữ liệu
            if (vtLuuFile == "" || dlInput.Count == 0)
            {
                start = false;
                this.thongBao("Không đủ dữ liệu để bắt đầu.", true, false);
                return;
            }

            // Disable các chức năng
            this.thayDoiTrangThai(false);

            // Điền trạng thái máy vào bảng theo dõi TÌNH TRẠNG MÁY ĐO


            // Đặt con trỏ chuột vào textbox QR
            tbQrCodeInput.Focus();

            // Cho phép máy chạy
            start = true;

            // Chuyển sang trạng thái tạm dừng
            end = false;
        }

        // Giúp chuyển đổi trạng thái các đối tượng khi nút BẮT ĐẦU hoặc TẠM DỪNG được nhấn
        private void thayDoiTrangThai(Boolean active)
        {
            btnDkiMay.Enabled = active;
            btnBatDau.Enabled = active;
            tbMayDo.Enabled = active;
            cbxPortMay.Enabled = active;
            btnLuuDS.Enabled = active;
            btnXoaDS.Enabled = active;
            btnChonNoiLuu.Enabled = active;
            //cbxChonMayDo.Enabled = active;

            tbQrCodeInput.Enabled = !active;

            btnKetThuc.Text = end == true ? "Tạm dừng" : "Kết thúc";
        }

        // Nút KẾT THÚC hoặc TẠM NGỪNG ĐƯỢC NHẤN
        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            // Đóng chương trình
            if (end)
            {
                DialogResult closeMess = MessageBox.Show("Chương trình sẽ đóng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (closeMess == DialogResult.Yes)
                {
                    // Viết một số hàm xuất excel ở đây
                    // ...

                    Close();
                }
                return;
            }

            DialogResult result = MessageBox.Show("Tạm dừng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            this.thayDoiTrangThai(true);

            // Tắt chạy
            start = false;

            // Nhấn nút nữa sẽ thoát
            end = true;

        }

        // Sự kiện nhận dữ liệu từ textbox Qr
        private void tbQrCodeInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region Bảng chú thích các kí hiệu
            // Kí tự CR = \r
            // Kí tự LF = \n
            // Kí tự CRLF = \r\n
            #endregion

            if (e.KeyChar == '\r')
            {
                // Lấy thông tin input
                ttInput tt = this.timTenMayTheoPORT();

                SerialPort port = this.taoSerialPort(tt.TenPort);
                if (port == null)
                {
                    this.thongBao("Không tìm thấy "+ tt.TenPort + ". Update lại DS ĐĂNG KÍ MÁY ĐO và thử lại.",true,false);
                    return;
                }

                try
                {
                    port.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    this.thongBao("Máy "+ tt.TenMay + " đang được sử dụng. Chọn máy đo khác", true, false);
                    return;
                }




            }
        }

        // Cập nhật dữ liệu vào bảng TÌNH TRẠNG MÁY ĐO



        private SerialPort taoSerialPort(string portName, int br = 9600)
        {
            SerialPort serialPort = new SerialPort();
            serialPort.PortName = portName;
            serialPort.BaudRate = br;
            return serialPort;
        }

        private ttInput timTenMayTheoPORT()
        {
            ttInput selectedItem = (ttInput)cbxChonMayDo.SelectedItem;
            return new ttInput(selectedItem.TenMay, selectedItem.TenPort);
        }

    }

    public class ttInput
    {
        public string TenMay { get; set; }
        public string TenPort { get; set; }
        public ttInput(string tenMay, string portMay)
        {
            TenMay = tenMay;
            TenPort = portMay;
        }
    }
}
