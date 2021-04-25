using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace der35_Personel_Kayıtları_SQL
{
    public partial class FormRapor : Form
    {
        public FormRapor()
        {
            InitializeComponent();
        }

        private void FormRapor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'PersonelVeriTabaniDataSet1.TBL_PERSONEL' table. You can move, or remove it, as needed.
            this.TBL_PERSONELTableAdapter.Fill(this.PersonelVeriTabaniDataSet1.TBL_PERSONEL);

            this.reportViewer1.RefreshReport();
        }
    }
}
