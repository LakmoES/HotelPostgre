using System;
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
using Npgsql;

namespace EditForms
{
    public partial class FormAddUpdatePersonTable : Form
    {
        private Dictionary<string, string> role;
        private PersonPresenter personPresenter;
        private StaffPresenter staffPresenter;
        private ICompanyRepository companyRepository;
        private DBPerson person;
        private bool adding;
        private string tableName;
        private List<DBCompany> companiesList;
        //private Regex regex; // [id]
        public FormAddUpdatePersonTable(DataGridView dgv, DBPerson person/*int index*/, string tableName) //редактирование
        {
            InitializeComponent();
            this.tableName = tableName;
            this.person = person;
            Init(dgv);

            adding = false;

            //int pID = Convert.ToInt32(dgv.Rows[index].Cells[0].Value);
            //string pName = dgv.Rows[index].Cells[1].Value.ToString();
            //string pSurname = dgv.Rows[index].Cells[2].Value.ToString();
            //string pTel = dgv.Rows[index].Cells[3].Value.ToString();

            if (tableName == "Staff")
            {
                FillTheFieldsForStaff();
                //Match match = regex.Match(dgv.Rows[index].Cells[4].Value.ToString());
                //int pCompany = Convert.ToInt32(match.Value.Substring(1, match.Value.Length - 2));
                //person = new DBStaff(pID, pName, pSurname, pTel, pCompany);
                //this.comboBoxCompany.Text = dgv.Rows[index].Cells[4].Value.ToString();
                this.comboBoxCompany.Text = companyRepository.GetConcreteRecord((person as DBStaff).company).title;                CheckPermissions();
            }
            else
            {
                //person = new DBPerson(pID, pName, pSurname, pTel);
            }

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
            //regex = new Regex("\\[[0-9]+\\]");
            personPresenter = new PersonPresenter(dgv, tableName);
            staffPresenter = new StaffPresenter(dgv);
            companyRepository = RepositoryFactory.GetCompanyRepository();//new CompanyRepository();

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

            companiesList = companyRepository.GetTable();
            foreach (var company in companiesList)
            {
                string companyText = String.Format("{1}", company.id, company.title);
                comboBoxCompany.Items.Add(companyText);

                if (adding && company.id == User.subrole)
                    comboBoxCompany.Text = companyText;
            }

            if (User.role == 2) //не админ
            {
                this.comboBoxCompany.Enabled = false;
            }


        }
        private void CheckPermissions()
        {
            if (User.role == 1)
                return;

            if((person as DBStaff).company != User.subrole)
            {
                this.textBoxName.ReadOnly = true;
                this.textBoxSurname.ReadOnly = true;
                this.textBoxTelephone.ReadOnly = true;
                this.buttonOK.Enabled = false;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (AddUpdatePerson())
                {
                    if (tableName == "Staff")
                        staffPresenter.ShowTable(true);
                    else
                        personPresenter.ShowTable(true);
                    this.Close();
                }
                //else
                //    MessageBox.Show("Проверьте правильность заполнения полей", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private bool AddUpdatePerson()
        {
            person.name = this.textBoxName.Text.Trim(' ');
            person.surname = this.textBoxSurname.Text.Trim(' ');
            person.telephone = this.textBoxTelephone.Text.Trim(' ');
            if (tableName == "Staff")
            {
                //Match match = regex.Match(this.comboBoxCompany.Text);
                //int companyID = -1;
                //if (match.Success)
                //   companyID = Convert.ToInt32(match.Value.Substring(1, match.Value.Length - 2));

                (person as DBStaff).company = -1;
                if (this.comboBoxCompany.SelectedIndex != -1)
                    (person as DBStaff).company = companiesList[this.comboBoxCompany.SelectedIndex].id;
                if (!adding)
                    return (staffPresenter.UpdateTable(person as DBStaff));
                else
                    return (staffPresenter.AddToTable(person as DBStaff));
            }
            else
            {
                if (!adding)
                    return (personPresenter.UpdateTable(person));
                else
                    return (personPresenter.AddToTable(person));
            }
        }
    }
}
