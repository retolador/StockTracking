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
                
            }
            
            
        }
    }
}
