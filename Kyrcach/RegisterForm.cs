using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kyrcach
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            userNameField.Text = "Введите Имя";
            userSurnameField.Text = "Введите Фамилию";
            loginField.Text = "Введите Логин";
            passField.Text = "Введите Пароль";
        }

        private void userNameField_Enter(object sender, EventArgs e)
        {
            if (userNameField.Text == "Введите Имя")
                userNameField.Text = "";
        }

        private void userNameField_Leave(object sender, EventArgs e)
        {
            if (userNameField.Text == "")
                userNameField.Text = "Введите Имя";
        }

        private void userSurnameField_Enter(object sender, EventArgs e)
        {
            if (userSurnameField.Text == "Введите Фамилию")
                userSurnameField.Text = "";
        }

        private void userSurnameField_Leave(object sender, EventArgs e)
        {
            if (userSurnameField.Text == "")
                userSurnameField.Text = "Введите Фамилию";
        }

        private void loginField_Enter(object sender, EventArgs e)
        {
            if (loginField.Text == "Введите Логин")
                loginField.Text = "";
        }

        private void loginField_Leave(object sender, EventArgs e)
        {
            if (loginField.Text == "")
                loginField.Text = "Введите Логин";
        }

        private void passField_Enter(object sender, EventArgs e)
        {
            if (passField.Text == "Введите Пароль")
                passField.Text = "";
        }

        private void passField_Leave(object sender, EventArgs e)
        {
            if (passField.Text == "")
                passField.Text = "Введите Пароль";
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            
            if (userSurnameField.Text == "Введите Фамилию")
            {
                MessageBox.Show("Введите Фамилию");
                return;
            }
            
            if (userNameField.Text == "Введите Имя")
            {
                MessageBox.Show("Введите Имя");
                return;
            }

            if (loginField.Text == "Введите Логин")
            {
                MessageBox.Show("Введите Логин");
                return;
            }
            if (passField.Text == "Введите Пароль")
            {
                MessageBox.Show("Введите Пароль");
                return;
            }

            if (isUserExists())
                return;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `pass`, `name`, `surname`) VALUES (@login, @pass, @name, @surname)", db.GetConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = loginField.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = passField.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = userNameField.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = userSurnameField.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Аккаунт был создан");
            else
                MessageBox.Show("Аккаунт не был создан");


            db.closeConnection();

        }



        public Boolean isUserExists()
        {
        DB db = new DB();

        DataTable table = new DataTable();

        MySqlDataAdapter adapter = new MySqlDataAdapter();

        MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.GetConnection());

        command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginField.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
               MessageBox.Show("Такой логин уже существует");
                return true;
            }  
            else
            {
                return false;
            }
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Operator oper = new Operator();
            oper.Show();
        }
    }
}
