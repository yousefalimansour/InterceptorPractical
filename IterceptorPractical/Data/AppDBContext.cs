using IterceptorPractical.Data.Interceptor;
using IterceptorPractical.Entities.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterceptorPractical.Data
{
    internal class AppDBContext : DbContext
    {
        public DbSet<Book> Books {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var Config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var ConnectionsStr = Config.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(ConnectionsStr)
                .AddInterceptors(new SoftDeletableIntercaptor());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);
        }
    }
}
