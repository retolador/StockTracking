using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockTracking.BLL;
using StockTracking.DAL.DTO;

namespace StockTracking
{
    public partial class FrmAlertStock : Form
    {
        public FrmAlertStock()
        {
            InitializeComponent();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            FrmMain frm = new FrmMain();
            this.Hide();
            frm.ShowDialog();
           
        }

        ProductBLL bll = new ProductBLL();
        ProductDTO dto = new ProductDTO();
        private void FrmAlertStock_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dto.Products = dto.Products.Where(x => x.StockAmount <= 10).ToList();
            dataGridView1.DataSource = dto.Products;
            dataGridView1.Columns[0].HeaderText = "Product Name";
            dataGridView1.Columns[1].HeaderText = "Category Name";
            dataGridView1.Columns[2].HeaderText = "Stock Amount";
            dataGridView1.Columns[3].HeaderText = "Price";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            if(dto.Products.Count == 0)
            {
                FrmMain frm = new FrmMain();
                this.Hide();
                frm.ShowDialog();
            }
        }
        ProductDetailDTO detail = new ProductDetailDTO();
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            detail.ProductName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            detail.Price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            detail.StockAmount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            detail.ProductID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
        }

        private void AddStock_Click(object sender, EventArgs e)
        {
            FrmAddStock frm = new FrmAddStock();
            frm.isUpdate = true;
            frm.detailUpdate = detail;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            dto = bll.Select();
            dto.Products = dto.Products.Where(x => x.StockAmount <= 10).ToList();
            dataGridView1.DataSource = dto.Products;
        }
    }
}
