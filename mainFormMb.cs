using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodEating
{
    public partial class mainFormMb : Form
    {
        private int _userId = 0;
        int productId = 0;
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
            tgMessageAsync(CollectProductInformation(dataGridViewProductDay));

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
            List<(int productId, string name, float calories, float protein, float fats, float carbs)> products = GetProductsForUser(_userId);

            // Распределение продуктов по приемам пищи
            var mealProducts = DistributeProducts(products, totalCalories);

            // Отображение продуктов в dataGridViewProductDay
            DisplayProductsInDataGridView(mealProducts);

            // Распределение продуктов по приемам пищи
            var meaInfProducts = DistributeProducts(products, totalCalories);

            // Запись данных о приемах пищи в БД
            InsertEatingInfoToDb(mealProducts);
        }

        private List<(int productId, string name, float calories, float protein, float fats, float carbs)> GetProductsForUser(int userId)
        {
            Db db = new Db();
            List<(int productId, string name, float calories, float protein, float fats, float carbs)> products = new List<(int productId, string name, float calories, float protein, float fats, float carbs)>();

            using (SqlConnection connection = db.getConnection())
            {
                connection.Open();
                string query = @"
            SELECT p.id_product, p.name_product, p.callories_content, p.proteins, p.fats, p.carbohydrates
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
                            int productId = reader.GetInt32(reader.GetOrdinal("id_product"));
                            string productName = reader.GetString(reader.GetOrdinal("name_product"));
                            float calories = reader["callories_content"] != DBNull.Value ? Convert.ToSingle(reader["callories_content"]) : 0f;
                            float protein = reader["proteins"] != DBNull.Value ? Convert.ToSingle(reader["proteins"]) : 0f;
                            float fats = reader["fats"] != DBNull.Value ? Convert.ToSingle(reader["fats"]) : 0f;
                            float carbs = reader["carbohydrates"] != DBNull.Value ? Convert.ToSingle(reader["carbohydrates"]) : 0f;

                            products.Add((productId, productName, calories, protein, fats, carbs));
                        }
                    }
                }
            }

            return products;
        }

        private void InsertEatingInfoToDb(Dictionary<string, List<(int productId, string name, float calories, float protein, float fats, float carbs)>> mealProducts)
        {
            Db db = new Db();

            using (SqlConnection connection = db.getConnection())
            {
                connection.Open();

                foreach (var meal in mealProducts)
                {
                    foreach (var product in meal.Value)
                    {
                        using (SqlCommand command = new SqlCommand("INSERT INTO modeEatingTable (id_user, id_norma, callories, carbohydrates, name, proteins, fats, date, id_products) VALUES (@userId, @normaId, @calories, @carbohydrates, @name, @proteins, @fats, @date, @productId)", connection))
                        {
                            command.Parameters.AddWithValue("@userId", _userId);
                            command.Parameters.AddWithValue("@normaId", _userId);
                            command.Parameters.AddWithValue("@calories", product.calories);
                            command.Parameters.AddWithValue("@carbohydrates", product.carbs);
                            command.Parameters.AddWithValue("@name", product.name);
                            command.Parameters.AddWithValue("@proteins", product.protein);
                            command.Parameters.AddWithValue("@fats", product.fats);
                            command.Parameters.AddWithValue("@date", DateTime.Now);
                            command.Parameters.AddWithValue("@productId", product.productId);

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }


        private Dictionary<string, List<(int productId, string name, float calories, float protein, float fats, float carbs)>> DistributeProducts(List<(int productId, string name, float calories, float protein, float fats, float carbs)> products, float totalCalories)
        {
            float breakfastCalories = totalCalories * 0.25f;
            float lunchCalories = totalCalories * 0.35f;
            float snackCalories = totalCalories * 0.15f;
            float dinnerCalories = totalCalories * 0.25f;

            var mealProducts = new Dictionary<string, List<(int productId, string name, float calories, float protein, float fats, float carbs)>> {
        {"Завтрак", new List<(int productId, string name, float calories, float protein, float fats, float carbs)>()},
        {"Обед", new List<(int productId, string name, float calories, float protein, float fats, float carbs)>()},
        {"Полдник", new List<(int productId, string name, float calories, float protein, float fats, float carbs)>()},
        {"Ужин", new List<(int productId, string name, float calories, float protein, float fats, float carbs)>()}
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


        private void DisplayProductsInDataGridView(Dictionary<string, List<(int productId, string name, float calories, float protein, float fats, float carbs)>> mealProducts)
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

        private void mainFormMb_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor("C:\\Users\\gorilla\\Desktop\\NikitaNOT DELETE\\visualStudioNikita\\GoodEating\\Resources\\busybutclickable_100191.ico");
        }

        private void reloadProductButton_Click(object sender, EventArgs e)
        {
            LoadProductsAndDistribute();
        }

        private void profileButton_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor("C:\\Users\\gorilla\\Desktop\\NikitaNOT DELETE\\visualStudioNikita\\GoodEating\\Resources\\hand_curso.ico");
        }

        private void reloadProductButton_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor("C:\\Users\\gorilla\\Desktop\\NikitaNOT DELETE\\visualStudioNikita\\GoodEating\\Resources\\hand_curso.ico");
        }

        private void buttonText_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Правильное питание важно для поддержания здоровья, улучшения самочувствия и достижения долголетия. Оно помогает контролировать вес, улучшает работу сердца и снижает риск развития многих заболеваний. Начните заботиться о своем питании сегодня!", "Почему важно правильно питаться", MessageBoxButtons.OK);
        }
       
        private string ProductClicked(int productId)
        {
            Db db = new Db();
            using (SqlConnection connection = db.getConnection())
            {
                connection.Open();
                string query = "SELECT cookingTime, compound, textRecept, proteins, fats, carbohydrates, callories_content " +
                               "FROM receptTable INNER JOIN productTable ON receptTable.id_Product = productTable.id_product " +
                               "WHERE productTable.id_product = @productId AND receptIsCorrect = 1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@productId", productId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string cookingTime = reader["cookingTime"].ToString();
                            string compound = reader["compound"].ToString();
                            string textRecept = reader["textRecept"].ToString();
                            string proteins = reader["proteins"].ToString();
                            string fats = reader["fats"].ToString();
                            string carbohydrates = reader["carbohydrates"].ToString();
                            string calloriesContent = reader["callories_content"].ToString();

                            string message = $"Время готовки: {cookingTime}\n\n" +
                                             $"Состав продукта: {compound}\n\n" +
                                             $"Описание приготовления: {textRecept}\n\n" +
                                             $"Содержание калорий: {calloriesContent}\n" +
                                             $"Белки: {proteins}\n" +
                                             $"Жиры: {fats}\n" +
                                             $"Углеводы: {carbohydrates}";

                            return message;
                        }
                        else
                        {
                            return "Рецепт не найден или некорректный";
                        }
                    }
                }
            }
        }
            private int FindProductIdByName(string productName)
            {
                int productId = -1; // Инициализируем productId значением, которое не может быть id продукта

                Db db = new Db();
                using (SqlConnection connection = db.getConnection())
                {
                    connection.Open();
                    string query = "SELECT id_product FROM productTable WHERE name_product = @productName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@productName", productName);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            productId = reader.GetInt32(0); // Получаем id продукта из первого столбца
                        }
                        reader.Close();
                    }
                }

                return productId;
            }
 
        private string ExtractProductName(string productString)
        {
            int index = productString.IndexOf('(');
            if (index != -1)
            {
                return productString.Substring(0, index).Trim();
            }
            return productString; // Возвращаем всю строку, если символ "(" не найден
        }
        private void OpenRecipeButton_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Получаем название продукта из ячейки
                string productName = ExtractProductName(dataGridViewProductDay.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                int productId = FindProductIdByName(productName);

                // Здесь должен быть код для отображения информации о рецепте в MessageBox
                MessageBox.Show($"Открыть рецепт для продукта: {ProductClicked(productId)}");
            }
        }

        private void dataGridViewProductDay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridViewProductDay.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                string productName = ExtractProductName(dataGridViewProductDay.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

                // Проверка наличия рецепта для продукта
                bool hasRecipe = CheckRecipeExistence(productName);

                if (hasRecipe)
                {
                    // Показываем кнопку
                    button2.Visible = true;
                }
                else
                {
                    // Скрываем кнопку
                    button2.Visible = false;
                }

                // Заполнение labelCompound информацией о составе продукта
                string compoundInfo = GetCompoundInfo(productName);
                labelCompound.Text = compoundInfo;
            }
        }

        private bool CheckRecipeExistence(string productName)
        {
            int productId = FindProductIdByName(productName);
            bool hasRecipe = false;
            Db db = new Db();
            using (SqlConnection connection = db.getConnection())
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM receptTable WHERE id_Product = @productName AND receptIsCorrect = 1";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@productName", productId);
                    int count = (int)command.ExecuteScalar();
                    hasRecipe = count > 0;
                }
            }
            return hasRecipe;
        }
        async Task tgMessageAsync(string messag)
        {
            string botToken = "7087331796:AAGG7BQAb-08YlJ9rgF3HA7mnjD4ompULsU";
            long chatId = 1493577013; // Замените <YourChatId> на ID вашего чата

            string message = messag;

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"https://api.telegram.org/bot{botToken}/sendMessage?chat_id={chatId}&text={message}");
                response.EnsureSuccessStatusCode();
            }
        }
        private string CollectProductInformation(DataGridView dataGridView)
        {
            StringBuilder sb = new StringBuilder();

            // Переменные для хранения общего количества калорий, белков, жиров и углеводов
            float totalCalories = 0f;
            string totalProteins = countProteins.Text, totalFats = fatsCount.Text, totalCarbs = carbohydratesCount.Text;

            // Для каждой строки в DataGridView
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Проверяем, что строка не является пустой
                if (!row.IsNewRow)
                {
                    // Для каждой ячейки в строке
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        // Получаем значение ячейки и разделяем его на имя продукта и его калорийность
                        string cellValue = cell.Value.ToString();
                        string[] parts = cellValue.Split('(');

                        // Проверяем, что разделение на имя продукта и калории произошло успешно
                        if (parts.Length == 2)
                        {
                            string productName = parts[0].Trim();
                            string caloriesStr = parts[1].Replace(" ккал)", "").Trim(); // Удаляем " ккал" и лишние пробелы

                            // Пытаемся преобразовать количество калорий в число
                            if (float.TryParse(caloriesStr, out float calories))
                            {
                                // Добавляем информацию о продукте в строку
                                sb.AppendLine($"Продукт: {productName}, Калории: {calories}");

                                // Обновляем общее количество калорий, белков, жиров и углеводов
                                totalCalories += calories;
                            }
                        }
                    }
                }
            }

            // Добавляем общую информацию о калориях, белках, жирах и углеводах в строку
            sb.AppendLine($"Общее количество калорий: {totalCalories} ккал");
            sb.AppendLine($"Общее количество белков: {totalProteins}");
            sb.AppendLine($"Общее количество жиров: {totalFats}");
            sb.AppendLine($"Общее количество углеводов: {totalCarbs}");
            sb.AppendLine("Дата на момент рациона: " + DateTime.Now);

            return sb.ToString();
        }

        private string GetCompoundInfo(string productName)
        {
            int productId = FindProductIdByName(productName);
            string compoundInfo = "";
            Db db = new Db();
            using (SqlConnection connection = db.getConnection())
            {
                connection.Open();
                string query = "SELECT proteins, fats, carbohydrates, callories_content FROM productTable WHERE id_product = @productName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@productName", productId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        float callories_content = reader["callories_content"] != DBNull.Value ? Convert.ToSingle(reader["callories_content"]) : 0f;
                        float proteins = reader["proteins"] != DBNull.Value ? Convert.ToSingle(reader["proteins"]) : 0f;
                        float fats = reader["fats"] != DBNull.Value ? Convert.ToSingle(reader["fats"]) : 0f;
                        float carbohydrates = reader["carbohydrates"] != DBNull.Value ? Convert.ToSingle(reader["carbohydrates"]) : 0f;

                        compoundInfo = $"Белки: {proteins}г, Жиры: {fats}г, Углеводы: {carbohydrates}г, Калории: {callories_content}ккал";
                    }
                    reader.Close();
                }
            }
            return compoundInfo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductDay.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dataGridViewProductDay.SelectedCells[0].RowIndex;
                int selectedColumnIndex = dataGridViewProductDay.SelectedCells[0].ColumnIndex;

                if (selectedRowIndex >= 0 && selectedColumnIndex >= 0)
                {
                    string productName = ExtractProductName(dataGridViewProductDay.Rows[selectedRowIndex].Cells[selectedColumnIndex].Value.ToString());
                    int productId = FindProductIdByName(productName);
                    MessageBox.Show(ProductClicked(productId), "Рецепт " + productName);
                   
                }
            }
            else
            {
                MessageBox.Show("Выделите ячейку с продуктом в таблице", "Ошибка");
            }
        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            allListProduct form4 = new allListProduct();
            form4.ShowDialog();
        }
    }
}

