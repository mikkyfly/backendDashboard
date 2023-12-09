using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace databasepg
{
    public partial class Table
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
    

    public partial class DataBaseContext : DbContext
    {
        public DataBaseContext() { }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options){ }

        public virtual DbSet<Table> test { get; set; } //table1 database
        public virtual DbSet<Table> test2 { get; set; } //table1 database

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=test_db;Username=postgres;Password=postgres");
    }

    public class testDataBase
    {
        public static void DataBasePostgreSQL(Notifier notifier)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    

                    var pke = db.test.ToList();
                    notifier.OnMessageReceived(pke.Select(t => JsonSerializer.Serialize(t)).ToList());
                    
                    Console.WriteLine("Список объектов");
                    foreach (Table t in pke)
                    {
                        Console.WriteLine($"{t.id}. {t.Name} = {t.Value}");
                    }
                }
                using (DataBaseContext db = new DataBaseContext())
                {
                    

                    var pke = db.test2.ToList();
                    notifier.OnMessageReceived(pke.Select(t => JsonSerializer.Serialize(t)).ToList());
                    
                    Console.WriteLine("Список объектов");
                    foreach (Table t in pke)
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