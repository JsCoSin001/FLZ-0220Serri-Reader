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
using OfficeOpenXml;

namespace FLZ_0220Serri_Reader
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Nếu true: Cho chương trình chạy
        /// Nếu false: Không cho chương trình chạy
        /// </summary>
        Boolean isReadingData = false;

        // Dấu phân cách
        char dau = ',';

        private readonly object _lock = new object();

        // Danh sách serial Port,
        private List<ketQuaDo> dsKQDo = new List<ketQuaDo>();

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += MainForm_KeyDown;

        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Nếu người dùng nhấn tổ hợp phím Alt + F4, thì chương trình sẽ đóng lại
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                string tb = "Để tắt chương trình, nhấn vào nút KẾT THÚC";

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
                isReadingData = false;
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

            grvDSMayDangHoatDong.Rows.Clear();
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

        private bool taoExcelFile(List<string> dsTieuDe)
        {
            string path = this.layDuongDanLuuKQ();
            string fileName = this.taoTenFile();
            string filePath = Path.Combine(path, fileName); // Kết hợp thư mục và tên tệp  

            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                FileInfo fileInfo = new FileInfo(filePath);

                // Nếu đường filePath không có dữ liệu thì tạo mới file
                ExcelPackage package = fileInfo.Exists ?  new ExcelPackage(fileInfo) : new ExcelPackage();

                // Lấy hoặc tạo trang Excel đầu tiên
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
                if (worksheet == null)
                {
                    worksheet = package.Workbook.Worksheets.Add("Sheet1");
                    worksheet.Cells[1, 1].LoadFromArrays(new List<string[]> { dsTieuDe.ToArray() });
                }

                // Xác định dòng cuối cùng chứa dữ liệu
                int lastRow = worksheet.Dimension?.End.Row ?? 0;

                // Bắt đầu ghi dữ liệu mới từ dòng tiếp theo sau dòng cuối cùng
                int newRow = lastRow + 1;

                worksheet.Cells["A" + newRow].LoadFromCollection(dsKQDo, false);

                package.SaveAs(fileInfo);

                return true;
            }catch { 
                return false;
            }
        }

        // Định dạng ngày tháng năm cho tên file
        private string taoTenFile()
        {
            return DateTime.Now.ToString("dd/MM/yyyy");
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
                isReadingData = false;
                this.thongBao("Không đủ dữ liệu để bắt đầu.", true, false);
                return;
            }

            // Disable các chức năng
            this.thayDoiTrangThai(false);

            // Điền trạng thái máy vào bảng theo dõi TÌNH TRẠNG MÁY ĐO


            // Đặt con trỏ chuột vào textbox QR
            tbQrCodeInput.Focus();

            // Cho phép máy chạy
            isReadingData = true;

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
            DialogResult closeMess = MessageBox.Show("Chương trình sẽ đóng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (closeMess == DialogResult.Yes)
            {
                if (dsKQDo.Count() == 0)
                {
                    Close();
                    return;
                };

                List<string> dsTieuDe = new List<string> { "MÃ HÀNG", "TÊN MÁY", "TÊN CỔNG", "NGÀY SX", "QR", "THỜI GIAN", "ĐÁNH GIÁ", "KẾT QUẢ", "ĐƠN VỊ", "ÁP SUẤT TEST", "ĐƠN VỊ ÁP SUẤT TEST" };

                bool taoFileExcel = this.taoExcelFile(dsTieuDe);

                do
                {
                    DialogResult tb = MessageBox.Show("FILE CHƯA ĐƯỢC LƯU. \nYES để thử lại - NO để thoát", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    taoFileExcel = tb == DialogResult.Yes ? true : false;
                } while (taoFileExcel);

                Close();
            }    
        }

        // Sự kiện nhận dữ liệu từ textbox Qr
        private async void tbQrCodeInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region Bảng chú thích các kí hiệu
            // Kí tự CR = \r
            // Kí tự LF = \n
            // Kí tự CRLF = \r\n
            #endregion

            if (e.KeyChar == '\r' && isReadingData)
            {
                // Lấy thông tin input
                ttInput tt = this.timTenMayTheoPORT();

                //lblQr.Text = tbQrCodeInput.Text;
                //tbQrCodeInput.Text = "";

                SerialPort port = this.taoSerialPort(tt.TenPort);

                if (port == null)
                {
                    this.thongBao("Không tìm thấy "+ tt.TenPort + ". Update lại DS ĐĂNG KÍ MÁY ĐO và Thử lại.",true,false);
                    return;
                }

                try
                {
                    //Thread listeningThread = new Thread(() => ListenSerialData(port));
                    //listeningThread.Start();


                    ketQuaDo kquado = new ketQuaDo();
                    kquado.maHang = "Test mã Hàng";
                    kquado.tenMay = tt.TenMay;
                    kquado.tenPort = tt.TenPort;
                    kquado.qr = tbQrCodeInput.Text;

                    await ListenSerialData(port, kquado);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    this.thongBao("Máy "+ tt.TenMay + " đang được sử dụng. Chọn máy đo khác", true, false);
                    return;
                }
            }
        }

        // Lắng nghe kết quả từ cổng serial port
        private Task ListenSerialData(SerialPort serialPort, ketQuaDo kquado)
        {
            try
            {
                serialPort.Open();

                serialPort.DataReceived += (sender, e) =>
                {
                    DataReceivedHandler(sender, e, kquado);
                };
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine("Timeout: Không nhận được dữ liệu mới từ port.");
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ khác
                //Console.WriteLine("Lỗi khi đọc dữ liệu từ port: " + ex.Message);
            }

            return Task.CompletedTask;
        }
        
        // Nhận dữ liệu
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e , ketQuaDo kquado)
        {
            SerialPort sp = (SerialPort)sender;
            string data = sp.ReadExisting();

            string[] arr = data.Split(dau);

            if (arr.Length < 1) return;

            // Định dạng ngày mong muốn
            string[] formats = { "yyyy-MM-dd" };

            // Kiểm tra xem chuỗi có đúng định dạng YYYY-MM-DD không
            if (!DateTime.TryParseExact(arr[0], formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime lotSX))
            {
                return;
            }

            kquado.lotSX = arr[0];
            kquado.thoiGian = arr[1];
            kquado.danhGia = arr[3];
            kquado.ketQua = arr[5];
            kquado.donVi = arr[6];
            kquado.apSuatTest = arr[7];
            kquado.donViApSuatTest = arr[8];  

            lock (_lock) { dsKQDo.Add(kquado); }
            sp.Close();
            return;
        }

        // Tạo 1 đối tượng serial port
        private SerialPort taoSerialPort(string portName, int br = 9600)
        {
            SerialPort serialPort = new SerialPort();
            serialPort.PortName = portName;
            serialPort.BaudRate = br;
            return serialPort;
        }

        // Tìm tên máy theo port
        private ttInput timTenMayTheoPORT()
        {
            ttInput selectedItem = (ttInput)cbxChonMayDo.SelectedItem;
            return new ttInput(selectedItem.TenMay, selectedItem.TenPort);
        }


        private void pbTrangThai_Click(object sender, EventArgs e)
        {
            #region
            //Sau này sẽ xoá dữ liệu này

            Console.WriteLine(dsKQDo);

            #endregion
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

    public class ketQuaDo
    {
        private string MaHang;
        private string TenMay;
        private string TenPort;
        private string LotSX;
        private string Qr;
        private string ThoiGian;
        private string DanhGia;
        private string KetQua;
        private string DonVi;
        private string ApSuatTest;
        private string DonViApSuatTest;
        public string maHang
        {
            get { return MaHang; }
            set { MaHang = value; }
        }
        public string tenMay
        {
            get { return TenMay; }
            set { TenMay = value; }
        }
        public string tenPort
        {
            get { return TenPort; }
            set { TenPort = value; }
        }
        public string lotSX
        {
            get { return LotSX; }
            set { LotSX = value; }
        }
        public string qr
        {
            get { return Qr; }
            set { Qr = value; }
        }
        public string thoiGian
        {
            get { return ThoiGian; }
            set { ThoiGian = value; }
        }
        public string danhGia
        {
            get { return DanhGia; }
            set { DanhGia = value; }
        }
        public string ketQua
        {
            get { return KetQua; }
            set { KetQua = value; }
        }
        public string donVi
        {
            get { return DonVi; }
            set { DonVi = value; }
        }
        public string apSuatTest
        {
            get { return ApSuatTest; }
            set { ApSuatTest = value; }
        }
        public string donViApSuatTest
        {
            get { return DonViApSuatTest; }
            set { DonViApSuatTest = value; }
        }
    }
}
