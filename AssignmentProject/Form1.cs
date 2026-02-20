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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string rName;
SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-PCPS2U4;Initial Catalog=Grifindo;Integrated Security=True");
        private void btnLog_Click(object sender, EventArgs e)
        {
            String un,pw;
            un=txtUN.Text;
            pw=txtPW.Text;

            if(un=="" || pw=="")
            {
                MessageBox.Show("Username or PAssword cannot be blank!","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtUN.Text="";
                txtPW.Text="";
                txtUN.Focus();
            }

            else
            {
                try
                {
                    string quelog="SELECT * FROM Login WHERE UserName='"+un+"' AND Password='"+pw+"'";

                    conn.Open();
                    SqlDataAdapter SqlDa=new SqlDataAdapter(quelog,conn);
                    DataTable Dt=new DataTable();
                    SqlDa.Fill(Dt);

                    if(Dt.Rows.Count>0)

                    {
                        SqlCommand cmd=new SqlCommand(quelog,conn);
                        SqlDataReader Rd=cmd.ExecuteReader();

                        if(Rd.Read())
                        {
                            rName=Rd.GetValue(2).ToString();
                        }

                        Form2 frm=new Form2();
                        frm.Show();
                        this.Hide();
                    }

                    else
                    {
                        MessageBox.Show("Incorrect UserName or Password!","Unauthorized access denied!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        txtUN.Text="";
                        txtPW.Text="";
                        txtUN.Focus();
                    }

                    conn.Close();
                }
                catch(Exception logErr)
                {
                    MessageBox.Show("Error While login..."+ Environment.NewLine+logErr.Message);
                }
            }

        }

        private void btnCl_Click(object sender, EventArgs e)
        {
            txtUN.Text = "";
            txtPW.Text = "";
            txtUN.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult resEx = MessageBox.Show("Are you sure you want to Exit?", "Confirm to Exit!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if(resEx==DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtUN_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPW_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
