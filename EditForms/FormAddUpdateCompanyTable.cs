using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Repositories;

namespace EditForms
{
    public partial class FormAddUpdateCompanyTable : Form
    {
        CompanyPresenter companyPresenter;
        DBCompany company;
        bool adding;
        public FormAddUpdateCompanyTable(DataGridView dgv, int index) //редактирование
        {
            InitializeComponent();
            adding = false;

            companyPresenter = new CompanyPresenter(dgv);
            company = new DBCompany(Convert.ToInt32(dgv.Rows[index].Cells[0].Value), dgv.Rows[index].Cells[1].Value.ToString(),
                dgv.Rows[index].Cells[2].Value.ToString(), dgv.Rows[index].Cells[3].Value.ToString());

            this.textBoxID.Text = company.id.ToString();
            this.textBoxTitle.Text = company.title;
            this.textBoxTelephone.Text = company.telephone;
            this.textBoxAddress.Text = company.address;
        }
        public FormAddUpdateCompanyTable(DataGridView dgv) //добавление
        {
            InitializeComponent();
            adding = true;

            companyPresenter = new CompanyPresenter(dgv);
            company = new DBCompany(-1, null, null, null);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (AddUpdateCompany())
                    this.Close();
                else
                    MessageBox.Show("Проверьте правильность заполнения полей", "Внимание" , MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (PostgresException pEx)
            {
                MessageBox.Show("Произошла ошибка при выполнении запроса к базе данных.\r\n" + pEx.Message, "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка.\r\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool AddUpdateCompany()
        {
            company.title = this.textBoxTitle.Text.Trim(' ');
            company.telephone = this.textBoxTelephone.Text.Trim(' ');
            company.address = this.textBoxAddress.Text.Trim(' ');

            if (CompanyController.checkAddition(company))
            {
                if (!adding)
                    companyPresenter.UpdateTable(company);
                else
                    companyPresenter.AddToTable(company);
                companyPresenter.ShowTable(true);
                return true;
            }
            return false;
        }
    }
}
