namespace TutorAppointment_New
{
    partial class StudentAccount
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
            this.dataGridViewSchedule = new System.Windows.Forms.DataGridView();
            this.DateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TutorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelScheduleHeader = new System.Windows.Forms.Panel();
            this.labelScheduleTitle = new System.Windows.Forms.Label();
            this.labelScheduleCount = new System.Windows.Forms.Label();
            this.panelWelcome = new System.Windows.Forms.Panel();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.labelClass = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonNewLesson = new System.Windows.Forms.Button();
            this.buttonMyTutors = new System.Windows.Forms.Button();
            this.buttonFavorites = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSchedule)).BeginInit();
            this.panelScheduleHeader.SuspendLayout();
            this.panelWelcome.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewSchedule
            // 
            this.dataGridViewSchedule.AllowUserToAddRows = false;
            this.dataGridViewSchedule.AllowUserToDeleteRows = false;
            this.dataGridViewSchedule.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSchedule.ColumnHeadersHeight = 30;
            this.dataGridViewSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateColumn,
            this.TimeColumn,
            this.SubjectColumn,
            this.TutorColumn,
            this.CommentColumn,
            this.StatusColumn});
            this.dataGridViewSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSchedule.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.dataGridViewSchedule.Location = new System.Drawing.Point(0, 130);
            this.dataGridViewSchedule.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewSchedule.MultiSelect = false;
            this.dataGridViewSchedule.Name = "dataGridViewSchedule";
            this.dataGridViewSchedule.ReadOnly = true;
            this.dataGridViewSchedule.RowHeadersVisible = false;
            this.dataGridViewSchedule.RowTemplate.Height = 30;
            this.dataGridViewSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSchedule.Size = new System.Drawing.Size(800, 241);
            this.dataGridViewSchedule.TabIndex = 4;
            // 
            // DateColumn
            // 
            this.DateColumn.HeaderText = "Дата";
            this.DateColumn.Name = "DateColumn";
            this.DateColumn.ReadOnly = true;
            // 
            // TimeColumn
            // 
            this.TimeColumn.HeaderText = "Время";
            this.TimeColumn.Name = "TimeColumn";
            this.TimeColumn.ReadOnly = true;
            this.TimeColumn.Width = 120;
            // 
            // SubjectColumn
            // 
            this.SubjectColumn.HeaderText = "Предмет";
            this.SubjectColumn.Name = "SubjectColumn";
            this.SubjectColumn.ReadOnly = true;
            this.SubjectColumn.Width = 120;
            // 
            // TutorColumn
            // 
            this.TutorColumn.HeaderText = "Преподаватель";
            this.TutorColumn.Name = "TutorColumn";
            this.TutorColumn.ReadOnly = true;
            this.TutorColumn.Width = 150;
            // 
            // CommentColumn
            // 
            this.CommentColumn.HeaderText = "Комментарий";
            this.CommentColumn.Name = "CommentColumn";
            this.CommentColumn.ReadOnly = true;
            this.CommentColumn.Width = 200;
            // 
            // StatusColumn
            // 
            this.StatusColumn.HeaderText = "Статус";
            this.StatusColumn.Name = "StatusColumn";
            this.StatusColumn.ReadOnly = true;
            // 
            // panelScheduleHeader
            // 
            this.panelScheduleHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelScheduleHeader.Controls.Add(this.labelScheduleTitle);
            this.panelScheduleHeader.Controls.Add(this.labelScheduleCount);
            this.panelScheduleHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelScheduleHeader.Location = new System.Drawing.Point(0, 98);
            this.panelScheduleHeader.Margin = new System.Windows.Forms.Padding(2);
            this.panelScheduleHeader.Name = "panelScheduleHeader";
            this.panelScheduleHeader.Size = new System.Drawing.Size(800, 32);
            this.panelScheduleHeader.TabIndex = 5;
            // 
            // labelScheduleTitle
            // 
            this.labelScheduleTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelScheduleTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.labelScheduleTitle.Location = new System.Drawing.Point(15, 6);
            this.labelScheduleTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelScheduleTitle.Name = "labelScheduleTitle";
            this.labelScheduleTitle.Size = new System.Drawing.Size(150, 20);
            this.labelScheduleTitle.TabIndex = 0;
            this.labelScheduleTitle.Text = "📅 МОЁ РАСПИСАНИЕ";
            // 
            // labelScheduleCount
            // 
            this.labelScheduleCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelScheduleCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.labelScheduleCount.Location = new System.Drawing.Point(562, 8);
            this.labelScheduleCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelScheduleCount.Name = "labelScheduleCount";
            this.labelScheduleCount.Size = new System.Drawing.Size(90, 16);
            this.labelScheduleCount.TabIndex = 1;
            this.labelScheduleCount.Text = "Всего занятий: 5";
            this.labelScheduleCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelWelcome
            // 
            this.panelWelcome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.panelWelcome.Controls.Add(this.labelWelcome);
            this.panelWelcome.Controls.Add(this.labelClass);
            this.panelWelcome.Controls.Add(this.labelPhone);
            this.panelWelcome.Controls.Add(this.labelEmail);
            this.panelWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWelcome.Location = new System.Drawing.Point(0, 0);
            this.panelWelcome.Margin = new System.Windows.Forms.Padding(2);
            this.panelWelcome.Name = "panelWelcome";
            this.panelWelcome.Size = new System.Drawing.Size(800, 98);
            this.panelWelcome.TabIndex = 7;
            // 
            // labelWelcome
            // 
            this.labelWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.labelWelcome.Location = new System.Drawing.Point(15, 16);
            this.labelWelcome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(450, 24);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Добро пожаловать, Иванов Иван!";
            // 
            // labelClass
            // 
            this.labelClass.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.labelClass.Location = new System.Drawing.Point(15, 45);
            this.labelClass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(150, 20);
            this.labelClass.TabIndex = 1;
            this.labelClass.Text = "Класс: 10А";
            // 
            // labelPhone
            // 
            this.labelPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.labelPhone.Location = new System.Drawing.Point(15, 65);
            this.labelPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(188, 16);
            this.labelPhone.TabIndex = 2;
            this.labelPhone.Text = "Телефон: +7 (999) 123-45-67";
            // 
            // labelEmail
            // 
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.labelEmail.Location = new System.Drawing.Point(210, 65);
            this.labelEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(188, 16);
            this.labelEmail.TabIndex = 3;
            this.labelEmail.Text = "Email: ivanov@mail.ru";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelButtons.Controls.Add(this.buttonNewLesson);
            this.panelButtons.Controls.Add(this.buttonMyTutors);
            this.panelButtons.Controls.Add(this.buttonFavorites);
            this.panelButtons.Controls.Add(this.buttonLogout);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 371);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(2);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(800, 57);
            this.panelButtons.TabIndex = 8;
            // 
            // buttonNewLesson
            // 
            this.buttonNewLesson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.buttonNewLesson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNewLesson.FlatAppearance.BorderSize = 0;
            this.buttonNewLesson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewLesson.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.buttonNewLesson.ForeColor = System.Drawing.Color.White;
            this.buttonNewLesson.Location = new System.Drawing.Point(15, 12);
            this.buttonNewLesson.Margin = new System.Windows.Forms.Padding(2);
            this.buttonNewLesson.Name = "buttonNewLesson";
            this.buttonNewLesson.Size = new System.Drawing.Size(165, 32);
            this.buttonNewLesson.TabIndex = 0;
            this.buttonNewLesson.Text = "📝 Записаться на новый урок";
            this.buttonNewLesson.UseVisualStyleBackColor = false;
            this.buttonNewLesson.Click += new System.EventHandler(this.buttonNewLesson_Click);
            // 
            // buttonMyTutors
            // 
            this.buttonMyTutors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.buttonMyTutors.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMyTutors.FlatAppearance.BorderSize = 0;
            this.buttonMyTutors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMyTutors.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.buttonMyTutors.ForeColor = System.Drawing.Color.White;
            this.buttonMyTutors.Location = new System.Drawing.Point(195, 12);
            this.buttonMyTutors.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMyTutors.Name = "buttonMyTutors";
            this.buttonMyTutors.Size = new System.Drawing.Size(112, 32);
            this.buttonMyTutors.TabIndex = 1;
            this.buttonMyTutors.Text = "⭐ Мои учителя";
            this.buttonMyTutors.UseVisualStyleBackColor = false;
            this.buttonMyTutors.Click += new System.EventHandler(this.buttonMyTutors_Click);
            // 
            // buttonFavorites
            // 
            this.buttonFavorites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.buttonFavorites.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFavorites.FlatAppearance.BorderSize = 0;
            this.buttonFavorites.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFavorites.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.buttonFavorites.ForeColor = System.Drawing.Color.White;
            this.buttonFavorites.Location = new System.Drawing.Point(322, 12);
            this.buttonFavorites.Margin = new System.Windows.Forms.Padding(2);
            this.buttonFavorites.Name = "buttonFavorites";
            this.buttonFavorites.Size = new System.Drawing.Size(112, 32);
            this.buttonFavorites.TabIndex = 2;
            this.buttonFavorites.Text = "❤️ Избранное";
            this.buttonFavorites.UseVisualStyleBackColor = false;
            this.buttonFavorites.Click += new System.EventHandler(this.buttonFavorites_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.buttonLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLogout.FlatAppearance.BorderSize = 0;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.buttonLogout.ForeColor = System.Drawing.Color.White;
            this.buttonLogout.Location = new System.Drawing.Point(562, 12);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(90, 32);
            this.buttonLogout.TabIndex = 3;
            this.buttonLogout.Text = "🚪 Выйти";
            this.buttonLogout.UseVisualStyleBackColor = false;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 428);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(88, 17);
            this.statusLabel.Text = "Готов к работе";
            // 
            // StudentAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewSchedule);
            this.Controls.Add(this.panelScheduleHeader);
            this.Controls.Add(this.panelWelcome);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.statusStrip);
            this.Name = "StudentAccount";
            this.Text = "StudentAccount";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSchedule)).EndInit();
            this.panelScheduleHeader.ResumeLayout(false);
            this.panelWelcome.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TutorColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommentColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusColumn;
        private System.Windows.Forms.Panel panelScheduleHeader;
        private System.Windows.Forms.Label labelScheduleTitle;
        private System.Windows.Forms.Label labelScheduleCount;
        private System.Windows.Forms.Panel panelWelcome;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label labelClass;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonNewLesson;
        private System.Windows.Forms.Button buttonMyTutors;
        private System.Windows.Forms.Button buttonFavorites;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}