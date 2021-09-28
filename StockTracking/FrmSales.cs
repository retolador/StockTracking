using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockTracking.DAL.DTO;
using StockTracking.BLL;

namespace StockTracking
{
    public partial class FrmSales : Form
    {
        public FrmSales()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }
        public SalesDTO dto = new SalesDTO();
        public SalesDetailDTO detail = new SalesDetailDTO();
        public bool isUpdate = false;
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool combofull = false;
        private void FrmSales_Load(object sender, EventArgs e)
        {
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;
            if (!isUpdate)
            {
                GridProduct.DataSource = dto.Products;
                GridProduct.Columns[0].HeaderText = "Product Name";
                GridProduct.Columns[1].HeaderText = "Category Name";
                GridProduct.Columns[2].HeaderText = "Stock Amount";
                GridProduct.Columns[3].HeaderText = "Price";
                GridProduct.Columns[4].Visible = false;
                GridProduct.Columns[5].Visible = false;
                GridProduct.Columns[6].Visible = false;
                GridCustomer.DataSource = dto.Customers;
                GridCustomer.Columns[0].Visible = false;
                GridCustomer.Columns[1].HeaderText = "Customer Name";
                if (dto.Categories.Count > 0)
                    combofull = true;
            }
            else
            {
                panel1.Hide();
                textCustomer.Text = detail.CustomerName;
                txtNameProduct.Text = detail.ProductName;
                txtPrice.Text = detail.Price.ToString();
                textproductsales.Text = detail.SalesAmount.ToString();
                ProductDetailDTO product = dto.Products.First(x => x.ProductID == detail.ProductID);
                detail.StockAmount = product.StockAmount;
                textStock.Text = detail.StockAmount.ToString();
            }
            
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combofull)
            {
                List<ProductDetailDTO> list = dto.Products;
                list = list.Where(x => x.CategoryID == Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
                GridProduct.DataSource = list;
                if(list.Count == 0)
                {
                    txtPrice.Clear();
                    txtNameProduct.Clear();
                    textStock.Clear();
                }
            }
        }

        private void textCustomerSearcher_TextChanged(object sender, EventArgs e)
        {
            List<CustomerDetailDTO> list = dto.Customers;
            list = list.Where(x => x.CustomerName.Contains(textCustomerSearcher.Text)).ToList();
            GridCustomer.DataSource = list;
            if (list.Count == 0)
                textCustomer.Clear();
        }
        
        private void GridProduct_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ProductName = GridProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
            detail.Price = Convert.ToInt32(GridProduct.Rows[e.RowIndex].Cells[3].Value);
            detail.StockAmount = Convert.ToInt32(GridProduct.Rows[e.RowIndex].Cells[2].Value);
            detail.ProductID = Convert.ToInt32(GridProduct.Rows[e.RowIndex].Cells[4].Value); ;
            detail.CategoryID = Convert.ToInt32(GridProduct.Rows[e.RowIndex].Cells[5].Value);
            txtNameProduct.Text = detail.ProductName;
            txtPrice.Text = detail.Price.ToString();
            textStock.Text = detail.StockAmount.ToString();

        }

        private void GridCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.CustomerID = Convert.ToInt32(GridCustomer.Rows[e.RowIndex].Cells[0].Value);
            detail.CustomerName = GridCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            textCustomer.Text = detail.CustomerName;
        }
        SalesBLL bll = new SalesBLL();
        private void butSave_Click(object sender, EventArgs e)
        {
            
                if(!isUpdate)
                {
                if (detail.ProductID == 0)
                    MessageBox.Show("Please select a product");
                else if (detail.CustomerID == 0)
                    MessageBox.Show("please select a customer");
                else if (detail.StockAmount < Convert.ToInt32(textproductsales.Text))
                    MessageBox.Show("you have bot enough product for sale");
                else if (Convert.ToInt32(textproductsales.Text) <= 0)
                    MessageBox.Show("You can't sell nothing");
                else
                {
                    detail.SalesAmount = Convert.ToInt32(textproductsales.Text);
                    detail.SalesDate = DateTime.Today;
                    if (bll.Insert(detail))
                    {
                        MessageBox.Show("Sales was addedd");
                        bll = new SalesBLL();
                        dto = bll.Select();
                        GridProduct.DataSource = dto.Products;
                        dto.Customers = dto.Customers;
                        combofull = false;
                        cmbCategory.DataSource = dto.Categories;
                        if (dto.Products.Count > 0)
                            combofull = true;
                        textproductsales.Clear();

                    }
                }
                }
                else //Update
                {
                if (detail.SalesAmount == Convert.ToInt32(textproductsales.Text))
                    MessageBox.Show("There is no change");
                else
                {
                    int temp = detail.StockAmount + detail.SalesAmount;
                    if (temp < Convert.ToInt32(textproductsales.Text))
                        MessageBox.Show("You have not enough of this product");
                    else
                    {
                        detail.SalesAmount = Convert.ToInt32(textproductsales.Text);
                        detail.StockAmount = temp - detail.SalesAmount;
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("sales was updated");
                            this.Close();
                        }
                    }
                }

                }
                
            
        }
    }
}
