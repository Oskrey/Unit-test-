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
            string query = "SELECT [Торговые точки].[Название], Номенклатура.[ID товара], Номенклатура.Название as [Название товара], Номенклатура.Количество " +
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
            ClassTotal.connection = new SqlConnection(); //Создание объекта подключения
            ClassTotal.connection.ConnectionString = ClassTotal.connectionString;
            try
            {
                ClassTotal.connection.Open();      //Опасная команда

            }
            catch (SqlException ex)     //Обработка сбоя при подключении
            {
                switch (ex.Number)      //Номер ошибки
                {
                    case 17: MessageBox.Show("Неверное имя сервера"); break;
                    case 4060: MessageBox.Show("Неверное имя БД"); break;
                    case 18456: MessageBox.Show("Неверное имя пользователя или пароль"); break;
                }
                MessageBox.Show(ex.Message + Environment.NewLine + "Уровень ошибки " + ex.Class); return;
            }
            catch (Exception ex)            //Общий сбой при подключении
            {
                MessageBox.Show("Ошибка подключения " + ex.Message); return;
            }
            finally
            {
                if (ClassTotal.connection.State == ConnectionState.Open) ClassTotal.connection.Close();
            }
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(text, ClassTotal.connection);
            da.Fill(ds);
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








        string верноеНазваниеТочки = "Название точки";
        string верноеIDтовара = "99";
        string верноеНазваниеТовара = "test";
        string верноеНазваниеПоставщика = "тестовый чел";
        string верноеКоличество = "200";
        string вернаяЦенаВПоставке = "1000";
        DateTime вернаяДатаДТ = new DateTime(2020, 01, 01);
        public int getID(string name)
        {
            SqlConnection sc = new SqlConnection(ClassTotal.connectionString);
            SqlCommand com = new SqlCommand();
            sc.Open();
            com.Connection = sc;
            //------------------------------Получение id торговой точки
            com.CommandText = "select * from [" + name + "]";
            int id = -1;
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    id = (int)reader[0];
                }
            }
            reader.Close();

            //com.CommandText = "dbcc checkident('Торговые точки', RESEED, " + id + ")";
            //    com.ExecuteNonQuery();
            sc.Close();
            return id;
        }
        public void insertAll()
        {
            SqlConnection sc = new SqlConnection(ClassTotal.connectionString);
            SqlCommand com = new SqlCommand();
            sc.Open();
            com.Connection = sc;

            //------------------------------Вносим тестовые данные
            string clear = " dbcc checkident('Торговые точки', RESEED, " + getID("Торговые точки") + ")"
                + " dbcc checkident('Поставки', RESEED, " + getID("Поставки") + ")"
                + " dbcc checkident('Поставщики', RESEED, " + getID("Поставщики") + ")";
            com.CommandText = clear;
            com.ExecuteNonQuery();

            string insertТорговыеТочки = " insert into [Торговые точки] values('" + верноеНазваниеТочки + "', 'Адрес точки')";
            string insertПоставщики = " insert into Поставщики values ('" + верноеНазваниеПоставщика + "')";
            string insertПоставки = " insert into Поставки values ('01.01.2020', " + (getID("Поставщики") + 1) + ")";
            string insertТоварыВПоставке = " insert into [Товары в поставке] values ('" + (getID("Поставки") + 1) + "', '" + верноеIDтовара + "', '" + верноеНазваниеТовара + "', '" + верноеКоличество + "','" + вернаяЦенаВПоставке + "')";
            string insertНоменклатура = " insert into Номенклатура values ('" + верноеIDтовара + "', '" + (getID("Поставки") + 1) + "', '" + (getID("Торговые точки") + 1) + "', '" + верноеНазваниеТовара + "', '100', + '" + верноеКоличество + "')";

            com.CommandText = insertТорговыеТочки + insertПоставщики + insertПоставки + insertТоварыВПоставке + insertНоменклатура;
            com.ExecuteNonQuery();
            sc.Close();
        }
        public void deleteAll()
        {
            SqlConnection sc = new SqlConnection(ClassTotal.connectionString);
            SqlCommand com = new SqlCommand();
            //------------------------------Чистим за собой
            sc.Open();
            com.Connection = sc;
            string clearПоставщики = " delete from [Поставщики] where Название = '" + верноеНазваниеПоставщика + "'";

            string clearНоменклатура = " delete from Номенклатура where Название = '" + верноеНазваниеТовара + "'";
            string clearПоставки = " delete from Поставки where [Дата поставки] = '2020-01-01'";

            string clearТоварыВПоставке = " delete from [Товары в поставке] where Название = '" + верноеНазваниеТовара + "'";

            string clearТорговыеТочки = " delete from [Торговые точки] where Название = '" + верноеНазваниеТочки + "'";

            string clear = " dbcc checkident('Торговые точки', RESEED, " + getID("Торговые точки") + ")"
                + " dbcc checkident('Поставки', RESEED, " + getID("Поставки") + ")"
                + " dbcc checkident('Поставщики', RESEED, " + getID("Поставщики") + ")";

            com.CommandText = clearНоменклатура + clearТоварыВПоставке + clearПоставки + clearПоставщики + clearТорговыеТочки;
            com.ExecuteNonQuery();
            com.CommandText = clear;
            com.ExecuteNonQuery();
            sc.Close();
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            insertAll();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            deleteAll();
        }
    }
}
