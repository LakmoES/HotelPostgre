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
    public partial class FormUpdateCompanyTable : Form
    {
        CompanyPresenter companyPresenter;
        DBCompany company;
        public FormUpdateCompanyTable(DataGridView dgv, int index/*DBCompany company*/)
        {
            InitializeComponent();

            companyPresenter = new CompanyPresenter(dgv);

            company = new DBCompany(Convert.ToInt32(dgv.Rows[index].Cells[0].Value), dgv.Rows[index].Cells[1].Value.ToString(), 
                dgv.Rows[index].Cells[2].Value.ToString(), dgv.Rows[index].Cells[3].Value.ToString());

            this.textBoxID.Text = company.id.ToString();
            this.textBoxTitle.Text = company.title;
            this.textBoxTelephone.Text = company.telephone;
            this.textBoxAddress.Text = company.address;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            company.title = this.textBoxTitle.Text;
            company.telephone = this.textBoxTelephone.Text;
            company.address = this.textBoxAddress.Text;

            companyPresenter.UpdateTable(company);
            companyPresenter.ShowTable();
            this.Close();
        }
    }
}
