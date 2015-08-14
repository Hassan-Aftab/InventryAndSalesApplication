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
    public partial class Product : Form
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader rdr;
        String cs = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Hassan\Downloads\Compressed\WindowsFormsApplication4\WindowsFormsApplication4\bin\Debug\MSM_DB.mdf;Integrated Security=True;Connect Timeout=30";//Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\MSM_DB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";


        public Product()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
         GetData();
         GetData1();
        }
      
        private void Reset()
        {
            txtCategoryName.Text = "";
            txtProductName.Text = "";
            txtCategoryID.Text = "";
            txtProductID.Text = "";
            txtPrice.Text = "";
            txtQtyAvailable.Text = "";
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            txtProductID.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductID.Text == "")
            {
                MessageBox.Show("Please enter product id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductID.Focus();
                return;
            }
            if (txtProductName.Text == "")
            {
                MessageBox.Show("Please enter product name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductName.Focus();
                return;
            }
            if (txtCategoryID.Text == "")
            {
                MessageBox.Show("Please retrieve category id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCategoryID.Focus();
                return;
            }
            if (txtPrice.Text == "")
            {
                MessageBox.Show("Please enter price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
                return;
            }
            if (txtQtyAvailable.Text == "")
            {
                MessageBox.Show("Please enter Qty. available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQtyAvailable.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs);
                con.Open();
                string ct = "select ProductID from Product where ProductID='" + txtProductID.Text + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Product ID Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtProductName.Text = "";
                    txtProductName.Focus();


                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                con = new SqlConnection(cs);
                con.Open();

                string cb = "insert into Product(ProductID,ProductName,CategoryID,Price,QtyAvailable) VALUES ('" + txtProductID.Text + "','" + txtProductName.Text+ "','" + txtCategoryID.Text+ "'," + txtPrice.Text +"," + txtQtyAvailable.Text + ")";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                GetData1();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }
        private void delete_records()
        {

            try
            {

                int RowsAffected = 0;
                con = new SqlConnection(cs);
                con.Open();
                string cq = "delete from product where productID='" + txtProductID.Text + "'";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    GetData1();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    GetData1();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs);
                con.Open();

                string cb = "update Product set productName='" + txtProductName.Text + "',CategoryID='" + txtCategoryID.Text + "',Price=" + txtPrice.Text + ",QtyAvailable= " + txtQtyAvailable.Text +" where ProductID='" + txtProductID.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate.Enabled = false;
                GetData1();
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
                    dataGridView2.Rows.Add(rdr[0], rdr[1]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetData1()
        {
            try
            {
                con = new SqlConnection(cs);
                con.Open();
                String sql = "SELECT rtrim(Productid),rtrim(ProductName), rtrim(tblCategory.CategoryID),rtrim(CategoryName),rtrim(price),rtrim(QtyAvailable) from Product,tblCategory where tblCategory.CategoryID=Product.CategoryID order by ProductName";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1],rdr[2],rdr[3],rdr[4],rdr[5]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView2.SelectedRows[0];
            txtCategoryID.Text = dr.Cells[0].Value.ToString();
            txtCategoryName.Text = dr.Cells[1].Value.ToString();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            txtProductID.Text = dr.Cells[0].Value.ToString();
            txtProductName.Text = dr.Cells[1].Value.ToString();
            txtCategoryID.Text = dr.Cells[2].Value.ToString();
            txtCategoryName.Text = dr.Cells[3].Value.ToString();
            txtPrice.Text = dr.Cells[4].Value.ToString();
            txtQtyAvailable.Text = dr.Cells[5].Value.ToString();
            btnSave.Enabled = false;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtQtyAvailable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

    }
}
