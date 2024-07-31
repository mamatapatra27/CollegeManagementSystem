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
    public partial class RemoveStudent : Form
    {
        public RemoveStudent()
        {
            InitializeComponent();
        }

        private void RemoveStudent_Load(object sender, EventArgs e)
        {
            // create Sql connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\Database.mdf;Integrated Security=True; Connect Timeout=60";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            //query
            cmd.CommandText = "select * from NewAdmission";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
                if(txtRegId.Text != "")
                {
                if(MessageBox.Show("This will DELETE your Data", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)== DialogResult.OK)
                {

                // create Sql connection
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\Database.mdf;Integrated Security=True; Connect Timeout=60";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                //query
                cmd.CommandText = "delete from NewAdmission where NAID = " + txtRegId.Text + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                MessageBox.Show("Deletion Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please Enter Registration Id which want to DELETE", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
    }
}
