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
            string Query = "Select * from EmployeeTbl";
            EmpList.DataSource = Con.GetData(Query);
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
                    string DOF = DOBTb.Value.ToString();
                    string JDate = JDateTb.Value.ToString();
                    int Salary = Convert.ToInt32(DailySalTb.Text);
                    string Query = "insert into EmployeeTbl values ('{0}','{1}','{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query,Name,Gender,Dep,DOF,JDate,Salary);
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
    }
}
