using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodEating
{
    public partial class coachFormMain : Form
    {
        int _Idconnect = 0;
        public coachFormMain(int IdConnect)
        {
            _Idconnect = IdConnect;
            
            InitializeComponent();
            dataGridViewInfoAllProducts.AutoGenerateColumns = true;
            dataGridViewInfoAllProducts.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewInfoAllProducts.AutoGenerateColumns = false;
            dataGridViewInfoAllProducts.Columns.Add("Название", "Название");
            dataGridViewInfoAllProducts.Columns.Add("Кол-во", "Кол-во");
            dataGridViewInfoAllProducts.Columns.Add("Состав", "Состав");
            dataGridViewInfoAllProducts.Columns.Add("Каллории", "Каллории");
            dataGridViewInfoAllProducts.Columns.Add("Жиры", "Жиры");
            dataGridViewInfoAllProducts.Columns.Add("Белки", "Белки");
            dataGridViewInfoAllProducts.Columns.Add("Углеводы", "Углеводы");
            dataGridViewInfoAllProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Метод заполнения продуктами
            //Метод отслеживания пользователя и диет привязанных к нему
            //Добавить бд тренера и их аккаунтов
            //отслеживания нормы белков, жиров, углеводов в использования данного методо диеты.
        }

        private void coachFormMain_Load(object sender, EventArgs e)
        {

        }

        private void idCoach_Click(object sender, EventArgs e)
        {

        }
    }
}
