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
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            listMPN.Items.Clear();
            DataSet DLPN = new DataSet();
            DLPN.ReadXml(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
            DataTable dlPN = new DataTable();
            dlPN = DLPN.Tables["PhieuNhapHang"];
            int i = 0;
            foreach (DataRow dtr in dlPN.Rows)
            {
                listMPN.Items.Add(dtr["MaPhieuNhap"].ToString());
                listMPN.Items[i].SubItems.Add(dtr["MaNhanVien"].ToString());
                listMPN.Items[i].SubItems.Add(dtr["MaNhaCungCap"].ToString());
                listMPN.Items[i].SubItems.Add(dtr["NgayNhap"].ToString());
                i++;
            }

            DataSet DLHD = new DataSet();
            DLHD.ReadXml(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
            DataTable dlHD = new DataTable();
            dlHD = DLPN.Tables["HoaDonBanHang"];
            int j = 0;
            foreach (DataRow dtr in dlHD.Rows)
            {
                listHD.Items.Add(dtr["MaHoaDonBAnHang"].ToString());
                listHD.Items[j].SubItems.Add(dtr["MaNhanVien"].ToString());
                listHD.Items[j].SubItems.Add(dtr["NgayNhap"].ToString());
                j++;
            }

            DataSet DLCTPN = new DataSet();
            DLCTPN.ReadXml(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
            DataTable dlCTPN = new DataTable();
            dlCTPN = DLCTPN.Tables["ChiTietPhieuNhapHang"];
            int k = 0;
            foreach (DataRow dtr in dlCTPN.Rows)
            {
                listCTN.Items.Add(dtr["MaPhieuNhap"].ToString());
                listCTN.Items[k].SubItems.Add(dtr["MaSach"].ToString());
                listCTN.Items[k].SubItems.Add(dtr["SoLuong"].ToString());
                listCTN.Items[k].SubItems.Add(dtr["DonGia"].ToString());
                k++;
            }

            DataSet DLCTHD = new DataSet();
            DLCTHD.ReadXml(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
            DataTable dlCTHD = new DataTable();
            dlCTHD = DLCTHD.Tables["ChiTietHoaDonBanHang"];
            int l = 0;
            foreach (DataRow dtr in dlCTHD.Rows)
            {
                listCTHDB.Items.Add(dtr["MaHoaDonBanHang"].ToString());
                listCTHDB.Items[l].SubItems.Add(dtr["MaSach"].ToString());
                listCTHDB.Items[l].SubItems.Add(dtr["SoLuong"].ToString());
                listCTHDB.Items[l].SubItems.Add(dtr["DonGia"].ToString());
                l++;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XDocument phieuNhap = XDocument.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
            XElement phieuNhapMoi = new XElement("PhieuNhapHang",
                new XElement("MaPhieuNhap", txtMaPN.Text),
                new XElement("MaNhanVien", txtMaNV.Text),
                new XElement("MaNhaCungCap", txtMaNCC.Text),
                new XElement("NgayNhap", txtNN.Text)
                );
            phieuNhap.Element("QLHSVP").Element("QLHS").Element("PhieuNhapHang").AddBeforeSelf(phieuNhapMoi);
            phieuNhap.Save(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
            listMPN.Items.Clear();
            ThongKe_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                foreach (XmlElement item in xd.SelectNodes("QLHSVP/QLHS/PhieuNhapHang"))
                {
                    if (item.SelectSingleNode("MaPhieuNhap").InnerText == txtMaPN.Text)
                    {
                        item.SelectSingleNode("MaNhanVien").InnerText = txtMaNV.Text;
                        item.SelectSingleNode("MaNhaCungCap").InnerText = txtMaNCC.Text;
                        item.SelectSingleNode("NgayNhap").InnerText = txtNN.Text;
                    }
                }
                xd.Save(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                listMPN.Items.Clear();
                ThongKe_Load(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void tnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");

                foreach (XmlElement item in xd.SelectNodes("QLHSVP/QLHS/PhieuNhapHang"))
                {
                    if (item.SelectSingleNode("MaPhieuNhap").InnerText == txtMaPN.Text)
                    {
                        item.SelectSingleNode("MaPhieuNhap").RemoveAll();
                        item.SelectSingleNode("MaNhanVien").RemoveAll();
                        item.SelectSingleNode("MaNhaCungCap").RemoveAll();
                        item.SelectSingleNode("NgayNhap").RemoveAll();
                    }
                }
                xd.Save(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                listMPN.Items.Clear();
                ThongKe_Load(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void tnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                listMPN.Items.Clear();
                XmlDocument xd = new XmlDocument();
                xd.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                foreach (XmlElement item in xd.SelectNodes("QLHSVP/QLHS/PhieuNhapHang"))
                {
                    if (item.SelectSingleNode("MaPhieuNhap").InnerText == txtMaPN.Text || item.SelectSingleNode("MaNhanVien").InnerText == txtMaNV.Text)
                    {
                        int i = 0;
                        listMPN.Items.Add(item.SelectSingleNode("MaPhieuNhap").InnerText);
                        listMPN.Items[i].SubItems.Add(item.SelectSingleNode("MaNhanVien").InnerText);
                        listMPN.Items[i].SubItems.Add(item.SelectSingleNode("MaNhaCungCap").InnerText);
                        listMPN.Items[i].SubItems.Add(item.SelectSingleNode("NgayNhap").InnerText);
                        i++;
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            XDocument hoaDon = XDocument.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
            XElement hoaDonMoi = new XElement("HoaDonBanHang",
                new XElement("MaHoaDonBanHang", txtMHD.Text),
                new XElement("MaNhanVien", txtNVN.Text),
                new XElement("NgayNhap", txtNNN.Text)
                );
            hoaDon.Element("QLHSVP").Element("QLHS").Element("HoaDonBanHang").AddBeforeSelf(hoaDonMoi);
            hoaDon.Save(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
            listHD.Items.Clear();
            ThongKe_Load(sender, e);
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                foreach (XmlElement item in xd.SelectNodes("QLHSVP/QLHS/HoaDonBanHang"))
                {
                    if (item.SelectSingleNode("MaHoaDonBanHang").InnerText == txtMHD.Text)
                    {
                        item.SelectSingleNode("MaNhanVien").InnerText = txtNVN.Text;
                        item.SelectSingleNode("NgayNhap").InnerText = txtNNN.Text;
                    }
                }
                xd.Save(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                listHD.Items.Clear();
                ThongKe_Load(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");

                foreach (XmlElement item in xd.SelectNodes("QLHSVP/QLHS/HoaDonBanHang"))
                {
                    if (item.SelectSingleNode("MaHoaDonBanHang").InnerText == txtMHD.Text)
                    {
                        item.SelectSingleNode("MaHoaDonBanHang").RemoveAll();
                        item.SelectSingleNode("MaNhanVien").RemoveAll();
                        item.SelectSingleNode("NgayNhap").RemoveAll();
                    }
                }
                xd.Save(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                listHD.Items.Clear();
                ThongKe_Load(sender, e);
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
                listHD.Items.Clear();
                XmlDocument xd = new XmlDocument();
                xd.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                foreach (XmlElement item in xd.SelectNodes("QLHSVP/QLHS/HoaDonBanHang"))
                {
                    if (item.SelectSingleNode("MaHoaDonBanHang").InnerText == txtMHD.Text || item.SelectSingleNode("MaNhanVien").InnerText == txtNVN.Text)
                    {
                        int i = 0;
                        listHD.Items.Add(item.SelectSingleNode("MaHoaDonBanHang").InnerText);
                        listHD.Items[i].SubItems.Add(item.SelectSingleNode("MaNhanVien").InnerText);
                        listHD.Items[i].SubItems.Add(item.SelectSingleNode("NgayNhap").InnerText);
                        i++;
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnCTNThem_Click(object sender, EventArgs e)
        {
            XDocument ctpn = XDocument.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
            XElement ctpnm = new XElement("ChiTietPhieuNhapHang",
                new XElement("MaPhieuNhap", txtCTNMPN.Text),
                new XElement("MaSach", txtCTNMS.Text),
                new XElement("SoLuong", txtCTNSL.Text),
                new XElement("DonGia", txtCTNDG.Text)
                );
            ctpn.Element("QLHSVP").Element("QLHS").Element("ChiTietPhieuNhapHang").AddBeforeSelf(ctpnm);
            ctpn.Save(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
            listCTN.Items.Clear();
            ThongKe_Load(sender, e);
        }

        private void btnCTNSua_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                foreach (XmlElement item in xd.SelectNodes("QLHSVP/QLHS/ChiTietPhieuNhapHang"))
                {
                    if (item.SelectSingleNode("MaPhieuNhap").InnerText == txtCTNMPN.Text)
                    {
                        item.SelectSingleNode("MaSach").InnerText = txtCTNMS.Text;
                        item.SelectSingleNode("SoLuong").InnerText = txtCTNSL.Text;
                        item.SelectSingleNode("DonGia").InnerText = txtCTNDG.Text;
                    }
                }
                xd.Save(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                listCTN.Items.Clear();
                ThongKe_Load(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnCTNXoa_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");

                foreach (XmlElement item in xd.SelectNodes("QLHSVP/QLHS/ChiTietPhieuNhapHang"))
                {
                    if (item.SelectSingleNode("MaPhieuNhap").InnerText == txtCTNMPN.Text)
                    {
                        item.SelectSingleNode("MaPhieuNhap").RemoveAll();
                        item.SelectSingleNode("MaSach").RemoveAll();
                        item.SelectSingleNode("SoLuong").RemoveAll();
                        item.SelectSingleNode("DonGia").RemoveAll();
                    }
                }
                xd.Save(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                listCTN.Items.Clear();
                ThongKe_Load(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnCTNTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                listCTN.Items.Clear();
                XmlDocument xd = new XmlDocument();
                xd.Load(@"D:\Document\xml\BaiTapNhom\QLHSVP.xml");
                foreach (XmlElement item in xd.SelectNodes("QLHSVP/QLHS/ChiTietHoaDonNhap"))
                {
                    if (item.SelectSingleNode("MaPhieuNhap").InnerText == txtCTNMPN.Text)
                    {
                        int i = 0;
                        listCTN.Items.Add(item.SelectSingleNode("MaPhieuNhap").InnerText);
                        listCTN.Items[i].SubItems.Add(item.SelectSingleNode("MaSach").InnerText);
                        listCTN.Items[i].SubItems.Add(item.SelectSingleNode("SoLuong").InnerText);
                        listCTN.Items[i].SubItems.Add(item.SelectSingleNode("DonGia").InnerText);
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
