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
    public partial class Employees : Form
    {
        Functions Con;
        public Employees()
        {
            InitializeComponent();
            Con = new Functions();
            ShowEmployees();
            GetDep();
        }

        private void ShowEmployees()
        {
            try
            {
                string Query = "Select * from EmployeeTbl";
                EmpList.DataSource = Con.GetData(Query);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        private void GetDep()
        {
            string Query = "select * from DepartmentTbl";
            DepCb.DisplayMember = Con.GetData(Query).Columns["DepName"].ToString();
            DepCb.ValueMember = Con.GetData(Query).Columns["Depid"].ToString();
            DepCb.DataSource = Con.GetData(Query);
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || GenCb.SelectedIndex==-1||DepCb.SelectedIndex==-1||DailySalTb.Text=="")
                {
                    MessageBox.Show("Missing Data!!!");
                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    int Dep =Convert.ToInt32(DepCb.SelectedValue.ToString());
                    string DOB = DOBTb.Value.ToString();
                    string JDate = JDateTb.Value.ToString();
                    int Salary = Convert.ToInt32(DailySalTb.Text);
                    string Query = "insert into EmployeeTbl values ('{0}','{1}','{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query,Name,Gender,Dep,DOB,JDate,Salary);
                    Con.SetData(Query);
                    ShowEmployees();
                    MessageBox.Show("Employee Added");
                    EmpNameTb.Text = "";
                    GenCb.SelectedIndex = -1;
                    DepCb.SelectedIndex = -1;
                    DailySalTb.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {



            try
            {
                if (EmpNameTb.Text == "" || GenCb.SelectedIndex == -1 || DepCb.SelectedIndex == -1 || DailySalTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!!");
                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    int Dep = Convert.ToInt32(DepCb.SelectedValue.ToString());
                    string DOB = DOBTb.Value.ToString();
                    string JDate = JDateTb.Value.ToString();
                    int Salary = Convert.ToInt32(DailySalTb.Text);
                    string Query = "Update EmployeeTbl set EmpName = '{0}',EmpGen = '{1}',EmpDep = '{2}',EmpDOF = '{3}',EmpJDate = '{4}',EmpSal = '{5}' where Empid = {6}";
                    Query = string.Format(Query, Name,Gender,Dep,DOB,JDate,Salary, Key);
                    Con.SetData(Query);
                    ShowEmployees();
                    MessageBox.Show("Employee Updated");
                    EmpNameTb.Text = "";
                    GenCb.SelectedIndex = -1;
                    DepCb.SelectedIndex = -1;
                    DailySalTb.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }


            
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("Missing Data!!!");
                }
                else
                {
                    string Query = "Delete from EmployeeTbl where Empid = {0}";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    ShowEmployees();
                    MessageBox.Show("Employee Deleted");
                    EmpNameTb.Text = "";
                    GenCb.SelectedIndex = -1;
                    DepCb.SelectedIndex = -1;
                    DailySalTb.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int Key = 0;
        private void EmpList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpNameTb.Text = EmpList.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.Text = EmpList.SelectedRows[0].Cells[2].Value.ToString();
            DepCb.SelectedValue = EmpList.SelectedRows[0].Cells[3].Value.ToString();
            DOBTb.Text = EmpList.SelectedRows[0].Cells[4].Value.ToString();
            JDateTb.Text = EmpList.SelectedRows[0].Cells[5].Value.ToString();
            DailySalTb.Text = EmpList.SelectedRows[0].Cells[6].Value.ToString();
            if (EmpNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(EmpList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
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
    }
}
