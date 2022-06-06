using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;


namespace QLHSVP
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            XmlDocument qlhs = new XmlDocument();
            qlhs.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
            foreach (XmlElement item in qlhs.SelectNodes("//TaiKhoan"))
            {
                if (item.SelectSingleNode("TenDangNhap").InnerText == txtDN.Text && item.SelectSingleNode("MatKhau").InnerText == txtMK.Text)
                {
                    QLHieuSach ql = new QLHieuSach();
                    this.Hide();
                    ql.Show();
                    MessageBox.Show("Đăng nhập thành công!");
                    break;
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
                    break;
                }

            }
        }
    }
}
