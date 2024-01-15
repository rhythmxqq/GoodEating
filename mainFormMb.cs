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
    public partial class mainFormMb : Form
    {
        private int _userId = 0;
        public mainFormMb(int userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            profileForm profile = new profileForm(_userId);
            profile.ShowDialog();
        }

        private void mainFormMb_Load(object sender, EventArgs e)
        {

            dataGridViewProductDay.AutoGenerateColumns = true;
            dataGridViewProductDay.BorderStyle = BorderStyle.Fixed3D;

            CalculateAndDisplayCalorieNorm(_userId, AllNormaCount);
            dataGridViewProductDay.AutoGenerateColumns = false;
            dataGridViewProductDay.Columns.Add("Завтрак", "Завтрак");
            dataGridViewProductDay.Columns.Add("Обед", "Обед");
            dataGridViewProductDay.Columns.Add("Полдник", "Полдник");
            dataGridViewProductDay.Columns.Add("Ужин", "Ужин");
            LoadProducts();


        }
        void CalculateAndDisplayCalorieNorm(int userId, Label calorieLabel)
        {
            Db db = new Db();

            using (SqlConnection connection = db.getConnection())
            {
                connection.Open();

                // SQL-запрос для получения веса и роста пользователя по id_user
                string query = @"
                  SELECT weight, height
                  FROM normaTable
                  WHERE id_user = @userId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Добавляем параметр для id_user
                    command.Parameters.AddWithValue("@userId", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Если нашли пользователя
                        {
                            int weight = reader.GetInt32(reader.GetOrdinal("weight"));
                            int height = reader.GetInt32(reader.GetOrdinal("height"));

                            // Рассчитываем норму калорий для похудения (пример использует упрощенную формулу Миффлина-Сан Жеора)
                            int calorieNorm = CalculateCalorieNorm(weight, height);

                            // Обновляем Label в вашем пользовательском интерфейсе
                            calorieLabel.Invoke((MethodInvoker)(() => calorieLabel.Text = calorieNorm.ToString()));
                        }
                        else
                        {
                            calorieLabel.Invoke((MethodInvoker)(() => calorieLabel.Text = "Пользователь не найдет"));
                        }
                    }
                }
            }
        }

        int CalculateCalorieNorm(int weight, int height)
        {
            // Упрощенная формула расчета базовой метаболической скорости (BMR)
            int bmr = (10 * weight) + (6 * height) - 500; // Примерное значение для "среза калорий"

            // Для расчета нормы калорий для похудения, мы можем вычесть 500-1000 калорий из BMR,
            // но не должны опускаться ниже 1200 калорий в день для женщин и 1800 для мужчин.
            int calorieNormForWeightLoss = Math.Max(bmr - 500, 1200);

            return calorieNormForWeightLoss;
        }

        private void LoadProducts()
        {
            // Получаем максимальное количество калорий пользователя из Label
            int maxCalories = int.Parse(AllNormaCount.Text);

            // Запрос для получения продуктов
            string query = @"
        SELECT id_product, name_product, compound, proteins, fats, carbohydrates, callories_content, grames, id_norma
        FROM productTable
        WHERE id_norma IN (
            SELECT id_norma
            FROM normaTable
            WHERE id_user = @userId
        )
        AND callories_content <= @maxCalories
        ORDER BY ABS(callories_content - @maxCalories)";

            // Очищаем dataGridViewProductDay перед добавлением новых данных
            dataGridViewProductDay.Rows.Clear();
            Db db = new Db();   
            using (SqlConnection connection = db.getConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", _userId);
                    command.Parameters.AddWithValue("@maxCalories", maxCalories);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        double caloriesRemaining = maxCalories;

                        while (reader.Read())
                        {
                            string nameProduct = reader.GetString(reader.GetOrdinal("name_product"));
                            double caloriesContent = reader.GetDouble(reader.GetOrdinal("callories_content"));

                            // Проверяем, в какой прием пищи можно добавить продукт
                            if (caloriesRemaining >= caloriesContent)
                            {
                                AddProductToMeal(nameProduct, dataGridViewProductDay);
                                caloriesRemaining -= caloriesContent;
                            }
                        }
                    }
                }
            }
        }

        private void AddProductToMeal(string nameProduct, DataGridView dataGridView)
        {
            // Добавляем название продукта в первую доступную ячейку в dataGridViewProductDay
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    {
                        cell.Value = nameProduct;
                        return;
                    }
                }
            }
        }

    }
}
