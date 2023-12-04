using Microsoft.EntityFrameworkCore;


namespace databasepg
{
    public class TagDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
    public class DataBasePG:DbContext
    {
        public DbSet<TagDb> Tags { get; set; } = null!;

        public DataBasePG()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=пароль_от_postgres");
        }
    }

    public class SendDb()
    {
        public void ForceDataBase()
        {
            using (DataBasePG db = new DataBasePG())
            {
                // получаем объекты из бд и выводим на консоль
                var tags = db.Tags.ToList();
                Console.WriteLine("Users list:");
                foreach (TagDb u in tags)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Value}");
                }
            }
        }
    }
}
