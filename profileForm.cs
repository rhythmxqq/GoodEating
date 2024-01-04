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
            mainFormMb formMb = new mainFormMb(_userId);
            formMb.ShowDialog();
        }

        private void profileForm_Load(object sender, EventArgs e)
        {
           loginLoad();
        }

        private void updatePasswordButton_Click(object sender, EventArgs e)
        {

        }
    }
}
