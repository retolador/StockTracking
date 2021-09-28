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
using StockTracking.DAL.DAO;
using StockTracking.DAL.DTO;

namespace StockTracking
{
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        CustomerBLL bll = new CustomerBLL();
        public CustomerDetailDTO detail = new CustomerDetailDTO();
        public bool isUpdate = false;
        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            if (isUpdate)
                textCustomer.Text = detail.CustomerName;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if (textCustomer.Text.Trim() == "")
                MessageBox.Show("Customer Name is empty");
            else
            {
                if (!isUpdate)
                {
                    CustomerDetailDTO customer = new CustomerDetailDTO();
                    customer.CustomerName = textCustomer.Text;
                    if (bll.Insert(customer))
                    {
                        MessageBox.Show("Customer was added correctly");
                        textCustomer.Clear();
                    }
                }
                else
                {
                    if (detail.CustomerName == textCustomer.Text)
                        MessageBox.Show("There is no changes");
                    else
                    {
                        detail.CustomerName = textCustomer.Text;
                        if(bll.Update(detail))
                        {
                            MessageBox.Show("Customer was updated");
                            this.Close();
                        }
                    }
                }
                
            }
        }
    }
}
