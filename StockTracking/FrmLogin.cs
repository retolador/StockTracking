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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        UserDetailDTO user = new UserDetailDTO();
        UserDTO dto = new UserDTO();
        UserBLL bll = new UserBLL();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim() == "")
                MessageBox.Show("There is no user");
            else if (txtPassword.Text.Trim() == "")
                MessageBox.Show("There is no password");
            else
            {
                user.UserName = txtUser.Text;
                user.Password = txtPassword.Text;
                user = bll.Select(user);
                if(user == null)
                {
                    MessageBox.Show("Username or password is incorrect");
                    user = new UserDetailDTO();
                }
                else
                {
                    GeneralUSer.User = user.UserName;
                    GeneralUSer.PermissionID = user.PermissionID;
                    if(GeneralUSer.PermissionID == 1 || GeneralUSer.PermissionID == 2 || GeneralUSer.PermissionID == 5)
                    { //Los de ventas, reponedores y admin pod´rán ver los stocks críticos los demás no.
                        FrmAlertStock frm = new FrmAlertStock();
                        this.Hide();
                        frm.ShowDialog();
                    }
                    else
                    {
                        //Los demás irán a la main page
                        FrmMain frm = new FrmMain();
                        this.Hide();
                        frm.ShowDialog();
                    }
                    
                }
            }
            
            
        }
    }
}
