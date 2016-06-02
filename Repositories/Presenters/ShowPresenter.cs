﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public class ShowPresenter
    {
        DataGridView dgv;
        IShowRepository showRepository;
        List<DBShow> dgvElements;

        IStaffRepository staffRepository;
        IPersonRepository clientRepository;
        IObjectRepository objectRepository;

        public ShowPresenter(DataGridView dgv)
        {
            dgvElements = new List<DBShow>();
            this.dgv = dgv;
            showRepository = RepositoryFactory.GetShowRepository();//new ShowRepository();

            staffRepository = RepositoryFactory.GetStaffRepository();//new StaffRepository();
            clientRepository = RepositoryFactory.GetClientRepository();//new PersonRepository("Client");
            objectRepository = RepositoryFactory.GetObjectRepository();//new ObjectRepository();

        }
        private Dictionary<int, DBStaff> GetStaffs()
        {
            var staffs = staffRepository.GetTable();
            var assocArray = new Dictionary<int, DBStaff>();

            //staffs.Sort((x, y) => x.id.CompareTo(y.id));
            foreach (DBStaff staff in staffs)
                assocArray.Add(staff.id, staff);

            return assocArray;
        }
        private Dictionary<int, DBPerson> GetClients()
        {
            var clients = clientRepository.GetTable();
            var assocArray = new Dictionary<int, DBPerson>();

            //clients.Sort((x, y) => x.id.CompareTo(y.id));
            foreach (DBPerson client in clients)
                assocArray.Add(client.id, client);

            return assocArray;
        }
        private Dictionary<int, DBObject> GetObjects()
        {
            var objects = objectRepository.GetTable();
            var assocArray = new Dictionary<int, DBObject>();

            //clients.Sort((x, y) => x.id.CompareTo(y.id));
            foreach (DBObject obj in objects)
                assocArray.Add(obj.id, obj);

            return assocArray;
        }
        public Dictionary<int, DBShow> ShowTable(bool sort = false)
        {
            try
            {
                var staffs = GetStaffs();
                var clients = GetClients();
                var objects = GetObjects();

                dgvElements = showRepository.GetTable();
                dgv.Rows.Clear();
                foreach (DBShow show in dgvElements)
                {
                    DBStaff dealer = null;
                    DBPerson client = null;
                    DBObject obj = null;
                    staffs.TryGetValue(show.dealer, out dealer);
                    clients.TryGetValue(show.client, out client);
                    objects.TryGetValue(show.obj, out obj);

                    dgv.Rows.Add(show.id,
                        String.Format("{1} {2}", dealer.id, dealer.surname, dealer.name),
                        String.Format("{1} {2}", client.id, client.surname, client.name),
                        obj.address,
                        show.date.ToString("dd/MM/yyyy"));
                }
            }
            catch (Exception) { MessageBox.Show("Ошибка базы данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            if (sort)
                dgv.Sort(dgv.Columns[0], ListSortDirection.Ascending);

            Dictionary<int, DBShow> dict = new Dictionary<int, DBShow>();
            foreach (var el in dgvElements)
                dict.Add(el.id, el);
            return dict;
        }
        public bool AddToTable(DBShow show)
        {
            List<string> errorList;
            bool checkFlag = ShowValidator.checkAddition(show, out errorList);
            try
            {
                if (checkFlag)
                    showRepository.AddToTable(show);
            }
            catch (Exception) { errorList.Add("Ошибка базы данных."); checkFlag = false; }

            ShowErrors(errorList);

            return checkFlag;
        }
        public bool UpdateTable(DBShow show)
        {
            List<string> errorList;
            bool checkFlag = ShowValidator.checkAddition(show, out errorList);
            try
            {
                if (checkFlag)
                    showRepository.UpdateTable(show);
            }
            catch (Exception) { errorList.Add("Ошибка базы данных."); checkFlag = false; }

            ShowErrors(errorList);

            return checkFlag;
        }
        public bool DeleteFromTable(int id)
        {
            List<string> errorList;
            bool checkFlag = ShowValidator.checkDelete(id, out errorList);
            try
            {
                if (checkFlag)
                    showRepository.DeleteFromTable(id);
            }
            catch (Exception) { errorList.Add("Ошибка базы данных."); checkFlag = false; }

            ShowErrors(errorList);

            return checkFlag;
        }

        private void ShowErrors(List<string> errorList)
        {
            if (errorList.Count == 0)
                return;

            string errors = "";
            foreach (string s in errorList)
                errors += s + System.Environment.NewLine;
            MessageBox.Show(errors, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
