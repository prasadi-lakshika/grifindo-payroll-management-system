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
    public partial class Form4 : Form
    {


        private int DRange;
        private decimal GovTax;
        public Form4()
        {
            InitializeComponent();
        }
        SqlDataAdapter SqlDa= new SqlDataAdapter();
        SqlCommand cmd=new SqlCommand();
SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-PCPS2U4;Initial Catalog=Grifindo;Integrated Security=True");

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                string queSel = "SELECT EmpID FROM Registration";
                conn.Open();
                SqlDa = new SqlDataAdapter(queSel, conn);
                DataTable DtR = new DataTable();
                SqlDa.Fill(DtR);

                if (DtR.Rows.Count>0)
                {
                    cmbEmpID.Items.Clear();
                    cmbEmpID.Items.Add("--SELECT--");
                    foreach (DataRow DR in DtR.Rows)
                    {
                        cmbEmpID.Items.Add(DR["EmpID"]);
                    }
                    cmbEmpID.SelectedIndex = 0;
                }

            }
            catch(Exception LoadRErr)
            {
                MessageBox.Show("Error while Loading from Registration..." + Environment.NewLine + LoadRErr.Message);
            }
            conn.Close();
            
            try
            {
                
                string queSet = "SELECT DRange,SCBeginDate,SCEndDate,GovRange FROM Setting";
                conn.Open();
                cmd = new SqlCommand(queSet, conn);
                SqlDataReader R = cmd.ExecuteReader();

                if(R.Read())
                {
                    DRange = R.GetInt32(0);
                    GovTax = R.GetDecimal(3) / 100;
                }

                conn.Close();



            }
            catch (Exception LoadSErr)
            {
                MessageBox.Show("Error while Loading from Setting..." + Environment.NewLine + LoadSErr.Message);
            }
            
            
                        
        }


        private void makanna()
        {
            cmbEmpID.SelectedIndex = 0;
            cmbMonth.SelectedIndex = 0;
            dtpBegDate.Text = "";
            dtpEndDate.Text = "";
            txtNoLeaves.Text = "";
            txtNoAbsent.Text = "";
            txtNoHoli.Text = "";
            txtOverTWH.Text = "";
            lblBasePay.Text = "";
            lblNoPay.Text = "";
            lblGrossPay.Text = "";
            lblMSal.Text = "";
            lblNoPay.Text = "";
            lblORate.Text = "";
        }

       
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult resEx = MessageBox.Show("Are you sure you want to Exit?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resEx == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbEmpID.SelectedIndex==0 || cmbMonth.SelectedIndex==0  || dtpBegDate.Text == "" || dtpEndDate.Text== "" || txtNoLeaves.Text == "" || txtNoAbsent.Text == "" || txtNoHoli.Text == "" || txtOverTWH.Text == "" || lblBasePay.Text== "" || lblNoPay.Text == "" ||  lblGrossPay.Text == "" )
                {
                    MessageBox.Show("All Fields must be filled!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    cmbEmpID.Focus();
                }
                else
                {
                    
                    String queReg = "INSERT INTO Salary(EmpID, EMonth,DRange, BeginDate,EndDate,NoOfLeaves,NoOfAbDays,NoOfHoliDays,OTWH,BasePay,NoPay,GrossPay) VALUES ('" + cmbEmpID.SelectedItem.ToString() + "','"+cmbMonth.SelectedItem.ToString()+"','"+txtDRange.Text+"','" + dtpBegDate.Text + "','" + dtpEndDate.Text + "','" + txtNoLeaves.Text + "','" + txtNoAbsent.Text+ "','" + txtNoHoli.Text + "','" + txtOverTWH.Text + "','" + lblBasePay.Text + "','" + lblNoPay.Text + "','" + lblGrossPay.Text + "')";
                    
                    conn.Open();
                    cmd = new SqlCommand(queReg, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("successfully save to the Database!", "Save Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    makanna();
                }
                conn.Close();
            }
            catch (Exception RegErr)
            {
                MessageBox.Show("Error while Register..." + Environment.NewLine + RegErr);
            }
        }
       

        

        
       

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            Form2 frmReg = new Form2();
            frmReg.Show();
            this.Hide();
        }

        private void btnCal_Click_1(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            
            try
            {
                decimal MSal = decimal.Parse(lblMSal.Text);
                decimal ORate = decimal.Parse(lblORate.Text);
                decimal Allowance = decimal.Parse(lblAllowance.Text);
                int NoOfAbsentDays = int.Parse(txtNoAbsent.Text);
                int NoOfOTHours = int.Parse(txtOverTWH.Text);
                

                //Calculate Base Pay
                decimal Basepay = MSal + Allowance + (ORate * NoOfOTHours);
                lblBasePay.Text = Basepay.ToString("0.00");


                //Calculate No-Pay Value
                decimal NoPayValue = (MSal / DRange) * NoOfAbsentDays;
                lblNoPay.Text = NoPayValue.ToString("0.00");


                //Calculate Gross Pay
                decimal GrossPay = Basepay - (NoPayValue + (Basepay * GovTax));
                lblGrossPay.Text = GrossPay.ToString("0.00");
            }
            catch(Exception CalErr)
            {
                MessageBox.Show("Error while Calculating..." + Environment.NewLine + CalErr.Message);
            }
        }

        private void cmbEmpID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbEmpID.SelectedIndex>0)
                {
                    String empNo = cmbEmpID.SelectedItem.ToString();
                    string queSelEmp = "SELECT MSal,ORate,Allowance FROM Registration WHERE EmpID='"+empNo+"'";
                    cmd = new SqlCommand(queSelEmp, conn);
                    //cmd.Parameters.AddWithValue("EmpID",cmbEmpID.SelectedItem.ToString());
                    conn.Open();
                    SqlDataReader R = cmd.ExecuteReader();
                    if (R.Read())
                    {
                        lblMSal.Text = R.GetValue(0).ToString();
                        lblORate.Text = R.GetValue(1).ToString();
                        lblAllowance.Text = R.GetValue(2).ToString();
                    }
                    conn.Close();
                }
            }

            catch(Exception EmpErr)
            {
                MessageBox.Show("Error while Loading Employee Data..." + Environment.NewLine + EmpErr.Message);
            }
        }

        private void btnCl_Click(object sender, EventArgs e)
        {
            makanna();
        }

        
    }
}
