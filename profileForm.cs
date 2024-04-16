using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodEating
{
    public partial class profileForm : Form
    {
        private int _userId = 0;

        public profileForm(int userId)
        {
            _userId = userId;
            InitializeComponent();
        }
       public void loginLoad() {
            Db db = new Db();
            using (SqlConnection connection = db.getConnection())
            {              
                db.openConnection();
                String quary = "SELECT login FROM userTable WHERE id_user = @id";
                SqlCommand command1 = new SqlCommand(quary, connection);
                command1.Parameters.AddWithValue("@id", _userId);
                String login = command1.ExecuteScalar().ToString();
                
                loginLabel.Text = login;
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            string input = weightTextBoxUpdate.Text;
            string input1 = heightTextBoxUpdate.Text;

            // Создание регулярного выражения
            Regex regex = new Regex(@"[a-zA-Zа-яА-Я]");

            // Проверка: возвращает true, если в строке есть хотя бы одна буква
            bool containsLetter = regex.IsMatch(input);
            bool containsLetter1 = regex.IsMatch(input1);

            if (containsLetter || containsLetter1)
            {
                MessageBox.Show("данные введены неправильно");
            }
            else
            {
                string weight = weightTextBoxUpdate.Text;
                string height = heightTextBoxUpdate.Text;
                string gender = comboBoxManOrWoman.Text;
                Db db = new Db();
                using (SqlConnection connection = db.getConnection())
                {
                    db.openConnection();
                    string quary = "UPDATE normaTable SET weight=@weight, height=@height, gender=@gender WHERE id_user=@id_user";
                    SqlCommand command = new SqlCommand(quary, connection);
                    command.Parameters.AddWithValue("@weight", weight);
                    command.Parameters.AddWithValue("@height", height);
                    command.Parameters.AddWithValue("@gender", gender);
                    command.Parameters.AddWithValue("@id_user", _userId);

                    command.ExecuteNonQuery();
                }
                mainFormMb formMb = new mainFormMb(_userId);
                formMb.ShowDialog();
            }
        }

        private void profileForm_Load(object sender, EventArgs e)
        {
           loginLoad();
        }

        private void updatePasswordButton_Click(object sender, EventArgs e)
        {
            UpdatePasswordForm pasForm = new UpdatePasswordForm(_userId);
            pasForm.ShowDialog();
        }

        private void historyButton_Click(object sender, EventArgs e)
        {
            DietHistoryForm form3 = new DietHistoryForm(_userId);
            form3.ShowDialog();
        }

        private void profileForm_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor("C:\\Users\\gorilla\\Desktop\\NikitaNOT DELETE\\visualStudioNikita\\GoodEating\\Resources\\busybutclickable_100191.ico");
        }

        private void historyButton_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor("C:\\Users\\gorilla\\Desktop\\NikitaNOT DELETE\\visualStudioNikita\\GoodEating\\Resources\\hand_curso.ico");
        }

        private void updatePasswordButton_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor("C:\\Users\\gorilla\\Desktop\\NikitaNOT DELETE\\visualStudioNikita\\GoodEating\\Resources\\hand_curso.ico");
        }

        private void saveButton_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor("C:\\Users\\gorilla\\Desktop\\NikitaNOT DELETE\\visualStudioNikita\\GoodEating\\Resources\\hand_curso.ico");
        }
    }
}
