using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeManagementSystem
{
    public partial class Fees : Form
    {
        public Fees()
        {
            InitializeComponent();
        }

        private void txtRegNumber_TextChanged(object sender, EventArgs e)
        {
            if(txtRegNumber.Text != "")
            {
                // create Sql connection
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\Database.mdf;Integrated Security=True; Connect Timeout=60";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // query
                cmd.CommandText = "select fname, mname, duration from NewAdmission where NAID = '" + txtRegNumber.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // set label text
                if (ds.Tables[0].Rows.Count != 0)
                {
                    lblFullName.Text = ds.Tables[0].Rows[0][0].ToString();
                    lblMotherName.Text = ds.Tables[0].Rows[0][1].ToString();
                    lblDuration.Text = ds.Tables[0].Rows[0][2].ToString();
                }
                else
                {
                    lblFullName.Text = "-----------";
                    lblMotherName.Text = "-----------";
                    lblDuration.Text = "-----------";
                }
            }
            else
            {
                txtRegNumber.Text = "";
                txtFees.Text = "";
                lblFullName.Text = "-----------";
                lblMotherName.Text = "-----------";
                lblDuration.Text = "-----------";
            }
        }

        // Submit Button
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(txtFees.Text != "")
            {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\Database.mdf;Integrated Security=True; Connect Timeout=60";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            // query for select the fees of given id
            cmd.CommandText = "select * from fees where NAID = '" + txtRegNumber.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // if the selected id is not present then insert 
            if (ds.Tables[0].Rows.Count == 0)
            {
                // create Sql connection
                SqlConnection con1 = new SqlConnection();
                con1.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\Database.mdf;Integrated Security=True; Connect Timeout=60";
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con1;

                // query
                cmd1.CommandText = "insert into fees (NAID, fees) values (" + txtRegNumber.Text + ", " + txtFees.Text + ")";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);

                if (MessageBox.Show("Fees Submission Successfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    txtRegNumber.Text = "";
                    txtFees.Text = "";
                    lblFullName.Text = "-----------";
                    lblMotherName.Text = "-----------";
                    lblDuration.Text = "-----------";
                }
            }
            else
            {
                MessageBox.Show("Your fees is already Submitted.");
                txtRegNumber.Text = "";
                txtFees.Text = "";
                lblFullName.Text = "-----------";
                lblMotherName.Text = "-----------";
                lblDuration.Text = "-----------";
            }
            }
            else
            {
                MessageBox.Show("Please Enter Fees", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
