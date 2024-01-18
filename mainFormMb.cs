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
            dataGridViewProductDay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadProductsAndDistribute();


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

        private void LoadProductsAndDistribute()
        {
            float totalCalories = float.Parse(AllNormaCount.Text); // Получение нормы калорий из Label

            // Получение продуктов из БД
            List<(string name, float calories, float protein, float fats, float carbs)> products = GetProductsForUser(_userId);

            // Распределение продуктов по приемам пищи
            var mealProducts = DistributeProducts(products, totalCalories);

            // Отображение продуктов в dataGridViewProductDay
            DisplayProductsInDataGridView(mealProducts);
        }

        private List<(string name, float calories, float protein, float fats, float carbs)> GetProductsForUser(int userId)
        {
            Db db = new Db();
            List<(string name, float calories, float protein, float fats, float carbs)> products = new List<(string name, float calories, float protein, float fats, float carbs)>();

            using (SqlConnection connection = db.getConnection())
            {
                connection.Open();
                string query = @"
        SELECT p.name_product, p.callories_content, p.proteins, p.fats, p.carbohydrates
        FROM productTable p
        JOIN normaTable n ON p.id_norma = n.id_norma
        WHERE n.id_user = @userId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string productName = reader.GetString(0);
                            float calories = 0f;

                            if (!reader.IsDBNull(1))
                            {
                                calories = (float)reader.GetDouble(1); // Преобразование double в float
                            }

                            float protein = (float)reader.GetDouble(2);
                            float fats = (float)reader.GetDouble(3);
                            float carbs = (float)reader.GetDouble(4);

                            products.Add((productName, calories, protein, fats, carbs));
                        }
                    }
                }
            }

            return products;
        }

       

   private Dictionary<string, List<(string name, float calories, float protein, float fats, float carbs)>> DistributeProducts(List<(string name, float calories, float protein, float fats, float carbs)> products, float totalCalories)
{
    float breakfastCalories = totalCalories * 0.25f;
    float lunchCalories = totalCalories * 0.35f;
    float snackCalories = totalCalories * 0.15f;
    float dinnerCalories = totalCalories * 0.25f;

    var mealProducts = new Dictionary<string, List<(string name, float calories, float protein, float fats, float carbs)>> {
        {"Завтрак", new List<(string name, float calories, float protein, float fats, float carbs)>()},
        {"Обед", new List<(string name, float calories, float protein, float fats, float carbs)>()},
        {"Полдник", new List<(string name, float calories, float protein, float fats, float carbs)>()},
        {"Ужин", new List<(string name, float calories, float protein, float fats, float carbs)>()}
    };

    foreach (var product in products)
    {
        // Пример распределения продуктов по приемам пищи, исходя из калорийности
        if (breakfastCalories >= product.calories)
        {
            mealProducts["Завтрак"].Add(product);
            breakfastCalories -= product.calories;
        }
        else if (lunchCalories >= product.calories)
        {
            mealProducts["Обед"].Add(product);
            lunchCalories -= product.calories;
        }
        else if (snackCalories >= product.calories)
        {
            mealProducts["Полдник"].Add(product);
            snackCalories -= product.calories;
        }
        else if (dinnerCalories >= product.calories)
        {
            mealProducts["Ужин"].Add(product);
            dinnerCalories -= product.calories;
        }
        // Если продукт не подходит ни в одну категорию, можно добавить исключения 
    }

    return mealProducts;
   }


        private void DisplayProductsInDataGridView(Dictionary<string, List<(string name, float calories, float protein, float fats, float carbs)>> mealProducts)
        {
            // Очистка текущих данных в DataGridView
            dataGridViewProductDay.Rows.Clear();

            // Найти максимальное количество строк
            int maxRows = mealProducts.Max(mp => mp.Value.Count);

            // Подготовка к подсчету общего количества белков, жиров и углеводов
            float totalProtein = 0f, totalFats = 0f, totalCarbs = 0f;

            for (int i = 0; i < maxRows; i++)
            {
                var row = new DataGridViewRow();

                foreach (var meal in mealProducts)
                {
                    if (meal.Value.Count > i)
                    {
                        var product = meal.Value[i];
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = $"{product.name} ({product.calories} ккал)" });

                        // Подсчет белков, жиров, углеводов для текущего продукта
                        totalProtein += product.protein;
                        totalFats += product.fats;
                        totalCarbs += product.carbs;
                    }
                    else
                    {
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = "" });
                    }
                }
                dataGridViewProductDay.Rows.Add(row);
            }

            // Обновление Label для отображения общего количества белков, жиров, углеводов
            countProteins.Text = $" {totalProtein}г";
            fatsCount.Text = $"{totalFats}г";
            carbohydratesCount.Text = $"{totalCarbs}г";
        }

    }
}

