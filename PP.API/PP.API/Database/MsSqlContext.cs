//using Microsoft.Data.SqlClient;
//using PP.Library.Models;

//namespace PP.API.Database
//{
//    public class MsSqlContext
//    {
//        private MsSqlContext()
//        {
//            connectionString = "Server=DESKTOP-P5123QT;Database=PP_DB;Trusted_Connection=True;TrustServerCertificate=True";
//        }

//        private string connectionString;

//        public Client Insert(Client c)
//        {
//            try
//            {
//                using (var conn = new SqlConnection(connectionString))
//                {
//                    var sql = $"InsertClient";
//                    using (var cmd = new SqlCommand(sql, conn))
//                    {
//                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                        cmd.Parameters.Add(new SqlParameter("name",c.Name));
//                        conn.Open();
//                        var Id = (int)cmd.ExecuteScalar();
//                        c.Id = Id;
//                    }
//                }
//            } catch(Exception)
//            {
//                return c;
//            }

//            return c;
//        }

//        public List<Client> Get()
//        {
//            var results = new List<Client>();
//            using (var conn = new SqlConnection(connectionString))
//            {
//                var sql = "select id, name from Clients";
//                using (var cmd = new SqlCommand(sql, conn))
//                {
//                    conn.Open();
//                    var reader = cmd.ExecuteReader();
//                    while (reader.Read())
//                    {
//                        results.Add(new Client
//                        {
//                            Id = (int)reader[0],
//                            Name = reader[1]?.ToString() ?? string.Empty
//                        });
//                    }
//                }
//            }

//            return results;
//        }

//        private static MsSqlContext? instance;
//        public static MsSqlContext Current
//        {
//            get
//            {
//                if(instance == null)
//                {
//                    instance = new MsSqlContext();
//                }
//                return instance;
//            }
//        }
//    }
//}
