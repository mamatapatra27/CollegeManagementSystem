using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace CollegeManagementSystem
{
    public partial class New_Admission : Form
    {
        public New_Admission()
        {
            InitializeComponent();
        }

        //--------------Submit Button-------------
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // extract the textboxes values
            String name = txtFullName.Text;
            String mname = txtMotherName.Text;
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
            Int64 mobile = Int64.Parse(txtMobile.Text);
            String email = txtEmail.Text;
            String semester = txtSemester.Text;
            String program = txtProgramming.Text;
            String sname = txtSchoolName.Text;
            String duration = txtDuration.Text;
            String add = txtAddress.Text;

            // create Sql connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MAMATA PATRA\source\repos\CollegeManagementSystem\CollegeManagementSystem\Database.mdf;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            // insert query
            cmd.CommandText = "insert into NewAdmission (fname, mname, gender, dob, mobile, email, semester, prog, sname, duration, address) values ('" + name + "', '" + mname + "', '" + gender + "', '" + dob + "', '" + mobile + "', '" + email + "', '" + semester + "', '" + program + "', '" + sname + "', '" + duration + "', '" + add + "')";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            MessageBox.Show("Data Saved, Remember the Registration ID", "Data", MessageBoxButtons.OK, MessageBoxIcon.Hand);

        }

        //---------------Reset Button----------------
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            txtMotherName.Clear();
            radioButtonFemale.Checked = false;
            radioButtonMale.Checked = false;
            txtMobile.Clear();
            txtProgramming.ResetText();
            txtSemester.ResetText();
            txtSchoolName.Clear();
            txtDuration.ResetText();
            txtDOB.ResetText();
        }

        //---------------Page load----------------
        private void New_Admission_Load(object sender, EventArgs e)
        {
            // create Sql connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MAMATA PATRA\source\repos\CollegeManagementSystem\CollegeManagementSystem\Database.mdf;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            // query for count maximun Registration number
            cmd.CommandText = "select max(NAID) from NewAdmission";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // extract the maximum number add 1 to increase reg. no
            Int64 abc = Convert.ToInt64(ds.Tables[0].Rows[0][0]);
            lblRegistrationNo.Text = (abc+1).ToString();
        }
    }
}
