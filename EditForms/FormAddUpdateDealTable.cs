using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Npgsql;
using Repositories;

namespace EditForms
{
    public partial class FormAddUpdateDealTable : Form
    {
        //private Regex regex;
        private Deal deal;
        private bool adding;
        private IStaffRepository staffRepository;
        private IPersonRepository clientRepository;
        private IObjectRepository objectRepository;
        private IDealRepository dealRepository;
        private DealPresenter dealPresenter;

        //deal,staff,client,object
        private List<Deal> dealList;
        private List<Staff> staffList;
        private List<Person> clientList;
        private List<Entity> objectList;
        public FormAddUpdateDealTable(DataGridView dgv, Deal deal) //редактирование
        {
            InitializeComponent();
            adding = false;
            this.deal = deal;
            Init(dgv);


            int objID = deal.obj;
            FillTheFields(objID);
            //Match matchObject = regex.Match(dgv.Rows[index].Cells[3].Value.ToString());
            //int objID = Convert.ToInt32(matchObject.Value.Substring(1, matchObject.Value.Length - 2));
            //FillTheFields(objID);

            //Match matchDealer = regex.Match(dgv.Rows[index].Cells[1].Value.ToString());
            //Match matchClient = regex.Match(dgv.Rows[index].Cells[2].Value.ToString());

            //deal = new DBDeal(Convert.ToInt32(dgv.Rows[index].Cells[0].Value.ToString()),
            //    Convert.ToInt32(matchDealer.Value.Substring(1, matchDealer.Value.Length - 2)),
            //    Convert.ToInt32(matchClient.Value.Substring(1, matchClient.Value.Length - 2)),
            //    objID,
            //    Convert.ToInt32(dgv.Rows[index].Cells[4].Value.ToString()),
            //    Convert.ToDateTime(dgv.Rows[index].Cells[5].Value.ToString())
            //    );
            ExtractDataFromDeal(deal);

            this.comboBoxObject.Enabled = false;
            this.comboBoxBuyer.Enabled = false;

            CheckPermissions();
        }
        public FormAddUpdateDealTable(DataGridView dgv) //добавление
        {
            InitializeComponent();
            adding = true;
            Init(dgv);
            FillTheFields();

            deal = new Deal(-1, -1, -1, -1, -1, new DateTime());
        }
        private void Init(DataGridView dgv)
        {
            staffRepository = RepositoryFactory.GetStaffRepository();//new StaffRepository();
            clientRepository = RepositoryFactory.GetClientRepository();//new PersonRepository("Client");
            objectRepository = RepositoryFactory.GetObjectRepository();//new ObjectRepository();
            dealRepository = RepositoryFactory.GetDealRepository();//new DealRepository();

            dealPresenter = new DealPresenter(dgv);

            //regex = new Regex("\\[[0-9]+\\]");

            numericUpDownCost.Minimum = -1;
            numericUpDownCost.Maximum = Int32.MaxValue;
        }
        private void FillTheFields(int objID = -1)
        {
            textBoxCurrency.Text = "у.е.";

            dealList = dealRepository.GetTable();
            Dictionary<int, Deal> deals = new Dictionary<int, Deal>();
            foreach (Deal curDeal in dealList)
                deals.Add(curDeal.id, curDeal);

            staffList = staffRepository.GetTable();
            foreach (var staff in staffList)
            {
                if ((User.role == 1) || (User.role == 2 && User.subrole == staff.company)) //todo: исправить отсутствие продавца, если он из другого филиала
                {
                    string staffText = String.Format("{1} {2}", staff.id, staff.surname, staff.name);
                    comboBoxDealer.Items.Add(staffText);
                }
            }
            clientList = clientRepository.GetTable();
            foreach (var client in clientList)
            {
                string clientText = String.Format("{1} {2}", client.id, client.surname, client.name);
                comboBoxBuyer.Items.Add(clientText);
            }
            objectList = objectRepository.GetTable();
            List<Entity> tempToSave = new List<Entity>();
            foreach (var obj in objectList)
            {
                Deal tempDeal;
                if (!deals.TryGetValue(obj.id, out tempDeal)) //игнорируем уже проданные объекты
                {
                    comboBoxObject.Items.Add(obj.address);
                    tempToSave.Add(obj);
                }
            }
            objectList = tempToSave;

            if (objID != -1)
            {
                Entity obj = objectRepository.GetConcreteRecord(objID);
                objectList.Add(obj);
                comboBoxObject.Items.Add(String.Format("{1}", obj.id, obj.address));
            }
        }
        private void ExtractDataFromDeal(Deal deal)
        {
            //try
            //{
                Staff dealer = staffRepository.GetConcreteRecord(deal.dealer);
                this.comboBoxDealer.Text = String.Format("{1} {2}", dealer.id, dealer.surname, dealer.name);

                Person client = clientRepository.GetConcreteRecord(deal.buyer);
                this.comboBoxBuyer.Text = String.Format("{1} {2}", client.id, client.surname, client.name);

                Entity obj = objectRepository.GetConcreteRecord(deal.obj);
                this.comboBoxObject.Text = String.Format("{1}", obj.id, obj.address);

                this.textBoxID.Text = deal.id.ToString();
                this.numericUpDownCost.Value = Convert.ToDecimal(deal.cost);
                this.dateTimePickerDate.Value = deal.date;
            //}
            //catch(Exception ex) { MessageBox.Show(ex.Message, "Ошибка"); }
        }
        void CheckPermissions()
        {
            if(User.role == 2)
            {
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
                if (AddUpdateDeal())
                {
                    dealPresenter.ShowTable(true);
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
        private bool AddUpdateDeal()
        {
            //id, Dealer, Buyer, Object, Cost, Date

            //Match matchDealer = regex.Match(this.comboBoxDealer.Text);
            //Match matchClient = regex.Match(this.comboBoxBuyer.Text);
            //Match matchObject = regex.Match(this.comboBoxObject.Text);

            //deal.dealer = Convert.ToInt32(matchDealer.Value.Substring(1, matchDealer.Value.Length - 2));
            //deal.buyer = Convert.ToInt32(matchClient.Value.Substring(1, matchClient.Value.Length - 2));
            //deal.obj = Convert.ToInt32(matchObject.Value.Substring(1, matchObject.Value.Length - 2));

            deal.dealer = -1;
            if (this.comboBoxDealer.SelectedIndex != -1)
                deal.dealer = staffList.ElementAt(this.comboBoxDealer.SelectedIndex).id;
            deal.buyer = -1;
            if (this.comboBoxBuyer.SelectedIndex != -1)
                deal.buyer = clientList.ElementAt(this.comboBoxBuyer.SelectedIndex).id;
            deal.obj = -1;
            if (this.comboBoxObject.SelectedIndex != -1)
                deal.obj = objectList.ElementAt(this.comboBoxObject.SelectedIndex).id;

            deal.cost = Convert.ToSingle(this.numericUpDownCost.Value);
            deal.date = this.dateTimePickerDate.Value;

            if (!adding)
                return (dealPresenter.UpdateTable(deal));
            else
                return (dealPresenter.AddToTable(deal));
        }

        private void comboBoxObject_TextChanged(object sender, EventArgs e)
        {
            //Match matchObjectID = regex.Match(this.comboBoxObject.Text);
            //int objectID = Convert.ToInt32(matchObjectID.Value.Substring(1, matchObjectID.Value.Length - 2));
            //var obj = objectRepository.GetConcreteRecord(objectID);
            //this.numericUpDownCost.Minimum = Convert.ToDecimal(obj.cost);
            if (comboBoxObject.SelectedIndex == -1)
                return;
            var obj = objectList[this.comboBoxObject.SelectedIndex];
            //MessageBox.Show(String.Format("[{0}] {1} {2}", obj.id, obj.address, obj.cost.ToString("N2")));
            this.numericUpDownCost.Minimum = Convert.ToDecimal(obj.cost);
        }

        private void numericUpDownCost_ValueChanged(object sender, EventArgs e)
        {
            if (this.comboBoxObject.SelectedIndex != -1)
                if (numericUpDownCost.Value < Convert.ToDecimal(objectList[this.comboBoxObject.SelectedIndex].cost))
                    numericUpDownCost.Value = Convert.ToDecimal(objectList[this.comboBoxObject.SelectedIndex].cost);
        }
    }
}
