namespace TutorAppointment_New
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewBookings = new System.Windows.Forms.DataGridView();
            this.ColumnBookingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTutor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStudent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.panelWelcome = new System.Windows.Forms.Panel();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.labelRole = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBookings)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelWelcome.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewBookings
            // 
            this.dataGridViewBookings.AllowUserToAddRows = false;
            this.dataGridViewBookings.AllowUserToDeleteRows = false;
            this.dataGridViewBookings.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewBookings.ColumnHeadersHeight = 35;
            this.dataGridViewBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewBookings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnBookingId,
            this.ColumnDate,
            this.ColumnStartTime,
            this.ColumnEndTime,
            this.ColumnSubject,
            this.ColumnTutor,
            this.ColumnStudent,
            this.ColumnNotes,
            this.ColumnStatus});
            this.dataGridViewBookings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBookings.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.dataGridViewBookings.Location = new System.Drawing.Point(0, 130);
            this.dataGridViewBookings.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewBookings.MultiSelect = false;
            this.dataGridViewBookings.Name = "dataGridViewBookings";
            this.dataGridViewBookings.ReadOnly = true;
            this.dataGridViewBookings.RowHeadersVisible = false;
            this.dataGridViewBookings.RowTemplate.Height = 30;
            this.dataGridViewBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBookings.Size = new System.Drawing.Size(1088, 400);
            this.dataGridViewBookings.TabIndex = 4;
            this.dataGridViewBookings.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBookings_CellContentClick);
            // 
            // ColumnBookingId
            // 
            this.ColumnBookingId.HeaderText = "ID";
            this.ColumnBookingId.Name = "ColumnBookingId";
            this.ColumnBookingId.ReadOnly = true;
            this.ColumnBookingId.Width = 50;
            // 
            // ColumnDate
            // 
            this.ColumnDate.HeaderText = "Дата";
            this.ColumnDate.Name = "ColumnDate";
            this.ColumnDate.ReadOnly = true;
            // 
            // ColumnStartTime
            // 
            this.ColumnStartTime.HeaderText = "Время начала";
            this.ColumnStartTime.Name = "ColumnStartTime";
            this.ColumnStartTime.ReadOnly = true;
            // 
            // ColumnEndTime
            // 
            this.ColumnEndTime.HeaderText = "Время окончания";
            this.ColumnEndTime.Name = "ColumnEndTime";
            this.ColumnEndTime.ReadOnly = true;
            // 
            // ColumnSubject
            // 
            this.ColumnSubject.HeaderText = "Предмет";
            this.ColumnSubject.Name = "ColumnSubject";
            this.ColumnSubject.ReadOnly = true;
            this.ColumnSubject.Width = 120;
            // 
            // ColumnTutor
            // 
            this.ColumnTutor.HeaderText = "Преподаватель";
            this.ColumnTutor.Name = "ColumnTutor";
            this.ColumnTutor.ReadOnly = true;
            this.ColumnTutor.Width = 150;
            // 
            // ColumnStudent
            // 
            this.ColumnStudent.HeaderText = "Студент";
            this.ColumnStudent.Name = "ColumnStudent";
            this.ColumnStudent.ReadOnly = true;
            this.ColumnStudent.Width = 150;
            // 
            // ColumnNotes
            // 
            this.ColumnNotes.HeaderText = "Комментарий";
            this.ColumnNotes.Name = "ColumnNotes";
            this.ColumnNotes.ReadOnly = true;
            this.ColumnNotes.Width = 150;
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.HeaderText = "Статус";
            this.ColumnStatus.Name = "ColumnStatus";
            this.ColumnStatus.ReadOnly = true;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Controls.Add(this.labelCount);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 98);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(2);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1088, 32);
            this.panelHeader.TabIndex = 5;
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.labelTitle.Location = new System.Drawing.Point(15, 6);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(250, 20);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "📋 ВСЕ ЗАПИСИ НА УРОКИ";
            // 
            // labelCount
            // 
            this.labelCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.labelCount.Location = new System.Drawing.Point(850, 8);
            this.labelCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(130, 16);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "Всего записей: 0";
            this.labelCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelWelcome
            // 
            this.panelWelcome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.panelWelcome.Controls.Add(this.labelWelcome);
            this.panelWelcome.Controls.Add(this.labelRole);
            this.panelWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWelcome.Location = new System.Drawing.Point(0, 0);
            this.panelWelcome.Margin = new System.Windows.Forms.Padding(2);
            this.panelWelcome.Name = "panelWelcome";
            this.panelWelcome.Size = new System.Drawing.Size(1088, 98);
            this.panelWelcome.TabIndex = 7;
            // 
            // labelWelcome
            // 
            this.labelWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.labelWelcome.Location = new System.Drawing.Point(15, 30);
            this.labelWelcome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(450, 24);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Добро пожаловать, Администратор!";
            // 
            // labelRole
            // 
            this.labelRole.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.labelRole.Location = new System.Drawing.Point(15, 60);
            this.labelRole.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(150, 20);
            this.labelRole.TabIndex = 1;
            this.labelRole.Text = "Роль: Администратор";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelButtons.Controls.Add(this.buttonRefresh);
            this.panelButtons.Controls.Add(this.buttonEdit);
            this.panelButtons.Controls.Add(this.buttonDelete);
            this.panelButtons.Controls.Add(this.buttonLogout);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 530);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(2);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1088, 57);
            this.panelButtons.TabIndex = 8;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.buttonRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRefresh.FlatAppearance.BorderSize = 0;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.buttonRefresh.ForeColor = System.Drawing.Color.White;
            this.buttonRefresh.Location = new System.Drawing.Point(15, 12);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(100, 32);
            this.buttonRefresh.TabIndex = 0;
            this.buttonRefresh.Text = "🔄 Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            // 
            // buttonEdit
            // 
            this.buttonEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.buttonEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEdit.FlatAppearance.BorderSize = 0;
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEdit.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.buttonEdit.ForeColor = System.Drawing.Color.White;
            this.buttonEdit.Location = new System.Drawing.Point(130, 12);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(2);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(100, 32);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "✏️ Редактировать";
            this.buttonEdit.UseVisualStyleBackColor = false;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(245, 12);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(100, 32);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "🗑️ Удалить";
            this.buttonDelete.UseVisualStyleBackColor = false;
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.buttonLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLogout.FlatAppearance.BorderSize = 0;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.buttonLogout.ForeColor = System.Drawing.Color.White;
            this.buttonLogout.Location = new System.Drawing.Point(880, 12);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(100, 32);
            this.buttonLogout.TabIndex = 3;
            this.buttonLogout.Text = "🚪 Выйти";
            this.buttonLogout.UseVisualStyleBackColor = false;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 587);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip.Size = new System.Drawing.Size(1088, 22);
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(138, 17);
            this.statusLabel.Text = "Администратор онлайн";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 609);
            this.Controls.Add(this.dataGridViewBookings);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelWelcome);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.statusStrip);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Администратор - Управление записями";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBookings)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelWelcome.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private System.Windows.Forms.DataGridView dataGridViewBookings;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Panel panelWelcome;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBookingId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTutor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStatus;
    }
}