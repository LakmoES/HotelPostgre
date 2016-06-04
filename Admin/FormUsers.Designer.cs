namespace Admin
{
    partial class FormUsers
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
            this.dataGridViewUser = new System.Windows.Forms.DataGridView();
            this.buttonUserRefresh = new System.Windows.Forms.Button();
            this.buttonUserAdd = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewUser
            // 
            this.dataGridViewUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.title,
            this.telephone,
            this.address});
            this.dataGridViewUser.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewUser.MultiSelect = false;
            this.dataGridViewUser.Name = "dataGridViewUser";
            this.dataGridViewUser.ReadOnly = true;
            this.dataGridViewUser.Size = new System.Drawing.Size(324, 247);
            this.dataGridViewUser.TabIndex = 1;
            // 
            // buttonUserRefresh
            // 
            this.buttonUserRefresh.Location = new System.Drawing.Point(361, 82);
            this.buttonUserRefresh.Name = "buttonUserRefresh";
            this.buttonUserRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonUserRefresh.TabIndex = 2;
            this.buttonUserRefresh.Text = "Обновить";
            this.buttonUserRefresh.UseVisualStyleBackColor = true;
            // 
            // buttonUserAdd
            // 
            this.buttonUserAdd.Location = new System.Drawing.Point(361, 204);
            this.buttonUserAdd.Name = "buttonUserAdd";
            this.buttonUserAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonUserAdd.TabIndex = 3;
            this.buttonUserAdd.Text = "Добавить";
            this.buttonUserAdd.UseVisualStyleBackColor = true;
            this.buttonUserAdd.Click += new System.EventHandler(this.buttonUserAdd_Click);
            // 
            // title
            // 
            this.title.HeaderText = "Имя";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            // 
            // telephone
            // 
            this.telephone.HeaderText = "Группа";
            this.telephone.Name = "telephone";
            this.telephone.ReadOnly = true;
            // 
            // address
            // 
            this.address.HeaderText = "Подгруппа";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            this.address.Width = 80;
            // 
            // FormUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 272);
            this.Controls.Add(this.buttonUserAdd);
            this.Controls.Add(this.buttonUserRefresh);
            this.Controls.Add(this.dataGridViewUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormUsers";
            this.Text = "Пользователи";
            this.Load += new System.EventHandler(this.FormUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUser;
        private System.Windows.Forms.Button buttonUserRefresh;
        private System.Windows.Forms.Button buttonUserAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn telephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
    }
}