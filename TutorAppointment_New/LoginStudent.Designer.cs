namespace TutorAppointment_New
{
    partial class LoginStudents
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
            this.Back = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonReg = new System.Windows.Forms.Button();
            this.buttonSignIn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Login = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.Transparent;
            this.Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Back.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Back.Location = new System.Drawing.Point(281, 354);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(76, 39);
            this.Back.TabIndex = 10;
            this.Back.Text = "Назад";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.groupBox1.Controls.Add(this.buttonReg);
            this.groupBox1.Controls.Add(this.buttonSignIn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Login);
            this.groupBox1.Controls.Add(this.Password);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(281, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 290);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // buttonReg
            // 
            this.buttonReg.BackColor = System.Drawing.Color.Transparent;
            this.buttonReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReg.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonReg.Location = new System.Drawing.Point(32, 233);
            this.buttonReg.Name = "buttonReg";
            this.buttonReg.Size = new System.Drawing.Size(135, 39);
            this.buttonReg.TabIndex = 7;
            this.buttonReg.Text = "Регистрация";
            this.buttonReg.UseVisualStyleBackColor = false;
            this.buttonReg.Click += new System.EventHandler(this.buttonReg_Click_1);
            // 
            // buttonSignIn
            // 
            this.buttonSignIn.BackColor = System.Drawing.Color.Transparent;
            this.buttonSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSignIn.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSignIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSignIn.Location = new System.Drawing.Point(32, 188);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(135, 39);
            this.buttonSignIn.TabIndex = 5;
            this.buttonSignIn.Text = "Войти";
            this.buttonSignIn.UseVisualStyleBackColor = false;
            this.buttonSignIn.Click += new System.EventHandler(this.buttonSignIn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(16, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Авторизация студента";
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(32, 92);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(135, 20);
            this.Login.TabIndex = 1;
            //this.Login.TextChanged += new System.EventHandler(this.Login_TextChanged_1);
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(32, 146);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(135, 20);
            this.Password.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(27, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(27, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Пароль";
            // 
            // LoginStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TutorAppointment_New.Properties.Resources.фон;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.groupBox1);
            this.Name = "LoginStudents";
            this.Text = "LoginStudent";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonReg;
        private System.Windows.Forms.Button buttonSignIn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Login;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}