using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssignmentProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

       

        private void Form2_Load(object sender, EventArgs e)
        {
            lblDis.Text = "Welcome to Grifindo Toy Strore, " + Form1.rName + "!";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult resEx = MessageBox.Show("Are you sure you want to Exit?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resEx == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void mExit_Click(object sender, EventArgs e)
        {
            DialogResult resEx = MessageBox.Show("Are you sure you want to Exit?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resEx == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void mLogout_Click(object sender, EventArgs e)
        {
            Form1 frmLog = new Form1();
            frmLog.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 frmLog = new Form1();
            frmLog.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lblDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frmReg = new Form3();
            frmReg.Show();
            this.Hide();
        }

        private void salaryCalculationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 frmSal = new Form4();
            frmSal.Show();
            this.Hide();
        }

        private void mSet_Click(object sender, EventArgs e)
        {
            Form5 frmSet = new Form5();
            frmSet.Show();
            this.Hide();
        }

        private void lblDis_Click(object sender, EventArgs e)
        {

        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        

        

        

        

        

        
    }
}
