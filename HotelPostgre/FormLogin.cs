using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelPostgre
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            try
            {
                //SQLProcessor.Instance.testRead(dataGridView1);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormAdmin().ShowDialog();
            this.Show();
        }
        
    }
}
