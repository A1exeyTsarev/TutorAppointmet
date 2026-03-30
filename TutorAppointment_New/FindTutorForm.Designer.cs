namespace TutorAppointment_New
{
    partial class FindTutorForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTutors = new System.Windows.Forms.DataGridView();
            this.buttonBack = new System.Windows.Forms.Button();
            this.labelCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTutors)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(200, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Мои преподаватели (репетиторы)";
            // 
            // dataGridViewTutors
            // 
            this.dataGridViewTutors.AllowUserToAddRows = false;
            this.dataGridViewTutors.AllowUserToDeleteRows = false;
            this.dataGridViewTutors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTutors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTutors.Location = new System.Drawing.Point(30, 70);
            this.dataGridViewTutors.Name = "dataGridViewTutors";
            this.dataGridViewTutors.ReadOnly = true;
            this.dataGridViewTutors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTutors.Size = new System.Drawing.Size(720, 300);
            this.dataGridViewTutors.TabIndex = 1;
            //this.dataGridViewTutors.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTutors_CellContentClick);
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonBack.Location = new System.Drawing.Point(320, 400);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(120, 40);
            this.buttonBack.TabIndex = 2;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelCount.Location = new System.Drawing.Point(30, 410);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(0, 20);
            this.labelCount.TabIndex = 3;
            // 
            // FindTutorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.dataGridViewTutors);
            this.Controls.Add(this.label1);
            this.Name = "FindTutorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Мои преподаватели";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTutors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewTutors;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelCount;
    }
}