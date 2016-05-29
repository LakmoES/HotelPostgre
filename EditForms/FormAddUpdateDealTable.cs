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
using Repositories;

namespace EditForms
{
    public partial class FormAddUpdateDealTable : Form
    {
        Regex regex;
        DBDeal deal;
        bool adding;
        StaffRepository staffRepository;
        PersonRepository clientRepository;
        ObjectRepository objectRepository;
        DealRepository dealRepository;
        DealPresenter dealPresenter;
        public FormAddUpdateDealTable(DataGridView dgv, int index) //редактирование
        {
            InitializeComponent();
            adding = false;
            Init(dgv);

            Match matchObject = regex.Match(dgv.Rows[index].Cells[3].Value.ToString());
            int objID = Convert.ToInt32(matchObject.Value.Substring(1, matchObject.Value.Length - 2));
            FillTheFields(objID);

            Match matchDealer = regex.Match(dgv.Rows[index].Cells[1].Value.ToString());
            Match matchClient = regex.Match(dgv.Rows[index].Cells[2].Value.ToString());

            deal = new DBDeal(Convert.ToInt32(dgv.Rows[index].Cells[0].Value.ToString()),
                Convert.ToInt32(matchDealer.Value.Substring(1, matchDealer.Value.Length - 2)),
                Convert.ToInt32(matchClient.Value.Substring(1, matchClient.Value.Length - 2)),
                objID,
                Convert.ToInt32(dgv.Rows[index].Cells[4].Value.ToString()),
                Convert.ToDateTime(dgv.Rows[index].Cells[5].Value.ToString())
                );
            ExtractDataFromDeal(deal);

            this.comboBoxObject.Enabled = false;
            this.comboBoxBuyer.Enabled = false;
        }
        public FormAddUpdateDealTable(DataGridView dgv) //добавление
        {
            InitializeComponent();
            adding = true;
            Init(dgv);
            FillTheFields();

            deal = new DBDeal(-1, -1, -1, -1, -1, new DateTime());
        }
        private void Init(DataGridView dgv)
        {
            staffRepository = new StaffRepository();
            clientRepository = new PersonRepository("Client");
            objectRepository = new ObjectRepository();
            dealRepository = new DealRepository();

            dealPresenter = new DealPresenter(dgv);

            regex = new Regex("\\[[0-9]+\\]");

            numericUpDownCost.Minimum = -1;
            numericUpDownCost.Maximum = Int32.MaxValue;
        }
        private void FillTheFields(int objID = -1)
        {
            textBoxCurrency.Text = "у.е.";

            var dealList = dealRepository.GetTable();
            Dictionary<int, DBDeal> deals = new Dictionary<int, DBDeal>();
            foreach (DBDeal curDeal in dealList)
                deals.Add(curDeal.id, curDeal);

            var staffList = staffRepository.GetTable();
            foreach (var staff in staffList)
            {
                string staffText = String.Format("[{0}] {1} {2}", staff.id, staff.surname, staff.name);
                comboBoxDealer.Items.Add(staffText);
            }
            var clientList = clientRepository.GetTable();
            foreach (var client in clientList)
            {
                string clientText = String.Format("[{0}] {1} {2}", client.id, client.surname, client.name);
                comboBoxBuyer.Items.Add(clientText);
            }
            var objectList = objectRepository.GetTable();
            foreach (var obj in objectList)
            {
                DBDeal tempDeal;
                if (!deals.TryGetValue(obj.id, out tempDeal)) //игнорируем уже проданные объекты
                {
                    string objectText = String.Format("[{0}] {1}", obj.id, obj.address);
                    comboBoxObject.Items.Add(objectText);
                }
            }
            if (objID != -1)
            {
                DBObject obj = objectRepository.GetConcreteRecord(objID);
                comboBoxObject.Items.Add(String.Format("[{0}] {1}", obj.id, obj.address));
            }
        }
        private void ExtractDataFromDeal(DBDeal deal)
        {
            try
            {
                DBStaff dealer = staffRepository.GetConcreteRecord(deal.dealer);
                this.comboBoxDealer.Text = String.Format("[{0}] {1} {2}", dealer.id, dealer.surname, dealer.name);

                DBPerson client = clientRepository.GetConcreteRecord(deal.buyer);
                this.comboBoxBuyer.Text = String.Format("[{0}] {1} {2}", client.id, client.surname, client.name);

                DBObject obj = objectRepository.GetConcreteRecord(deal.obj);
                this.comboBoxObject.Text = String.Format("[{0}] {1}", obj.id, obj.address);

                this.textBoxID.Text = deal.id.ToString();
                this.numericUpDownCost.Value = deal.cost;
                this.dateTimePickerDate.Value = deal.date;
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Ошибка"); }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            AddUpdateDeal();
            this.Close();
        }
        private void AddUpdateDeal()
        {
            //id, Dealer, Buyer, Object, Cost, Date
            Match matchDealer = regex.Match(this.comboBoxDealer.Text);
            Match matchClient = regex.Match(this.comboBoxBuyer.Text);
            Match matchObject = regex.Match(this.comboBoxObject.Text);

            deal.dealer = Convert.ToInt32(matchDealer.Value.Substring(1, matchDealer.Value.Length - 2));
            deal.buyer = Convert.ToInt32(matchClient.Value.Substring(1, matchClient.Value.Length - 2));
            deal.obj = Convert.ToInt32(matchObject.Value.Substring(1, matchObject.Value.Length - 2));

            deal.cost = Convert.ToInt32(this.numericUpDownCost.Value);
            deal.date = this.dateTimePickerDate.Value;

            if (!adding)
                dealPresenter.UpdateTable(deal);
            else
                dealPresenter.AddToTable(deal);
            dealPresenter.ShowTable();
        }

        private void comboBoxObject_TextChanged(object sender, EventArgs e)
        {
            Match matchObjectID = regex.Match(this.comboBoxObject.Text);
            int objectID = Convert.ToInt32(matchObjectID.Value.Substring(1, matchObjectID.Value.Length - 2));
            var obj = objectRepository.GetConcreteRecord(objectID);
            this.numericUpDownCost.Minimum = obj.cost;
        }
    }
}
