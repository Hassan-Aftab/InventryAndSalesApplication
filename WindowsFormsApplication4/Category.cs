using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication4
{
    public partial class btnUpdate : Form
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader rdr;
        String cs = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Hassan\Downloads\Compressed\WindowsFormsApplication4\WindowsFormsApplication4\bin\Debug\MSM_DB.mdf;Integrated Security=True;Connect Timeout=30";
 
        public btnUpdate()
        {
            InitializeComponent();

        }

        private void bt_catinsert_Click(object sender, EventArgs e)
        {
            if (txtCategoryID.Text == "")
            {
                MessageBox.Show("Please enter Category ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCategoryID.Focus();
                return;
            }
            if (txtCategoryName.Text == "")
            {
                MessageBox.Show("Please enter Category name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCategoryName.Focus();
                return;
            }


            try
            {
                con = new SqlConnection(cs);
                con.Open();
                string ct = "select CategoryID from tblCategory where CategoryID='" + txtCategoryID.Text + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Category ID Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCategoryID.Text = "";
                    txtCategoryID.Focus();


                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs);
                con.Open();

                string cb = "insert into tblCategory(CategoryID,CategoryName) VALUES ('" + txtCategoryID.Text + "','" + txtCategoryName.Text + "')";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetData();
                btnInsert.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetData()
        {
            try
            {
                con = new SqlConnection(cs);
                con.Open();
                String sql = "SELECT rtrim(CategoryID),rtrim(CategoryName) from tblCategory order by CategoryName";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0],rdr[1]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void insertctg_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs);
                con.Open();

                string cb = "update tblCategory set CategoryName='" + txtCategoryName.Text + "' where CategoryID='" + txtCategoryID.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button1.Enabled = false;
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            txtCategoryID.Text = dr.Cells[0].Value.ToString();
            txtCategoryName.Text = dr.Cells[1].Value.ToString();
            btnInsert.Enabled = false;
            button1.Enabled = true;

        }
        private void Reset()
        {
            
          
        txtCategoryID.Text = "";
            txtCategoryName.Text = "";
            btnInsert.Enabled = true;
            button1.Enabled = false;
            txtCategoryID.Focus();
          
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
           Reset();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void delete_records()
        {

            try
            {

                int RowsAffected = 0;
                con = new SqlConnection(cs);
                con.Open();
                string cq1 = "delete from tblCategory where CategoryID='" + txtCategoryID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();

                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                GetData();  //yha call ni kiya to delete sucess hone pe bhi gridview me record dekhega ye function ek bar likh chuke upper


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            delete_records();
        }

     
    

    }
}