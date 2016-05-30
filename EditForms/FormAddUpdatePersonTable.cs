﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Repositories;

namespace EditForms
{
    public partial class FormAddUpdatePersonTable : Form
    {
        Dictionary<string, string> role;
        PersonPresenter personPresenter;
        StaffPresenter staffPresenter;
        CompanyRepository companyRepository;
        DBPerson person;
        bool adding;
        string tableName;
        Regex regex; // [id]
        public FormAddUpdatePersonTable(DataGridView dgv, int index, string tableName) //редактирование
        {
            InitializeComponent();
            this.tableName = tableName;
            Init(dgv);

            adding = false;

            int pID = Convert.ToInt32(dgv.Rows[index].Cells[0].Value);
            string pName = dgv.Rows[index].Cells[1].Value.ToString();
            string pSurname = dgv.Rows[index].Cells[2].Value.ToString();
            string pTel = dgv.Rows[index].Cells[3].Value.ToString();

            if (tableName == "Staff")
            {
                FillTheFieldsForStaff();
                Match match = regex.Match(dgv.Rows[index].Cells[4].Value.ToString());
                int pCompany = Convert.ToInt32(match.Value.Substring(1, match.Value.Length - 2));
                person = new DBStaff(pID, pName, pSurname, pTel, pCompany);
                this.comboBoxCompany.Text = dgv.Rows[index].Cells[4].Value.ToString();
            }
            else
                person = new DBPerson(pID, pName, pSurname, pTel);

            this.textBoxID.Text = person.id.ToString();
            this.textBoxName.Text = person.name;
            this.textBoxSurname.Text = person.surname;
            this.textBoxTelephone.Text = person.telephone;
        }
        public FormAddUpdatePersonTable(DataGridView dgv, string tableName) //добавление
        {
            InitializeComponent();
            this.tableName = tableName;
            Init(dgv);
            adding = true;

            if (tableName == "Staff")
            {
                person = new DBStaff(-1, null, null, null, -1);
                FillTheFieldsForStaff();
            }
            else
                person = new DBPerson(-1, null, null, null);
        }
        private void Init(DataGridView dgv)
        {
            regex = new Regex("\\[[0-9]+\\]");
            personPresenter = new PersonPresenter(dgv, tableName);
            staffPresenter = new StaffPresenter(dgv);
            companyRepository = new CompanyRepository();

            role = new Dictionary<string, string>();
            role.Add("Staff", "Работник");
            role.Add("Owner", "Владелец");
            role.Add("Client", "Клиент");

            string title = "Person";
            role.TryGetValue(tableName, out title);
            this.Text = title;
        }
        private void FillTheFieldsForStaff()
        {
            this.comboBoxCompany.Visible = true;
            this.labelCompany.Visible = true;

            var companiesList = companyRepository.GetTable();
            foreach (var company in companiesList)
            {
                string companyText = String.Format("[{0}] {1}", company.id, company.title);
                comboBoxCompany.Items.Add(companyText);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            AddUpdatePerson();
            this.Close();
        }
        private void AddUpdatePerson()
        {
            person.name = this.textBoxName.Text.Trim(' ');
            person.surname = this.textBoxSurname.Text.Trim(' ');
            person.telephone = this.textBoxTelephone.Text.Trim(' ');
            if (tableName == "Staff")
            {
                Match match = regex.Match(this.comboBoxCompany.Text);
                int companyID = Convert.ToInt32(match.Value.Substring(1, match.Value.Length - 2));

                (person as DBStaff).company = companyID;

                if (!adding)
                    staffPresenter.UpdateTable(person as DBStaff);
                else
                    staffPresenter.AddToTable(person as DBStaff);
                staffPresenter.ShowTable(true);
            }
            else
            {
                if (!adding)
                    personPresenter.UpdateTable(person);
                else
                    personPresenter.AddToTable(person);
                personPresenter.ShowTable(true);
            }
        }
    }
}