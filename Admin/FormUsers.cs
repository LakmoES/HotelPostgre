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
        private IRepositoryFactory repositoryFactory;
        private SecureUserPresenter userPresenter;
        public FormUsers(IRepositoryFactory repositoryFactory)
        {
            InitializeComponent();
            this.repositoryFactory = repositoryFactory;
        }

        private void buttonUserAdd_Click(object sender, EventArgs e)
        {
            new FormAddUpdateUser().ShowDialog();
        }

        private void FormUsers_Load(object sender, EventArgs e)
        {
            userPresenter = new SecureUserPresenter(this.dataGridViewUser, repositoryFactory);
            userPresenter.ShowTable(true);
        }
    }
}
