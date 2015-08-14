using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace WindowsFormsApplication4
{
    public partial class frmCustomers : Form
    {
        SqlDataReader rdr = null;
        SqlConnection con = null;
        SqlCommand cmd = null;
        String cs = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Hassan\Downloads\Compressed\WindowsFormsApplication4\WindowsFormsApplication4\bin\Debug\MSM_DB.mdf;Integrated Security=True;Connect Timeout=30";


        public frmCustomers()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            txtAddress.Text = "";
            txtCity.Text = "";
            txtEmail.Text = "";
            txtFaxNo.Text = "";
            txtCustomerName.Text = "";
            txtLandmark.Text = "";
            txtMobileNo.Text = "";
            txtNotes.Text = "";
            txtPhone.Text = "";
            txtCustomerID.Text = "";
            txtZipCode.Text = "";
            cmbState.Text = "";
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            txtCustomerName.Focus();

        }
        private void frmCustomers_Load(object sender, EventArgs e)
        {

        }
        private void auto()
        {
            txtCustomerID.Text = "C-" + GetUniqueKey(6);
        }
        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars = "123456789".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
        private void txtZipCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtZipCode.TextLength > 6)
            {
                MessageBox.Show("Only 6 digits are allowed", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtZipCode.Focus();
            }
        }

        private void txtZipCode_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (txtMobileNo.TextLength > 10)
            {
                MessageBox.Show("Only 10 digits are allowed", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMobileNo.Focus();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text == "")
            {
                MessageBox.Show("Please enter name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerName.Focus();
                return;
            }

            if (txtAddress.Text == "")
            {
                MessageBox.Show("Please enter address", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.Focus();
                return;
            }
            if (txtCity.Text == "")
            {
                MessageBox.Show("Please enter city", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCity.Focus();
                return;
            }
            if (cmbState.Text == "")
            {
                MessageBox.Show("Please select state", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbState.Focus();
                return;
            }
            if (txtZipCode.Text == "")
            {
                MessageBox.Show("Please enter zip/post code", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtZipCode.Focus();
                return;
            }


            if (txtMobileNo.Text == "")
            {
                MessageBox.Show("Please enter mobile no.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMobileNo.Focus();
                return;
            }

            try
            {
                auto();
                con = new SqlConnection(cs);
                con.Open();
                string ct = "select CustomerID from Customer where CustomerID=@find";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.VarChar, 20, "CustomerID"));
                cmd.Parameters["@find"].Value = txtCustomerID.Text;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Customer ID Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }


                }
                else
                {


                    con = new SqlConnection(cs);
                    con.Open();

                    string cb = "insert into Customer(CustomerID,Customername,address,landmark,city,state,zipcode,Phone,email,mobileno,faxno,notes) VALUES (@d1,@d2,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13)";

                    cmd = new SqlCommand(cb);

                    cmd.Connection = con;

                    cmd.Parameters.Add(new SqlParameter("@d1", System.Data.SqlDbType.VarChar, 20, "CustomerID"));
                    cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.VarChar, 100, "Customername"));
                    cmd.Parameters.Add(new SqlParameter("@d4", System.Data.SqlDbType.VarChar, 250, "address"));
                    cmd.Parameters.Add(new SqlParameter("@d5", System.Data.SqlDbType.VarChar, 250, "landmark"));

                    cmd.Parameters.Add(new SqlParameter("@d6", System.Data.SqlDbType.VarChar, 50, "city"));
                   

                    cmd.Parameters.Add(new SqlParameter("@d7", System.Data.SqlDbType.VarChar, 50, "state"));

                    cmd.Parameters.Add(new SqlParameter("@d8", System.Data.SqlDbType.VarChar, 10, "zipcode"));

                    cmd.Parameters.Add(new SqlParameter("@d9", System.Data.SqlDbType.VarChar, 15, "phone"));

                    cmd.Parameters.Add(new SqlParameter("@d10", System.Data.SqlDbType.VarChar, 150, "email"));

                    cmd.Parameters.Add(new SqlParameter("@d11", System.Data.SqlDbType.VarChar, 15, "mobileno"));

                    cmd.Parameters.Add(new SqlParameter("@d12", System.Data.SqlDbType.VarChar, 15, "faxno"));

                    cmd.Parameters.Add(new SqlParameter("@d13", System.Data.SqlDbType.VarChar, 250, "notes"));


                    cmd.Parameters["@d1"].Value = txtCustomerID.Text;
                    cmd.Parameters["@d2"].Value = txtCustomerName.Text;
                    cmd.Parameters["@d4"].Value = txtAddress.Text;
                    cmd.Parameters["@d5"].Value = txtLandmark.Text;
                    cmd.Parameters["@d6"].Value = txtCity.Text;
                    cmd.Parameters["@d7"].Value = cmbState.Text;
                    cmd.Parameters["@d8"].Value = txtZipCode.Text;
                    cmd.Parameters["@d9"].Value = txtPhone.Text;
                    cmd.Parameters["@d10"].Value = txtEmail.Text;
                    cmd.Parameters["@d11"].Value = txtMobileNo.Text;
                    cmd.Parameters["@d12"].Value = txtFaxNo.Text;
                    cmd.Parameters["@d13"].Value = txtNotes.Text;

                    cmd.ExecuteReader();
                    MessageBox.Show("Successfully saved", "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSave.Enabled = false;
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                    con.Close();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void delete_records()
        {

            try
            {

              int RowsAffected = 0;
              con = new SqlConnection(cs);
              con.Open();
              string cq = "delete from Customer where CustomerID=@DELETE1;";
              cmd = new SqlCommand(cq);
              cmd.Connection = con;
              cmd.Parameters.Add(new SqlParameter("@DELETE1", System.Data.SqlDbType.VarChar, 20, "CustomerID"));
              cmd.Parameters["@DELETE1"].Value = txtCustomerID.Text;
                RowsAffected = cmd.ExecuteNonQuery();

                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                else
                {
                    MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                    con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {


                if (MessageBox.Show("Do you really want to delete the record?", "Customer Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    delete_records();
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

                string cb = "update Customer set Customername = '" + txtCustomerName.Text + "',address= '" + txtAddress.Text + "',landmark= '" + txtLandmark.Text + "',city= '" + txtCity.Text + "',state= '" + cmbState.Text + "',zipcode= '" + txtZipCode.Text + "',Phone= '" + txtPhone.Text + "',email= '" + txtEmail.Text + "',mobileno= '" + txtMobileNo.Text + "',faxno= '" + txtFaxNo.Text + "',notes= '" + txtNotes.Text + "' where CustomerID= '" + txtCustomerID.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                MessageBox.Show("Successfully updated", "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate.Enabled = false;
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFaxNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomersRecord frm = new CustomersRecord();
            frm.Show();
            frm.GetData();
        }

      
    }
}
