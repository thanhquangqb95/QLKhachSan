using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKHACHSAN
{
    public partial class UCNhanVien : UserControl
    {
        String manv;
        public UCNhanVien()
        {
            InitializeComponent();
        }

        private void UCNhanVien_Load(object sender, EventArgs e)
        {
            ChucVu();
            BoPhan();
            NhanVien();
        }
        private void NhanVien()
        {
            lvNhanVien.Items.Clear();
            DataTable nv = CSDL.ketnoi(@"select MaNV,TenNV, NgaySinh, GioiTinh, DienThoai, DiaChi , TenBoPhan ,TenCV from NhanVien n, BoPhan b, ChucVu c where n.MaBP= b.MaBP and c.MaCV=n.MaCV");
            for (int i = 0; i < nv.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = nv.Rows[i][0].ToString();
                item.SubItems.Add(nv.Rows[i][1].ToString());
                item.SubItems.Add(nv.Rows[i][2].ToString());
                if (nv.Rows[i][3].ToString() == "1")
                    item.SubItems.Add("Nam");
                if (nv.Rows[i][3].ToString() == "0")
                    item.SubItems.Add("Nữ");
                item.SubItems.Add(nv.Rows[i][4].ToString());
                item.SubItems.Add(nv.Rows[i][5].ToString());
                item.SubItems.Add(nv.Rows[i][7].ToString());
                item.SubItems.Add(nv.Rows[i][6].ToString());
                lvNhanVien.Items.Add(item);
            }
        }
        private void BoPhan()
        {
            DataTable bp =CSDL.ketnoi(@"select TenBoPhan from BoPhan");
            for (int h = 0; h < bp.Rows.Count; h++)
            {
                cbbBoPhan_NV.Items.Add(bp.Rows[h][0].ToString());
            }
        }
        private void ChucVu()
        {
            DataTable cv = CSDL.ketnoi(@"select TenCV from ChucVu");
            for (int h = 0; h < cv.Rows.Count; h++)
            {
                cbbChucVu_nv.Items.Add(cv.Rows[h][0].ToString());
            }
        }
        private void lvNhanVien_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var item = e.Item;
            manv = item.Text;
            txtHoTen_nv.Text = item.SubItems[1].Text;
            dateNgaySinh_NV.Text = item.SubItems[2].Text;
            cbbGioiTinh_nv.Text = item.SubItems[3].Text;
            txtSDT_NV.Text = item.SubItems[4].Text;
            txtDiaChi_nv.Text = item.SubItems[5].Text;
            cbbChucVu_nv.Text = item.SubItems[6].Text;
            cbbBoPhan_NV.Text = item.SubItems[7].Text;
        }

        public void capnhap_nv()
        {
            txtHoTen_nv.Text = "";
            dateNgaySinh_NV.Text = "";
            cbbGioiTinh_nv.Text = "";
            txtSDT_NV.Text = "";
            txtDiaChi_nv.Text = "";
            cbbChucVu_nv.Text = "";
            cbbBoPhan_NV.Text = "";
        }
        
      
        private void btnSuaQL_Click(object sender, EventArgs e)
        {
            DataTable dt = CSDL.ketnoi(@"select MaBP from BoPhan where TenBoPhan=N'" + cbbBoPhan_NV.Text + "'");
            DataTable dt2 = CSDL.ketnoi(@"select MaCV from ChucVu where TenCV=N'" + cbbChucVu_nv.Text + "'");
            String gioitinh;
            if (cbbGioiTinh_nv.Text == "Nam")
            {
                gioitinh = "1";
            }
            else
            {
                gioitinh = "0";
            }
            if (CSDL.Luucsdl(" update NhanVien set TenNV=N'" + txtHoTen_nv.Text + "',NgaySinh='" + dateNgaySinh_NV.Text + "',GioiTinh='" + gioitinh
                + "',DienThoai='" + txtSDT_NV.Text + "',DiaChi=N'" + txtDiaChi_nv.Text + "',MaCV='" + dt2.Rows[0][0].ToString() + "',MaBP='" + dt.Rows[0][0].ToString() + "' where MaNV='" + manv + "'") == 1)
            {
                MessageBox.Show("Sửa Thành Công");
                NhanVien();
                capnhap_nv();
            }
            else
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnThemQL_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = CSDL.ketnoi(@"select MaBP from BoPhan where TenBoPhan=N'" + cbbBoPhan_NV.Text + "'");
                DataTable dt2 = CSDL.ketnoi(@"select MaCV from ChucVu where TenCV=N'" + cbbChucVu_nv.Text + "'");
                String gioitinh;
                if (cbbGioiTinh_nv.Text == "Nam")
                {
                    gioitinh = "1";
                }
                else
                {
                    gioitinh = "0";
                }
                if (CSDL.Luucsdl("insert into NhanVien values(N'" + txtHoTen_nv.Text + "','" + dateNgaySinh_NV.Text + "'," + gioitinh + ",'"
                    + txtSDT_NV.Text + "',N'" + txtDiaChi_nv.Text + "','" + dt2.Rows[0][0].ToString() + "','" + dt.Rows[0][0].ToString() + "')") == 1)
                {
                    MessageBox.Show("Thêm Thành công");
                    NhanVien();
                    capnhap_nv();
                }
                else
                {
                    MessageBox.Show("Lỗi");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnXoaQL_Click(object sender, EventArgs e)
        {
            if (CSDL.Luucsdl(" delete from NhanVien where MaNV='" + manv + "'") == 1)
            {
                MessageBox.Show("Xóa Thành Công");
                NhanVien();
                capnhap_nv();
            }
            else
            {
                MessageBox.Show("Lỗi");
            }
        }
    }
}
