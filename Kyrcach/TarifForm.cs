using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using SD = System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kyrcach
{
    public partial class TarifForm : Form
    {
        public TarifForm()
        {
            InitializeComponent();
        }

        public MySqlConnection mycon;
        public MySqlCommand mycom;
        public string connect = "server=localhost; port=3306;username=root;password=;database=cellular;charset=utf8;";
        public SD.DataSet ds;

        private void button1_Click(object sender, EventArgs e)//проверка подключения к БД
        {
            try
            {
                mycon = new MySqlConnection(connect);
                mycon.Open();
                MessageBox.Show("Connect");
                mycon.Close();
            }
            catch
            {
                MessageBox.Show("No connect");
            }
        }

        private void zapros_Click(object sender, EventArgs e)//запрос и вывод данных из бд
        {
            try
            {
                string script = "SELECT * FROM tarif";
                mycon = new MySqlConnection(connect);
                mycon.Open();
                MySqlDataAdapter ms_data = new MySqlDataAdapter(script, connect);
                SD.DataTable table = new SD.DataTable();
                ms_data.Fill(table);
                dgv.DataSource = table;
                mycon.Close();
            }
            catch
            {
                MessageBox.Show("No connect");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm oper = new MainForm();
            oper.Show();
        }
    }
}
