using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Unit_test_ИС
{
    public partial class Form1 : Form
    {
        private OleDbConnection myConnection;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string shop = textBox1.Text;

            string query1 = "SELECT [Торговые точки].[Название], Номенклатура.[ID товара], Номенклатура.Название, Номенклатура.Количество FROM [Торговые точки] JOIN Номенклатура ON Номенклатура.[ID торговой точки] = [Торговые точки].[ID Торговой точки] WHERE [Торговые точки].[Название] = '" + shop + "'";
           
            OleDbDataAdapter command = new OleDbDataAdapter(query1, myConnection); //для вывода в компонент, а не изменять в бд. для выборки обязательно
            DataTable dt = new DataTable();//таблицы для выборки в виртуальной памяти
            command.Fill(dt); //заполнение выборкой таблицы в виртуальной памяти
            dataGridView1.DataSource = dt; //заполнение таблицы на форме
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string order = textBox1.Text;

            string query3 = "SELECT * FROM Поставки WHERE [ID поставки] = '" + order + "'";
           
            OleDbDataAdapter command = new OleDbDataAdapter(query3, myConnection); //для вывода в компонент, а не изменять в бд. для выборки обязательно
            DataTable dt = new DataTable();//таблицы для выборки в виртуальной памяти
            command.Fill(dt); //заполнение выборкой таблицы в виртуальной памяти
            dataGridView1.DataSource = dt; //заполнение таблицы на форме
        }
    }
}
