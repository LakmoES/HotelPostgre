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

namespace Staff
{
    public partial class FormDemandObject : Form
    {
        private Entity ent;
        private ISpecialRepository specialRepository;
        public FormDemandObject(Entity ent, IRepositoryFactory repositoryFactory)
        {
            InitializeComponent();
            this.ent = ent;
            this.specialRepository = repositoryFactory.GetSpecialRepository();
        }

        private void FormDemandObject_Load(object sender, EventArgs e)
        {
            this.textBoxObjectAddress.Text = ent.address;
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            this.labelDemand.Text = specialRepository.GetDemandOfObject(ent.id, dateTimePickerFrom.Value, dateTimePickerTo.Value).ToString();
        }
    }
}
