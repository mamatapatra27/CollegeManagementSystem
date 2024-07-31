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
    public partial class SearchTeacher : Form
    {
        public SearchTeacher()
        {
            InitializeComponent();
        }

        // load data when page load
        private void SearchTeacher_Load(object sender, EventArgs e)
        {
            // create Sql connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\Database.mdf;Integrated Security=True; Connect Timeout=60";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            //query
            cmd.CommandText = "Select * from teacher";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        // search button
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\Database.mdf;Integrated Security=True; Connect Timeout=60";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            //query
            if(txtRegId.Text != "")
            {
                cmd.CommandText = "select * from teacher where tID = '" + txtRegId.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Please enter Teacher Id", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
