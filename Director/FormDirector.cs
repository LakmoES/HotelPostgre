using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EditForms;
using Repositories;

namespace Director
{
    public partial class FormDirector : Form
    {
        ObjectPresenter objectPresenter;
        PersonPresenter ownerPresenter;
        StaffPresenter staffPresenter;
        PersonPresenter clientPresenter;
        DealPresenter dealPresenter;
        ShowPresenter showPresenter;
        WishPresenter wishPresenter;

        ContextMenu contextMenu;
        DataGridView selectedDGV;

        public FormDirector()
        {
            InitializeComponent();

            MenuItem editItem = new MenuItem("Правка", dataGridView_Edit_Click);
            MenuItem removeItem = new MenuItem("Удалить", dataGridView_Remove_Click);
            contextMenu = new ContextMenu(new MenuItem[] { editItem, removeItem });

            selectedDGV = null;
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            objectPresenter = new ObjectPresenter(this.dataGridViewObject);
            objectPresenter.ShowTable(true);

            ownerPresenter = new PersonPresenter(this.dataGridViewOwner, "Owner");
            ownerPresenter.ShowTable(true);

            staffPresenter = new StaffPresenter(this.dataGridViewStaff);
            staffPresenter.ShowTable(true);

            clientPresenter = new PersonPresenter(this.dataGridViewClient, "Client");
            clientPresenter.ShowTable(true);

            dealPresenter = new DealPresenter(this.dataGridViewDeal);
            dealPresenter.ShowTable(true);

            showPresenter = new ShowPresenter(this.dataGridViewShow);
            showPresenter.ShowTable(true);

            wishPresenter = new WishPresenter(this.dataGridViewWish);
            wishPresenter.ShowTable(true);
        }
        private void buttonObjectRefresh_Click(object sender, EventArgs e)
        {
            objectPresenter.ShowTable(true);
        }
        private void buttonOwnerRefresh_Click(object sender, EventArgs e)
        {
            ownerPresenter.ShowTable(true);
        }
        private void buttonStaffRefresh_Click(object sender, EventArgs e)
        {
            staffPresenter.ShowTable(true);
        }
        private void buttonClientRefresh_Click(object sender, EventArgs e)
        {
            clientPresenter.ShowTable(true);
        }
        private void buttonDealRefresh_Click(object sender, EventArgs e)
        {
            dealPresenter.ShowTable(true);
        }
        private void buttonShowRefresh_Click(object sender, EventArgs e)
        {
            showPresenter.ShowTable(true);
        }
        private void buttonWishRefresh_Click(object sender, EventArgs e)
        {
            wishPresenter.ShowTable(true);
        }
        private void dataGridView_SelectAndShowMenu(object sender, MouseEventArgs e)
        {
            selectedDGV = sender as DataGridView;
            if (e.Button == MouseButtons.Right)
            {
                selectedDGV.ClearSelection();
                DataGridView.HitTestInfo hittestinfo = selectedDGV.HitTest(e.X, e.Y);
                if (hittestinfo.RowIndex == selectedDGV.Rows.Count - 1) //пропускаем клик по последней пустой строке
                    return;

                if (hittestinfo != null && hittestinfo.Type == DataGridViewHitTestType.Cell)
                {
                    var activeRow = selectedDGV.Rows[hittestinfo.RowIndex];
                    activeRow.Selected = true;
                    contextMenu.Show(selectedDGV, new Point(e.X, e.Y));
                }

            }
        }
        private void dataGridView_Edit_Click(object sender, EventArgs e)
        {
            if (selectedDGV == dataGridViewObject)
            {
                new FormAddUpdateObjectTable(selectedDGV, selectedDGV.CurrentRow.Index).ShowDialog();
            }
            if (selectedDGV == dataGridViewOwner)
            {
                new FormAddUpdatePersonTable(selectedDGV, selectedDGV.CurrentRow.Index, "Owner").ShowDialog();
            }
            if (selectedDGV == dataGridViewStaff)
            {
                new FormAddUpdatePersonTable(selectedDGV, selectedDGV.CurrentRow.Index, "Staff").ShowDialog();
            }
            if (selectedDGV == dataGridViewClient)
            {
                new FormAddUpdatePersonTable(selectedDGV, selectedDGV.CurrentRow.Index, "Client").ShowDialog();
            }
            if (selectedDGV == dataGridViewDeal)
            {
                new FormAddUpdateDealTable(selectedDGV, selectedDGV.CurrentRow.Index).ShowDialog();
            }
            if (selectedDGV == dataGridViewShow)
            {
                new FormAddUpdateShowTable(selectedDGV, selectedDGV.CurrentRow.Index).ShowDialog();
            }
            if (selectedDGV == dataGridViewWish)
            {
                new FormAddUpdateWishTable(selectedDGV, selectedDGV.CurrentRow.Index).ShowDialog();
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

                //if (selectedDGV == dataGridViewObject)
                //{
                //    MessageBox.Show("У вас нет прав на удаление в этой таблице", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                //if (selectedDGV == dataGridViewOwner)
                //{
                //    MessageBox.Show("У вас нет прав на удаление в этой таблице", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                if (selectedDGV == dataGridViewStaff)
                {
                    if (RepositoryFactory.GetStaffRepository().GetConcreteRecord(id).company == User.subrole)
                    {
                        succeedFlag = staffPresenter.DeleteFromTable(id);
                        if (succeedFlag) staffPresenter.ShowTable(true);
                    }
                }
                //if (selectedDGV == dataGridViewClient)
                //{
                //    MessageBox.Show("У вас нет прав на удаление в этой таблице", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                //if (selectedDGV == dataGridViewDeal)
                //{
                //    MessageBox.Show("У вас нет прав на удаление в этой таблице", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                //if (selectedDGV == dataGridViewShow)
                //{
                //    MessageBox.Show("У вас нет прав на удаление в этой таблице", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                if (selectedDGV == dataGridViewWish)
                {
                    succeedFlag = wishPresenter.DeleteFromTable(id);
                    if (succeedFlag) wishPresenter.ShowTable(true);
                }

                if (succeedFlag)
                    MessageBox.Show("Успешно удалено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Удалить не удалось", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void buttonObjectAdd_Click(object sender, EventArgs e)
        {
            new FormAddUpdateObjectTable(dataGridViewObject).ShowDialog();
        }
        private void buttonOwnerAdd_Click(object sender, EventArgs e)
        {
            new FormAddUpdatePersonTable(dataGridViewOwner, "Owner").ShowDialog();
        }
        private void buttonStaffAdd_Click(object sender, EventArgs e)
        {
            new FormAddUpdatePersonTable(dataGridViewStaff, "Staff").ShowDialog();
        }
        private void buttonClientAdd_Click(object sender, EventArgs e)
        {
            new FormAddUpdatePersonTable(dataGridViewClient, "Client").ShowDialog();
        }
        private void buttonDealAdd_Click(object sender, EventArgs e)
        {
            new FormAddUpdateDealTable(dataGridViewDeal).ShowDialog();
        }
        private void buttonShowAdd_Click(object sender, EventArgs e)
        {
            new FormAddUpdateShowTable(selectedDGV).ShowDialog();
        }
        private void buttonWishAdd_Click(object sender, EventArgs e)
        {
            new FormAddUpdateWishTable(dataGridViewWish).ShowDialog();
        }
    }
}
