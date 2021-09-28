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
            this.Visible = true;
        }
        
        private void FrmUserList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
        }
    }
}
