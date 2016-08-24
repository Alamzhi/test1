using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsersPool
{
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            var lr = this.reportViewer1.LocalReport.DataSources.FirstOrDefault();
            if (lr != null)
            {
                var list = User.GetAll();
                if (list == null || list.Count==0)
                {
                    MessageBox.Show("Список пуст.");
                }
                lr.Value = list;
            }
            this.reportViewer1.RefreshReport();
        }
    }
}
