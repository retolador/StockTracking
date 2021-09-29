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
    public partial class FrmUserList : Form
    {
        public FrmUserList()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CleanFilters();
        }
        private void CleanFilters()
        {
            txtPassword.Clear();
            txtUserName.Clear();
            cmbPermission.SelectedIndex = -1;
            dataGridView1.DataSource = dto.Users;
        }

        private void buttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        UserDTO dto = new UserDTO();
        UserBLL bll = new UserBLL();
        private void butAdd_Click(object sender, EventArgs e)
        {
            FrmUser frm = new FrmUser();
            frm.dto = dto;
            this.Hide();
            frm.ShowDialog();
            dto = bll.Select();
            dataGridView1.DataSource = dto.Users;
            CleanFilters();
            this.Visible = true;
        }
        
        private void FrmUserList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Users;
            cmbPermission.DataSource = dto.Permissions;
            cmbPermission.DisplayMember = "PermissionName";
            cmbPermission.ValueMember = "ID";
            cmbPermission.SelectedIndex = -1;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "User Name";
            dataGridView1.Columns[2].HeaderText = "Password";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].HeaderText = "Permission";
           
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<UserDetailDTO> list = dto.Users;

            if (txtUserName.Text.Trim() != "")
                list = list.Where(x => x.UserName.Contains(txtUserName.Text)).ToList();
            if (txtPassword.Text.Trim() != "")
                list = list.Where(x => x.Password.Contains(txtPassword.Text)).ToList();
            if (cmbPermission.SelectedIndex != -1)
                list = list.Where(x => x.PermissionID == Convert.ToInt32(cmbPermission.SelectedValue)).ToList();
            dataGridView1.DataSource = list;
        }
        UserDetailDTO detail = new UserDetailDTO();
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new UserDetailDTO();
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.UserName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            detail.Password = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.PermissionID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
        }

        private void butUpdate_Click(object sender, EventArgs e)
        {
            if (detail.ID == 0)
                MessageBox.Show("You have select nothing");
            else
            {
                FrmUser frm = new FrmUser();
                frm.dto = dto;
                frm.detail = detail;
                frm.isUpdate = true;
                this.Hide();
                frm.ShowDialog();
                dto = bll.Select();
                dataGridView1.DataSource = dto.Users;
                CleanFilters();
                this.Visible = true;
            }
        }

        private void butDelete_Click(object sender, EventArgs e)//Se borra definitivamente el usuario
        {
            if (detail.ID == 0)
                MessageBox.Show("You have select nothing");
            else
            {
                DialogResult result = MessageBox.Show("Are you sure?", "Warning!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (bll.Delete(detail))
                    {
                        MessageBox.Show("User was deleted");
                        detail = new UserDetailDTO();
                        dto = bll.Select();
                        dataGridView1.DataSource = dto.Users;
                        CleanFilters();
                    }
                }
            }
        }
    }
}
