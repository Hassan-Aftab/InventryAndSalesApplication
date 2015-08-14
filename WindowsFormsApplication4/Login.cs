using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        MDIParent1 m1 = new MDIParent1();
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             if ((textBox2.Text == "") || (textBox1.Text ==""))
            {

                MessageBox.Show("Plz Insert User Name & Password");

            }
             else if (textBox2.Text != "admin")
            {
                MessageBox.Show("Incorrect User Name");
            }
            else if (textBox1.Text != "admin123")
            {
                MessageBox.Show("Incorrect Password");
            }
            else if ((textBox2.Text != "admin") || (textBox1.Text != "admin123"))
            {

                MessageBox.Show("Incorrect User Name & Password");

            }
            
            else if((textBox2.Text =="admin" )|| (textBox1.Text=="admin123"))
            {
                this.Hide();
                  
              m1.Show();
            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text == "") || (textBox1.Text == ""))
            {

                MessageBox.Show("Plz Insert User Name & Password");

            }
            else if (textBox2.Text != "manager")
            {
                MessageBox.Show("Incorrect User Name");
            }
            else if (textBox1.Text != "manager123")
            {
                MessageBox.Show("Incorrect Password");
            }
            else if ((textBox2.Text != "manager") || (textBox1.Text != "manager123"))
            {

                MessageBox.Show("Incorrect User Name & Password");

            }

            else if ((textBox2.Text == "manager") || (textBox1.Text == "manager123"))
            {
                this.Hide();
                frmInvoice frm = new frmInvoice();
                frm.Show();

            }
        }
    }
}
