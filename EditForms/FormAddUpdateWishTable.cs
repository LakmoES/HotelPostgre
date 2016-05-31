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
    public partial class FormAddUpdateWishTable : Form
    {
        Regex regex;
        DBWish wish;
        bool adding;
        IPersonRepository clientRepository;
        IWishRepository wishRepository;
        WishPresenter wishPresenter;
        public FormAddUpdateWishTable(DataGridView dgv, int index) //редактирование
        {
            InitializeComponent();
            adding = false;
            Init(dgv);

            FillTheFields();

            Match matchClient = regex.Match(dgv.Rows[index].Cells[1].Value.ToString());

            wish = new DBWish(Convert.ToInt32(dgv.Rows[index].Cells[0].Value.ToString()),
                Convert.ToInt32(matchClient.Value.Substring(1, matchClient.Value.Length - 2)),
                ConvertToStringOrNull(dgv.Rows[index].Cells[2].Value),
                ConvertToStringOrNull(dgv.Rows[index].Cells[3].Value),
                ConvertToIntOrNull(dgv.Rows[index].Cells[4].Value),
                ConvertToIntOrNull(dgv.Rows[index].Cells[5].Value),
                ConvertToIntOrNull(dgv.Rows[index].Cells[6].Value)
                );
            ExtractDataFromWish(wish);

            this.comboBoxClient.Enabled = false;
        }
        public FormAddUpdateWishTable(DataGridView dgv) //добавление
        {
            InitializeComponent();
            adding = true;
            Init(dgv);
            FillTheFields();

            wish = new DBWish(-1, -1, null, null, null, null, null);
        }
        private void Init(DataGridView dgv)
        {
            clientRepository = RepositoryFactory.GetClientRepository();//new PersonRepository("Client");
            wishRepository = RepositoryFactory.GetWishRepository();//new WishRepository();

            wishPresenter = new WishPresenter(dgv);

            regex = new Regex("\\[[0-9]+\\]");

            this.numericUpDownArea.Minimum = 0;
            this.numericUpDownArea.Maximum = Int32.MaxValue;
            this.numericUpDownNumberOfRooms.Minimum = 0;
            this.numericUpDownNumberOfRooms.Maximum = Int32.MaxValue;
            this.numericUpDownCost.Minimum = 0;
            this.numericUpDownCost.Maximum = Int32.MaxValue;
        }
        private void FillTheFields()
        {
            var wishList = wishRepository.GetTable();
            Dictionary<int, DBWish> wishs = new Dictionary<int, DBWish>();
            foreach (DBWish curWish in wishList)
                wishs.Add(curWish.id, curWish);

            var clientList = clientRepository.GetTable();
            foreach (var client in clientList)
            {
                string clientText = String.Format("[{0}] {1} {2}", client.id, client.surname, client.name);
                comboBoxClient.Items.Add(clientText);
            }

            comboBoxApartamentOrHouse.Items.AddRange(new string[] { "", "House", "Appartament" });
        }
        private void ExtractDataFromWish(DBWish wish)
        {
            try
            {
                this.textBoxID.Text = wish.id.ToString();

                DBPerson client = clientRepository.GetConcreteRecord(wish.client);
                this.comboBoxClient.Text = String.Format("[{0}] {1} {2}", client.id, client.surname, client.name);
                this.textBoxTownship.Text = wish.township;
                this.comboBoxApartamentOrHouse.Text = wish.apartamentOrHouse;
                this.numericUpDownArea.Value = (wish.area ?? 0);
                this.numericUpDownNumberOfRooms.Value = (wish.numberOfRooms ?? 0);
                this.numericUpDownCost.Value = (wish.cost ?? 0);
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
                if (AddUpdateWish())
                {
                    wishPresenter.ShowTable(true);
                    this.Close();
                }
                else
                    MessageBox.Show("Проверьте правильность заполнения полей", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private bool AddUpdateWish()
        {
            try
            {
                //int id, int client, string township, string apartamentOrHouse, int area, int numberOfRooms, int cost
                Match matchClient = regex.Match(this.comboBoxClient.Text);

                wish.client = matchClient.Success ? Convert.ToInt32(matchClient.Value.Substring(1, matchClient.Value.Length - 2)) : -1;
                wish.township = ConvertToStringOrNull(this.textBoxTownship.Text);
                wish.apartamentOrHouse = ConvertToStringOrNull(this.comboBoxApartamentOrHouse.Text);
                wish.area = ConvertToIntOrNull(numericUpDownArea.Value);
                wish.numberOfRooms = ConvertToIntOrNull(numericUpDownNumberOfRooms.Value);
                wish.cost = ConvertToIntOrNull(numericUpDownCost.Value);

                if (!adding)
                    return (wishPresenter.UpdateTable(wish));
                else
                    return (wishPresenter.AddToTable(wish));
            }
            catch (PostgresException pEx)
            {
                MessageBox.Show(pEx.InnerException.ToString(), "Ошибка БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            return false;
        }
        private int? ConvertToIntOrNull(object obj)
        {
            int a = Convert.ToInt32(obj);
            return a != 0 ? ToNullableInt(a) : null;
        }
        private int? ToNullableInt(int a)
        {
            int? b = a;
            return b;
        }
        private string ConvertToStringOrNull(object obj)
        {
            string s = obj.ToString();
            return !s.Equals("") ? s : null;
        }
    }
}
