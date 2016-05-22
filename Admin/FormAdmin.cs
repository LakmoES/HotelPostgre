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
using Repositories;

namespace Admin
{
    public partial class FormAdmin : Form
    {
        NpgsqlConnection conn;
        ObjectPresenter objectPresenter;
        CompanyPresenter companyPresenter;
        PersonPresenter ownerPresenter;

        CompanyController companyController;
        ObjectController objectController;
        PersonController ownerController;

        ContextMenu contextMenu;
        DataGridView selectedDGV;
        public FormAdmin(NpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;

            companyController = new CompanyController(dataGridViewCompany);
            objectController = new ObjectController(dataGridViewObject);
            ownerController = new PersonController(dataGridViewOwner, "Owner");

            DBConnection.Instance.setConnection(conn);
            DBConnection.Instance.openConnection();

            MenuItem editItem = new MenuItem("Правка", dataGridView_Edit_Click);
            MenuItem removeItem = new MenuItem("Удалить", dataGridView_Remove_Click);
            contextMenu = new ContextMenu(new MenuItem[] { editItem, removeItem });

            selectedDGV = null;
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            objectPresenter = new ObjectPresenter(this.dataGridViewObject);
            objectPresenter.ShowTable(true);

            companyPresenter = new CompanyPresenter(this.dataGridViewCompany);
            companyPresenter.ShowTable(true);

            ownerPresenter = new PersonPresenter(this.dataGridViewOwner, "Owner");
            ownerPresenter.ShowTable(true);
        }
        private void buttonCompanyRefresh_Click(object sender, EventArgs e)
        {
            companyPresenter.ShowTable(true);
        }

        private void buttonObjectRefresh_Click(object sender, EventArgs e)
        {
            objectPresenter.ShowTable(true);
        }

        private void buttonOwnerRefresh_Click(object sender, EventArgs e)
        {
            ownerPresenter.ShowTable(true);
        }

        private void FormAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            DBConnection.Instance.closeConnection();
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
            if(selectedDGV == dataGridViewCompany)
            {
                new FormAddUpdateCompanyTable(selectedDGV, selectedDGV.SelectedRows[0].Index).ShowDialog();
            }
            if (selectedDGV == dataGridViewObject)
            {
                new FormAddUpdateObjectTable(selectedDGV, selectedDGV.CurrentRow.Index).ShowDialog();
            }
            if (selectedDGV == dataGridViewOwner)
            {
                new FormAddUpdatePersonTable(selectedDGV, selectedDGV.CurrentRow.Index, "Owner").ShowDialog();
            }
        }
        private void dataGridView_Remove_Click(object sender, EventArgs e)
        {
            var cell = selectedDGV[0, selectedDGV.CurrentRow.Index];
            int id = Convert.ToInt32(cell.Value);
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (selectedDGV == dataGridViewCompany)
                {
                    companyController.checkDelete(id);
                    companyPresenter.ShowTable();
                }
                if (selectedDGV == dataGridViewObject)
                {
                    objectController.checkDelete(id);
                    objectPresenter.ShowTable();
                }
                if(selectedDGV == dataGridViewOwner)
                {
                    ownerController.checkDelete(id);
                    ownerPresenter.ShowTable();
                }
            }
        }

        private void buttonCompanyAdd_Click(object sender, EventArgs e)
        {
            new FormAddUpdateCompanyTable(dataGridViewCompany).ShowDialog();
        }

        private void buttonObjectAdd_Click(object sender, EventArgs e)
        {
            new FormAddUpdateObjectTable(dataGridViewObject).ShowDialog();
        }

        private void buttonOwnerAdd_Click(object sender, EventArgs e)
        {
            new FormAddUpdatePersonTable(dataGridViewOwner, "Owner").ShowDialog();
        }
    }
}
