﻿namespace Admin
{
    partial class FormAdmin
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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonCompanyRefresh = new System.Windows.Forms.Button();
            this.dataGridViewCompany = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonObjectRefresh = new System.Windows.Forms.Button();
            this.dataGridViewObject = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppartamentOrHouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rooms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonCompanyAdd = new System.Windows.Forms.Button();
            this.buttonObjectAdd = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompany)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewObject)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPage1);
            this.tabControlMain.Controls.Add(this.tabPage2);
            this.tabControlMain.Location = new System.Drawing.Point(12, 12);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(659, 279);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonCompanyAdd);
            this.tabPage1.Controls.Add(this.buttonCompanyRefresh);
            this.tabPage1.Controls.Add(this.dataGridViewCompany);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(651, 253);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Компании";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonCompanyRefresh
            // 
            this.buttonCompanyRefresh.Location = new System.Drawing.Point(569, 105);
            this.buttonCompanyRefresh.Name = "buttonCompanyRefresh";
            this.buttonCompanyRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonCompanyRefresh.TabIndex = 1;
            this.buttonCompanyRefresh.Text = "Обновить";
            this.buttonCompanyRefresh.UseVisualStyleBackColor = true;
            this.buttonCompanyRefresh.Click += new System.EventHandler(this.buttonCompanyRefresh_Click);
            // 
            // dataGridViewCompany
            // 
            this.dataGridViewCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompany.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.title,
            this.telephone,
            this.address});
            this.dataGridViewCompany.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewCompany.MultiSelect = false;
            this.dataGridViewCompany.Name = "dataGridViewCompany";
            this.dataGridViewCompany.ReadOnly = true;
            this.dataGridViewCompany.Size = new System.Drawing.Size(534, 247);
            this.dataGridViewCompany.TabIndex = 0;
            this.dataGridViewCompany.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView_SelectAndShowMenu);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 30;
            // 
            // title
            // 
            this.title.HeaderText = "Title";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            // 
            // telephone
            // 
            this.telephone.HeaderText = "Telephone";
            this.telephone.Name = "telephone";
            this.telephone.ReadOnly = true;
            // 
            // address
            // 
            this.address.HeaderText = "Address";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            this.address.Width = 250;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonObjectAdd);
            this.tabPage2.Controls.Add(this.buttonObjectRefresh);
            this.tabPage2.Controls.Add(this.dataGridViewObject);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(651, 253);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Объекты";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonObjectRefresh
            // 
            this.buttonObjectRefresh.Location = new System.Drawing.Point(570, 96);
            this.buttonObjectRefresh.Name = "buttonObjectRefresh";
            this.buttonObjectRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonObjectRefresh.TabIndex = 2;
            this.buttonObjectRefresh.Text = "Обновить";
            this.buttonObjectRefresh.UseVisualStyleBackColor = true;
            this.buttonObjectRefresh.Click += new System.EventHandler(this.buttonObjectRefresh_Click);
            // 
            // dataGridViewObject
            // 
            this.dataGridViewObject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewObject.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.ObjectOwner,
            this.AppartamentOrHouse,
            this.Area,
            this.Rooms});
            this.dataGridViewObject.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewObject.MultiSelect = false;
            this.dataGridViewObject.Name = "dataGridViewObject";
            this.dataGridViewObject.ReadOnly = true;
            this.dataGridViewObject.Size = new System.Drawing.Size(561, 247);
            this.dataGridViewObject.TabIndex = 1;
            this.dataGridViewObject.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView_SelectAndShowMenu);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Address";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "AddDate";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 70;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Cost";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // ObjectOwner
            // 
            this.ObjectOwner.HeaderText = "Owner";
            this.ObjectOwner.Name = "ObjectOwner";
            this.ObjectOwner.ReadOnly = true;
            this.ObjectOwner.Width = 40;
            // 
            // AppartamentOrHouse
            // 
            this.AppartamentOrHouse.HeaderText = "AppartamentOrHouse";
            this.AppartamentOrHouse.Name = "AppartamentOrHouse";
            this.AppartamentOrHouse.ReadOnly = true;
            this.AppartamentOrHouse.Width = 40;
            // 
            // Area
            // 
            this.Area.HeaderText = "Area";
            this.Area.Name = "Area";
            this.Area.ReadOnly = true;
            this.Area.Width = 40;
            // 
            // Rooms
            // 
            this.Rooms.HeaderText = "Rooms";
            this.Rooms.Name = "Rooms";
            this.Rooms.ReadOnly = true;
            this.Rooms.Width = 45;
            // 
            // buttonCompanyAdd
            // 
            this.buttonCompanyAdd.Location = new System.Drawing.Point(569, 224);
            this.buttonCompanyAdd.Name = "buttonCompanyAdd";
            this.buttonCompanyAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonCompanyAdd.TabIndex = 2;
            this.buttonCompanyAdd.Text = "Добавить";
            this.buttonCompanyAdd.UseVisualStyleBackColor = true;
            this.buttonCompanyAdd.Click += new System.EventHandler(this.buttonCompanyAdd_Click);
            // 
            // buttonObjectAdd
            // 
            this.buttonObjectAdd.Location = new System.Drawing.Point(573, 224);
            this.buttonObjectAdd.Name = "buttonObjectAdd";
            this.buttonObjectAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonObjectAdd.TabIndex = 3;
            this.buttonObjectAdd.Text = "Добавить";
            this.buttonObjectAdd.UseVisualStyleBackColor = true;
            this.buttonObjectAdd.Click += new System.EventHandler(this.buttonObjectAdd_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 303);
            this.Controls.Add(this.tabControlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAdmin";
            this.Text = "База данных [Администратор]";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAdmin_FormClosed);
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompany)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewObject)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridViewCompany;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonCompanyRefresh;
        private System.Windows.Forms.Button buttonObjectRefresh;
        private System.Windows.Forms.DataGridView dataGridViewObject;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn telephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppartamentOrHouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rooms;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectOwner;
        private System.Windows.Forms.Button buttonCompanyAdd;
        private System.Windows.Forms.Button buttonObjectAdd;
    }
}
