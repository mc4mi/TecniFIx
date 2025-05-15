using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TecniFix
{
    public static class Database
    {
        private static readonly string connectionString =
            "Server=DESKTOP-MILA\\SQLEXPRESS;Database=TecniFix_db;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString); // NO la abrimos aquí
        }
    }

}
