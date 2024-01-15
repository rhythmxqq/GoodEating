using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodEating
{
    public partial class Form2 : Form
    {
        Boolean checkLog = true;
        Boolean checkPas = true;
       
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void buttonEnterReg_Click(object sender, EventArgs e)
        {
            if (passwordtextBox.Text.Equals(passwordCheckTextBox.Text))
            {
                Db db = new Db();        
                SqlConnection connection = db.getConnection();
                connection.Open();

                // Проверяем, существует ли уже пользователь с таким логином
                string checkUserQuery = "SELECT COUNT(*) FROM userTable WHERE login = @login";
                using (SqlCommand checkUserCommand = new SqlCommand(checkUserQuery, connection))
                {
                    checkUserCommand.Parameters.AddWithValue("@login", loginTextBox.Text);
                    int userExists = (int)checkUserCommand.ExecuteScalar();

                    if (userExists > 0)
                    {
                        MessageBox.Show("Данный логин уже занят");
                        checkLog = false;
                    }
                    else 
                        checkLog = true;
                
                }
                if (checkLog == true) {
                    // Начинаем транзакцию
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Вставляем данные в таблицу userTable
                            string insertUserQuery = @"
                        INSERT INTO userTable (login, password, name)
                        OUTPUT INSERTED.id_user
                        VALUES (@login, @password, @name);";

                            int userId;
                            using (SqlCommand insertUserCommand = new SqlCommand(insertUserQuery, connection, transaction))
                            {
                                insertUserCommand.Parameters.AddWithValue("@login", loginTextBox.Text);
                                insertUserCommand.Parameters.AddWithValue("@password", passwordtextBox.Text); // Здесь должно быть хеширование пароля
                                insertUserCommand.Parameters.AddWithValue("@name", nameTextBox.Text);

                                // Получаем ID нового пользователя
                                userId = (int)insertUserCommand.ExecuteScalar();
                            }

                            // Вставляем данные в таблицу normaTable
                            string insertProfileQuery = @"
                        INSERT INTO normaTable (id_user, allergy, weight, height)
                        VALUES (@id_user, @allergy, @weight, @height);";

                            using (SqlCommand insertProfileCommand = new SqlCommand(insertProfileQuery, connection, transaction))
                            {
                                insertProfileCommand.Parameters.AddWithValue("@id_user", userId);
                                insertProfileCommand.Parameters.AddWithValue("@allergy", allergiaComboBox1.Text);
                                insertProfileCommand.Parameters.AddWithValue("@weight", weightTextBox.Text);
                                insertProfileCommand.Parameters.AddWithValue("@height", hightTextBox.Text);

                                insertProfileCommand.ExecuteNonQuery();
                            }

                            // Подтверждаем транзакцию
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            // В случае ошибки откатываем транзакцию
                            transaction.Rollback();
                            MessageBox.Show("что-то не робит");
                        }
                        MessageBox.Show("Вы успешно зарегестрировались");
                        Form1 form1 = new Form1();
                        form1.ShowDialog();
                    }
                    
                }   
            }
            else
                MessageBox.Show("Ваш пароль не совпадает");
        }
    }
}
