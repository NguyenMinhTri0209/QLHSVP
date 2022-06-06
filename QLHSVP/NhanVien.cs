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
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            listNV.Items.Clear();
            DataSet DLNV = new DataSet();
            DLNV.ReadXml(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
            DataTable dlNV = new DataTable();
            dlNV = DLNV.Tables["NhanVien"];
            int i = 0;
            foreach (DataRow dtr in dlNV.Rows)
            {
                listNV.Items.Add(dtr["MaNhanVien"].ToString());
                listNV.Items[i].SubItems.Add(dtr["TenNhanVien"].ToString());
                listNV.Items[i].SubItems.Add(dtr["NgaySinh"].ToString());
                listNV.Items[i].SubItems.Add(dtr["GioiTinh"].ToString());
                listNV.Items[i].SubItems.Add(dtr["DiaChi"].ToString());
                listNV.Items[i].SubItems.Add(dtr["SoDienThoai"].ToString());
                listNV.Items[i].SubItems.Add(dtr["Luong"].ToString());
                i++;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                XDocument nhanVien = XDocument.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                XElement nhanVienMoi = new XElement("NhanVien",
                    new XElement("MaNhanVien", txtMaNV.Text),
                    new XElement("TenNhanVien", txtTenNV.Text),
                    new XElement("NgaySinh", txtNS.Text),
                    new XElement("GioiTinh", txtGioiTinh.Text),
                    new XElement("DiaChi", txtDiaChi.Text),
                    new XElement("SoDienThoai", txtSDT.Text),
                    new XElement("Luong", txtLuong.Text)
                    );
                nhanVien.Element("QLHSVP").Element("QLHS").Element("NhanVien").AddBeforeSelf(nhanVienMoi);
                nhanVien.Save(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                listNV.Items.Clear();
                NhanVien_Load(sender, e);
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
                foreach (XmlElement item in xd.SelectNodes("QLHSVP/QLHS/NhanVien"))
                {
                    if (item.SelectSingleNode("MaNhanVien").InnerText == txtMaNV.Text)
                    {
                        item.SelectSingleNode("TenNhanVien").InnerText = txtTenNV.Text;
                        item.SelectSingleNode("NgaySinh").InnerText = txtNS.Text;
                        item.SelectSingleNode("GioiTinh").InnerText = txtGioiTinh.Text;
                        item.SelectSingleNode("DiaChi").InnerText = txtDiaChi.Text;
                        item.SelectSingleNode("SoDienThoai").InnerText = txtSDT.Text;
                        item.SelectSingleNode("Luong").InnerText = txtLuong.Text;
                    }
                }
                xd.Save(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                listNV.Items.Clear();
                NhanVien_Load(sender, e);
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

                foreach (XmlElement item in xd.SelectNodes("QLHSVP/QLHS/NhanVien"))
                {
                    if (item.SelectSingleNode("MaNhanVien").InnerText == txtMaNV.Text)
                    {
                        item.SelectSingleNode("MaNhanVien").RemoveAll();
                        item.SelectSingleNode("TenNhanVien").RemoveAll();
                        item.SelectSingleNode("NgaySinh").RemoveAll();
                        item.SelectSingleNode("GioiTinh").RemoveAll();
                        item.SelectSingleNode("DiaChi").RemoveAll();
                        item.SelectSingleNode("SoDienThoai").RemoveAll();
                        item.SelectSingleNode("Luong").RemoveAll();
                    }
                }
                xd.Save(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                listNV.Items.Clear();
                NhanVien_Load(sender, e);
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
                listNV.Items.Clear();
                XmlDocument xd = new XmlDocument();
                xd.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                foreach (XmlElement item in xd.SelectNodes("QLHSVP/QLHS/NhanVien"))
                {
                    if (item.SelectSingleNode("MaNhanVien").InnerText == txtMaNV.Text || item.SelectSingleNode("TenNhanVien").InnerText == txtTenNV.Text)
                    {
                        int i = 0;
                        listNV.Items.Add(item.SelectSingleNode("MaNhanVien").InnerText);
                        listNV.Items[i].SubItems.Add(item.SelectSingleNode("TenNhanVien").InnerText);
                        listNV.Items[i].SubItems.Add(item.SelectSingleNode("NgaySinh").InnerText);
                        listNV.Items[i].SubItems.Add(item.SelectSingleNode("GioiTinh").InnerText);
                        listNV.Items[i].SubItems.Add(item.SelectSingleNode("DiaChi").InnerText);
                        listNV.Items[i].SubItems.Add(item.SelectSingleNode("SoDienThoai").InnerText);
                        listNV.Items[i].SubItems.Add(item.SelectSingleNode("Luong").InnerText);
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
