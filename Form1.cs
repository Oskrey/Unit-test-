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
        public void query1(string name)
        {
            string query = "SELECT [Торговые точки].[Название], Номенклатура.[ID товара], Номенклатура.Название, Номенклатура.Количество " +
                "FROM [Торговые точки] " +
                "JOIN Номенклатура " +
                "ON Номенклатура.[ID торговой точки] = [Торговые точки].[ID Торговой точки] " +
                "WHERE [Торговые точки].[Название] = '" + name + "'";
            setter(query);            
        }
        public void query2(string IDтовара, string IDпоставщика, DateTime from, DateTime to)
        {
            string query = "";
            if (!checkBox3.Checked)
                query = "SELECT Поставки.[ID заказа], Поставки.[Дата поставки], Поставщики.Название as [Название поставщика], [Товары в поставке].Название as [Название товара], [Товары в поставке].Количество, [Товары в поставке].Цена " +
                       "FROM Поставки JOIN Поставщики " +
                       "ON Поставщики.[ID поставщика] = Поставки.[ID поставщика] " +
                       "join[Товары в поставке] " +
                       "on[Товары в поставке].[ID заказа] = Поставки.[ID заказа] " +
                       "Where[ID товара] = '" + IDтовара + "' and Поставки.[ID поставщика] = '" + IDпоставщика + "'";
            else
                query = "SELECT Поставки.[ID заказа], Поставки.[Дата поставки], Поставщики.Название as [Название поставщика], [Товары в поставке].Название as [Название товара], [Товары в поставке].Количество, [Товары в поставке].Цена " +
                        "FROM Поставки JOIN Поставщики " +
                        "ON Поставщики.[ID поставщика] = Поставки.[ID поставщика] " +
                        "join[Товары в поставке] " +
                        "on[Товары в поставке].[ID заказа] = Поставки.[ID заказа] " +
                        "Where[ID товара] = '" + IDтовара + "' and Поставки.[ID поставщика] = '" + IDпоставщика + "' " +
                        "and [Дата поставки] between '" + from + "' and '" + to + "'";

            setter(query);
        }
        public void query3(string IDзаказа)
        {
            string query = "SELECT Поставки.[ID заказа], Поставки.[Дата поставки], Поставщики.Название " +
                "FROM Поставки " +
                "join Поставщики  " +
                "on Поставки.[ID поставщика] = Поставщики.[ID поставщика] " +
                "WHERE [ID заказа] = '" + IDзаказа + "'";
            setter(query);
        }
        public void setter(string text)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(text, ClassTotal.connection);
            da.Fill(ds, "Name");
            dataGridView1.DataSource = ds.Tables["Name"];
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void buttonQuery1(object sender, EventArgs e)
        {
            query1(textBoxМагазин.Text);
        }

        private void buttonQuery2(object sender, EventArgs e)
        {
            query2(textBoxТовар.Text, textBoxПоставщик.Text, dateTimePickerОт.Value.Date, dateTimePickerДо.Value.Date);
        }

        private void buttonQuery3(object sender, EventArgs e)
        {
            query3(textBox2.Text);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox3.Checked)
            {
                labelОт.Visible = true;
                labelДо.Visible = true;
                dateTimePickerОт.Visible = true;
                dateTimePickerДо.Visible = true;

            }
            else
            {
                labelОт.Visible = false;
                labelДо.Visible = false;
                dateTimePickerОт.Visible = false;
                dateTimePickerДо.Visible = false;
            }
        }
    }
}
