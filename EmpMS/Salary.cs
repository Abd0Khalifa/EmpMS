﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpMS
{
    public partial class Salary : Form
    {
        Functions Con;
        public Salary()
        {
            InitializeComponent();
            Con = new Functions();
            ShowSalary();
            GetEmp();
        }

        private void GetEmp()
        {
            string Query = "select * from EmployeeTbl";
            EmpCb.DisplayMember = Con.GetData(Query).Columns["EmpName"].ToString();
            EmpCb.ValueMember = Con.GetData(Query).Columns["Empid"].ToString();
            EmpCb.DataSource = Con.GetData(Query);
        }
        int DSal = 0;
        string period = "";
        private void GetSal()
        {
            string Query = "select * from EmployeeTbl where Empid = {0}";
            Query = string.Format(Query, EmpCb.SelectedValue.ToString());
            foreach(DataRow dr in Con.GetData(Query).Rows)
            {
                DSal = Convert.ToInt32(dr["EmpName"].ToString());
            }
            
            // MessageBox.Show("" + DSal);
            // EmpCb.DataSource = Con.GetData(Query);
        }

        private void ShowSalary()
        {
            try
            {
                string Query = "Select * from SalaryTbl";
                SalList.DataSource = Con.GetData(Query);
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void guna2DateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void SalList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void EmpCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSal();

        }
    }
}
