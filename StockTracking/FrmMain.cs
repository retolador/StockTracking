using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockTracking
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void butSales_Click(object sender, EventArgs e)
        {
            FrmSalesList frm = new FrmSalesList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void butProduct_Click(object sender, EventArgs e)
        {
            FrmProductList frm = new FrmProductList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void butCustomer_Click(object sender, EventArgs e)
        {
            FrmCustomerList frm = new FrmCustomerList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void butAddStock_Click(object sender, EventArgs e)
        {
            FrmAddStock frm = new FrmAddStock();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void butCategory_Click(object sender, EventArgs e)
        {
            FrmCategoryList frm = new FrmCategoryList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void butDeleted_Click(object sender, EventArgs e)
        {
            FrmDeleted frm = new FrmDeleted();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
