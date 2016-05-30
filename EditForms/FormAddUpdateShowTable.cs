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
    public partial class FormAddUpdateShowTable : Form
    {
        Regex regex;
        DBShow show;
        bool adding;
        StaffRepository staffRepository;
        PersonRepository clientRepository;
        ObjectRepository objectRepository;
        ShowRepository showRepository;
        ShowPresenter showPresenter;
        public FormAddUpdateShowTable(DataGridView dgv, int index) //редактирование
        {
            InitializeComponent();
            adding = false;
            Init(dgv);

            Match matchObject = regex.Match(dgv.Rows[index].Cells[3].Value.ToString());
            int objID = Convert.ToInt32(matchObject.Value.Substring(1, matchObject.Value.Length - 2));
            FillTheFields(objID);

            Match matchShower = regex.Match(dgv.Rows[index].Cells[1].Value.ToString());
            Match matchClient = regex.Match(dgv.Rows[index].Cells[2].Value.ToString());

            show = new DBShow(Convert.ToInt32(dgv.Rows[index].Cells[0].Value.ToString()),
                Convert.ToInt32(matchShower.Value.Substring(1, matchShower.Value.Length - 2)),
                Convert.ToInt32(matchClient.Value.Substring(1, matchClient.Value.Length - 2)),
                objID,
                Convert.ToDateTime(dgv.Rows[index].Cells[4].Value.ToString())
                );
            ExtractDataFromShow(show);

            this.comboBoxObject.Enabled = false;
            this.comboBoxClient.Enabled = false;
        }
        public FormAddUpdateShowTable(DataGridView dgv) //добавление
        {
            InitializeComponent();
            adding = true;
            Init(dgv);
            FillTheFields();

            show = new DBShow(-1, -1, -1, -1, new DateTime());
        }
        private void Init(DataGridView dgv)
        {
            staffRepository = new StaffRepository();
            clientRepository = new PersonRepository("Client");
            objectRepository = new ObjectRepository();
            showRepository = new ShowRepository();

            showPresenter = new ShowPresenter(dgv);

            regex = new Regex("\\[[0-9]+\\]");
        }
        private void FillTheFields(int objID = -1)
        {
            var showList = showRepository.GetTable();
            Dictionary<int, DBShow> shows = new Dictionary<int, DBShow>();
            foreach (DBShow curShow in showList)
                shows.Add(curShow.id, curShow);

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
                comboBoxClient.Items.Add(clientText);
            }
            var objectList = objectRepository.GetTable();
            foreach (var obj in objectList)
            {
                DBShow tempShow;
                if (!shows.TryGetValue(obj.id, out tempShow)) //игнорируем уже проданные объекты
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
        private void ExtractDataFromShow(DBShow show)
        {
            try
            {
                DBStaff dealer = staffRepository.GetConcreteRecord(show.dealer);
                this.comboBoxDealer.Text = String.Format("[{0}] {1} {2}", dealer.id, dealer.surname, dealer.name);

                DBPerson client = clientRepository.GetConcreteRecord(show.client);
                this.comboBoxClient.Text = String.Format("[{0}] {1} {2}", client.id, client.surname, client.name);

                DBObject obj = objectRepository.GetConcreteRecord(show.obj);
                this.comboBoxObject.Text = String.Format("[{0}] {1}", obj.id, obj.address);

                this.textBoxID.Text = show.id.ToString();
                this.dateTimePickerDate.Value = show.date;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка"); }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            AddUpdateShow();
            this.Close();
        }
        private void AddUpdateShow()
        {
            //id, Shower, Buyer, Object, Cost, Date
            Match matchDealer = regex.Match(this.comboBoxDealer.Text);
            Match matchClient = regex.Match(this.comboBoxClient.Text);
            Match matchObject = regex.Match(this.comboBoxObject.Text);

            show.dealer = Convert.ToInt32(matchDealer.Value.Substring(1, matchDealer.Value.Length - 2));
            show.client = Convert.ToInt32(matchClient.Value.Substring(1, matchClient.Value.Length - 2));
            show.obj = Convert.ToInt32(matchObject.Value.Substring(1, matchObject.Value.Length - 2));
            
            show.date = this.dateTimePickerDate.Value;

            if (!adding)
                showPresenter.UpdateTable(show);
            else
                showPresenter.AddToTable(show);
            showPresenter.ShowTable();
        }
    }
}