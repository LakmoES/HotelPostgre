namespace EditForms
{
    partial class FormAddUpdateDealTable
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
            this.labelCompany = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxDealer = new System.Windows.Forms.ComboBox();
            this.comboBoxBuyer = new System.Windows.Forms.ComboBox();
            this.comboBoxObject = new System.Windows.Forms.ComboBox();
            this.numericUpDownCost = new System.Windows.Forms.NumericUpDown();
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxCurrency = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCost)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCompany
            // 
            this.labelCompany.AutoSize = true;
            this.labelCompany.Location = new System.Drawing.Point(4, 122);
            this.labelCompany.Name = "labelCompany";
            this.labelCompany.Size = new System.Drawing.Size(62, 13);
            this.labelCompany.TabIndex = 33;
            this.labelCompany.Text = "Стоимость";
            this.labelCompany.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Объект";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Покупатель";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Сотрудник";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "ID";
            this.label1.Visible = false;
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(70, 15);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.ReadOnly = true;
            this.textBoxID.Size = new System.Drawing.Size(41, 20);
            this.textBoxID.TabIndex = 25;
            this.textBoxID.Visible = false;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(104, 190);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 24;
            this.buttonOK.Text = "Готово";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(23, 190);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 23;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // comboBoxDealer
            // 
            this.comboBoxDealer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDealer.FormattingEnabled = true;
            this.comboBoxDealer.Location = new System.Drawing.Point(70, 41);
            this.comboBoxDealer.Name = "comboBoxDealer";
            this.comboBoxDealer.Size = new System.Drawing.Size(100, 21);
            this.comboBoxDealer.TabIndex = 35;
            // 
            // comboBoxBuyer
            // 
            this.comboBoxBuyer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBuyer.FormattingEnabled = true;
            this.comboBoxBuyer.Location = new System.Drawing.Point(70, 67);
            this.comboBoxBuyer.Name = "comboBoxBuyer";
            this.comboBoxBuyer.Size = new System.Drawing.Size(100, 21);
            this.comboBoxBuyer.TabIndex = 36;
            // 
            // comboBoxObject
            // 
            this.comboBoxObject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxObject.FormattingEnabled = true;
            this.comboBoxObject.Location = new System.Drawing.Point(70, 93);
            this.comboBoxObject.Name = "comboBoxObject";
            this.comboBoxObject.Size = new System.Drawing.Size(100, 21);
            this.comboBoxObject.TabIndex = 37;
            this.comboBoxObject.TextChanged += new System.EventHandler(this.comboBoxObject_TextChanged);
            // 
            // numericUpDownCost
            // 
            this.numericUpDownCost.DecimalPlaces = 2;
            this.numericUpDownCost.Location = new System.Drawing.Point(70, 120);
            this.numericUpDownCost.Name = "numericUpDownCost";
            this.numericUpDownCost.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownCost.TabIndex = 38;
            this.numericUpDownCost.ValueChanged += new System.EventHandler(this.numericUpDownCost_ValueChanged);
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.Enabled = false;
            this.dateTimePickerDate.Location = new System.Drawing.Point(70, 146);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(115, 20);
            this.dateTimePickerDate.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Дата";
            this.label5.Visible = false;
            // 
            // textBoxCurrency
            // 
            this.textBoxCurrency.Location = new System.Drawing.Point(140, 120);
            this.textBoxCurrency.Name = "textBoxCurrency";
            this.textBoxCurrency.ReadOnly = true;
            this.textBoxCurrency.Size = new System.Drawing.Size(45, 20);
            this.textBoxCurrency.TabIndex = 41;
            this.textBoxCurrency.Text = "у.е.";
            // 
            // FormAddUpdateDealTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 240);
            this.Controls.Add(this.textBoxCurrency);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePickerDate);
            this.Controls.Add(this.numericUpDownCost);
            this.Controls.Add(this.comboBoxObject);
            this.Controls.Add(this.comboBoxBuyer);
            this.Controls.Add(this.comboBoxDealer);
            this.Controls.Add(this.labelCompany);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormAddUpdateDealTable";
            this.Text = "Сделка";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelCompany;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxDealer;
        private System.Windows.Forms.ComboBox comboBoxBuyer;
        private System.Windows.Forms.ComboBox comboBoxObject;
        private System.Windows.Forms.NumericUpDown numericUpDownCost;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxCurrency;
    }
}