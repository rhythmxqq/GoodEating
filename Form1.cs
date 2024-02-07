using MySql.Data.MySqlClient;
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
    public partial class Form1 : Form
    {
        private int userId = 0;
        public Form1()
        {
            InitializeComponent();
        }

        //loging
        private void button1_Click(object sender, EventArgs e)
        {
            String loginUser = loginTextBox.Text;
            String passwordUser = passwordTextBox.Text;

            Db db = new Db();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT * FROM userTable WHERE login = @uL AND password = @pU", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@pU", MySqlDbType.VarChar).Value = passwordUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
                using (SqlConnection connection = db.getConnection())
                {
                    db.openConnection();
                    String quary = "SELECT id_user FROM userTable WHERE login = @login";
                    SqlCommand command1 = new SqlCommand(quary, connection);
                    command1.Parameters.AddWithValue("@login", loginUser);

                        int userId = (int)command1.ExecuteScalar();
           
                    mainFormMb formMb = new mainFormMb(userId);
                    formMb.ShowDialog();
                }
            else
                MessageBox.Show("не работает, давай по новой");

        }

        //registration
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor("C:\\Users\\gorilla\\Desktop\\NikitaNOT DELETE\\visualStudioNikita\\GoodEating\\Resources\\busybutclickable_100191.ico");
        }

        private void enterButton_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor("C:\\Users\\gorilla\\Desktop\\NikitaNOT DELETE\\visualStudioNikita\\GoodEating\\Resources\\hand_curso.ico");
        }

        private void regButton_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor("C:\\Users\\gorilla\\Desktop\\NikitaNOT DELETE\\visualStudioNikita\\GoodEating\\Resources\\hand_curso.ico");
        }
    }
}

