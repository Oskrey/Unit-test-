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
            string ID = "select [ID торговой точки] from [Торговые точки]";
            com.CommandText = ID;
            int id = -1;
            SqlDataReader reader = com.ExecuteReader();
            while (reader.HasRows)
            {
                reader.Read();
                id = (int)reader["ID торговой точки"] + 1;
            }

            int ident;
            string firstInsert = "insert into [Торговые точки] values('Название точки', 'Адрес точки')";
            string secondInsert = "insert into Номенклатура values ('1', '1', '" + id + "', 'test', '100', '200')";
            string query = "SELECT [Торговые точки].[Название], Номенклатура.[ID товара], Номенклатура.Название, Номенклатура.Количество " +
                "FROM [Торговые точки] " +
                "JOIN Номенклатура " +
                "ON Номенклатура.[ID торговой точки] = [Торговые точки].[ID Торговой точки] " +
                "WHERE [Торговые точки].[Название] = 'Название точки'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(query, sc);
            da.Fill(ds);

            string clear = " delete from [Торговые точки] where [ID торговой точки] = " + id +
                " dbcc checkident('Торговые точки')";
            Form1 form = new Form1();

            com.CommandText = (firstInsert + " " + secondInsert);

            com.ExecuteNonQuery();


            //act
            form.query1("Название точки");
            while (reader.HasRows)
            {
                reader.Read();
                id = (int)reader["ID торговой точки"] + 1;
            }


            com.CommandText = clear;
            com.ExecuteNonQuery();
            sc.Close();

            Assert.AreEqual(ds.Tables[0], ds.Tables[1]);
        }
    }
}
