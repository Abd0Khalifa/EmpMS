using System;
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
                DSal = Convert.ToInt32(dr["EmpSal"].ToString());
            }
            
            // MessageBox.Show("" + DSal);
            // EmpCb.DataSource = Con.GetData(Query);

            if (DayTb.Text == "")
            {
                AmountTb.Text = "Rs  " + (d * DSal);
            }else if(Convert.ToInt32(DayTb.Text) > 31)
            {
                MessageBox.Show("Days Can Not be Greater than 31");
            }
            else
            {
                d = Convert.ToInt32(DayTb.Text);
                AmountTb.Text = "Rs  " + (d * DSal);
            }
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
        int d = 1;
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpCb.SelectedIndex == -1 || DayTb.Text == "" || PeriodTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!!");
                }
                else
                {
                    period = PeriodTb.Value.Date.Month.ToString() + "-" + PeriodTb.Value.Date.Year.ToString();
                    int Amount = DSal * Convert.ToInt32(DayTb.Text);
                    int Days = Convert.ToInt32(DayTb.Text);
                    string Query = "insert into SalaryTbl values ({0},{1},'{2}',{3},'{4}')";
                    Query = string.Format(Query, EmpCb.SelectedValue.ToString(), Days, period, Amount, DateTime.Today.Date);
                    Con.SetData(Query);
                    ShowSalary();
                    MessageBox.Show("Salary Paid");
                    DayTb.Text = "";
                    
                }
                
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void EmpCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSal();

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Departments obj = new Departments();
            obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Salary obj = new Salary();
            obj.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Employees obj = new Employees();
            obj.Show();
            this.Hide();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            
        }
    }
}
