using Npgsql;
using System.Data;


namespace databasepg
{
    public class DBPG
    {
        // Obtain connection string information from the portal
        //
        private static string Host = "localhost";
        private static string User = "postgres";
        private static string DBname = "test_db";
        private static string Password = "QWE123!";
        private static string Port = "5432";
       


        public static void ForceBD()
        {
            // Build connection string using parameters from portal
            //
             string pkge;



            string connString =
                String.Format(
                    "Server={0}; User Id={1}; Database={2}; Port={3}; Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);
            
            using (var conn = new NpgsqlConnection(connString))
            {
                
                Console.Out.WriteLine("Opening connection DataBase PostgreSQL");
                conn.Open();
                while (true)
                {
                    Thread.Sleep(2000);
                    using (var command = new NpgsqlCommand("SELECT * FROM test", conn))
                    {

                        var reader = command.ExecuteReader();
                        
                        

                        while (reader.Read())
                        {
                            pkge = reader.GetInt32(2).ToString();
                           Thread.Sleep(500);
                            //Console.WriteLine(reader.GetInt32(0).ToString()); 
                            //Console.WriteLine(reader.GetString(1)); 
                            Console.WriteLine(reader.GetInt32(2).ToString());
                            /* Console.WriteLine(
                                 string.Format(
                                     "Reading from table=({0}, {1}, {2})", //{0}, {1}, 
                                     reader.GetInt32(0).ToString(),
                                     reader.GetString(1),
                                     reader.GetInt32(2).ToString()
                                     )
                                 );*/
                        }
                        Console.WriteLine();
                        reader.Close();
                    }
                }

            }
        }
    }
}
