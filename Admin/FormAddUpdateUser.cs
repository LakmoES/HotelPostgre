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

namespace Admin
{
    public partial class FormAddUpdateUser : Form
    {
        private SecureDBUser user;
        private bool adding;

        private ISecureRepositoryFactory secureRepositoryFactory;
        private IRepositoryFactory repositoryFactory;
        private SecureUserPresenter userPresenter;

        private ISecureUserRepository userRepository;
        private ICompanyRepository companyRepository;
        private IStaffRepository staffRepository;

        private List<SecureDBUser> userList;
        private List<Company> companyList;
        private List<Staff> staffList;
        public FormAddUpdateUser(DataGridView dgv, SecureDBUser user, ISecureRepositoryFactory secureRepositoryFactory, IRepositoryFactory repositoryFactory) //редактирование
        {
            InitializeComponent();
            adding = false;
            this.user = user;
            this.secureRepositoryFactory = secureRepositoryFactory;
            this.repositoryFactory = repositoryFactory;
            Init(dgv);

            FillTheFields();

            ExtractDataFromUser(user);

            this.textBoxName.ReadOnly = true;
        }
        public FormAddUpdateUser(DataGridView dgv, ISecureRepositoryFactory secureRepositoryFactory, IRepositoryFactory repositoryFactory) //добавление
        {
            InitializeComponent();
            adding = true;
            this.secureRepositoryFactory = secureRepositoryFactory;
            this.repositoryFactory = repositoryFactory;
            Init(dgv);
            FillTheFields();

            user = new SecureDBUser(null, null, -1, -1);
        }
        private void Init(DataGridView dgv)
        {
            userRepository = secureRepositoryFactory.GetSecureUserRepository();
            userPresenter = new SecureUserPresenter(dgv, repositoryFactory, secureRepositoryFactory);

            companyRepository = repositoryFactory.GetCompanyRepository();
            staffRepository = repositoryFactory.GetStaffRepository();
        }
        private void FillTheFields()
        {
            for (int i = 2; i <= 3; ++i)
                comboBoxRole.Items.Add(String.Format("[{0}] {1}", i, SecureConst.GetRoleName(i)));

            userList = userRepository.GetTable();
            companyList = companyRepository.GetTable();
            staffList = staffRepository.GetTable();
        }
        private void ExtractDataFromUser(SecureDBUser user)
        {
            try
            {
                this.textBoxName.Text = user.name;

                this.comboBoxRole.Text = String.Format("[{0}] {1}", user.db_role, SecureConst.GetRoleName(user.db_role));
                if (user.db_role == 2)
                {
                    Company company = companyRepository.GetConcreteRecord(user.subgroup);
                    this.comboBoxSubgroup.Text = String.Format("[{0}] {1}", company.id, company.title);
                }
                if (user.db_role == 3)
                {
                    Staff staff = staffRepository.GetConcreteRecord(user.subgroup);
                    this.comboBoxSubgroup.Text = String.Format("[{0}] {1} {2}", staff.id, staff.surname, staff.name);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка"); }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (AddUpdateShow())
                {
                    userPresenter.ShowTable(true);
                    this.Close();
                }
            }
            catch (PostgresException pEx)
            {
                MessageBox.Show("Произошла ошибка при выполнении запроса к базе данных.\r\n" + pEx.Message, "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка. Проверьте поля.\r\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool AddUpdateShow()
        {
            //id, Shower, Buyer, Object, Cost, Date

            user.name = this.textBoxName.Text;

            user.password = "";
            if (adding && textBoxPassword.Text.Length > 0) //при добавлении хешируем пароль
                user.password = SecureCrypt.MD5(textBoxPassword.Text).ToLower();
            if (!adding && textBoxPassword.Text.Length > 0)
                user.password = SecureCrypt.MD5(textBoxPassword.Text).ToLower();

            user.db_role = -1;
            if (this.comboBoxRole.SelectedIndex != -1)
                user.db_role = this.comboBoxRole.SelectedIndex + 2;
            user.subgroup = -1;
            if(this.comboBoxSubgroup.SelectedIndex != -1)
            {
                switch(user.db_role)
                {
                    case 2: //директор
                        user.subgroup = companyList[this.comboBoxSubgroup.SelectedIndex].id;
                        break;
                    case 3: //работник
                        user.subgroup = staffList[this.comboBoxSubgroup.SelectedIndex].id;
                        break;
                }
            }

            if (!adding)
                return (userPresenter.UpdateTable(user));
            else
                return (userPresenter.AddToTable(user));
        }

        private void comboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxSubgroup.Items.Clear();
            switch(comboBoxRole.SelectedIndex)
            {
                case 0: //директор
                    foreach (var company in companyList)
                        comboBoxSubgroup.Items.Add(String.Format("[{0}] {1}", company.id, company.title));
                    break;
                case 1: //работник
                    foreach (var staff in staffList)
                        comboBoxSubgroup.Items.Add(String.Format("[{0}] {1} {2}", staff.id, staff.surname, staff.name));
                    break;
            }
        }
    }
}
