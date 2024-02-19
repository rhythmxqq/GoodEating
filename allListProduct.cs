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
    public partial class allListProduct : Form
    {
        public allListProduct()
        {
            InitializeComponent();
            LoadAllProducts();
        }
        private void LoadAllProducts()
        {
            dataGridViewAllProducts.Columns.Clear(); // Очищаем существующие колонки

            // Создаем колонки
            dataGridViewAllProducts.Columns.Add("id_product", "ID");
            dataGridViewAllProducts.Columns.Add("name_product", "Название");
            dataGridViewAllProducts.Columns.Add("proteins", "Белки (г)");
            dataGridViewAllProducts.Columns.Add("fats", "Жиры (г)");
            dataGridViewAllProducts.Columns.Add("carbohydrates", "Углеводы (г)");
            dataGridViewAllProducts.Columns.Add("callories_content", "Калории (ккал)");

            Db db = new Db();
            using (SqlConnection connection = db.getConnection())
            {
                connection.Open();
                string query = "SELECT * FROM productTable";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("id_product"));
                        string name = reader.GetString(reader.GetOrdinal("name_product"));
                        float callories_content = reader["callories_content"] != DBNull.Value ? Convert.ToSingle(reader["callories_content"]) : 0f;
                        float proteins = reader["proteins"] != DBNull.Value ? Convert.ToSingle(reader["proteins"]) : 0f;
                        float fats = reader["fats"] != DBNull.Value ? Convert.ToSingle(reader["fats"]) : 0f;
                        float carbohydrates = reader["carbohydrates"] != DBNull.Value ? Convert.ToSingle(reader["carbohydrates"]) : 0f;

                        dataGridViewAllProducts.Rows.Add(id, name, proteins, fats, carbohydrates, callories_content);
                    }
                    reader.Close();
                }
            }
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
