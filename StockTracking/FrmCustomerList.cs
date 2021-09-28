﻿using System;
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
    public partial class FrmCustomerList : Form
    {
        public FrmCustomerList()
        {
            InitializeComponent();
        }

        private void buttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            FrmCustomer frm = new FrmCustomer();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            dto = bll.Select();
            dataGridView1.DataSource = dto.Customers;
        }
        CustomerBLL bll = new CustomerBLL();
        CustomerDTO dto = new CustomerDTO();
        private void FrmCustomerList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Customers;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Customer Name";

        }
        CustomerDetailDTO detail = new CustomerDetailDTO();
        private void textCustomer_TextChanged(object sender, EventArgs e)
        {
            List<CustomerDetailDTO> list = dto.Customers;
            list = list.Where(x => x.CustomerName.Contains(textCustomer.Text)).ToList();
            dataGridView1.DataSource = list;

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new CustomerDetailDTO();
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.CustomerName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void butUpdate_Click(object sender, EventArgs e)
        {
            if (detail.ID == 0)
                MessageBox.Show("Please select a Customer");
            else
            {
                FrmCustomer frm = new FrmCustomer();
                frm.detail = detail;
                frm.isUpdate = true;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                bll = new CustomerBLL();
                dto = bll.Select();
                dataGridView1.DataSource = dto.Customers;
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (detail.ID == 0)
                MessageBox.Show("Please select a Customer");
            else
            {
                DialogResult result = MessageBox.Show("Are you sure?", "Warning!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if(bll.Delete(detail))
                    {
                        MessageBox.Show("Customer was deleted");
                        bll = new CustomerBLL();
                        dto = bll.Select();
                        dataGridView1.DataSource = dto.Customers;
                        textCustomer.Clear();
                    }
                }
            }
        }
    }
}
