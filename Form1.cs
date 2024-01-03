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
        public Form1()
        {
            InitializeComponent();
        }
        
        //log
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
                MessageBox.Show("нормасик все");
            else
                MessageBox.Show("хуйня, давай по новой");

        }

        //reg
        private void button1_Click_1(object sender, EventArgs e)
        {        
            Form2 form2  = new Form2();
            form2.ShowDialog();
        }
    }
}
