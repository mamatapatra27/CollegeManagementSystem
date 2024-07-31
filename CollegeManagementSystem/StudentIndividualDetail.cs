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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CollegeManagementSystem
{
    public partial class StudentIndividualDetail : Form
    {
        public StudentIndividualDetail()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if(txtRegId.Text != "")
            {

            // create Sql connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\Database.mdf;Integrated Security=True; Connect Timeout=60";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            //query
            cmd.CommandText = "select * from NewAdmission where NAID = '"+txtRegId.Text+"'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                // extract values
                lblFullName.Text = ds.Tables[0].Rows[0][1].ToString();
                lblMotherName.Text = ds.Tables[0].Rows[0][2].ToString();
                lblGender.Text = ds.Tables[0].Rows[0][3].ToString();
                lblDob.Text = ds.Tables[0].Rows[0][4].ToString();
                lblMobile.Text = ds.Tables[0].Rows[0][5].ToString();
                lblEmail.Text = ds.Tables[0].Rows[0][6].ToString();
                lblSemester.Text = ds.Tables[0].Rows[0][7].ToString();
                lblProgramming.Text = ds.Tables[0].Rows[0][8].ToString();
                lblSchoolName.Text = ds.Tables[0].Rows[0][9].ToString();
                lblDuration.Text = ds.Tables[0].Rows[0][10].ToString();
                lblAddress.Text = ds.Tables[0].Rows[0][11].ToString();
            }
            else
            {
                MessageBox.Show("No Record Found", "No Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }
            else
            {
                MessageBox.Show("Please Enter Registration Id to Show Details", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblFullName.Text = "______";
            lblMotherName.Text = "______";
            lblGender.Text = "______";
            lblDob.Text = "______";
            lblMobile.Text = "______";
            lblEmail.Text = "______";
            lblSemester.Text = "______";
            lblProgramming.Text = "______";
            lblSchoolName.Text = "______";
            lblDuration.Text = "______";
            lblAddress.Text = "______";
        }
    }
}
