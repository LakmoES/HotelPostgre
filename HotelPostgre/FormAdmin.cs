using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;

namespace HotelPostgre
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void buttonCompanyRefresh_Click(object sender, EventArgs e)
        {
            var list = SelectTablesQuery.getCompanyTable();
            MessageBox.Show(String.Format("Найдено {0} записей.", list.Count));
            foreach (var cur in list)
                dataGridView1.Rows.Add(cur.id, cur.title, cur.telephone, cur.address);
        }
    }
}
