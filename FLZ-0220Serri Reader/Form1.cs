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
        string vtLuuFile = "";
        public Form1()
        {
            InitializeComponent();
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

        private void layDSPortCoSan()
        {
            string[] ports = GetAvailableCOMPorts();

            //
            if (ports.Length == 0)
            {
                this.thongBao("Không tìm thấy cổng COM nào trên máy tính.");
            }
            else
            {
                cbxPortMay.Items.Clear();
                cbxPortMay.Items.AddRange(ports);
                cbxPortMay.Text = ports[0];
            }

        }

        public void thongBao(string tb, Boolean hienTB = true, Boolean xoaTB = true)
        {

            lbThongBaoLoi.Text = tb;

            if (hienTB) { MessageBox.Show(tb, "Thông Báo"); }
            if (xoaTB) { this.xoaThongBaoLoi(); }

        }

        static string[] GetAvailableCOMPorts()
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
            this.thongBao("Lưu dữ liệu thành công");

        }

        private void updateDsMayDoHang(List<ttInput> dsPort)
        {
            cbxChonMayDo.Items.Clear();
            foreach (var ttIp in dsPort)
            {
                cbxChonMayDo.Items.Add(ttIp.TenMay);
            }
            cbxChonMayDo.Text = dsPort[0].TenMay;

        }

        private void saveSettingsTTInput(List<ttInput> ttInput)
        {
            string json = JsonConvert.SerializeObject(ttInput);

            // Lưu chuỗi JSON vào setting ABC
            Properties.Settings.Default.ttInput = json;

            // Lưu các thay đổi
            Properties.Settings.Default.Save();

        }

        private void btnXoaDS_Click(object sender, EventArgs e)
        {

            // Xoá dữ liệu lưu trong Settings.setting
            this.xoaDLSetting();

            // Xoá dữ liệu trong datagridview danh sách đăng kí
            this.xoaDLDatagridView(grvDSDki);

            // Xoá dữ liệu trong Chọn máy đo
            cbxChonMayDo.Items.Clear();

            // Thông báo
            this.thongBao("Xoá dữ liệu thành công");

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


        private void Form1_Shown(object sender, EventArgs e)
        {
            // Lấy danh sách các port có sẵn 
            this.layDSPortCoSan();

            // Lấy vị trí lưu
            vtLuuFile = this.layVTLuuKQ();

            lbThuMucLuuKQ.Text = vtLuuFile;

            List<ttInput> ttInput = this.layDuLieuInput();

            if (ttInput.Count > 0)
            {
                this.ghiDLVaoDSDki(ttInput);
                this.updateDsMayDoHang(ttInput);
            }
            else
            {
                this.thongBao("Cần cập nhật danh sách máy kiểm tra",false,false);
            }

        }

        private void ghiDLVaoDSDki(List<ttInput> ttInput)
        {
            foreach (var item in ttInput)
            {
                int rowIndex = grvDSDki.Rows.Add();
                grvDSDki.Rows[rowIndex].Cells["TenMay"].Value = item.TenMay;
                grvDSDki.Rows[rowIndex].Cells["TenPort"].Value = item.TenPort;
            }
        }

        private string layDuongDanLuuKQ()
        {
            return Properties.Settings.Default.vtLuuKQ;
        }

        private void btnMoThuMucLuuKQ_Click(object sender, EventArgs e)
        {
            string path = this.layDuongDanLuuKQ();

            if (System.IO.Directory.Exists(path))
            {
                // Mở thư mục sử dụng Process.Start
                Process.Start("explorer.exe", path);
            }
            else
            {
                this.thongBao("Thư mục không tồn tại hoặc đã bị xoá",true,false);
            }
        }

        private void linklbAboutMe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/tuy.chon.921?locale=vi_VN");
        }

        private void llableZaloMe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://zalo.me/0589988998");
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
