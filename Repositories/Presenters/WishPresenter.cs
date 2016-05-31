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
            try
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
            }
            catch (Exception) { MessageBox.Show("Ошибка базы данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            if (sort)
                dgv.Sort(dgv.Columns[0], ListSortDirection.Ascending);
        }
        public bool AddToTable(DBWish wish)
        {
            List<string> errorList;
            bool checkFlag = WishValidator.checkAddition(wish, out errorList);
            try
            {
                if (checkFlag)
                    wishRepository.AddToTable(wish);
            }
            catch (Exception) { errorList.Add("Ошибка базы данных."); }

            ShowErrors(errorList);

            return checkFlag;
        }
        public bool UpdateTable(DBWish wish)
        {
            List<string> errorList;
            bool checkFlag = WishValidator.checkAddition(wish, out errorList);
            try
            {
                if (checkFlag)
                    wishRepository.UpdateTable(wish);
            }
            catch (Exception) { errorList.Add("Ошибка базы данных."); }

            ShowErrors(errorList);

            return checkFlag;
        }
        public bool DeleteFromTable(int id)
        {
            List<string> errorList;
            bool checkFlag = WishValidator.checkDelete(id, out errorList);
            try
            {
                if (checkFlag)
                    wishRepository.DeleteFromTable(id);
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
