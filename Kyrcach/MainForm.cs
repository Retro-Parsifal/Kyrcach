using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using SD=System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kyrcach
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            CompaniForm oper = new CompaniForm();
            oper.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            NomeraForm1 oper = new NomeraForm1();
            oper.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            TarifForm oper = new TarifForm();
            oper.Show();
        }
    }
    
}
