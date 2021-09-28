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
    public partial class FrmUser : Form
    {
        public FrmUser()
        {
            InitializeComponent();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        UserBLL bll = new UserBLL();
        public UserDTO dto = new UserDTO();
        private void butSave_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == "")
                MessageBox.Show("User name is empty!!");
            else if (txtPassword.Text.Trim() == "")
                MessageBox.Show("The password is empty");
            else if (cmbPermission.SelectedIndex == -1)
                MessageBox.Show("User doesn't have any role!!");
            else
            {
                UserDetailDTO user = new UserDetailDTO();
                user.UserName = txtUserName.Text;
                user.Password = txtPassword.Text;
                user.PermissionID = Convert.ToInt32(cmbPermission.SelectedValue);
                if (bll.Insert(user))
                {
                    MessageBox.Show("User added correctly");
                    txtUserName.Clear();
                    txtPassword.Clear();
                    cmbPermission.SelectedIndex = -1;
                }
            }

        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            cmbPermission.DataSource = dto.Permissions;
            cmbPermission.DisplayMember = "PermissionName";
            cmbPermission.ValueMember = "ID";
            cmbPermission.SelectedIndex = -1;
        }
    }
}
