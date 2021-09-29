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
    public partial class FrmAddStock : Form
    {
        public FrmAddStock()
        {
            InitializeComponent();
        }

        private void textStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        ProductBLL bll = new ProductBLL();
        ProductDTO dto = new ProductDTO();
        public ProductDetailDTO detailUpdate = new ProductDetailDTO(); //Para updatear los stocks críticos
        public bool isUpdate = false;
        private void FrmAddStock_Load(object sender, EventArgs e)
        {  
            dto = bll.Select();
            dataGridView1.DataSource = dto.Products;
            dataGridView1.Columns[0].HeaderText = "Product Name";
            dataGridView1.Columns[1].HeaderText = "Category Name";
            dataGridView1.Columns[2].HeaderText = "Stock Amount";
            dataGridView1.Columns[3].HeaderText = "Price";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;
            dataGridView1.DataSource = dto.Products;
            if (dto.Categories.Count > 0)
                combofull = true;

            if (isUpdate) //Si solamente es para actualizar un producto, no se muestra el panel de selección
            {
                panel1.Visible = false;
                txtName.Text = detailUpdate.ProductName;
                txtPrice.Text = detailUpdate.Price.ToString();

            }
               
        }
        bool combofull = false;
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combofull)
            {
                List<ProductDetailDTO> list = dto.Products;
                list = list.Where(x => x.CategoryID == Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
                dataGridView1.DataSource = list;
                if(list.Count == 0)
                {
                    txtPrice.Clear();
                    txtName.Clear();
                    textStock.Clear();
                }


            }

        }
        ProductDetailDTO detail = new ProductDetailDTO();
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ProductName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = detail.ProductName;
            detail.Price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            txtPrice.Text = detail.Price.ToString();
            detail.StockAmount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            detail.ProductID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);

        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if (!isUpdate)
            {
                if (txtName.Text.Trim() == "")
                    MessageBox.Show("Select a product");
                else if (textStock.Text.Trim() == "")
                    MessageBox.Show("Please select a Stock amount");
                else
                {
                    int sumstock = detail.StockAmount;
                    sumstock += Convert.ToInt32(textStock.Text);
                    detail.StockAmount = sumstock;
                    if (bll.Update(detail))
                    {
                        MessageBox.Show("the Stock was addedd");
                        bll = new ProductBLL();
                        dto = bll.Select();
                        dataGridView1.DataSource = dto.Products;
                        textStock.Clear();
                    }
                }
            }
            else
            {
                if (textStock.Text.Trim() == "")
                    MessageBox.Show("Please select a Stock amount");
                else if(Convert.ToInt32(textStock.Text) <= 0)
                    MessageBox.Show("You can't update 0 items or less");
                else
                {
                    int sumstock = detailUpdate.StockAmount;
                    sumstock += Convert.ToInt32(textStock.Text);
                    detailUpdate.StockAmount = sumstock;
                    if (bll.Update(detailUpdate))
                    {
                        MessageBox.Show("the Stock was Updated");
                        this.Close();
                    }

                }
                
            }
        }
    }
}
