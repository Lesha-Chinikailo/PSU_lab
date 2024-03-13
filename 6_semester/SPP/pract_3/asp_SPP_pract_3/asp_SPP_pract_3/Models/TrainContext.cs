using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
//using System.Data.Entity;
using System.Reflection.Metadata;

namespace asp_SPP_pract_3.Models
{
    public class TrainContext : DbContext
    {
        private static TrainContext _trainContext;
        private static  string _connectionString;
        public TrainContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Carriage> Carriages { get; set; }
        public static TrainContext GetInstance()
        {
            if(_trainContext == null)
                _trainContext = new TrainContext(_connectionString);
            return _trainContext;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
