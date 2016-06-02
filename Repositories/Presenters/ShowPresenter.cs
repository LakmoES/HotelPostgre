using System;
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
        List<Show> dgvElements;

        IStaffRepository staffRepository;
        IPersonRepository clientRepository;
        IObjectRepository objectRepository;

        public ShowPresenter(DataGridView dgv)
        {
            dgvElements = new List<Show>();
            this.dgv = dgv;
            showRepository = RepositoryFactory.GetShowRepository();//new ShowRepository();

            staffRepository = RepositoryFactory.GetStaffRepository();//new StaffRepository();
            clientRepository = RepositoryFactory.GetClientRepository();//new PersonRepository("Client");
            objectRepository = RepositoryFactory.GetObjectRepository();//new ObjectRepository();

        }
        private Dictionary<int, Staff> GetStaffs()
        {
            var staffs = staffRepository.GetTable();
            var assocArray = new Dictionary<int, Staff>();

            //staffs.Sort((x, y) => x.id.CompareTo(y.id));
            foreach (Staff staff in staffs)
                assocArray.Add(staff.id, staff);

            return assocArray;
        }
        private Dictionary<int, Person> GetClients()
        {
            var clients = clientRepository.GetTable();
            var assocArray = new Dictionary<int, Person>();

            //clients.Sort((x, y) => x.id.CompareTo(y.id));
            foreach (Person client in clients)
                assocArray.Add(client.id, client);

            return assocArray;
        }
        private Dictionary<int, Entity> GetObjects()
        {
            var objects = objectRepository.GetTable();
            var assocArray = new Dictionary<int, Entity>();

            //clients.Sort((x, y) => x.id.CompareTo(y.id));
            foreach (Entity obj in objects)
                assocArray.Add(obj.id, obj);

            return assocArray;
        }
        public Dictionary<int, Show> ShowTable(bool sort = false)
        {
            try
            {
                var staffs = GetStaffs();
                var clients = GetClients();
                var objects = GetObjects();

                dgvElements = showRepository.GetTable();
                dgv.Rows.Clear();
                foreach (Show show in dgvElements)
                {
                    Staff dealer = null;
                    Person client = null;
                    Entity obj = null;
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

            Dictionary<int, Show> dict = new Dictionary<int, Show>();
            foreach (var el in dgvElements)
                dict.Add(el.id, el);
            return dict;
        }
        public bool AddToTable(Show show)
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
        public bool UpdateTable(Show show)
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
