namespace AssemblyViewerV2
{
    partial class Form_Settings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Button_Save = new System.Windows.Forms.Button();
            this.Button_Close = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.TextBox_SQLHost = new System.Windows.Forms.TextBox();
            this.TextBox_SQLPort = new System.Windows.Forms.TextBox();
            this.TextBox_SQLDatabase = new System.Windows.Forms.TextBox();
            this.TextBox_SQLUsername = new System.Windows.Forms.TextBox();
            this.TextBox_SQLPassword = new System.Windows.Forms.TextBox();
            this.TextBox_OpenAI_URL = new System.Windows.Forms.TextBox();
            this.TextBox_OpenAI_Model = new System.Windows.Forms.TextBox();
            this.Button_TestDB = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.TextBox_OpenAI_APIKey = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 251);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки БД";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Location = new System.Drawing.Point(12, 269);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(426, 173);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "OpenAI Провайдер";
            // 
            // Button_Save
            // 
            this.Button_Save.Location = new System.Drawing.Point(211, 448);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(146, 23);
            this.Button_Save.TabIndex = 2;
            this.Button_Save.Text = "Сохранить изменения";
            this.Button_Save.UseVisualStyleBackColor = true;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // Button_Close
            // 
            this.Button_Close.Location = new System.Drawing.Point(363, 448);
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.Size = new System.Drawing.Size(75, 23);
            this.Button_Close.TabIndex = 3;
            this.Button_Close.Text = "Отмена";
            this.Button_Close.UseVisualStyleBackColor = true;
            this.Button_Close.Click += new System.EventHandler(this.Button_Close_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox7, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(420, 232);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TextBox_SQLHost);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(414, 40);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SQL_Host";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TextBox_SQLPort);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 49);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(414, 40);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "SQL_Port";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.TextBox_SQLDatabase);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 95);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(414, 40);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "SQL_Database";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.TextBox_SQLUsername);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(3, 141);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(414, 40);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "SQL_Username";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.Button_TestDB);
            this.groupBox7.Controls.Add(this.TextBox_SQLPassword);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(3, 187);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(414, 42);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "SQL_Password";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox8, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox9, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox10, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(420, 154);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.TextBox_OpenAI_URL);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(3, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(414, 45);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "OpenAI_URL";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.TextBox_OpenAI_Model);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox9.Location = new System.Drawing.Point(3, 54);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(414, 45);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "OpenAI_Model";
            // 
            // TextBox_SQLHost
            // 
            this.TextBox_SQLHost.Location = new System.Drawing.Point(6, 19);
            this.TextBox_SQLHost.Name = "TextBox_SQLHost";
            this.TextBox_SQLHost.Size = new System.Drawing.Size(402, 20);
            this.TextBox_SQLHost.TabIndex = 0;
            // 
            // TextBox_SQLPort
            // 
            this.TextBox_SQLPort.Location = new System.Drawing.Point(7, 19);
            this.TextBox_SQLPort.Name = "TextBox_SQLPort";
            this.TextBox_SQLPort.Size = new System.Drawing.Size(401, 20);
            this.TextBox_SQLPort.TabIndex = 0;
            // 
            // TextBox_SQLDatabase
            // 
            this.TextBox_SQLDatabase.Location = new System.Drawing.Point(7, 19);
            this.TextBox_SQLDatabase.Name = "TextBox_SQLDatabase";
            this.TextBox_SQLDatabase.Size = new System.Drawing.Size(401, 20);
            this.TextBox_SQLDatabase.TabIndex = 0;
            // 
            // TextBox_SQLUsername
            // 
            this.TextBox_SQLUsername.Location = new System.Drawing.Point(6, 19);
            this.TextBox_SQLUsername.Name = "TextBox_SQLUsername";
            this.TextBox_SQLUsername.Size = new System.Drawing.Size(401, 20);
            this.TextBox_SQLUsername.TabIndex = 0;
            // 
            // TextBox_SQLPassword
            // 
            this.TextBox_SQLPassword.Location = new System.Drawing.Point(7, 20);
            this.TextBox_SQLPassword.Name = "TextBox_SQLPassword";
            this.TextBox_SQLPassword.Size = new System.Drawing.Size(289, 20);
            this.TextBox_SQLPassword.TabIndex = 0;
            // 
            // TextBox_OpenAI_URL
            // 
            this.TextBox_OpenAI_URL.Location = new System.Drawing.Point(7, 19);
            this.TextBox_OpenAI_URL.Name = "TextBox_OpenAI_URL";
            this.TextBox_OpenAI_URL.Size = new System.Drawing.Size(400, 20);
            this.TextBox_OpenAI_URL.TabIndex = 0;
            // 
            // TextBox_OpenAI_Model
            // 
            this.TextBox_OpenAI_Model.Location = new System.Drawing.Point(7, 20);
            this.TextBox_OpenAI_Model.Name = "TextBox_OpenAI_Model";
            this.TextBox_OpenAI_Model.Size = new System.Drawing.Size(401, 20);
            this.TextBox_OpenAI_Model.TabIndex = 0;
            // 
            // Button_TestDB
            // 
            this.Button_TestDB.Location = new System.Drawing.Point(302, 17);
            this.Button_TestDB.Name = "Button_TestDB";
            this.Button_TestDB.Size = new System.Drawing.Size(105, 23);
            this.Button_TestDB.TabIndex = 4;
            this.Button_TestDB.Text = "Тест соединения";
            this.Button_TestDB.UseVisualStyleBackColor = true;
            this.Button_TestDB.Click += new System.EventHandler(this.Button_TestDB_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.TextBox_OpenAI_APIKey);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox10.Location = new System.Drawing.Point(3, 105);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(414, 46);
            this.groupBox10.TabIndex = 2;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "OpenAI_API_KEY";
            // 
            // TextBox_OpenAI_APIKey
            // 
            this.TextBox_OpenAI_APIKey.Location = new System.Drawing.Point(7, 20);
            this.TextBox_OpenAI_APIKey.Name = "TextBox_OpenAI_APIKey";
            this.TextBox_OpenAI_APIKey.Size = new System.Drawing.Size(400, 20);
            this.TextBox_OpenAI_APIKey.TabIndex = 0;
            // 
            // Form_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 483);
            this.Controls.Add(this.Button_Close);
            this.Controls.Add(this.Button_Save);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_Settings";
            this.Text = "Настройки программы";
            this.Load += new System.EventHandler(this.Form_Settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TextBox_SQLHost;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox TextBox_SQLPort;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox TextBox_SQLDatabase;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button Button_Save;
        private System.Windows.Forms.Button Button_Close;
        private System.Windows.Forms.TextBox TextBox_SQLUsername;
        private System.Windows.Forms.TextBox TextBox_SQLPassword;
        private System.Windows.Forms.TextBox TextBox_OpenAI_URL;
        private System.Windows.Forms.TextBox TextBox_OpenAI_Model;
        private System.Windows.Forms.Button Button_TestDB;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TextBox TextBox_OpenAI_APIKey;
    }
}