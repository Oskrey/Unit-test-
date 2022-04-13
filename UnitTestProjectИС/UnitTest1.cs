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
        
        public int getID(string name)
        {
            SqlConnection sc = new SqlConnection(ClassTotal.connectionString);
            SqlCommand com = new SqlCommand();
            sc.Open();
            com.Connection = sc;
            //------------------------------Получение id торговой точки
            com.CommandText = "select * from ["+name+"]";
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

            com.CommandText = "dbcc checkident('Торговые точки', RESEED, " + id + ")";
            com.ExecuteNonQuery();
            sc.Close();
            return id;
        }
        string верноеНазваниеТочки = "Название точки";
        string верноеIDтовара = "99";
        string верноеНазваниеТовара = "test";
        string верноеНазваниеПоставщика = "тестовый чел";
        string верноеКоличество = "200";
        string вернаяЦенаВПоставке = "1000";
        DateTime вернаяДатаДТ = new DateTime(2020, 01, 01);
        
        [TestMethod]
        public void aaaaaaa()
        {
            insertAll();
            deleteAll();
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
        [TestMethod]
        public void query1Test()
        {
            //arrange
            insertAll();

            //act
            Form1 form = new Form1();
            form.query1(верноеНазваниеТочки);
            string название = form.dataGridView1.Rows[0].Cells[0].Value.ToString();
            string IDтовара = form.dataGridView1.Rows[0].Cells[1].Value.ToString();
            string названиеТовара = form.dataGridView1.Rows[0].Cells[2].Value.ToString();
            string количество = form.dataGridView1.Rows[0].Cells[3].Value.ToString();
            deleteAll();

            //assert
            Assert.AreEqual(название, верноеНазваниеТочки);
            Assert.AreEqual(IDтовара, верноеIDтовара);
            Assert.AreEqual(названиеТовара, верноеНазваниеТовара);
            Assert.AreEqual(количество, верноеКоличество);
        }

        [TestMethod]
        public void query2_1Test()
        {
            insertAll();
            Form1 form = new Form1();
            form.query2(верноеIDтовара,getID("Поставщики").ToString(), вернаяДатаДТ, вернаяДатаДТ);
            string IDзаказа = form.dataGridView1.Rows[0].Cells[0].Value.ToString();
            string датаПоставки = form.dataGridView1.Rows[0].Cells[1].Value.ToString();
            string названиеПоставщика = form.dataGridView1.Rows[0].Cells[2].Value.ToString();
            string названиеТовара = form.dataGridView1.Rows[0].Cells[3].Value.ToString();
            string количество = form.dataGridView1.Rows[0].Cells[4].Value.ToString();
            string цена = form.dataGridView1.Rows[0].Cells[5].Value.ToString();

            Assert.AreEqual(IDзаказа, getID("Поставки").ToString());
            Assert.AreEqual(датаПоставки, вернаяДатаДТ.ToString());
            Assert.AreEqual(названиеПоставщика, верноеНазваниеПоставщика);
            Assert.AreEqual(названиеТовара, верноеНазваниеТовара);
            Assert.AreEqual(количество, верноеКоличество);
            Assert.AreEqual(цена, вернаяЦенаВПоставке);
            deleteAll();
        }
        [TestMethod]
        public void query2_2Test()
        {
            insertAll();
            Form1 form = new Form1();
            form.checkBox3.Checked = true;

            form.query2(верноеIDтовара, getID("Поставщики").ToString(), вернаяДатаДТ, вернаяДатаДТ);
            string IDзаказа = form.dataGridView1.Rows[0].Cells[0].Value.ToString();
            string датаПоставки = form.dataGridView1.Rows[0].Cells[1].Value.ToString();
            string названиеПоставщика = form.dataGridView1.Rows[0].Cells[2].Value.ToString();
            string названиеТовара = form.dataGridView1.Rows[0].Cells[3].Value.ToString();
            string количество = form.dataGridView1.Rows[0].Cells[4].Value.ToString();
            string цена = form.dataGridView1.Rows[0].Cells[5].Value.ToString();

            Assert.AreEqual(IDзаказа, getID("Поставки").ToString());
            Assert.AreEqual(датаПоставки, вернаяДатаДТ.ToString());
            Assert.AreEqual(названиеПоставщика, верноеНазваниеПоставщика);
            Assert.AreEqual(названиеТовара, верноеНазваниеТовара);
            Assert.AreEqual(количество, верноеКоличество);
            Assert.AreEqual(цена, вернаяЦенаВПоставке);
            deleteAll();
        }
    }
}
