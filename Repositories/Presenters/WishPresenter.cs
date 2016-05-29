using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repositories
{
    public class WishPresenter
    {
        DataGridView dgv;
        IWishRepository wishRepository;
        List<DBWish> dgvElements;

        IPersonRepository clientRepository;

        public WishPresenter(DataGridView dgv)
        {
            dgvElements = new List<DBWish>();
            this.dgv = dgv;
            wishRepository = RepositoryFactory.GetWishRepository();//new WishRepository();

            clientRepository = RepositoryFactory.GetClientRepository();//new PersonRepository("Client");

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
        public void ShowTable(bool sort = false)
        {
            var clients = GetClients();

            dgvElements = wishRepository.GetTable();
            dgv.Rows.Clear();
            foreach (DBWish wish in dgvElements)
            {
                //int id, int client, string township, string apartamentOrHouse, int area, int numberOfRooms, int cost
                DBPerson client = null;
                clients.TryGetValue(wish.client, out client);

                dgv.Rows.Add(wish.id,
                    String.Format("[{0}] {1} {2}", client.id, client.surname, client.name),
                    wish.township,
                    wish.apartamentOrHouse,
                    wish.area.ToString(),
                    wish.numberOfRooms.ToString(),
                    wish.cost);
            }
            if (sort)
                dgv.Sort(dgv.Columns[0], ListSortDirection.Ascending);
        }
        public void AddToTable(DBWish wish)
        {
            wishRepository.AddToTable(wish);
        }
        public void UpdateTable(DBWish wish)
        {
            wishRepository.UpdateTable(wish);
        }
        public void DeleteFromTable(int id)
        {
            wishRepository.DeleteFromTable(id);
        }
    }
}
