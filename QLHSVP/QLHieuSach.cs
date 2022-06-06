using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLHSVP
{
    public partial class QLHieuSach : Form
    {

        public QLHieuSach()
        {
            InitializeComponent();
        }

        private void btnQLy_Click(object sender, EventArgs e)
        {
            panel2.Height = btnQLy.Height;
            panel2.Top = btnQLy.Top;
            QuanLy qL = new QuanLy();
            qL.TopLevel = false;
            PanelContent.Controls.Clear();
            PanelContent.Controls.Add(qL);
            qL.Show();
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            panel2.Height = btnTK.Height;
            panel2.Top = btnTK.Top;
            ThongKe tK = new ThongKe();
            tK.TopLevel = false;
            PanelContent.Controls.Clear();
            PanelContent.Controls.Add(tK);
            tK.Show();
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            panel2.Height = btnNV.Height;
            panel2.Top = btnNV.Top;
            NhanVien nV = new NhanVien();
            nV.TopLevel = false;
            PanelContent.Controls.Clear();
            PanelContent.Controls.Add(nV);
            nV.Show();
        }

         private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void tabPageQL_Click(object sender, EventArgs e)
        {

        }
    }
}
