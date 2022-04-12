using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unit_test_ИС;
using System.Windows.Forms;

using System;
using System.Data.SqlClient;
using System.Data;

namespace ИСUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void query1Test()
        {
            SqlConnection sc = new SqlConnection(ClassTotal.connectionString);
            SqlCommand com = new SqlCommand();
            sc.Open();
            com.Connection = sc;
            //------------------------------Получение id торговой точки
            com.CommandText = "select [ID торговой точки] from [Торговые точки]";
            int idТорговойТочки = -1;
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    idТорговойТочки = (int)reader[0] + 1;
                }
            }
            reader.Close();
            //------------------------------Получение id заказа

            com.CommandText = "select [ID заказа] from [Поставки]";
            int idЗаказа = -1;
            reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    idЗаказа = (int)reader[0] + 1;
                }
            }
            reader.Close();
            //------------------------------Получение id поставщика

            com.CommandText = "select [ID поставщика] from [Поставщики]";
            int idПоставщика = -1;
            reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    idПоставщика = (int)reader[0] + 1;
                }
            }
            reader.Close();
            //------------------------------Вносим тестовые данные

            string верноеНазвание = "Название точки";
            string верноеIDтовара = "99";
            string верноеНазваниеТовара = "test";
            string верноеКоличество = "200";

            string firstInsert = " insert into [Торговые точки] values('"+ верноеНазвание + "', 'Адрес точки')";
            string secondInsert  = " insert into Поставщики values ('тестовый чел')";
            string  thirdInsert= " insert into Поставки values ('01.01.2020', " + idПоставщика + ")";
            string fourthInsert = " insert into Номенклатура values ('"+верноеIDтовара+"', '"+idЗаказа+"', '" + idТорговойТочки + "', '"+ верноеНазваниеТовара+"', '100', '"+ верноеКоличество+"')";
            
            
            com.CommandText = (firstInsert + secondInsert + thirdInsert+fourthInsert);
                com.ExecuteNonQuery();


            //------------------------------Вызываем нашу программу
            
            Form1 form = new Form1();
            form.query1("Название точки");
            string название = form.dataGridView1.Rows[0].Cells[0].Value.ToString();
            string IDтовара = form.dataGridView1.Rows[0].Cells[1].Value.ToString();
            string названиеТовара = form.dataGridView1.Rows[0].Cells[2].Value.ToString();
            string количество = form.dataGridView1.Rows[0].Cells[3].Value.ToString();




            //------------------------------Чистим за собой

            string clear = " delete from [Торговые точки] where [ID торговой точки] = " + idТорговойТочки +
                " dbcc checkident('Торговые точки')";
            string clear1 = " delete from Номенклатура where Название = " + верноеНазваниеТовара;
            string clear2 = " delete from Поставки where [ID заказа] = " + idЗаказа +
                " dbcc checkident('Торговые точки')";
            string clear3 = " delete from [Поставщики] where [ID поставщика] = " + idПоставщика +
                " dbcc checkident('Торговые точки')";
            com.CommandText = clear+clear1+clear2+clear3;
            com.ExecuteNonQuery();
            sc.Close();
            //------------------------------Проверяем чокак

            Assert.AreEqual(название, верноеНазвание);
            Assert.AreEqual(IDтовара, верноеIDтовара);
            Assert.AreEqual(названиеТовара, верноеНазваниеТовара);
            Assert.AreEqual(количество, верноеКоличество);
        }
    }
}
