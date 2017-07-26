using DevComponents.DotNetBar;
using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLKHACHSAN
{
    public partial class FrmMain : DevComponents.DotNetBar.Office2007RibbonForm
    {
        
        public FrmMain()
        {
            InitializeComponent();
        }
        public void FrmMain_Load(object sender, EventArgs e)
        {
            kiemtraketnoi();
        }


        //Chức năng
        // Thêm Tab mới 
        private void addtab(string tabname, UserControl control)
        {
            foreach (TabItem tabPage in tabControl1.Tabs)
                if (tabPage.Text == tabname)
                {
                    tabControl1.SelectedTab = tabPage;
                    return;
                }
            TabControlPanel newtabpannel = new DevComponents.DotNetBar.TabControlPanel();
            TabItem newtab = new TabItem(this.components);
            newtabpannel.Dock = System.Windows.Forms.DockStyle.Fill;
            newtabpannel.Location = new System.Drawing.Point(0, 26);
            newtabpannel.Name = tabname;
            newtabpannel.Padding = new System.Windows.Forms.Padding(1);
            newtabpannel.Size = new System.Drawing.Size(1230, 384);
            newtabpannel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            newtabpannel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            newtabpannel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            newtabpannel.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            newtabpannel.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            newtabpannel.Style.GradientAngle = 90;
            newtabpannel.TabIndex = 2;
            newtabpannel.TabItem = newtab;
            Random ran = new Random();
            newtab.Name = tabname + ran.Next(100000) + ran.Next(22342);

            newtab.AttachedControl = newtabpannel;
            newtab.Text = tabname;
            newtab.CloseButtonVisible = true;
            control.Dock = DockStyle.Fill;
            newtabpannel.Controls.Add(control);
            tabControl1.Controls.Add(newtabpannel);
            tabControl1.Tabs.Add(newtab);
            tabControl1.SelectedTab = newtab;

        }
        private void kiemtraketnoi()
        {
 
            try
            {
                MessageBox.Show("Kết nối dữ liệu");

                CSDL.con.Open();

                MessageBox.Show("Kết nối dữ liệu thành công!");
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message);
            }

            
        }
        private void close()
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
        private void tabControl1_TabItemClose(object sender, TabStripActionEventArgs e)
        {
            //Thoát tabcontrol 
            close();
        }

        //Click button
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            UCNhanVien ucNhanVien = new UCNhanVien();
            addtab("Nhân Viên", ucNhanVien);
        }

        private void btnBoPhan_Click(object sender, EventArgs e)
        {
           
        }
    }
}
