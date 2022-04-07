using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_test_ИС
{
    public class ClassTotal
    {
        public static string connectionString = @"Data Source=LapTop, 1433;Initial Catalog=UnitTest;User ID=testo;Password=testo;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";  //Строка подключения
        public static SqlConnection connection;
    }
}
