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
        string верноеНазваниеТочки = "Название точки";
        string верноеIDтовара = "99";
        string верноеНазваниеТовара = "test";
        string верноеНазваниеПоставщика = "тестовый чел";
        string верноеКоличество = "200";
        string вернаяЦенаВПоставке = "1000";
        DateTime вернаяДатаДТ = new DateTime(2020, 01, 01);

        public int getID(string name)//Получение актуального ID
        {
            SqlConnection sc = new SqlConnection(ClassTotal.connectionString);
            SqlCommand com = new SqlCommand();
            sc.Open();
            com.Connection = sc;
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

            com.CommandText = "dbcc checkident('Торговые точки', RESEED, " + id + ")";
            com.ExecuteNonQuery();
            sc.Close();
            return id;
        }
        public void insertAll()//Внесение всех тестовых данных
        {
            SqlConnection sc = new SqlConnection(ClassTotal.connectionString);
            SqlCommand com = new SqlCommand();
            sc.Open();
            com.Connection = sc;

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
        public void deleteAll()//Удаление всех тестовых записей
        {
            SqlConnection sc = new SqlConnection(ClassTotal.connectionString);
            SqlCommand com = new SqlCommand();
            sc.Open();
            com.Connection = sc;
            string clearПоставщики = " delete from [Поставщики] where Название = '" + верноеНазваниеПоставщика + "'";
            string clearНоменклатура = " delete from Номенклатура where Название = '" + верноеНазваниеТовара + "'";
            string clearПоставки = " delete from Поставки where [Дата поставки] = '2020-01-01'";
            string clearТоварыВПоставке = " delete from [Товары в поставке] where Название = '" + верноеНазваниеТовара + "'";
            string clearТорговыеТочки = " delete from [Торговые точки] where Название = '" + верноеНазваниеТочки + "'";
           
            com.CommandText = clearНоменклатура + clearТоварыВПоставке + clearПоставки + clearПоставщики + clearТорговыеТочки;
            com.ExecuteNonQuery();

            string clear = " dbcc checkident('Торговые точки', RESEED, " + getID("Торговые точки") + ")"
               + " dbcc checkident('Поставки', RESEED, " + getID("Поставки") + ")"
               + " dbcc checkident('Поставщики', RESEED, " + getID("Поставщики") + ")";
            com.CommandText = clear;
            com.ExecuteNonQuery();
            sc.Close();
        }







        [TestMethod]
        public void query1CorrectDataTest()//Тест получения номенклатуры и объема товаров в указанной торговой точке с корректными данными
        {
            //arrange
            insertAll();
            Form1 form = new Form1();

            //act
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
        public void query1InCorrectDataSpaceBeforeTest()// Тест получения номенклатуры и объема товаров в указанной торговой точке с некорректными данными(пробел перез значением),
        {
            //arrange
            insertAll();
            Form1 form = new Form1();

            //act
            form.query1(" "+верноеНазваниеТочки);
            deleteAll();
            
            //assert
            Assert.AreEqual(form.dataGridView1.RowCount, 0);
        }




        [TestMethod]
        public void query2WithoutDateTest()// Тест получения сведений о поставках определенного товара указанным поставщиком за все время поставок
        {
            //Arrange
            insertAll();
            Form1 form = new Form1();

            //Act
            form.query2(верноеIDтовара, getID("Поставщики").ToString(), вернаяДатаДТ, вернаяДатаДТ);
            string IDзаказа = form.dataGridView1.Rows[0].Cells[0].Value.ToString();
            string датаПоставки = form.dataGridView1.Rows[0].Cells[1].Value.ToString();
            string названиеПоставщика = form.dataGridView1.Rows[0].Cells[2].Value.ToString();
            string названиеТовара = form.dataGridView1.Rows[0].Cells[3].Value.ToString();
            string количество = form.dataGridView1.Rows[0].Cells[4].Value.ToString();
            string цена = form.dataGridView1.Rows[0].Cells[5].Value.ToString();

            //Assert
            Assert.AreEqual(IDзаказа, getID("Поставки").ToString());
            Assert.AreEqual(датаПоставки, вернаяДатаДТ.ToString());
            Assert.AreEqual(названиеПоставщика, верноеНазваниеПоставщика);
            Assert.AreEqual(названиеТовара, верноеНазваниеТовара);
            Assert.AreEqual(количество, верноеКоличество);
            Assert.AreEqual(цена, вернаяЦенаВПоставке);
            deleteAll();
        }
        [TestMethod]
        public void query2WithDateTest()// Тест получения сведений о поставках определенного товара указанным поставщиком за некоторый период
        {
            //Arramge
            insertAll();
            Form1 form = new Form1();

            //Act
            form.checkBox3.Checked = true;
            form.query2(верноеIDтовара, getID("Поставщики").ToString(), вернаяДатаДТ, вернаяДатаДТ);
            string IDзаказа = form.dataGridView1.Rows[0].Cells[0].Value.ToString();
            string датаПоставки = form.dataGridView1.Rows[0].Cells[1].Value.ToString();
            string названиеПоставщика = form.dataGridView1.Rows[0].Cells[2].Value.ToString();
            string названиеТовара = form.dataGridView1.Rows[0].Cells[3].Value.ToString();
            string количество = form.dataGridView1.Rows[0].Cells[4].Value.ToString();
            string цена = form.dataGridView1.Rows[0].Cells[5].Value.ToString();

            //Assert
            Assert.AreEqual(IDзаказа, getID("Поставки").ToString());
            Assert.AreEqual(датаПоставки, вернаяДатаДТ.ToString());
            Assert.AreEqual(названиеПоставщика, верноеНазваниеПоставщика);
            Assert.AreEqual(названиеТовара, верноеНазваниеТовара);
            Assert.AreEqual(количество, верноеКоличество);
            Assert.AreEqual(цена, вернаяЦенаВПоставке);
            deleteAll();
        }




        [TestMethod]
        public void query3CorrectNumberTest()//Тест получения сведений о поставках товаров по указанному номеру заказа с корректным номером закза
        {
            //Arrange
            insertAll();
            Form1 form = new Form1();

            //Act
            form.query3(getID("Поставки").ToString());
            string IDзаказа = form.dataGridView1.Rows[0].Cells[0].Value.ToString();
            string датаПоставки = form.dataGridView1.Rows[0].Cells[1].Value.ToString();
            string названиеПоставщика = form.dataGridView1.Rows[0].Cells[2].Value.ToString();

            //Assert
            Assert.AreEqual(IDзаказа, getID("Поставки").ToString());
            Assert.AreEqual(датаПоставки, вернаяДатаДТ.ToString());
            Assert.AreEqual(названиеПоставщика, верноеНазваниеПоставщика);
            deleteAll();

        }
        [TestMethod]
        public void query3NANTest()//Тест получения сведений о поставках товаров по указанному номеру заказа с некорректным номером закза(буквы)
        {
            //Arrange
            insertAll();
            Form1 form = new Form1();

            //Act
            form.query3("нет");

            //Assert
            Assert.AreEqual(form.dataGridView1.RowCount, 0);
            deleteAll();

        }
    }
}
