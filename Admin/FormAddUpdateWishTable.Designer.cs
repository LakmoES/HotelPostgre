namespace Admin
{
    partial class FormAddUpdateWishTable
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
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxTownship = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownArea = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownNumberOfRooms = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCost = new System.Windows.Forms.NumericUpDown();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxApartamentOrHouse = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCost)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(75, 44);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(100, 21);
            this.comboBoxClient.TabIndex = 64;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "Клиент";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "ID";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(75, 18);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.ReadOnly = true;
            this.textBoxID.Size = new System.Drawing.Size(41, 20);
            this.textBoxID.TabIndex = 58;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(105, 212);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 57;
            this.buttonOK.Text = "Готово";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(24, 212);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 56;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxTownship
            // 
            this.textBoxTownship.Location = new System.Drawing.Point(75, 71);
            this.textBoxTownship.Name = "textBoxTownship";
            this.textBoxTownship.Size = new System.Drawing.Size(100, 20);
            this.textBoxTownship.TabIndex = 65;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 66;
            this.label2.Text = "Район";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 68;
            this.label4.Text = "Тип";
            // 
            // numericUpDownArea
            // 
            this.numericUpDownArea.Location = new System.Drawing.Point(75, 123);
            this.numericUpDownArea.Name = "numericUpDownArea";
            this.numericUpDownArea.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownArea.TabIndex = 69;
            // 
            // numericUpDownNumberOfRooms
            // 
            this.numericUpDownNumberOfRooms.Location = new System.Drawing.Point(75, 149);
            this.numericUpDownNumberOfRooms.Name = "numericUpDownNumberOfRooms";
            this.numericUpDownNumberOfRooms.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownNumberOfRooms.TabIndex = 70;
            // 
            // numericUpDownCost
            // 
            this.numericUpDownCost.Location = new System.Drawing.Point(75, 175);
            this.numericUpDownCost.Name = "numericUpDownCost";
            this.numericUpDownCost.Size = new System.Drawing.Size(69, 20);
            this.numericUpDownCost.TabIndex = 71;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(150, 174);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(25, 20);
            this.textBox3.TabIndex = 72;
            this.textBox3.Text = "у.е.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 73;
            this.label5.Text = "Площадь";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 74;
            this.label6.Text = "Комнаты";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 75;
            this.label7.Text = "Стоимость";
            // 
            // comboBoxApartamentOrHouse
            // 
            this.comboBoxApartamentOrHouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxApartamentOrHouse.FormattingEnabled = true;
            this.comboBoxApartamentOrHouse.Location = new System.Drawing.Point(75, 97);
            this.comboBoxApartamentOrHouse.Name = "comboBoxApartamentOrHouse";
            this.comboBoxApartamentOrHouse.Size = new System.Drawing.Size(100, 21);
            this.comboBoxApartamentOrHouse.TabIndex = 76;
            // 
            // FormAddUpdateWishTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 256);
            this.Controls.Add(this.comboBoxApartamentOrHouse);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.numericUpDownCost);
            this.Controls.Add(this.numericUpDownNumberOfRooms);
            this.Controls.Add(this.numericUpDownArea);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxTownship);
            this.Controls.Add(this.comboBoxClient);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormAddUpdateWishTable";
            this.Text = "FormAddUpdateWishTable";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxClient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxTownship;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownArea;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfRooms;
        private System.Windows.Forms.NumericUpDown numericUpDownCost;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxApartamentOrHouse;
    }
}