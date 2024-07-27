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
    public partial class SearchStudent : Form
    {
        public SearchStudent()
        {
            InitializeComponent();
        }

        // page load
        private void SearchStudent_Load(object sender, EventArgs e)
        {
            // create Sql connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MAMATA PATRA\source\repos\CollegeManagementSystem\CollegeManagementSystem\Database.mdf;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            //query
            cmd.CommandText = "select NewAdmission.NAID as student_ID, NewAdmission.fname as Full_Name, NewAdmission.mname as Mother_Name, NewAdmission.gender as Gender, NewAdmission.dob as Date_of_Birth, NewAdmission.email as Email_ID, NewAdmission.semester as Semester, NewAdmission.prog as Programming_Language, NewAdmission.sname as School_Name, NewAdmission.duration as Duration, NewAdmission.address as Address, fees.fees as Fees from NewAdmission inner join fees on NewAdmission.NAID = fees.NAID";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        // search button
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MAMATA PATRA\source\repos\CollegeManagementSystem\CollegeManagementSystem\Database.mdf;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            //query
            cmd.CommandText = "select * from NewAdmission where NAID = '"+txtRegId.Text+"'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
