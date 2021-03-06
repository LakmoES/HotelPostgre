﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
using EditForms;
using System.Windows.Forms;

namespace Staff
{
    public partial class FormStaff : Form
    {
        private IRepositoryFactory repositoryFactory;

        private EntityPresenter objectPresenter;
        private PersonPresenter ownerPresenter;
        private StaffPresenter staffPresenter;
        private PersonPresenter clientPresenter;
        private DealPresenter dealPresenter;
        private ShowPresenter showPresenter;
        private WishPresenter wishPresenter;

        private ContextMenu contextMenu;
        private DataGridView selectedDGV;

        private Dictionary<int, Deal> deals;
        private Dictionary<int, Entity> objects;
        private Dictionary<int, Person> clients;
        private Dictionary<int, Person> owners;
        private Dictionary<int, Show> shows;
        private Dictionary<int, Wish> wishes;
        private Dictionary<int, Repositories.Staff> staffs;

        bool satisfShow;
        public FormStaff(IRepositoryFactory repositoryFactory)
        {
            InitializeComponent();
            this.repositoryFactory = repositoryFactory;
            satisfShow = false;
            Repositories.Staff staff = repositoryFactory.GetStaffRepository().GetConcreteRecord(User.subgroup);

            this.textBoxYou.Text = String.Format("{0} ({1})",
                SecureConst.GetRoleName(User.role),
                String.Format("{0} {1}", staff.surname, staff.name));

            MenuItem editItem = new MenuItem("Правка", dataGridView_Edit_Click);
            MenuItem removeItem = new MenuItem("Удалить", dataGridView_Remove_Click);
            contextMenu = new ContextMenu(new MenuItem[] { editItem, removeItem });

            selectedDGV = null;
        }

        private void FormStaff_Load(object sender, EventArgs e)
        {
            objectPresenter = new EntityPresenter(this.dataGridViewObject, repositoryFactory);
            objects = objectPresenter.ShowTable(true);

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
            DeleteSatis();
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
            if (selectedDGV == dataGridViewClient)
            {
                Person client;
                clients.TryGetValue(Convert.ToInt32(selectedDGV.CurrentRow.Cells[0].Value), out client);
                new FormAddUpdatePersonTable(selectedDGV, repositoryFactory, client, "Client").ShowDialog();
            }
            if (selectedDGV == dataGridViewWish)
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
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool succeedFlag = false;

                if (selectedDGV == dataGridViewWish)
                {
                    succeedFlag = wishPresenter.DeleteFromTable(id);
                    if (succeedFlag) wishPresenter.ShowTable(true);
                }

                if (succeedFlag)
                    MessageBox.Show("Успешно удалено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Удалить не удалось.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            new FormAddUpdateShowTable(selectedDGV, repositoryFactory).ShowDialog();
        }
        private void buttonWishAdd_Click(object sender, EventArgs e)
        {
            new FormAddUpdateWishTable(dataGridViewWish, repositoryFactory).ShowDialog();
        }

        private void dataGridViewObject_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Entity obj;
            objects.TryGetValue(Convert.ToInt32(dataGridViewObject.CurrentRow.Cells[0].Value), out obj);

            new FormDemandObject(obj, repositoryFactory).ShowDialog();
        }

        private void buttonClientSatisfShowHide_Click(object sender, EventArgs e)
        {
            this.groupBoxSatisf.Visible = !this.groupBoxSatisf.Visible;
            if(this.groupBoxSatisf.Visible == false && satisfShow)
            {
                DeleteSatis();
            }
        }

        private void buttonFindSatisf_Click(object sender, EventArgs e)
        {
            if (!satisfShow)
            {
                this.dataGridViewClient.ColumnCount = this.dataGridViewClient.ColumnCount + 1;
                this.dataGridViewClient.Columns[dataGridViewClient.ColumnCount - 1].HeaderText = "Satisf";
                satisfShow = true;

                
            }
            AddSatis();
        }
        private void AddSatis()
        {
            float lowerArea = Convert.ToSingle(this.numericUpDownAreaFrom.Value);
            float higherArea = Convert.ToSingle(this.numericUpDownAreaTo.Value);
            float deltaArea = Convert.ToSingle(this.numericUpDownAreaDelta.Value);
            DateTime from = this.dateTimePickerFrom.Value;
            DateTime to = this.dateTimePickerTo.Value;
            var satisfList = repositoryFactory.GetSpecialRepository().GetSatisfiedClients(lowerArea, higherArea, deltaArea, from, to);

            dataGridViewClient.Rows.Clear();

            foreach (Tuple<Person,int> tup in satisfList)
                dataGridViewClient.Rows.Add(tup.Item1.id, tup.Item1.name, tup.Item1.surname, tup.Item1.telephone, tup.Item2);
        }
        private void buttonClearSatisf_Click(object sender, EventArgs e)
        {
            DeleteSatis();
        }

        private void DeleteSatis()
        {
            if (satisfShow)
            {
                dataGridViewClient.Rows.Clear();

                clients = clientPresenter.ShowTable(true);

                this.dataGridViewClient.ColumnCount = this.dataGridViewClient.ColumnCount - 1;
                satisfShow = false;
            }
        }
    }
}
