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
        

        public Form1()
        {
            InitializeComponent();
        }

        private void query1(object sender, EventArgs e)
        {
            string query = "SELECT [Торговые точки].[Название], Номенклатура.[ID товара], Номенклатура.Название, Номенклатура.Количество " +
                "FROM [Торговые точки] " +
                "JOIN Номенклатура " +
                "ON Номенклатура.[ID торговой точки] = [Торговые точки].[ID Торговой точки] " +
                "WHERE [Торговые точки].[Название] = '" + textBox1.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(query, ClassTotal.connection);
            da.Fill(ds, "Name");
            dataGridView1.DataSource = ds.Tables["Name"];
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void query2(object sender, EventArgs e)
        { 
            string query = "";
            if (!checkBox3.Checked)
             query = "SELECT Поставки.[ID заказа], Поставки.[Дата поставки], Поставщики.Название as [Название поставщика], [Товары в поставке].Название as [Название товара], [Товары в поставке].Количество, [Товары в поставке].Цена " +
                    "FROM Поставки JOIN Поставщики " +
                    "ON Поставщики.[ID поставщика] = Поставки.[ID поставщика] " +
                    "join[Товары в поставке] " +
                    "on[Товары в поставке].[[ID заказа] = Поставки.[ID заказа] " +
                    "Where[ID товара] = '"+ textBoxТовар.Text + "' and Поставки.[ID поставщика] = '" + textBoxПоставщик.Text + "'";
            else
            query = "SELECT Поставки.[ID заказа], Поставки.[Дата поставки], Поставщики.Название as [Название поставщика], [Товары в поставке].Название as [Название товара], [Товары в поставке].Количество, [Товары в поставке].Цена " +
                    "FROM Поставки JOIN Поставщики " +
                    "ON Поставщики.[ID поставщика] = Поставки.[ID поставщика] " +
                    "join[Товары в поставке] " +
                    "on[Товары в поставке].[[ID заказа] = Поставки.[ID заказа] " +
                    "Where[ID товара] = '" + textBoxТовар.Text + "' and Поставки.[ID поставщика] = '" + textBoxПоставщик.Text + "' " +
                    "and [Дата поставки] between '"+dateTimePicker1.Value.Date+ "' and '" + dateTimePicker2.Value.Date + "'";

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(query, ClassTotal.connection);
            da.Fill(ds, "name_table");
            dataGridView1.DataSource = ds.Tables["name_table"];
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void query3(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Поставки WHERE [ID заказа] = '" + textBox2.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(query, ClassTotal.connection);
            da.Fill(ds, "Name");
            dataGridView1.DataSource = ds.Tables["Name"];
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
