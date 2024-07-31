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
using System.Xml.Linq;

namespace CollegeManagementSystem
{
    public partial class AddTeacher : Form
    {
        public AddTeacher()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            String gender = "";
            bool isChecked = radioButtonMale.Checked;
            if (isChecked)
            {
                gender = radioButtonMale.Text;
            }
            else
            {
                gender = radioButtonFemale.Text;
            }

            String dob = txtDOB.Text;
            
            Int64 mobile = 0;
            bool isMobileValid = Int64.TryParse(txtMobile.Text, out mobile);
            String email = txtEmail.Text;
            String joinDate = txtJoinDate.Text;
            String dept = txtDept.Text;
            String program = txtProgramming.Text;
            String add = txtAddress.Text;

            // create Sql connection
            if(gender != "" && dob != "" && email != "" && isMobileValid && mobile != 0 && joinDate != "" && dept != "" && program != "" && add != "")
            {

            SqlConnection con = new SqlConnection();
            //con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MAMATA PATRA\source\repos\CollegeManagementSystem\CollegeManagementSystem\Database.mdf;Integrated Security=True";
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\Database.mdf;Integrated Security=True; Connect Timeout=60";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            // insert query
            cmd.CommandText = "insert into teacher (fname, gender, dob, mobile, email, joinDate, dept, prog, adr) values ('" + txtFullName.Text + "', '" + gender + "', '" + txtDOB.Text + "', " + txtMobile.Text + ", '" + txtEmail.Text + "', '" + txtJoinDate.Text + "', '" + txtDept.Text + "', '" + txtProgramming.Text + "', '" + txtAddress.Text + "')";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            MessageBox.Show("Data Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please Enter all Required Information", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            radioButtonFemale.Checked = false;
            radioButtonMale.Checked = false;
            txtMobile.Clear();
            txtProgramming.ResetText();
            txtDept.ResetText();
            txtDOB.ResetText();
            txtJoinDate.ResetText();
        }
    }
}
