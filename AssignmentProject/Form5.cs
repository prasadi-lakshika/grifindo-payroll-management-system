using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace AssignmentProject
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        SqlDataAdapter SqlDa = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-PCPS2U4;Initial Catalog=Grifindo;Integrated Security=True");
       
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult resEx = MessageBox.Show("Are you sure you want to Exit?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resEx == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void makanna()
        {
            txtDRange.Text="";
            dtpSCBeginD.Text="";
            dtpSCEndD.Text="";
            txtNLeaves.Text="";
            txtGovRange.Text="";

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string queUp = "UPDATE Setting SET DRange='" + txtDRange.Text + "',SCBeginDate='" + dtpSCBeginD.Value.ToString() +"',SCEndDate='" + dtpSCEndD.Value.ToString() + "',NLeaves='" + txtNLeaves.Text + "',GovRange='" + txtGovRange.Text + "'";

                conn.Open();
                cmd = new SqlCommand(queUp, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Settings are successfully updated!", "UPDATED!",MessageBoxButtons.OK, MessageBoxIcon.Information);
                makanna();
               

                }
            
            catch (Exception UpErr)
            {
                MessageBox.Show("Error while Save..." + Environment.NewLine + UpErr.Message);
            }
        }

        private void txtDRange_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form2 frmReg = new Form2();
            frmReg.Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            btnUp.Visible = false;
            string queData ="SELECT * FROM Setting";

            conn.Open();

            SqlDa = new SqlDataAdapter(queData, conn);
            DataTable DtR = new DataTable();
            SqlDa.Fill(DtR);
            conn.Close();


            if (DtR.Rows.Count >0)
            {
                string queGet = "SELECT * FROM Setting";
                conn.Open();
                cmd = new SqlCommand(queGet, conn);
                SqlDataReader R = cmd.ExecuteReader();


while (R.Read())
                {
                    txtDRange.Text = R.GetValue(1).ToString();
                    dtpSCBeginD.Value = DateTime.Parse(R.GetValue(2).ToString());
                    dtpSCEndD.Value = DateTime.Parse(R.GetValue(3).ToString());
                    txtNLeaves.Text = R.GetValue(4).ToString();
                    txtGovRange.Text = R.GetValue(5).ToString();
                }
                btnUp.Visible = true;
                btnSave.Visible = false;
                conn.Close();
            }

            else
            {
                btnSave.Visible = true;
            }


                    

                   

                    

                    
                    

                    

                   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDRange.Text==""|| dtpSCBeginD.Text==""||dtpSCEndD.Text==""||txtNLeaves.Text==""||txtGovRange.Text=="")
                {
                    MessageBox.Show("All Fields must be filled!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    makanna();
                    txtDRange.Focus();
                }
                else
                {
                   
                    
                    String queReg = "INSERT INTO Setting(DRange,SCBeginDate,SCEndDate,NLeaves,GovRange) VALUES ('" +txtDRange.Text + "','" + dtpSCBeginD.Value.ToString() + "','" +dtpSCEndD.Value.ToString() + "','" + txtNLeaves.Text + "','" + txtGovRange.Text + "')";
                    conn.Open();
                    cmd = new SqlCommand(queReg, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();


                    MessageBox.Show("settings are successfully save to the Database!", "Save Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    makanna();

                }
            }
            catch (Exception SaveErr)
            {
                MessageBox.Show("Error while Save..." + Environment.NewLine + SaveErr.Message);
            }
        }

    
    }
}
