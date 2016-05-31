using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
    public partial class FormAddUpdateUser : Form
    {
        public FormAddUpdateUser()
        {
            InitializeComponent();
        }

        private void comboBoxRole_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Добавление / редактирование", "[Заглушка]");
            this.Close();
        }
    }
}
