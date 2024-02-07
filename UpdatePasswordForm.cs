using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodEating
{
    public partial class UpdatePasswordForm : Form
    {
        int _userId = 0;
        public UpdatePasswordForm(int  userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            if (firstPass.Text == secondPass.Text)
            {
                UpdateUserPassword(_userId, firstPass.Text);
                MessageBox.Show("Пароль успешно изменен.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Пароли не совпадают. Попробуйте еще раз.");
            }
        }
        private void UpdateUserPassword(int userId, string newPassword)
        {
            Db db = new Db();
            using (SqlConnection connection = db.getConnection())
            {
                db.openConnection();
                string query = "UPDATE userTable SET password = @password WHERE id_user = @userId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@password", newPassword);
                command.Parameters.AddWithValue("@userId", userId);

                command.ExecuteNonQuery();
            }
        }

        private void UpdatePasswordForm_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor("C:\\Users\\gorilla\\Desktop\\NikitaNOT DELETE\\visualStudioNikita\\GoodEating\\Resources\\busybutclickable_100191.ico");
        }

        private void changeButton_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor("C:\\Users\\gorilla\\Desktop\\NikitaNOT DELETE\\visualStudioNikita\\GoodEating\\Resources\\hand_curso.ico");
        }
    }
}
