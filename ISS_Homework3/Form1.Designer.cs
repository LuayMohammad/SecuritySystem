namespace ISS_Homework3
{
    partial class Form1
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
            this.grid_users = new System.Windows.Forms.DataGridView();
            this.user_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Classification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.classes = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acl6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acl1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acl2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acl3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acl4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acl5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.state = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ACL = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.CheckBox();
            this.modify = new System.Windows.Forms.CheckBox();
            this.execute = new System.Windows.Forms.CheckBox();
            this.write = new System.Windows.Forms.CheckBox();
            this.read = new System.Windows.Forms.CheckBox();
            this.full = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid_users)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classes)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid_users
            // 
            this.grid_users.AllowUserToAddRows = false;
            this.grid_users.AllowUserToDeleteRows = false;
            this.grid_users.AllowUserToResizeColumns = false;
            this.grid_users.AllowUserToResizeRows = false;
            this.grid_users.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grid_users.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid_users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_users.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.user_id,
            this.domain,
            this.USER_NAME,
            this.Classification});
            this.grid_users.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.grid_users.Location = new System.Drawing.Point(7, 17);
            this.grid_users.MultiSelect = false;
            this.grid_users.Name = "grid_users";
            this.grid_users.ReadOnly = true;
            this.grid_users.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid_users.RowHeadersVisible = false;
            this.grid_users.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_users.Size = new System.Drawing.Size(328, 150);
            this.grid_users.TabIndex = 0;
            // 
            // user_id
            // 
            this.user_id.HeaderText = "id";
            this.user_id.Name = "user_id";
            this.user_id.ReadOnly = true;
            this.user_id.Visible = false;
            // 
            // domain
            // 
            this.domain.FillWeight = 75F;
            this.domain.HeaderText = "Domain \\";
            this.domain.Name = "domain";
            this.domain.ReadOnly = true;
            this.domain.Width = 75;
            // 
            // USER_NAME
            // 
            this.USER_NAME.FillWeight = 90F;
            this.USER_NAME.HeaderText = "USER NAME";
            this.USER_NAME.Name = "USER_NAME";
            this.USER_NAME.ReadOnly = true;
            this.USER_NAME.Width = 90;
            // 
            // Classification
            // 
            this.Classification.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Classification.HeaderText = "Classification";
            this.Classification.Name = "Classification";
            this.Classification.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Security classifications :";
            // 
            // classes
            // 
            this.classes.AllowUserToAddRows = false;
            this.classes.AllowUserToDeleteRows = false;
            this.classes.AllowUserToResizeColumns = false;
            this.classes.AllowUserToResizeRows = false;
            this.classes.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.classes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.classes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.classes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.dataGridViewTextBoxColumn1,
            this.P_id,
            this.acl6,
            this.acl1,
            this.acl2,
            this.acl3,
            this.acl4,
            this.acl5});
            this.classes.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.classes.Location = new System.Drawing.Point(17, 298);
            this.classes.MultiSelect = false;
            this.classes.Name = "classes";
            this.classes.ReadOnly = true;
            this.classes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.classes.RowHeadersVisible = false;
            this.classes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.classes.Size = new System.Drawing.Size(249, 150);
            this.classes.TabIndex = 4;
            this.classes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.classes_CellClick);
            // 
            // id
            // 
            this.id.FillWeight = 25F;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 25;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.FillWeight = 140F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Classification Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // P_id
            // 
            this.P_id.FillWeight = 60F;
            this.P_id.HeaderText = "parent ID";
            this.P_id.Name = "P_id";
            this.P_id.ReadOnly = true;
            this.P_id.Width = 60;
            // 
            // acl6
            // 
            this.acl6.HeaderText = "fullcontrol";
            this.acl6.Name = "acl6";
            this.acl6.ReadOnly = true;
            this.acl6.Visible = false;
            // 
            // acl1
            // 
            this.acl1.HeaderText = "read";
            this.acl1.Name = "acl1";
            this.acl1.ReadOnly = true;
            this.acl1.Visible = false;
            // 
            // acl2
            // 
            this.acl2.HeaderText = "write";
            this.acl2.Name = "acl2";
            this.acl2.ReadOnly = true;
            this.acl2.Visible = false;
            // 
            // acl3
            // 
            this.acl3.HeaderText = "execute";
            this.acl3.Name = "acl3";
            this.acl3.ReadOnly = true;
            this.acl3.Visible = false;
            // 
            // acl4
            // 
            this.acl4.HeaderText = "modify";
            this.acl4.Name = "acl4";
            this.acl4.ReadOnly = true;
            this.acl4.Visible = false;
            // 
            // acl5
            // 
            this.acl5.HeaderText = "delete";
            this.acl5.Name = "acl5";
            this.acl5.ReadOnly = true;
            this.acl5.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(357, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Assign USER to Classification";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(357, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(164, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "ADD NEW Classification";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(187, 38);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(164, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Assign FILE to Classification";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(527, 38);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(164, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Generate MAC ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(527, 67);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(164, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "View File Log";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 94);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(221, 20);
            this.textBox1.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(11, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Enter Classifications Name :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "New Security Classifications :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(10, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Select Parent Classification From Table";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(76, 121);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 14;
            this.button6.Text = "save";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(528, 298);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 150);
            this.panel1.TabIndex = 15;
            this.panel1.Visible = false;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(13, 49);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(221, 21);
            this.comboBox2.TabIndex = 18;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(357, 67);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(164, 23);
            this.button7.TabIndex = 16;
            this.button7.Text = "Delete USER\'s Classification";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 462);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "STATUS :";
            // 
            // state
            // 
            this.state.AutoSize = true;
            this.state.ForeColor = System.Drawing.Color.Purple;
            this.state.Location = new System.Drawing.Point(60, 462);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(0, 13);
            this.state.TabIndex = 17;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(17, 9);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(164, 23);
            this.button8.TabIndex = 6;
            this.button8.Text = "IMPORT Windows Local Users";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(17, 67);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(164, 23);
            this.button9.TabIndex = 9;
            this.button9.Text = "Manage Users ";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(17, 38);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(164, 23);
            this.button10.TabIndex = 8;
            this.button10.Text = "ALL System Users ";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.button12);
            this.panel2.Controls.Add(this.button11);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(527, 297);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 150);
            this.panel2.TabIndex = 16;
            this.panel2.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(10, 49);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(221, 21);
            this.comboBox1.TabIndex = 19;
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Red;
            this.button12.Location = new System.Drawing.Point(157, 123);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(74, 23);
            this.button12.TabIndex = 18;
            this.button12.Text = "Delete Level";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(13, 123);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 14;
            this.button11.Text = "Edit";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Green;
            this.label7.Location = new System.Drawing.Point(9, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "2- Classifications New Name :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Green;
            this.label8.Location = new System.Drawing.Point(8, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(229, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "1- Select New Parent Classification From Table";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(10, 97);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(221, 20);
            this.textBox2.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Edit Security Classifications :";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.grid_users);
            this.panel3.Location = new System.Drawing.Point(17, 96);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(350, 174);
            this.panel3.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "System users :";
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(187, 9);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(164, 23);
            this.button13.TabIndex = 19;
            this.button13.Text = "Make User Admin";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(527, 9);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(164, 23);
            this.button14.TabIndex = 20;
            this.button14.Text = "Edit OLD Classification";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(187, 67);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(164, 23);
            this.button15.TabIndex = 21;
            this.button15.Text = "Load FILEs ";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ACL);
            this.panel4.Controls.Add(this.delete);
            this.panel4.Controls.Add(this.modify);
            this.panel4.Controls.Add(this.execute);
            this.panel4.Controls.Add(this.write);
            this.panel4.Controls.Add(this.read);
            this.panel4.Controls.Add(this.full);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(281, 296);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(218, 158);
            this.panel4.TabIndex = 22;
            this.panel4.Visible = false;
            // 
            // ACL
            // 
            this.ACL.Location = new System.Drawing.Point(129, 73);
            this.ACL.Name = "ACL";
            this.ACL.Size = new System.Drawing.Size(75, 23);
            this.ACL.TabIndex = 30;
            this.ACL.Text = "Save";
            this.ACL.UseVisualStyleBackColor = true;
            this.ACL.Click += new System.EventHandler(this.ACL_Click);
            // 
            // delete
            // 
            this.delete.AutoSize = true;
            this.delete.Location = new System.Drawing.Point(6, 137);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(57, 17);
            this.delete.TabIndex = 29;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            // 
            // modify
            // 
            this.modify.AutoSize = true;
            this.modify.Location = new System.Drawing.Point(6, 114);
            this.modify.Name = "modify";
            this.modify.Size = new System.Drawing.Size(58, 17);
            this.modify.TabIndex = 28;
            this.modify.Text = "Modify";
            this.modify.UseVisualStyleBackColor = true;
            // 
            // execute
            // 
            this.execute.AutoSize = true;
            this.execute.Location = new System.Drawing.Point(6, 91);
            this.execute.Name = "execute";
            this.execute.Size = new System.Drawing.Size(65, 17);
            this.execute.TabIndex = 27;
            this.execute.Text = "Execute";
            this.execute.UseVisualStyleBackColor = true;
            // 
            // write
            // 
            this.write.AutoSize = true;
            this.write.Location = new System.Drawing.Point(6, 68);
            this.write.Name = "write";
            this.write.Size = new System.Drawing.Size(52, 17);
            this.write.TabIndex = 26;
            this.write.Text = "Write";
            this.write.UseVisualStyleBackColor = true;
            // 
            // read
            // 
            this.read.AutoSize = true;
            this.read.Location = new System.Drawing.Point(6, 45);
            this.read.Name = "read";
            this.read.Size = new System.Drawing.Size(51, 17);
            this.read.TabIndex = 25;
            this.read.Text = "Read";
            this.read.UseVisualStyleBackColor = true;
            // 
            // full
            // 
            this.full.AutoSize = true;
            this.full.Location = new System.Drawing.Point(6, 23);
            this.full.Name = "full";
            this.full.Size = new System.Drawing.Size(80, 17);
            this.full.TabIndex = 24;
            this.full.Text = "Full Control";
            this.full.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Security classification ACL:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(373, 113);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(394, 157);
            this.textBox3.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Enabled = false;
            this.label11.Location = new System.Drawing.Point(373, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Log File :";
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(698, 10);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(75, 20);
            this.button16.TabIndex = 24;
            this.button16.Text = "Save MAC";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(698, 38);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(75, 20);
            this.button17.TabIndex = 25;
            this.button17.Text = "Verify MAC";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 486);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.state);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.classes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.grid_users)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid_users;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView classes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn domain;
        private System.Windows.Forms.DataGridViewTextBoxColumn USER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn Classification;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label state;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox delete;
        private System.Windows.Forms.CheckBox modify;
        private System.Windows.Forms.CheckBox execute;
        private System.Windows.Forms.CheckBox write;
        private System.Windows.Forms.CheckBox read;
        private System.Windows.Forms.CheckBox full;
        private System.Windows.Forms.Button ACL;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn acl6;
        private System.Windows.Forms.DataGridViewTextBoxColumn acl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn acl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn acl3;
        private System.Windows.Forms.DataGridViewTextBoxColumn acl4;
        private System.Windows.Forms.DataGridViewTextBoxColumn acl5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
    }
}

