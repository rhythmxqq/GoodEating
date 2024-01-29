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
    public partial class DietHistoryForm : Form
    {
        private readonly int _userId;
        public DietHistoryForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            dateTimePickerInfo.ValueChanged += DateTimePickerInfo_ValueChanged;
            InitializeDataGridViewColumns();
        }
        private void InitializeDataGridViewColumns()
        {
            // Устанавливаем типы столбцов, их заголовки и другие свойства
            dataGridViewInfoDay.Columns.Clear(); // Удаляем все предыдущие столбцы, если они есть

            dataGridViewInfoDay.Columns.Add("name", "Название продукта");
            dataGridViewInfoDay.Columns.Add("proteins", "Белки");
            dataGridViewInfoDay.Columns.Add("fats", "Жиры");
            dataGridViewInfoDay.Columns.Add("carbohydrates", "Углеводы");
            dataGridViewInfoDay.Columns.Add("calories", "Калории");

            // Устанавливаем режим автоматического изменения размера, чтобы столбцы растягивались на всю ширину DataGridView
            dataGridViewInfoDay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void DietHistoryForm_Load(object sender, EventArgs e)
        {
            LoadDietForDate(dateTimePickerInfo.Value);
        }
        private void DateTimePickerInfo_ValueChanged(object sender, EventArgs e)
        {
            LoadDietForDate(dateTimePickerInfo.Value);
        }

        private void LoadDietForDate(DateTime date)
        {
            dataGridViewInfoDay.Rows.Clear();
            Db db = new Db();
            using (SqlConnection connection = db.getConnection())
            {
                connection.Open();
                string query = @"
                SELECT name, proteins, fats, carbohydrates, callories
                FROM modeEatingTable
                WHERE id_user = @userId AND date = @date";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", _userId);
                    command.Parameters.AddWithValue("@date", date.Date);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            float proteins = reader.IsDBNull(1) ? 0f : (float)reader.GetDouble(1);
                            float fats = reader.IsDBNull(2) ? 0f : (float)reader.GetDouble(2);
                            float carbohydrates = reader.IsDBNull(3) ? 0f : (float)reader.GetDouble(3);
                            float calories = reader.IsDBNull(4) ? 0f : (float)reader.GetDouble(4);

                            // Добавляем новую строку с данными о продукте
                            dataGridViewInfoDay.Rows.Add(name, proteins, fats, carbohydrates, calories);
                        }
                    }
                }
            }
        }

        private void PreviousButton_Click_1(object sender, EventArgs e)
        {
            dateTimePickerInfo.Value = dateTimePickerInfo.Value.AddDays(-1);
        }

        private void NextButton_Click_1(object sender, EventArgs e)
        {
            dateTimePickerInfo.Value = dateTimePickerInfo.Value.AddDays(1);
        }
    }
}
