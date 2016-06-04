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
        SecureUserPresenter userPresenter;
        public FormUsers()
        {
            InitializeComponent();
        }

        private void buttonUserAdd_Click(object sender, EventArgs e)
        {
            new FormAddUpdateUser().ShowDialog();
        }

        private void FormUsers_Load(object sender, EventArgs e)
        {
            userPresenter = new SecureUserPresenter(this.dataGridViewUser);
            userPresenter.ShowTable(true);
        }
    }
}
