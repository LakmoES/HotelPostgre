using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using EditForms;
using Repositories;

namespace Admin
{
    public partial class FormAdmin : Form
    {
        private IRepositoryFactory repositoryFactory;
        private ISecureRepositoryFactory secureRepositoryFactory;

        private EntityPresenter objectPresenter;
        private CompanyPresenter companyPresenter;
        private PersonPresenter ownerPresenter;
        private StaffPresenter staffPresenter;
        private PersonPresenter clientPresenter;
        private DealPresenter dealPresenter;
        private ShowPresenter showPresenter;
        private WishPresenter wishPresenter;

        private Dictionary<int, Company> companies;
        private Dictionary<int, Deal> deals;
        private Dictionary<int, Entity> objects;
        private Dictionary<int, Person> clients;
        private Dictionary<int, Person> owners;
        private Dictionary<int, Show> shows;
        private Dictionary<int, Wish> wishes;
        private Dictionary<int, Staff> staffs;

        private ContextMenu contextMenu;
        private DataGridView selectedDGV;
        public FormAdmin(IRepositoryFactory repositoryFactory, ISecureRepositoryFactory secureRepositoryFactory)
        {
            InitializeComponent();
            this.repositoryFactory = repositoryFactory;
            this.secureRepositoryFactory = secureRepositoryFactory;
            this.textBoxYou.Text = String.Format("{0} ({1})", SecureConst.GetRoleName(User.role), User.name);

            MenuItem editItem = new MenuItem("Правка", dataGridView_Edit_Click);
            MenuItem removeItem = new MenuItem("Удалить", dataGridView_Remove_Click);
            contextMenu = new ContextMenu(new MenuItem[] { editItem, removeItem });

            selectedDGV = null;
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            objectPresenter = new EntityPresenter(this.dataGridViewObject, repositoryFactory);
            objects = objectPresenter.ShowTable(true);

            companyPresenter = new CompanyPresenter(this.dataGridViewCompany, repositoryFactory);
            companies = companyPresenter.ShowTable(true);

            ownerPresenter = new PersonPresenter(this.dataGridViewOwner, repositoryFactory, "Owner");
            owners = ownerPresenter.ShowTable(true);

            staffPresenter = new StaffPresenter(this.dataGridViewStaff, repositoryFactory);
            staffs = staffPresenter.ShowTable(true);

            clientPresenter = new PersonPresenter(this.dataGridViewClient, repositoryFactory, "Client");
            clients = clientPresenter.ShowTable(true);

            dealPresenter = new DealPresenter(this.dataGridViewDeal, repositoryFactory);
            deals = dealPresenter.ShowTable(true);

            showPresenter = new ShowPresenter(this.dataGridViewShow, repositoryFactory);
            shows = showPresenter.ShowTable(true);

            wishPresenter = new WishPresenter(this.dataGridViewWish, repositoryFactory);
            wishes = wishPresenter.ShowTable(true);
        }
        private void buttonCompanyRefresh_Click(object sender, EventArgs e)
        {
            companies = companyPresenter.ShowTable(true);
        }
        private void buttonObjectRefresh_Click(object sender, EventArgs e)
        {
            objects = objectPresenter.ShowTable(true);
        }
        private void buttonOwnerRefresh_Click(object sender, EventArgs e)
        {
            owners = ownerPresenter.ShowTable(true);
        }
        private void buttonStaffRefresh_Click(object sender, EventArgs e)
        {
            staffs = staffPresenter.ShowTable(true);
        }
        private void buttonClientRefresh_Click(object sender, EventArgs e)
        {
            clients = clientPresenter.ShowTable(true);
        }
        private void buttonDealRefresh_Click(object sender, EventArgs e)
        {
            deals = dealPresenter.ShowTable(true);
        }
        private void buttonShowRefresh_Click(object sender, EventArgs e)
        {
            shows = showPresenter.ShowTable(true);
        }
        private void buttonWishRefresh_Click(object sender, EventArgs e)
        {
            wishes = wishPresenter.ShowTable(true);
        }
        private void dataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectedDGV = sender as DataGridView;
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                selectedDGV.CurrentCell = selectedDGV.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (selectedDGV.CurrentRow.Index == selectedDGV.Rows.Count - 1) //избавляемся от клика по последней пустой строке
                    return;

                selectedDGV.Rows[e.RowIndex].Selected = true;
                selectedDGV.Focus();
                contextMenu.Show(selectedDGV, selectedDGV.PointToClient(Cursor.Position));
            }
        }
        private void dataGridView_Edit_Click(object sender, EventArgs e)
        {
            if(selectedDGV == dataGridViewCompany)
            {
                new FormAddUpdateCompanyTable(selectedDGV, repositoryFactory, selectedDGV.SelectedRows[0].Index).ShowDialog();
            }
            if (selectedDGV == dataGridViewObject)
            {
                Entity obj;
                objects.TryGetValue(Convert.ToInt32(selectedDGV.CurrentRow.Cells[0].Value), out obj);
                new FormAddUpdateObjectTable(selectedDGV, repositoryFactory, obj/*selectedDGV.CurrentRow.Index*/).ShowDialog();
            }
            if (selectedDGV == dataGridViewOwner)
            {
                Person owner;
                owners.TryGetValue(Convert.ToInt32(selectedDGV.CurrentRow.Cells[0].Value), out owner);
                new FormAddUpdatePersonTable(selectedDGV, repositoryFactory, owner, "Owner").ShowDialog();
            }
            if (selectedDGV == dataGridViewStaff)
            {
                Staff staff;
                staffs.TryGetValue(Convert.ToInt32(selectedDGV.CurrentRow.Cells[0].Value), out staff);
                new FormAddUpdatePersonTable(selectedDGV, repositoryFactory, staff, "Staff").ShowDialog();
            }
            if (selectedDGV == dataGridViewClient)
            {
                Person client;
                clients.TryGetValue(Convert.ToInt32(selectedDGV.CurrentRow.Cells[0].Value), out client);
                new FormAddUpdatePersonTable(selectedDGV, repositoryFactory, client, "Client").ShowDialog();
            }
            if (selectedDGV == dataGridViewDeal)
            {
                Deal deal;
                deals.TryGetValue(Convert.ToInt32(selectedDGV.CurrentRow.Cells[0].Value), out deal);
                new FormAddUpdateDealTable(selectedDGV, repositoryFactory, deal/*selectedDGV.CurrentRow.Index*/).ShowDialog();
            }
            if(selectedDGV == dataGridViewShow)
            {
                Show show;
                shows.TryGetValue(Convert.ToInt32(selectedDGV.CurrentRow.Cells[0].Value), out show);
                new FormAddUpdateShowTable(selectedDGV, repositoryFactory, show).ShowDialog();
            }
            if(selectedDGV == dataGridViewWish)
            {
                Wish wish;
                wishes.TryGetValue(Convert.ToInt32(selectedDGV.CurrentRow.Cells[0].Value), out wish);
                new FormAddUpdateWishTable(selectedDGV, repositoryFactory, wish).ShowDialog();
            }
        }
        private void dataGridView_Remove_Click(object sender, EventArgs e)
        {
            var cell = selectedDGV[0, selectedDGV.CurrentRow.Index];
            int id = Convert.ToInt32(cell.Value);
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                bool succeedFlag = false;
                if (selectedDGV == dataGridViewObject)
                {
                    succeedFlag = objectPresenter.DeleteFromTable(id);
                    if (succeedFlag) objectPresenter.ShowTable(true);
                }
                if (selectedDGV == dataGridViewOwner)
                {
                    succeedFlag = ownerPresenter.DeleteFromTable(id);
                    if (succeedFlag) ownerPresenter.ShowTable(true);
                }
                if (selectedDGV == dataGridViewStaff)
                {
                    succeedFlag = staffPresenter.DeleteFromTable(id);
                    if (succeedFlag) staffPresenter.ShowTable(true);
                }
                if (selectedDGV == dataGridViewClient)
                {
                    succeedFlag = clientPresenter.DeleteFromTable(id);
                    if (succeedFlag) clientPresenter.ShowTable(true);
                }
                if (selectedDGV == dataGridViewDeal)
                {
                    succeedFlag = dealPresenter.DeleteFromTable(id);
                    if (succeedFlag) dealPresenter.ShowTable(true);
                }
                if (selectedDGV == dataGridViewShow)
                {
                    succeedFlag = showPresenter.DeleteFromTable(id);
                    if (succeedFlag) showPresenter.ShowTable(true);
                }
                if (selectedDGV == dataGridViewWish)
                {
                    succeedFlag = wishPresenter.DeleteFromTable(id);
                    if (succeedFlag) wishPresenter.ShowTable(true);
                }
                if (selectedDGV == dataGridViewCompany)
                {
                    succeedFlag = companyPresenter.DeleteFromTable(id);
                    if (succeedFlag) companyPresenter.ShowTable(true);
                }

                if (succeedFlag)
                    MessageBox.Show("Успешно удалено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Удалить не удалось", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonCompanyAdd_Click(object sender, EventArgs e)
        {
            new FormAddUpdateCompanyTable(dataGridViewCompany, repositoryFactory).ShowDialog();
        }
        private void buttonObjectAdd_Click(object sender, EventArgs e)
        {
            new FormAddUpdateObjectTable(dataGridViewObject, repositoryFactory).ShowDialog();
        }
        private void buttonOwnerAdd_Click(object sender, EventArgs e)
        {
            new FormAddUpdatePersonTable(dataGridViewOwner, repositoryFactory, "Owner").ShowDialog();
        }
        private void buttonStaffAdd_Click(object sender, EventArgs e)
        {
            new FormAddUpdatePersonTable(dataGridViewStaff, repositoryFactory, "Staff").ShowDialog();
        }
        private void buttonClientAdd_Click(object sender, EventArgs e)
        {
            new FormAddUpdatePersonTable(dataGridViewClient, repositoryFactory, "Client").ShowDialog();
        }
        private void buttonDealAdd_Click(object sender, EventArgs e)
        {
            new FormAddUpdateDealTable(dataGridViewDeal, repositoryFactory).ShowDialog();
        }
        private void buttonShowAdd_Click(object sender, EventArgs e)
        {
            new FormAddUpdateShowTable(dataGridViewShow, repositoryFactory).ShowDialog();
        }
        private void buttonWishAdd_Click(object sender, EventArgs e)
        {
            new FormAddUpdateWishTable(dataGridViewWish, repositoryFactory).ShowDialog();
        }

        private void menuButtonUsers_Click(object sender, EventArgs e)
        {
            new FormUsers(repositoryFactory, secureRepositoryFactory).ShowDialog();
        }
    }
}
