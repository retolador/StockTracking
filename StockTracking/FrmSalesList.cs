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
    public partial class FrmSalesList : Form
    {
        public FrmSalesList()
        {
            InitializeComponent();
        }

        private void buttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void textSalesAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            FrmSales frm = new FrmSales();
            frm.dto = dto;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            dto = bll.Select();
            dataGridView1.DataSource = dto.Sales;
            CleanFilters();
        }
        SalesBLL bll = new SalesBLL();
        SalesDTO dto = new SalesDTO();
        SalesDetailDTO detail = new SalesDetailDTO();
        private void FrmSalesList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Sales;
            dataGridView1.Columns[0].HeaderText = "Customer Name";
            dataGridView1.Columns[1].HeaderText = "Product Name";
            dataGridView1.Columns[2].HeaderText = "Category Name";
            dataGridView1.Columns[6].HeaderText = "Sales Amount";
            dataGridView1.Columns[7].HeaderText = "Price";
            dataGridView1.Columns[8].HeaderText = "Sales Date";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            List<SalesDetailDTO> list = dto.Sales;
            if (txtProductName.Text.Trim() != "")
                list = list.Where(x => x.ProductName.Contains(txtProductName.Text)).ToList();
            if (txtCustomer.Text.Trim() != "")
                list = list.Where(x => x.CustomerName.Contains(txtCustomer.Text)).ToList();
            if (cmbCategory.SelectedIndex != -1)
                list = list.Where(x => x.CategoryID == Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
            if (txtPrice.Text.Trim() != "")
            {
                if (radbutEqualPrice.Checked)
                    list = list.Where(x => x.Price == Convert.ToInt32(txtPrice.Text)).ToList();
                else if (radbutMoreprice.Checked)
                    list = list.Where(x => x.Price > Convert.ToInt32(txtPrice.Text)).ToList();
                else if (radbutLessprice.Checked)
                    list = list.Where(x => x.Price < Convert.ToInt32(txtPrice.Text)).ToList();
                else
                    MessageBox.Show("Please select a criterion for the price");
            }
            if (txtSalesAmount.Text.Trim() != "")
            {
                if (radbutequalsales.Checked)
                    list = list.Where(x => x.SalesAmount == Convert.ToInt32(txtSalesAmount.Text)).ToList();
                else if (radbutmoresales.Checked)
                    list = list.Where(x => x.SalesAmount > Convert.ToInt32(txtSalesAmount.Text)).ToList();
                else if (radbutlessSales.Checked)
                    list = list.Where(x => x.SalesAmount < Convert.ToInt32(txtSalesAmount.Text)).ToList();
                else
                    MessageBox.Show("Please select a criterion for the Sales Amount");
            }
            if (checkDate.Checked)
            {
                list = list.Where(x => x.SalesDate > dateTimePickerStart.Value && x.SalesDate < dateTimePickerEnd.Value).ToList();

            }
            dataGridView1.DataSource = list;



        }

        private void butClean_Click(object sender, EventArgs e)
        {
            CleanFilters();
               
        }
        private void CleanFilters()
        {
            txtPrice.Clear();
            txtCustomer.Clear();
            txtProductName.Clear();
            txtSalesAmount.Clear();
            radbutEqualPrice.Checked = false;
            radbutequalsales.Checked = false;
            radbutLessprice.Checked = false;
            radbutlessSales.Checked = false;
            radbutMoreprice.Checked = false;
            radbutmoresales.Checked = false;
            dateTimePickerStart.Value = DateTime.Today;
            dateTimePickerEnd.Value = DateTime.Today;
            cmbCategory.SelectedIndex = -1;
            checkDate.Checked = false;
            dataGridView1.DataSource = dto.Sales;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new SalesDetailDTO();
            detail.SalesID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
            detail.ProductID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            detail.CustomerName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            detail.ProductName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            detail.Price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
            detail.SalesAmount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
            detail.StockAmount = GetStockAmount(detail.ProductID);
            

        }

        private int GetStockAmount(int productID)
        {
            ProductDetailDTO productdto = new ProductDetailDTO();
            productdto = dto.Products.Where(x => x.ProductID == productID).First();
            return productdto.StockAmount;

        }

        private void butUpdate_Click(object sender, EventArgs e)
        {
            if (detail.SalesID == 0)
                MessageBox.Show("Please select a sales from table");
            else
            {
                FrmSales frm = new FrmSales();
                frm.isUpdate = true;
                frm.detail = detail;
                frm.dto = dto;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                bll = new SalesBLL();
                dto = bll.Select();
                dataGridView1.DataSource = dto.Sales;
                CleanFilters();
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (detail.SalesID == 0)
                MessageBox.Show("Please select a sales from table");
            else
            {
                DialogResult result = MessageBox.Show("Are you sure?", "Warning!", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                   
                {
                    if (bll.Delete(detail))
                    {
                        
                        MessageBox.Show("Sales was deleted");
                        bll = new SalesBLL();
                        dto = bll.Select();
                        dataGridView1.DataSource = dto.Sales;
                        CleanFilters();
                    }
                }
            }
        }
    }
}
