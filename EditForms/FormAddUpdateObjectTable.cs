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
using Npgsql;
using Repositories;

namespace EditForms
{
    public partial class FormAddUpdateObjectTable : Form
    {
        ObjectPresenter objectPresenter;
        IPersonRepository ownerRepository;
        DBObject obj;
        Regex regex; // [id]
        bool adding;
        public FormAddUpdateObjectTable(DataGridView dgv, int index) //редактирование
        {
            InitializeComponent();
            adding = false;
            numericUpDownCost.Minimum = -1;
            numericUpDownCost.Maximum = Int32.MaxValue;
            numericUpDownArea.Minimum = -1;
            numericUpDownArea.Maximum = Int32.MaxValue;

            objectPresenter = new ObjectPresenter(dgv);
            ownerRepository = RepositoryFactory.GetOwnerRepository();//new PersonRepository("Owner");

            FillTheFields();
            this.textBoxAddress.ReadOnly = true;
            this.comboBoxType.Enabled = false;

            Match match = regex.Match(dgv.Rows[index].Cells[4].Value.ToString());

            obj = new DBObject(Convert.ToInt32(dgv.Rows[index].Cells[0].Value.ToString()),
                dgv.Rows[index].Cells[1].Value.ToString(),
                Convert.ToDateTime(dgv.Rows[index].Cells[2].Value.ToString()),
                Convert.ToInt32(dgv.Rows[index].Cells[3].Value.ToString()),
                Convert.ToInt32(match.Value.Substring(1, match.Value.Length - 2)), //owner id
                dgv.Rows[index].Cells[5].Value.ToString(),
                Convert.ToInt32(dgv.Rows[index].Cells[6].Value.ToString()),
                Convert.ToInt32(dgv.Rows[index].Cells[7].Value.ToString()));



            this.textBoxID.Text = obj.id.ToString();
            this.textBoxAddress.Text = obj.address;
            this.dateTimePickerToday.Value = obj.addDate;
            this.numericUpDownCost.Value = obj.cost;

            DBPerson owner = ownerRepository.GetConcreteRecord(obj.owner);
            this.comboBoxOwner.Text = String.Format("[{0}] {1} {2}", owner.id, owner.surname, owner.name);

            this.comboBoxType.Text = obj.appartamentOrHouse;
            this.numericUpDownArea.Value = obj.area;
            this.numericUpDownRooms.Value = obj.numberOfRooms;
        }
        public FormAddUpdateObjectTable(DataGridView dgv) //добавление
        {
            InitializeComponent();
            adding = true;
            numericUpDownCost.Minimum = -1;
            numericUpDownCost.Maximum = Int32.MaxValue;

            objectPresenter = new ObjectPresenter(dgv);
            ownerRepository = RepositoryFactory.GetOwnerRepository();//new PersonRepository("Owner");

            FillTheFields();
            obj = new DBObject(-1, null, new DateTime(), -1, -1, null, -1, -1);
        }
        private void FillTheFields()
        {
            regex = new Regex("\\[[0-9]+\\]");
            textBoxCurrency.Text = "у.е.";
            var ownersList = ownerRepository.GetTable();
            foreach (var owner in ownersList)
            {
                string ownerText = String.Format("[{0}] {1} {2}", owner.id, owner.surname, owner.name);
                comboBoxOwner.Items.Add(ownerText);
            }
            comboBoxType.Items.AddRange(new string[] { "Apartament", "House" });
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (AddUpdateObject())
                {
                    objectPresenter.ShowTable(true);
                    this.Close();
                }
                else
                    MessageBox.Show("Проверьте правильность заполнения полей", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(PostgresException pEx)
            {
                MessageBox.Show("Произошла ошибка при выполнении запроса к базе данных.\r\n" + pEx.Message, "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Произошла ошибка.\r\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool AddUpdateObject()
        {
            //address,adddate,cost,owner,apartamentorHouse,area,numberOfRooms
            obj.address = this.textBoxAddress.Text;
            obj.addDate = dateTimePickerToday.Value;
            obj.cost = Convert.ToInt32(this.numericUpDownCost.Value);

            
            Match match = regex.Match(this.comboBoxOwner.Text);
            int ownerID = 0;

            if(match.Success)
                ownerID = Convert.ToInt32(match.Value.Substring(1, match.Value.Length - 2));
            obj.owner = ownerID;

            obj.appartamentOrHouse = this.comboBoxType.Text;
            obj.area = Convert.ToInt32(this.numericUpDownArea.Value);
            obj.numberOfRooms = Convert.ToInt32(this.numericUpDownRooms.Value);

            if (!adding)
                return (objectPresenter.UpdateTable(obj));
            else
                return (objectPresenter.AddToTable(obj));
        }
    }
}
