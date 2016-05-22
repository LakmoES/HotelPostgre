namespace Admin
{
    partial class FormAddUpdateObjectTable
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.dateTimePickerToday = new System.Windows.Forms.DateTimePicker();
            this.comboBoxOwner = new System.Windows.Forms.ComboBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.numericUpDownRooms = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownArea = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCost = new System.Windows.Forms.NumericUpDown();
            this.textBoxCurrency = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCost)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(89, 26);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.ReadOnly = true;
            this.textBoxID.Size = new System.Drawing.Size(52, 20);
            this.textBoxID.TabIndex = 1;
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(89, 52);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(121, 20);
            this.textBoxAddress.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Адрес";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Дата";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Стоимость";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Владелец";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Тип";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Площадь";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Комнат";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(24, 245);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(105, 245);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 17;
            this.buttonOK.Text = "Готово";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // dateTimePickerToday
            // 
            this.dateTimePickerToday.Enabled = false;
            this.dateTimePickerToday.Location = new System.Drawing.Point(89, 78);
            this.dateTimePickerToday.Name = "dateTimePickerToday";
            this.dateTimePickerToday.Size = new System.Drawing.Size(121, 20);
            this.dateTimePickerToday.TabIndex = 18;
            // 
            // comboBoxOwner
            // 
            this.comboBoxOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOwner.FormattingEnabled = true;
            this.comboBoxOwner.Location = new System.Drawing.Point(89, 129);
            this.comboBoxOwner.Name = "comboBoxOwner";
            this.comboBoxOwner.Size = new System.Drawing.Size(121, 21);
            this.comboBoxOwner.TabIndex = 19;
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(89, 156);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxType.TabIndex = 20;
            // 
            // numericUpDownRooms
            // 
            this.numericUpDownRooms.Location = new System.Drawing.Point(90, 209);
            this.numericUpDownRooms.Name = "numericUpDownRooms";
            this.numericUpDownRooms.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownRooms.TabIndex = 21;
            // 
            // numericUpDownArea
            // 
            this.numericUpDownArea.Location = new System.Drawing.Point(90, 183);
            this.numericUpDownArea.Name = "numericUpDownArea";
            this.numericUpDownArea.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownArea.TabIndex = 22;
            // 
            // numericUpDownCost
            // 
            this.numericUpDownCost.Location = new System.Drawing.Point(89, 105);
            this.numericUpDownCost.Name = "numericUpDownCost";
            this.numericUpDownCost.Size = new System.Drawing.Size(66, 20);
            this.numericUpDownCost.TabIndex = 23;
            // 
            // textBoxCurrency
            // 
            this.textBoxCurrency.Location = new System.Drawing.Point(161, 105);
            this.textBoxCurrency.Name = "textBoxCurrency";
            this.textBoxCurrency.ReadOnly = true;
            this.textBoxCurrency.Size = new System.Drawing.Size(49, 20);
            this.textBoxCurrency.TabIndex = 24;
            // 
            // FormAddUpdateObjectTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 280);
            this.Controls.Add(this.textBoxCurrency);
            this.Controls.Add(this.numericUpDownCost);
            this.Controls.Add(this.numericUpDownArea);
            this.Controls.Add(this.numericUpDownRooms);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.comboBoxOwner);
            this.Controls.Add(this.dateTimePickerToday);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormAddUpdateObjectTable";
            this.Text = "FormAddUpdateObjectTable";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.DateTimePicker dateTimePickerToday;
        private System.Windows.Forms.ComboBox comboBoxOwner;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.NumericUpDown numericUpDownRooms;
        private System.Windows.Forms.NumericUpDown numericUpDownArea;
        private System.Windows.Forms.NumericUpDown numericUpDownCost;
        private System.Windows.Forms.TextBox textBoxCurrency;
    }
}