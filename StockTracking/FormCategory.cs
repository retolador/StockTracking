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
    public partial class FormCategory : Form
    {
        CategoryBLL bll = new CategoryBLL();
        public CategoryDetailDTO detail = new CategoryDetailDTO();
        public bool isUpdate = false;
        public FormCategory()
        {
            InitializeComponent();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCategory_Load(object sender, EventArgs e)
        {
            if (isUpdate)
                txtCategory.Text = detail.CategoryName;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if (txtCategory.Text.Trim() == "")
                MessageBox.Show("Check the box is not null");
            else
            {
                if (!isUpdate)
                {
                    CategoryDetailDTO category = new CategoryDetailDTO();
                    category.CategoryName = txtCategory.Text;
                    if (bll.Insert(category))
                    {
                        MessageBox.Show("Category Added Correctly");
                        txtCategory.Clear();
                    }
                }
                else if(isUpdate)
                {
                    if (detail.CategoryName == txtCategory.Text.Trim())
                        MessageBox.Show("There is no change");
                    else
                    {
                        detail.CategoryName = txtCategory.Text;
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("Category was updated");
                            this.Close();
                        }
                    }
                   
                }
               

            }   
        }
    }
}
