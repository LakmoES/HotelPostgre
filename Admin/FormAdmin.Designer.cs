namespace Admin
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
            this.buttonCompanyAdd = new System.Windows.Forms.Button();
            this.buttonCompanyRefresh = new System.Windows.Forms.Button();
            this.dataGridViewCompany = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonObjectAdd = new System.Windows.Forms.Button();
            this.buttonObjectRefresh = new System.Windows.Forms.Button();
            this.dataGridViewObject = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridViewOwner = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppartamentOrHouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rooms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonOwnerRefresh = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonOwnerAdd = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompany)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewObject)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOwner)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPage1);
            this.tabControlMain.Controls.Add(this.tabPage2);
            this.tabControlMain.Controls.Add(this.tabPage3);
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonOwnerAdd);
            this.tabPage3.Controls.Add(this.buttonOwnerRefresh);
            this.tabPage3.Controls.Add(this.dataGridViewOwner);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(651, 253);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Владельцы";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewOwner
            // 
            this.dataGridViewOwner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOwner.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.dataGridViewOwner.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewOwner.MultiSelect = false;
            this.dataGridViewOwner.Name = "dataGridViewOwner";
            this.dataGridViewOwner.ReadOnly = true;
            this.dataGridViewOwner.Size = new System.Drawing.Size(436, 247);
            this.dataGridViewOwner.TabIndex = 2;
            this.dataGridViewOwner.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView_SelectAndShowMenu);
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
            this.title.HeaderText = "Название";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            // 
            // telephone
            // 
            this.telephone.HeaderText = "Телефон";
            this.telephone.Name = "telephone";
            this.telephone.ReadOnly = true;
            // 
            // address
            // 
            this.address.HeaderText = "Адрес";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            this.address.Width = 250;
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
            this.dataGridViewTextBoxColumn2.HeaderText = "Адрес";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 145;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Дата";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 70;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Стоимость";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 65;
            // 
            // ObjectOwner
            // 
            this.ObjectOwner.HeaderText = "Владелец";
            this.ObjectOwner.Name = "ObjectOwner";
            this.ObjectOwner.ReadOnly = true;
            this.ObjectOwner.Width = 60;
            // 
            // AppartamentOrHouse
            // 
            this.AppartamentOrHouse.HeaderText = "Тип";
            this.AppartamentOrHouse.Name = "AppartamentOrHouse";
            this.AppartamentOrHouse.ReadOnly = true;
            this.AppartamentOrHouse.Width = 40;
            // 
            // Area
            // 
            this.Area.HeaderText = "Площадь";
            this.Area.Name = "Area";
            this.Area.ReadOnly = true;
            this.Area.Width = 50;
            // 
            // Rooms
            // 
            this.Rooms.HeaderText = "Комнат";
            this.Rooms.Name = "Rooms";
            this.Rooms.ReadOnly = true;
            this.Rooms.Width = 55;
            // 
            // buttonOwnerRefresh
            // 
            this.buttonOwnerRefresh.Location = new System.Drawing.Point(515, 74);
            this.buttonOwnerRefresh.Name = "buttonOwnerRefresh";
            this.buttonOwnerRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonOwnerRefresh.TabIndex = 3;
            this.buttonOwnerRefresh.Text = "Обновить";
            this.buttonOwnerRefresh.UseVisualStyleBackColor = true;
            this.buttonOwnerRefresh.Click += new System.EventHandler(this.buttonOwnerRefresh_Click);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "id";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 30;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Имя";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Фамилия";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Телефон";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // buttonOwnerAdd
            // 
            this.buttonOwnerAdd.Location = new System.Drawing.Point(570, 224);
            this.buttonOwnerAdd.Name = "buttonOwnerAdd";
            this.buttonOwnerAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonOwnerAdd.TabIndex = 4;
            this.buttonOwnerAdd.Text = "Добавить";
            this.buttonOwnerAdd.UseVisualStyleBackColor = true;
            this.buttonOwnerAdd.Click += new System.EventHandler(this.buttonOwnerAdd_Click);
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
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOwner)).EndInit();
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
        private System.Windows.Forms.Button buttonCompanyAdd;
        private System.Windows.Forms.Button buttonObjectAdd;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridViewOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn telephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppartamentOrHouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rooms;
        private System.Windows.Forms.Button buttonOwnerRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Button buttonOwnerAdd;
    }
}

