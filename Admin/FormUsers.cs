using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Repositories;

namespace Admin
{
    public partial class FormUsers : Form
    {
        private ISecureRepositoryFactory secureRepositoryFactory;
        private IRepositoryFactory repositoryFactory;
        private SecureUserPresenter userPresenter;

        private Dictionary<string, SecureDBUser> users;
        private ContextMenu contextMenu;
        public FormUsers(IRepositoryFactory repositoryFactory, ISecureRepositoryFactory secureRepositoryFactory)
        {
            InitializeComponent();
            this.secureRepositoryFactory = secureRepositoryFactory;
            this.repositoryFactory = repositoryFactory;

            MenuItem editItem = new MenuItem("Правка", dataGridViewUser_Edit_Click);
            MenuItem removeItem = new MenuItem("Удалить", dataGridViewUser_Remove_Click);
            contextMenu = new ContextMenu(new MenuItem[] { editItem, removeItem });
        }

        private void buttonUserAdd_Click(object sender, EventArgs e)
        {
            new FormAddUpdateUser(this.dataGridViewUser, secureRepositoryFactory, repositoryFactory).ShowDialog();
        }

        private void FormUsers_Load(object sender, EventArgs e)
        {
            userPresenter = new SecureUserPresenter(this.dataGridViewUser, repositoryFactory, secureRepositoryFactory);
            users = userPresenter.ShowTable(true);
        }

        private void buttonUserRefresh_Click(object sender, EventArgs e)
        {
            users = userPresenter.ShowTable(true);
        }

        private void dataGridViewUser_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                dataGridViewUser.CurrentCell = dataGridViewUser.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (dataGridViewUser.CurrentRow.Index == dataGridViewUser.Rows.Count - 1) //избавляемся от клика по последней пустой строке
                    return;

                dataGridViewUser.Rows[e.RowIndex].Selected = true;
                dataGridViewUser.Focus();

                SecureDBUser user;
                users.TryGetValue(dataGridViewUser.SelectedRows[0].Cells[0].Value.ToString(), out user);
                if (user.db_role != 1) //редактировать и удалять администратора возможности не даем
                    contextMenu.Show(dataGridViewUser, dataGridViewUser.PointToClient(Cursor.Position));
            }
        }
        private void dataGridViewUser_Remove_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool succeedFlag = false;

                SecureDBUser user;
                users.TryGetValue(dataGridViewUser.SelectedRows[0].Cells[0].Value.ToString(), out user);
                if (user.db_role != 1)
                {
                    succeedFlag = userPresenter.DeleteFromTable(user.name);
                    if (succeedFlag) userPresenter.ShowTable(true);
                }
                if (succeedFlag)
                    MessageBox.Show("Успешно удалено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Удалить не удалось", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dataGridViewUser_Edit_Click(object sender, EventArgs e)
        {
                SecureDBUser user;
                users.TryGetValue(dataGridViewUser.CurrentRow.Cells[0].Value.ToString(), out user);
                new FormAddUpdateUser(dataGridViewUser, user, secureRepositoryFactory, repositoryFactory/*selectedDGV.CurrentRow.Index*/).ShowDialog();
            
        }
    }
}
