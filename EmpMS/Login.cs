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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ResetLbl_Click(object sender, EventArgs e)
        {
            UNameTb.Text = "";
            PassTb.Text = "";
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UNameTb.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }else if(UNameTb.Text == "Abdo" && PassTb.Text == "Abdo")
            {
                Employees obj = new Employees();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorect Username Or Password");
                UNameTb.Text = "";
                PassTb.Text = "";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
