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
        public void ShowTable(bool sort = false)
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
                    String.Format("[{0}] {1} {2}", dealer.id, dealer.surname, dealer.name),
                    String.Format("[{0}] {1} {2}", client.id, client.surname, client.name),
                    String.Format("[{0}] {1}", obj.id, obj.address),
                    show.date.ToString("dd/MM/yyyy"));
            }
            if (sort)
                dgv.Sort(dgv.Columns[0], ListSortDirection.Ascending);
        }
        public void AddToTable(DBShow show)
        {
            showRepository.AddToTable(show);
        }
        public void UpdateTable(DBShow show)
        {
            showRepository.UpdateTable(show);
        }
        public void DeleteFromTable(int id)
        {
            showRepository.DeleteFromTable(id);
        }
    }
}
