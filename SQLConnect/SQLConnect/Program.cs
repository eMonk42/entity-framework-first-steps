using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SQLConnect
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            var context = serviceProvider.GetService<Context>();

            var lukas = context.Users.Where(u => u.FirstName == "Lukas").FirstOrDefault();

            //lukas.TelephoneNumbers.Add(new TelephoneNumber { Type = "Fax", Number = "not safe" });

            //context.SaveChanges();


            //------------------------------------------------------------


            var numbers = context.Users.Include(a => a.TelephoneNumbers).Where(u => u.FirstName == "Lukas").ToList()[0].TelephoneNumbers;

            if (!numbers.Any())
            {
                Console.WriteLine("no phone numbers");
            }
            else
            {
                Console.WriteLine("There are "+numbers.Count+" numbers for this user.");
                foreach (var number in numbers)
                {
                    Console.WriteLine(number.Type + ":\t\t" + number.Number);
                }
            }

        }

        // needed for creating a new migrations-state. Needs 'using Microsoft.Extensions.Hosting;'

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureServices(ConfigureServices);
        }

        // That's the code you'll need in your main Function/Application to establish a connection to the database. Use a connectionString based on the SQL-DB you wish to use. Here it is PostgresSQL

        static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options => options.UseNpgsql(@"Server=127.0.0.1;Port=5432;Database=spark;User Id=spark;Password=mysparkpassword;"));
        }
    }
}
