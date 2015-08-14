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
    public partial class CustomersRecord : Form
    {
       
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        DataSet ds = new DataSet();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        String cs = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Hassan\Downloads\Compressed\WindowsFormsApplication4\WindowsFormsApplication4\bin\Debug\MSM_DB.mdf;Integrated Security=True;Connect Timeout=30";

        public CustomersRecord()
        {
            InitializeComponent();
        }
        public void GetData()
        {
                try{
                con = new SqlConnection(cs);
                con.Open();
                cmd = new SqlCommand( "SELECT Rtrim(CustomerID)[Customer ID],rtrim(Customername)[Customer Name],rtrim(address)[Address],rtrim(landmark)[Landmark],rtrim(city)[City],rtrim(state)[State],rtrim(zipcode)[Zip/Post Code],rtrim(Phone)[Phone],rtrim(email)[Email],rtrim(mobileno)[Mobile No],rtrim(faxno)[Fax No],rtrim(notes)[Notes] from Customer order by CustomerName", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Customer");
                dataGridView1.DataSource = myDataSet.Tables["Customer"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
       }

        private void frmCustomersRecord_Load(object sender, EventArgs e)
        {
            GetData();
        }
         
    

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
     
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
             try{
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            this.Hide();
            frmCustomers frm= new frmCustomers();
           frm.Show();
           frm.txtCustomerID.Text = dr.Cells[0].Value.ToString();
           frm.txtCustomerName.Text = dr.Cells[1].Value.ToString();
           frm.txtAddress.Text = dr.Cells[2].Value.ToString();
           frm.txtCity.Text = dr.Cells[4].Value.ToString();
           frm.txtLandmark.Text = dr.Cells[3].Value.ToString();
           frm.cmbState.Text = dr.Cells[5].Value.ToString();
           frm.txtZipCode.Text = dr.Cells[6].Value.ToString();
           frm.txtPhone.Text = dr.Cells[7].Value.ToString();
           frm.txtEmail.Text = dr.Cells[8].Value.ToString();
           frm.txtMobileNo.Text = dr.Cells[9].Value.ToString();
           frm.txtFaxNo.Text = dr.Cells[10].Value.ToString();
           frm.txtNotes.Text = dr.Cells[11].Value.ToString();
           frm.btnUpdate.Enabled = true;
           frm.btnDelete.Enabled = true;
           frm.btnSave.Enabled = false;
           frm.txtCustomerName.Focus();
             }
        
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCustomers_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs);
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(CustomerID)[Customer ID],rtrim(Customername)[Customer Name],rtrim(address)[Address],rtrim(landmark)[Landmark],rtrim(city)[City],rtrim(state)[State],rtrim(zipcode)[Zip/Post Code],rtrim(Phone)[Phone],rtrim(email)[Email],rtrim(mobileno)[Mobile No],rtrim(faxno)[Fax No],rtrim(notes)[Notes] from Customer where CustomerName like '" + txtCustomers.Text + "%' order by CustomerName", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Customer");
                dataGridView1.DataSource = myDataSet.Tables["Customer"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void frmCustomersRecord1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmCustomers frm = new frmCustomers();
            frm.Show();
        }
    }
}
