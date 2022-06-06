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
using System.Xml.XPath;

namespace QLHSVP
{
    public partial class QuanLy : Form
    {
        public QuanLy()
        {
            InitializeComponent();
        }

       private void TaiDuLieu()
        {

            listSach.Items.Clear();
            DataSet DLSach = new DataSet();
            DLSach.ReadXml(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
            DataTable dlS = new DataTable();
            dlS = DLSach.Tables["Sach"];
            int i = 0;
            foreach(DataRow dtr in dlS.Rows)
            {
                listSach.Items.Add(dtr["MaSach"].ToString());
                listSach.Items[i].SubItems.Add(dtr["TenSach"].ToString());
                listSach.Items[i].SubItems.Add(dtr["MaTheLoai"].ToString());
                listSach.Items[i].SubItems.Add(dtr["MaTacGia"].ToString());
                listSach.Items[i].SubItems.Add(dtr["DonGia"].ToString());
                listSach.Items[i].SubItems.Add(dtr["NamXuatBan"].ToString());
                i++;
            }

            DataSet dlTL = new DataSet();
            dlTL.ReadXml(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
            DataTable dlTheLoai = new DataTable();
            dlTheLoai = dlTL.Tables["TheLoai"];
            int k = 0;
            foreach(DataRow dtr in dlTheLoai.Rows)
            {
                listTL.Items.Add(dtr["MaTheLoai"].ToString());
                listTL.Items[k].SubItems.Add(dtr["TenTheLoai"].ToString());
                k++;
            }

            DataSet dlTG = new DataSet();
            dlTG.ReadXml(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
            DataTable dlTacGia = new DataTable();
            dlTacGia = dlTG.Tables["TacGia"];
            int j = 0;
            foreach (DataRow dtr in dlTacGia.Rows)
            {
                listTacGia.Items.Add(dtr["MaTacGia"].ToString());
                listTacGia.Items[j].SubItems.Add(dtr["TenTacGia"].ToString());
                j++;
            }

            DataSet dlNCC = new DataSet();
            dlNCC.ReadXml(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
            DataTable dlNhaCungCap = new DataTable();
            dlNhaCungCap = dlNCC.Tables["NhaCungCap"];
            int l = 0;
            foreach (DataRow dtr in dlNhaCungCap.Rows)
            {
                listNCC.Items.Add(dtr["MaNhaCungCap"].ToString());
                listNCC.Items[l].SubItems.Add(dtr["TenNhaCungCap"].ToString());
                listNCC.Items[l].SubItems.Add(dtr["DiaChi"].ToString());
                listNCC.Items[l].SubItems.Add(dtr["DienThoai"].ToString());
                l++;
            }
        }

        private void TaiDuLieuBD(object sender, EventArgs e)
        {
            TaiDuLieu();
        }

        private void bnbThem_Click(object sender, EventArgs e)
        {

            try
            {
                XDocument sach = XDocument.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                XElement SachMoi = new XElement("Sach",
                    new XElement("MaSach", txtMaSach.Text),
                    new XElement("TenSach", txtTenSach.Text),
                    new XElement("MaTheLoai", txtMaTheLoai.Text),
                    new XElement("MaTacGia", txtMaTacGia.Text),
                    new XElement("DonGia", txtDonGia.Text),
                    new XElement("NamXuatBan", txtNamXuatBan.Text)
                    );
                sach.Element("QLHSVP").Element("QLHS").AddFirst(SachMoi);
                sach.Save(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                listSach.Items.Clear();
                TaiDuLieuBD(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                foreach (XmlElement item in xd.SelectNodes("QLHSVP/QLHS/Sach"))
                {
                    if (item.SelectSingleNode("MaSach").InnerText == txtMaSach.Text)
                    {
                        item.SelectSingleNode("TenSach").InnerText = txtTenSach.Text;
                        item.SelectSingleNode("MaTheLoai").InnerText = txtMaTheLoai.Text;
                        item.SelectSingleNode("MaTacGia").InnerText = txtMaTacGia.Text;
                        item.SelectSingleNode("DonGia").InnerText = txtDonGia.Text;
                        item.SelectSingleNode("NamXuatBan").InnerText = txtNamXuatBan.Text;
                    }
                }
                xd.Save(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                TaiDuLieuBD(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");

                foreach (XmlElement item in xd.SelectNodes("QLHSVP/QLHS/Sach"))
                {
                    if (item.SelectSingleNode("MaSach").InnerText == txtMaSach.Text)
                    {
                        item.SelectSingleNode("MaSach").RemoveAll();
                        item.SelectSingleNode("TenSach").RemoveAll();
                        item.SelectSingleNode("MaTheLoai").RemoveAll();
                        item.SelectSingleNode("MaTacGia").RemoveAll();
                        item.SelectSingleNode("DonGia").RemoveAll();
                        item.SelectSingleNode("NamXuatBan").RemoveAll();
                    }
                }

                xd.Save(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                TaiDuLieuBD(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                listSach.Items.Clear();
                XmlDocument xd = new XmlDocument();
                xd.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                foreach (XmlElement item in xd.SelectNodes("QLHSVP/QLHS/Sach"))
                {
                    if (item.SelectSingleNode("MaSach").InnerText == txtMaSach.Text || item.SelectSingleNode("TenSach").InnerText == txtTenSach.Text)
                    {
                        int i = 0;
                        listSach.Items.Add(item.SelectSingleNode("MaSach").InnerText);
                        listSach.Items[i].SubItems.Add(item.SelectSingleNode("TenSach").InnerText);
                        listSach.Items[i].SubItems.Add(item.SelectSingleNode("MaTheLoai").InnerText);
                        listSach.Items[i].SubItems.Add(item.SelectSingleNode("MaTacGia").InnerText);
                        listSach.Items[i].SubItems.Add(item.SelectSingleNode("DonGia").InnerText);
                        listSach.Items[i].SubItems.Add(item.SelectSingleNode("NamXuatBan").InnerText);
                        i++;
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnThemTL_Click(object sender, EventArgs e)
        {
            try
            {
                XDocument TheLoai = XDocument.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                XElement TheLoaiMoi = new XElement("TheLoai",
                    new XElement("MaTheLoai", txtMaTL.Text),
                    new XElement("TenTheLoai", txtTenTL.Text)
                    );
                TheLoai.Element("QLHSVP").Element("QLHS").Element("TheLoai").AddBeforeSelf(TheLoaiMoi);
                TheLoai.Save(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                listTL.Items.Clear();
                TaiDuLieuBD(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnSuaTL_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument TheLoai = new XmlDocument();
                TheLoai.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                foreach (XmlElement item in TheLoai.SelectNodes("QLHSVP/QLHS/TheLoai"))
                {
                    if (item.SelectSingleNode("MaTheLoai").InnerText == txtMaTL.Text)
                    {
                        item.SelectSingleNode("TenTheLoai").InnerText = txtTenTL.Text;
                    }
                }
                TheLoai.Save(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                listTL.Items.Clear();
                TaiDuLieuBD(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnXoaTL_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");

                foreach (XmlElement item in xd.SelectNodes("QLHSVP/QLHS/TheLoai"))
                {
                    if (item.SelectSingleNode("MaTheLoai").InnerText == txtMaTL.Text)
                    {
                        item.SelectSingleNode("MaTheLoai").RemoveAll();
                        item.SelectSingleNode("TenTheLoai").RemoveAll();
                    }
                }
                xd.Save(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                listTL.Items.Clear();
                TaiDuLieuBD(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnTimKiemTL_Click(object sender, EventArgs e)
        {
            try
            {
                listTL.Items.Clear();
                XmlDocument xd = new XmlDocument();
                xd.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                foreach (XmlElement item in xd.SelectNodes("QLHSVP/QLHS/TheLoai"))
                {
                    if (item.SelectSingleNode("MaTheLoai").InnerText == txtMaTL.Text || item.SelectSingleNode("TenTheLoai").InnerText == txtTenTL.Text)
                    {
                        int i = 0;
                        listTL.Items.Add(item.SelectSingleNode("MaTheLoai").InnerText);
                        listTL.Items[i].SubItems.Add(item.SelectSingleNode("TenTheLoai").InnerText);
                        i++;
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnThemTG_Click(object sender, EventArgs e)
        {
            try
            {
                XDocument TacGia = XDocument.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                XElement TacGiaMoi = new XElement("TacGia",
                    new XElement("MaTacGia", txtMaTG.Text),
                    new XElement("TenTacGia", txtTenTG.Text)
                    );
                TacGia.Element("QLHSVP").Element("QLHS").Element("TacGia").AddBeforeSelf(TacGiaMoi);
                TacGia.Save(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                listTacGia.Items.Clear();
                TaiDuLieuBD(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnSuaTG_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                foreach (XmlElement item in xd.SelectNodes("QLHSVP/QLHS/TacGia"))
                {
                    if (item.SelectSingleNode("MaTacGia").InnerText == txtMaTG.Text)
                    {
                        item.SelectSingleNode("TenTacGia").InnerText = txtTenTG.Text;
                    }
                }
                xd.Save(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                listTacGia.Items.Clear();
                TaiDuLieuBD(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnXoaTG_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");

                foreach (XmlElement item in xd.SelectNodes("QLHSVP/QLHS/TacGia"))
                {
                    if (item.SelectSingleNode("MaTacGia").InnerText == txtMaTG.Text)
                    {
                        item.SelectSingleNode("MaTacGia").RemoveAll();
                        item.SelectSingleNode("TenTacGia").RemoveAll();
                    }
                }
                xd.Save(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                listTacGia.Items.Clear();
                TaiDuLieuBD(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnTimKiemTG_Click(object sender, EventArgs e)
        {
            try
            {
                listTacGia.Items.Clear();
                XmlDocument xd = new XmlDocument();
                xd.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                foreach (XmlElement item in xd.SelectNodes("QLHSVP/QLHS/TacGia"))
                {
                    if (item.SelectSingleNode("MaTacGia").InnerText == txtMaTG.Text || item.SelectSingleNode("TenTacGia").InnerText == txtTenTG.Text)
                    {
                        int i = 0;
                        listTacGia.Items.Add(item.SelectSingleNode("MaTacGia").InnerText);
                        listTacGia.Items[i].SubItems.Add(item.SelectSingleNode("TenTacGia").InnerText);
                        i++;
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            try
            {
                XDocument NhaCungCap = XDocument.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                XElement NhaCungCapMoi = new XElement("NhaCungCap",
                    new XElement("MaNhaCungCap", txtmaNCC.Text),
                    new XElement("TenNhaCungCap", txtTenNCC.Text),
                    new XElement("DiaChi", txtDiaChiNCC.Text),
                    new XElement("DienThoai", txtDienThoaiNCC.Text)
                    );
                NhaCungCap.Element("QLHSVP").Element("QLHS").Element("NhaCungCap").AddBeforeSelf(NhaCungCapMoi);
                NhaCungCap.Save(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                listNCC.Items.Clear();
                TaiDuLieuBD(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                foreach (XmlElement item in xd.SelectNodes("QLHSVP/QLHS/NhaCungCap"))
                {
                    if (item.SelectSingleNode("MaNhaCungCap").InnerText == txtmaNCC.Text)
                    {
                        item.SelectSingleNode("TenNhaCungCap").InnerText = txtTenNCC.Text;
                        item.SelectSingleNode("DiaChi").InnerText = txtDiaChiNCC.Text;
                        item.SelectSingleNode("DienThoai").InnerText = txtDienThoaiNCC.Text;
                    }
                }
                xd.Save(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                listNCC.Items.Clear();
                TaiDuLieuBD(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");

                foreach (XmlElement item in xd.SelectNodes("QLHSVP/QLHS/NhaCungCap"))
                {
                    if (item.SelectSingleNode("MaNhaCungCap").InnerText == txtmaNCC.Text)
                    {
                        item.SelectSingleNode("MaNhaCungCap").RemoveAll();
                        item.SelectSingleNode("TenNhaCungCap").RemoveAll();
                        item.SelectSingleNode("DiaChi").RemoveAll();
                        item.SelectSingleNode("DienThoai").RemoveAll();
                    }
                }
                xd.Save(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                listNCC.Items.Clear();
                TaiDuLieuBD(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnTimKiemNCC_Click(object sender, EventArgs e)
        {
            try
            {
                listNCC.Items.Clear();
                XmlDocument xd = new XmlDocument();
                xd.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                foreach (XmlElement item in xd.SelectNodes("QLHSVP/QLHS/NhaCungCap"))
                {
                    if (item.SelectSingleNode("MaNhaCungCap").InnerText == txtmaNCC.Text || item.SelectSingleNode("TenNhaCungCap").InnerText == txtTenNCC.Text)
                    {
                        int i = 0;
                        listNCC.Items.Add(item.SelectSingleNode("MaNhaCungCap").InnerText);
                        listNCC.Items[i].SubItems.Add(item.SelectSingleNode("TenNhaCungCap").InnerText);
                        listNCC.Items[i].SubItems.Add(item.SelectSingleNode("DiaChi").InnerText);
                        listNCC.Items[i].SubItems.Add(item.SelectSingleNode("DienThoai").InnerText);
                        i++;
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
