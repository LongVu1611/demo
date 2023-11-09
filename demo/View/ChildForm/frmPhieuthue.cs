using demo.Controller;
using demo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo.View.ChildForm
{
    public partial class frmPhieuthue : Form
    {
        KhachController khachController;
        SanphamController sanphamController;
        PhieuthueController phieuthueController;
        ChitietController chitietController;
        NhanvienController nhanvienController;
        List<Sanpham> ds_sanpham;//danh sach kho
        List<Khach> ds_khach;//danh sach hang hoa
        List<Nhanvien> ds_nhanvien;
        Phieuthue currentphieu;
        public frmPhieuthue()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                String idsp = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                dataGridView1.Rows[e.RowIndex].Cells[1].Value = sanphamController.get(idsp).getNamesp();
                dataGridView1.Rows[e.RowIndex].Cells[2].Value = sanphamController.get(idsp).getGiavon();

            }
            //column index 4 là đơn giá
            if (e.ColumnIndex == 4)
            {
                int sn = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString().Trim());
                int hd = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString().Trim());
                dataGridView1.Rows[e.RowIndex].Cells[5].Value = sn * hd;

            }
        }

        private void frmPhieuthue_Load(object sender, EventArgs e)
        {
            chitietController = new ChitietController();
            sanphamController = new SanphamController();
            nhanvienController = new NhanvienController();
            khachController = new KhachController();
            ds_sanpham = new List<Sanpham>(); 
            ds_khach = khachController.load();
            ds_khach = new List<Khach>();
            ds_nhanvien = new List<Nhanvien>();
            ds_nhanvien = nhanvienController.load();
            ds_sanpham = sanphamController.load();
            phieuthueController = new PhieuthueController();

            foreach (Nhanvien n in ds_nhanvien)
            {
                comboBox1.Items.Add(n.getIdnv());

            }
            DataGridViewComboBoxColumn comboboxColumn;
            comboboxColumn = new DataGridViewComboBoxColumn();
            comboboxColumn.DataPropertyName = "masp";
            comboboxColumn.HeaderText = "Mã sản phẩm";
            comboboxColumn.DropDownWidth = 160;
            comboboxColumn.Width = 90;
            comboboxColumn.MaxDropDownItems = 3;
            comboboxColumn.FlatStyle = FlatStyle.Flat;
            foreach (Sanpham sp in ds_sanpham)
            {
                comboboxColumn.Items.Add(sp.getIdsp());
            }
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(comboboxColumn);//Ma san pham
            //tên hàng
            DataGridViewTextBoxColumn colTenHang = new DataGridViewTextBoxColumn();
            colTenHang.DataPropertyName = "tensp";
            colTenHang.HeaderText = "Tên sản phẩm";
            dataGridView1.Columns.Add(colTenHang);
            // Đơn vị tính
            DataGridViewTextBoxColumn colGiavon = new DataGridViewTextBoxColumn();
            colGiavon.DataPropertyName = "giavon";
            colGiavon.HeaderText = "Giá vốn";
            dataGridView1.Columns.Add(colGiavon);
            // Số ngày thuê
            DataGridViewTextBoxColumn colSoLuong = new DataGridViewTextBoxColumn();
            colSoLuong.DataPropertyName = "giathue1ngay";
            colSoLuong.HeaderText = "Giá thuê 1 ngày";
            dataGridView1.Columns.Add(colSoLuong);
            // Đơn giá
            DataGridViewTextBoxColumn colDongia = new DataGridViewTextBoxColumn();
            colDongia.DataPropertyName = "giathue1ngay";
            colDongia.HeaderText = "Đơn giá";
            dataGridView1.Columns.Add(colDongia);
            // Thành tiền
            DataGridViewTextBoxColumn colThanhTien = new DataGridViewTextBoxColumn();
            colThanhTien.DataPropertyName = "ThanhTien";
            colThanhTien.HeaderText = "Thành tiền";
            dataGridView1.Columns.Add(colThanhTien);
        }
    }
}
