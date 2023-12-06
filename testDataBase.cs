using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databasepg
{
    public partial class Tag
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }

    public partial class DataBaseContext : DbContext
    {
        public DataBaseContext() { }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }
        public virtual DbSet<Tag> test { get; set; } //table database

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=test_db;Username=postgres;Password=QWE123!");
    }
    public class testDataBase
    {
        public static object[] pke = Array.Empty<string>();
        public static void DataBasePostgreSQL()
        {
            
            try
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    //var tags = db.test.ToList();
                    
                    pke = db.test.Cast<object>().ToArray();

                    Console.WriteLine("Список объектов");
                    foreach (Tag t in pke)
                    {
                        Console.WriteLine($"{t.id}. {t.Name} = {t.Value}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }
    }
}
