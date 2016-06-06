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
        List<Wish> dgvElements;

        IPersonRepository clientRepository;

        public WishPresenter(DataGridView dgv, IRepositoryFactory repositoryFactory)
        {
            dgvElements = new List<Wish>();
            this.dgv = dgv;
            wishRepository = repositoryFactory.GetWishRepository();//new WishRepository();

            clientRepository = repositoryFactory.GetClientRepository();//new PersonRepository("Client");

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
        public Dictionary<int, Wish> ShowTable(bool sort = false)
        {
            try
            {
                var clients = GetClients();

                dgvElements = wishRepository.GetTable();
                dgv.Rows.Clear();
                foreach (Wish wish in dgvElements)
                {
                    //int id, int client, string township, string apartamentOrHouse, int area, int numberOfRooms, int cost
                    Person client = null;
                    clients.TryGetValue(wish.client, out client);

                    dgv.Rows.Add(wish.id,
                        String.Format("{1} {2}", client.id, client.surname, client.name),
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

            Dictionary<int, Wish> dict = new Dictionary<int, Wish>();
            foreach (var el in dgvElements)
                dict.Add(el.id, el);
            return dict;
        }
        public bool AddToTable(Wish wish)
        {
            List<string> errorList;
            bool checkFlag = WishValidator.checkAddition(wish, out errorList);
            try
            {
                if (checkFlag)
                    wishRepository.AddToTable(wish);
            }
            catch (Npgsql.PostgresException pEx) { errorList.Add("Ошибка базы данных.\r\nКод ошибки: " + pEx.SqlState); checkFlag = false; }
            catch (Exception) { errorList.Add("Ошибка базы данных."); checkFlag = false; }

            ShowErrors(errorList);

            return checkFlag;
        }
        public bool UpdateTable(Wish wish)
        {
            List<string> errorList;
            bool checkFlag = WishValidator.checkAddition(wish, out errorList);
            try
            {
                if (checkFlag)
                    wishRepository.UpdateTable(wish);
            }
            catch (Npgsql.PostgresException pEx) { errorList.Add("Ошибка базы данных.\r\nКод ошибки: " + pEx.SqlState); checkFlag = false; }
            catch (Exception) { errorList.Add("Ошибка базы данных."); checkFlag = false; }

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
            catch (Npgsql.PostgresException pEx) { errorList.Add("Ошибка базы данных.\r\nКод ошибки: " + pEx.SqlState); checkFlag = false; }
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
