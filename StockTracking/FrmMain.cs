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

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            FrmUserList frm = new FrmUserList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if(GeneralUSer.PermissionID == 1)// Vendedor solo puede hacer ventas y recuperar ventas borradas.
            {
                butCustomer.Hide();
                butProduct.Hide();
                butAddStock.Hide();
                butCategory.Hide();
                btnEmployee.Hide();
                butSales.Location = new Point(99, 23);
                butDeleted.Location = new Point(319, 23);
                butExit.Location = new Point(530, 23);
            }
            else if(GeneralUSer.PermissionID == 2)//Reponedor: solo puede crear categorías, productos y rellenar stock, además de recuperar-los
            {
                butCustomer.Hide();
                btnEmployee.Hide();
                butSales.Hide();
                butAddStock.Location = new Point(319, 23);
                butProduct.Location = new Point(99, 23);
                butCategory.Location = new Point(530, 23);
                butExit.Location = new Point(229, 224);
            }
            else if(GeneralUSer.PermissionID == 3)//Comercial: solo puede añadir clientes y nuevos productos, además de recuperarlos
            {
                butAddStock.Hide();
                butCategory.Hide();
                btnEmployee.Hide();
                butSales.Hide();
                butDeleted.Location = new Point(530, 23);

            }
            else if(GeneralUSer.PermissionID == 4)//Recursos Humanos: puede dar de alta nuevos usuarios y cambiar sus permisos de acceso
            {
                butAddStock.Hide();
                butCategory.Hide();
                butCustomer.Hide();
                butSales.Hide();
                butDeleted.Hide();
                btnEmployee.Location = new Point(99, 23);
                butExit.Location = new Point(319, 23);
                
            }
        }
    }
}
