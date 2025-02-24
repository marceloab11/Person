using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace PersonTable.Banco
{
    public class PersonContext : DbContext
    {
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PersonBD;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public DbSet<Modelo.Person> Person { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurando PersonId como chave primária e garantindo que seja auto-incremento
            modelBuilder.Entity<Modelo.Person>()
                .HasKey(p => p.PersonId);

            modelBuilder.Entity<Modelo.Person>()
                .Property(p => p.PersonId)
                .ValueGeneratedOnAdd();  // Indica que o valor é gerado automaticamente (auto-incremento)
        }
    }
}