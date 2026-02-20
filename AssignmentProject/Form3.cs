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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlDataAdapter SqlDa = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-PCPS2U4;Initial Catalog=Grifindo;Integrated Security=True");

        string gen, EID;
        private void AutoNumGen()
        {
            try
            {
                int Emp = 0;
                     
                conn.Open();
                String queFind = "SELECT EmpID FROM Registration";
                SqlDa = new SqlDataAdapter(queFind, conn);
                DataTable Dt = new DataTable();
                SqlDa.Fill(Dt);


                if (Dt.Rows.Count > 0)
                {
                    String queMax = "SELECT MAX(SerialNo) FROM Registration";
                    cmd = new SqlCommand(queMax, conn);
                    SqlDataReader R = cmd.ExecuteReader();

                    while (R.Read())
                    {
                        Emp = int.Parse(R.GetValue(0).ToString());
                    }
                    Emp += 1;
                }
                else
                {
                    Emp = 1;
                }

               
                conn.Close();

                if (Emp < 10) { EID = "G-000000" + Emp; }
                else if (Emp < 100) { EID = "G-00000" + Emp; }
                else if (Emp < 1000) { EID = "G-0000" + Emp; }
                else if (Emp < 10000) { EID = "G-000" + Emp; }
                else if (Emp < 100000) { EID = "G-00" + Emp; }
                else if (Emp < 1000000) { EID = "G-0" + Emp; }

                lblEmpID.Text = EID;
            }
            catch(Exception NumErr)
            {
                MessageBox.Show("Error While AutoNumGen..." + Environment.NewLine + NumErr.Message);

            }
        }
       

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cmbCS.SelectedIndex = 0;
            AutoNumGen();
            btnSExit.Visible = false;

        }

        

       

        private void button5_Click(object sender, EventArgs e)
        {
            makanna();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult resEx = MessageBox.Show("Are you sure you want to Exit?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resEx == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            
        }
        private void makanna()
        {
            cmbEmpID.Text = "";
            txtEmpName.Text = "";
            dtpDOB.Text = "";
            rbF.Checked=false;
            rbM.Checked=false;
            cmbCS.SelectedIndex=0;
            txtConNO.Text = "";
            txtNIC.Text = "";
            txtAdd.Text = "";
            txtEmail.Text = "";
            txtMonSal.Text = "";
            txtOverRate.Text = "";
            txtAllow.Text = "";
            btnReg.Visible = true;
            btnUp.Visible = false;
            btnDel.Visible = false;
            cmbEmpID.Visible = false;
            lblEmpID.Visible = true;
            AutoNumGen();




            
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblEmpID.Text==""|| txtEmpName.Text == "" || dtpDOB.Text == "" || gen == "" || cmbCS.SelectedIndex==0 || txtConNO.Text == "" || txtNIC.Text == "" || txtAdd.Text == "" || txtEmail.Text == "" || txtMonSal.Text == "" || txtOverRate.Text == "" || txtAllow.Text == "")
                {
                    MessageBox.Show("All Fields must be filled!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    makanna();
                    txtEmpName.Focus();
                }
                else
                {
                    if (rbM.Checked == true) { gen = "Male"; }
                    if (rbF.Checked == true) { gen = "Female";}

                   
                        String queReg = "INSERT INTO Registration(EmpID,EmpName,DOB,Gender,CS,ConNo,NIC,EAddress,Email,MSal, ORate,Allowance) VALUES ('"+lblEmpID.Text+"','" + txtEmpName.Text + "','" + dtpDOB.Text + "','" + gen + "','" + cmbCS.SelectedItem.ToString() + "','" + txtConNO.Text + "','" + txtNIC.Text + "','" + txtAdd.Text + "','" + txtEmail.Text + "','" + txtMonSal.Text.ToString() + "','" + txtOverRate.Text.ToString() + "','" + txtAllow.Text.ToString() + "')";
                        conn.Open();
                        cmd = new SqlCommand(queReg, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();


                        MessageBox.Show("Employee ID:" + EID + " successfully save to the Database!", "Save Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        makanna();
                    
                }
            }
            catch(Exception RegErr)
            {
                MessageBox.Show("Error while Register..." + Environment.NewLine + RegErr.Message);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbM.Checked == true) { gen = "Male"; }
                if (rbF.Checked == true) { gen = "Female"; }

                String queUp = "UPDATE Registration SET EmpName='" + txtEmpName.Text + "',DOB='" + dtpDOB.Text + "',Gender='" + gen + "',CS='" + cmbCS.SelectedItem.ToString() + "',ConNo='" + txtConNO.Text + "',NIC='" + txtNIC.Text + "',EAddress='" + txtAdd.Text + "',Email='" + txtEmail.Text + "',MSal='" + txtMonSal.Text + "',ORate='" + txtOverRate.Text + "',Allowance='" + txtAllow.Text + "' ";

                conn.Open();
                cmd = new SqlCommand(queUp, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Employee ID: " + cmbEmpID.SelectedItem.ToString() + "successfully updated!", "UPDATED!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                makanna();

            }
            catch (Exception UpErr)
            {
                MessageBox.Show("Error while Update..." + Environment.NewLine + UpErr.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                EID = cmbEmpID.SelectedItem.ToString();


                DialogResult resDel = MessageBox.Show("Are you sure you want to DELETE this record?", "CONFIRM TO DELETE!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resDel == DialogResult.Yes)
                {
                    string queDel = "DELETE FROM Registration WHERE EmpID='" + EID + "'";

                    conn.Open();
                    cmd = new SqlCommand(queDel, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Employee ID: " + EID + "successfully DELETE from the Database!", "DELETED!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    makanna();
                    
                }
                
            }
            catch(Exception DelErr)
            {
                {
                    MessageBox.Show("Error while Delete..." + Environment.NewLine + DelErr.Message);
                }

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string queGet = "SELECT EmpID FROM Registration";
                conn.Open();
                SqlDa = new SqlDataAdapter(queGet, conn);
                DataTable DtR = new DataTable();
                SqlDa.Fill(DtR);

                 if (DtR.Rows.Count>0)
                 {
                     cmbEmpID.Visible = true;
                     lblEmpID.Visible = false;
                     btnReg.Visible = false;
                     btnUp.Visible = true;
                     btnDel.Visible = true;
                     btnSExit.Visible = true;

                     cmbEmpID.Items.Clear();
                     cmbEmpID.Items.Add("--SELECT--");
                     foreach (DataRow DR in DtR.Rows)
                     {
                         cmbEmpID.Items.Add(DR["EmpID"]);
                     }
                     cmbEmpID.SelectedIndex = 0;
                 }

                else
                 {
                     MessageBox.Show("No Records in the Database!", "NO DATA!!!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                     makanna();
                 }

                 conn.Close();
            }
            catch(Exception SearchErr)
            {
                MessageBox.Show("Eror while search..." + Environment.NewLine + SearchErr.Message);
            }
        }

        private void cmbEmpID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbEmpID.SelectedIndex>0)
                {
                    EID = cmbEmpID.SelectedItem.ToString();
                    string queData ="SELECT * FROM Registration WHERE EmpID='"+EID+"'";

                    conn.Open();
                    cmd = new SqlCommand(queData, conn);
                    SqlDataReader R = cmd.ExecuteReader();

                    while (R.Read())
                    {
                        
                        cmbEmpID.Text = R.GetValue(1).ToString();
                        txtEmpName.Text = R.GetValue(2).ToString();
                        dtpDOB.Text = R.GetValue(3).ToString();
                        gen= R.GetValue(4).ToString();
                        cmbCS.Text = R.GetValue(5).ToString();
                        txtConNO.Text = R.GetValue(6).ToString();
                        txtNIC.Text = R.GetValue(7).ToString();
                        txtAdd.Text = R.GetValue(8).ToString();
                        txtEmail.Text = R.GetValue(9).ToString();
                        txtMonSal.Text = R.GetValue(10).ToString();
                        txtOverRate.Text = R.GetValue(11).ToString();
                        txtAllow.Text = R.GetValue(12).ToString();
                    }

                    if (gen.Equals("Male")) { rbM.Checked = true; }
                    else if (gen.Equals("Female")) { rbF.Checked = true; }

                    conn.Close();

                }


                else
                {
                    txtEmpName.Text = "";
                    dtpDOB.Text = "";
                    rbM.Checked = false;
                    rbF.Checked = false;
                    cmbCS.SelectedIndex = 0;
                    txtConNO.Text = "";
                    txtNIC.Text = "";
                    txtAdd.Text = "";
                    txtEmail.Text = "";
                    txtMonSal.Text = "";
                    txtOverRate.Text = "";
                    txtAllow.Text = "";

                }
            }
            catch (Exception SelErr)
            {
                MessageBox.Show("Error while Selecting..." + Environment.NewLine + SelErr);
            }
        }

        private void txtNIC_TextChanged(object sender, EventArgs e)
        {
            if (txtNIC.TextLength == 10 || txtNIC.TextLength == 12)
            {
                txtNIC.ForeColor = Color.Green;
            }
            else
            {
                txtNIC.ForeColor = Color.Red;
            }
        }

        private void txtConNO_TextChanged(object sender, EventArgs e)
        {
            if (txtConNO.TextLength < 10)
            {
                txtConNO.ForeColor = Color.Red;
            }
            else
            {
                txtConNO.ForeColor = Color.Green;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            cmbEmpID.Visible = false;
            btnReg.Visible = true;
            btnCl.Visible = true;
            makanna();
            btnSExit.Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form2 frmReg = new Form2();
            frmReg.Show();
            this.Hide();
        }
    }
}
