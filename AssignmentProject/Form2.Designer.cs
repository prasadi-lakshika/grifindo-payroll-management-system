namespace AssignmentProject
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mReg = new System.Windows.Forms.ToolStripMenuItem();
            this.muReg = new System.Windows.Forms.ToolStripMenuItem();
            this.mSal = new System.Windows.Forms.ToolStripMenuItem();
            this.salaryCalculationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSet = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDis = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mReg,
            this.mSal,
            this.mSet});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(957, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mReg
            // 
            this.mReg.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.muReg});
            this.mReg.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mReg.Name = "mReg";
            this.mReg.Size = new System.Drawing.Size(90, 25);
            this.mReg.Text = "Employee";
            // 
            // muReg
            // 
            this.muReg.Name = "muReg";
            this.muReg.Size = new System.Drawing.Size(142, 26);
            this.muReg.Text = "Register";
            this.muReg.Click += new System.EventHandler(this.registerToolStripMenuItem_Click);
            // 
            // mSal
            // 
            this.mSal.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salaryCalculationToolStripMenuItem});
            this.mSal.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mSal.Name = "mSal";
            this.mSal.Size = new System.Drawing.Size(64, 25);
            this.mSal.Text = "Salary";
            // 
            // salaryCalculationToolStripMenuItem
            // 
            this.salaryCalculationToolStripMenuItem.Name = "salaryCalculationToolStripMenuItem";
            this.salaryCalculationToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.salaryCalculationToolStripMenuItem.Text = "Salary Calculation";
            this.salaryCalculationToolStripMenuItem.Click += new System.EventHandler(this.salaryCalculationToolStripMenuItem_Click);
            // 
            // mSet
            // 
            this.mSet.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mSet.Name = "mSet";
            this.mSet.Size = new System.Drawing.Size(70, 25);
            this.mSet.Text = "Setting";
            this.mSet.Click += new System.EventHandler(this.mSet_Click);
            // 
            // lblDis
            // 
            this.lblDis.AutoSize = true;
            this.lblDis.BackColor = System.Drawing.Color.Transparent;
            this.lblDis.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDis.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblDis.Location = new System.Drawing.Point(29, 77);
            this.lblDis.Name = "lblDis";
            this.lblDis.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDis.Size = new System.Drawing.Size(86, 35);
            this.lblDis.TabIndex = 1;
            this.lblDis.Text = "label1";
            this.lblDis.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.lblDis.Click += new System.EventHandler(this.lblDis_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(100, 448);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(86, 35);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "label2";
            this.lblTime.Click += new System.EventHandler(this.lblTime_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(100, 511);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(74, 29);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "label3";
            this.lblDate.Click += new System.EventHandler(this.lblDate_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Location = new System.Drawing.Point(822, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 522);
            this.panel1.TabIndex = 4;
            // 
            // btnLogout
            // 
            this.btnLogout.BackgroundImage = global::AssignmentProject.Properties.Resources.logout_icon;
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(43, 465);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(51, 47);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::AssignmentProject.Properties.Resources.Actions_dialog_close_icon;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(43, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(51, 49);
            this.btnExit.TabIndex = 4;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::AssignmentProject.Properties.Resources.Brown_Simple_Round_Badge_Coffee_Shop_Logo_modified__1_1;
            this.pictureBox1.Location = new System.Drawing.Point(35, 141);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AssignmentProject.Properties.Resources.background_gradient_pink_design_vector_48874488;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(957, 589);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblDis);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mReg;
        private System.Windows.Forms.ToolStripMenuItem muReg;
        private System.Windows.Forms.ToolStripMenuItem mSal;
        private System.Windows.Forms.ToolStripMenuItem mSet;
        private System.Windows.Forms.Label lblDis;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ToolStripMenuItem salaryCalculationToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
    }
}