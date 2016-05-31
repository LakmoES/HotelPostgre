using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public class DealPresenter
    {
        DataGridView dgv;
        IDealRepository dealRepository;
        List<DBDeal> dgvElements;

        IStaffRepository staffRepository;
        IPersonRepository clientRepository;
        IObjectRepository objectRepository;

        public DealPresenter(DataGridView dgv)
        {
            dgvElements = new List<DBDeal>();
            this.dgv = dgv;
            dealRepository = RepositoryFactory.GetDealRepository();//new DealRepository();

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
        public void ShowTable(bool sort = false)
        {
            try
            {
                var staffs = GetStaffs();
                var clients = GetClients();
                var objects = GetObjects();

                dgvElements = dealRepository.GetTable();

                dgv.Rows.Clear();
                foreach (DBDeal deal in dgvElements)
                {
                    DBStaff dealer = null;
                    DBPerson buyer = null;
                    DBObject obj = null;
                    staffs.TryGetValue(deal.dealer, out dealer);
                    clients.TryGetValue(deal.buyer, out buyer);
                    objects.TryGetValue(deal.obj, out obj);

                    dgv.Rows.Add(deal.id, String.Format("[{0}] {1} {2}", dealer.id, dealer.surname, dealer.name),
                        String.Format("[{0}] {1} {2}", buyer.id, buyer.surname, buyer.name),
                        String.Format("[{0}] {1}", obj.id, obj.address),
                        deal.cost.ToString(),
                        deal.date.ToString("dd/MM/yyyy"));
                }
            }
            catch (Exception) { MessageBox.Show("Ошибка базы данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
            if (sort)
                dgv.Sort(dgv.Columns[0], ListSortDirection.Ascending);
        }
        public bool AddToTable(DBDeal deal)
        {
            List<string> errorList;
            bool checkFlag = DealValidator.checkAddition(deal, out errorList);
            try
            {
                if (checkFlag)
                    dealRepository.AddToTable(deal);
            }
            catch (Exception) { errorList.Add("Ошибка базы данных."); }

            ShowErrors(errorList);

            return checkFlag;
        }
        public bool UpdateTable(DBDeal deal)
        {
            List<string> errorList;
            bool checkFlag = DealValidator.checkAddition(deal, out errorList);
            try
            {
                if (checkFlag)
                    dealRepository.UpdateTable(deal);
            }
            catch(Exception) { errorList.Add("Ошибка базы данных."); }

            ShowErrors(errorList);

            return checkFlag;
        }
        public bool DeleteFromTable(int id)
        {
            List<string> errorList;
            bool checkFlag = DealValidator.checkDelete(id, out errorList);
            try
            { 
            if (checkFlag)
                dealRepository.DeleteFromTable(id);
            }
            catch (Exception) { errorList.Add("Ошибка базы данных."); }

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
