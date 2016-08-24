using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace UsersPool
{
    public partial class Form1 : Form
    {
        //private readonly object _locker = new object();
        //private string path = "pool.xml";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = new User
            {
                Fam = txFam.Text,
                Im = txIm.Text,
                Om = txOt.Text,
                Login = txLogin.Text,
                Pass = txPass.Text
            };
            user.SaveInXML();

            string okText = string.Format("Пользователь '{0} {1} {2}' успешно добавлен", txFam.Text, txIm.Text,
                txOt.Text);
            Logger.WriteInEventLog(okText);
            MessageBox.Show(okText);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            FormReport f = new FormReport();
            f.ShowDialog();
        }
    }
}
