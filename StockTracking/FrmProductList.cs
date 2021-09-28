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
    public partial class FrmProductList : Form
    {
        public FrmProductList()
        {
            InitializeComponent();
        }

        private void buttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void textStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void textStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            FrmProduct frm = new FrmProduct();
            frm.dto = dto;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            dto = bll.Select();
            dataGridView1.DataSource = dto.Products;
            CleanFilters();
        }

        ProductBLL bll = new ProductBLL();
        ProductDTO dto = new ProductDTO();
        private void FrmProductList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;
            dataGridView1.DataSource = dto.Products;
            dataGridView1.Columns[0].HeaderText = "Product Name";
            dataGridView1.Columns[1].HeaderText = "Category Name";
            dataGridView1.Columns[2].HeaderText = "Stock Amount";
            dataGridView1.Columns[3].HeaderText = "Price";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
           

        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            List<ProductDetailDTO> list = dto.Products;
            if (txtName.Text.Trim() != "")
                list = list.Where(x => x.ProductName.Contains(txtName.Text)).ToList();
            if (cmbCategory.SelectedIndex != -1)
                list = list.Where(x => x.CategoryID == Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
            if (txtPrice.Text.Trim() != "")
            {
                if (radbutEqual.Checked)
                    list = list.Where(x => x.Price == Convert.ToInt32(txtPrice.Text)).ToList();
                else if (radbutMore.Checked)
                    list = list.Where(x => x.Price > Convert.ToInt32(txtPrice.Text)).ToList();
                else if (radbutLess.Checked)
                    list = list.Where(x => x.Price < Convert.ToInt32(txtPrice.Text)).ToList();
                else
                    MessageBox.Show("Please select a criterion for the price");
            }
            if (textStock.Text.Trim() != "")
            {
                if (radbutequalstock.Checked)
                    list = list.Where(x => x.StockAmount == Convert.ToInt32(textStock.Text)).ToList();
                else if (radbutmorestock.Checked)
                    list = list.Where(x => x.StockAmount > Convert.ToInt32(textStock.Text)).ToList();
                else if (radbutlessStock.Checked)
                    list = list.Where(x => x.StockAmount < Convert.ToInt32(textStock.Text)).ToList();
                else
                    MessageBox.Show("Please select a criterion for the Stock");
            }
            dataGridView1.DataSource = list;
        }

        private void butClean_Click(object sender, EventArgs e)
        {
            CleanFilters();
        }
        private void CleanFilters()
        {
            txtName.Clear();
            txtPrice.Clear();
            cmbCategory.SelectedIndex = -1;
            textStock.Clear();
            radbutEqual.Checked = false;
            radbutequalstock.Checked = false;
            radbutLess.Checked = false;
            radbutlessStock.Checked = false;
            radbutMore.Checked = false;
            radbutmorestock.Checked = false;
            dataGridView1.DataSource = dto.Products;
        }
        ProductDetailDTO detail = new ProductDetailDTO();
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new ProductDetailDTO();
            detail.ProductID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            detail.CategoryID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
            detail.ProductName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            detail.Price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
        }

        private void butUpdate_Click(object sender, EventArgs e)
        {
            if (detail.ProductID == 0)
                MessageBox.Show("Please select a product");
            else
            {
                FrmProduct frm = new FrmProduct();
                frm.isUpdate = true;
                frm.detail = detail;
                frm.dto = dto;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                bll = new ProductBLL();
                dto = bll.Select();
                dataGridView1.DataSource = dto.Products;
                CleanFilters();

            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (detail.ProductID == 0)
                MessageBox.Show("Please select a product");

            else
            {
                DialogResult result = MessageBox.Show("Are you sure?", "Warning!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)

                {
                    if (bll.Delete(detail))
                    {
                        MessageBox.Show("Product was deleted");
                        bll = new ProductBLL();
                        dto = bll.Select();
                        dataGridView1.DataSource = dto.Products;
                        cmbCategory.DataSource = dto.Categories;
                        CleanFilters();
                    }
                }
            }
        }
    }
}
