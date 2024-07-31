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
    public partial class UpgradeSemester : Form
    {
        public UpgradeSemester()
        {
            InitializeComponent();
        }

        // Upgrade Button Click
        private void btnUpgrade_Click(object sender, EventArgs e)
        {
            if(comboBoxFrom.SelectedIndex > 0 && comboBoxTo.SelectedIndex > 0)
            {
            if(MessageBox.Show("Semester Update Warning !", "Confirm?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                // create Sql connection
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\Database.mdf;Integrated Security=True; Connect Timeout=60";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                //query for update
                cmd.CommandText = "update NewAdmission set semester = '" + comboBoxTo.Text + "' where semester = '" + comboBoxFrom.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // confirmation message
                MessageBox.Show("Upgrade Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Upgrade Cancelled", "Cancle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }
            else
            {
                MessageBox.Show("Please Select Semester to Upgrade", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
