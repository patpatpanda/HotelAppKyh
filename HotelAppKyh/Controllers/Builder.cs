using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelAppKyh.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelAppKyh.Controllers
{
    public class Builder
    {
        public AppDbContext AppBuilder()
        {

            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();

            var options = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);

            var myContext = new AppDbContext(options.Options);

            var dataSeeder = new DataSeeder();
            dataSeeder.MigrateAndSeed(myContext);

            var dbContextReturned = new AppDbContext(options.Options);
            return dbContextReturned;
        }

    }
}
