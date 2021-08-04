# Connect and manage a DB with C# and Entity Framework

## Set up Postgres & PGAdmin:

cd into the dir with th .yml file and run "docker-compose up"

if you dont't have a -yml file check out you boilerplate on GitHub. There is one for postgres-pgadmin.

other helpful commands are: "docker container list -a" and "docker stop $(docker ps -aq)" - to stop all containers.

visit localhost:9001 to log into pgadmin anf choose new server. The name is in the field name/host type the alias from the .yml, which is "postgres". Insert all other data as it is stated int he .yml-file.

The DB is already created, so just add a new table and enter some mock-data.

## How to connect with JS:

As you would expect it. Use pg-package, create a pool with your credentials and then run a query.

## Set up your C# Project

You'll need the following nuget packages:

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.Extensions.DependencyInjection
- Npqsql.EntityFrameworkCore.PostgreSQL

Create two new classes in your project: one named like your table and one named like Context or so. The Contex.cs file is for your Entity Framework to registrate which tables you want to work with. For example when you have a user table and a telephoneNumber table you woul register the Users-table but probably not the TelephoneNumber table because you most likely would access the number via the user table based on a userId.

### Why is Entity Framework so cool?

You create classes based on your tables and wok with them without having to write a single line of SQL! Entity Framework also creates the schema for you and even interrelational tables if needed.
You run the Entity framework by:
'dotnet ef ...'

- dotnet tool update --global dotnet-ef (to initiate)
- dotnet ef migrations add <name> (to add a new state -> a migrations-folder will be created, or - if it already exists - a new set of files)
- dotnet ef remove (to remove the latest state added to migrations)
- dotnet ef database update (to add the desired changes to the database)

EF will automatically create Indexes for your tables, figure out which table to remove/add in what order and all the stuff that you don't really enjoy about manually creating a DB. You can also run it from a pipeline so schemas can be changed without having issues.

### Connecting to DB

- create a new ServiceCollection - object. This is part of the Microsoft.Extensions.DependencyInjection - package.
- call .AddDbContext<yourContext> on it with (options => options.UseNpgsql(connString)). The UseNpgsql is also part of the package from the step earlier. For the connString you can get a template here: https://web.archive.org/web/20210502141547/https://www.connectionstrings.com/postgresql/
- now you can use this object to create a new ServiceProvider - object by typing "var serviceProvider = services.BuildServiceProvider();"
- Now you can use your Context on this and interact with it based on your tables/classes you creatd. When you want to get a user for exmple you can do the following: 'var context = serviceProvider.GetService<Context>; var user = context.Users.Where(u => u.FirstName == 'name')'
- You can also insert information to the DB by doing the following:

            var lukas = context.Users.Where(u => u.FirstName == "Lukas").FirstOrDefault();

            lukas.TelephoneNumbers.Add(new TelephoneNumber { Type = "Fax", Number = "not safe" });

            context.SaveChanges();

The context.SaveChanges is very essential here. EF is keeping track locally what changes you make but you have to call SaveChanges in order to take effect and change the DB.

What your User.cs file should look like:

    [Table("users", Schema = "public")]
    public class User
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("first_name", TypeName = "varchar(40)")]
        [Required]
        [MaxLength(40)]
        public string FirstName { get; set; }

        [Column("last_name", TypeName = "varchar(40)")]
        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }

        [Column("age")]
        [Required]
        public int Age { get; set; }

        [Column("telephone_numbers")]
        [Required]
        public virtual ICollection<TelephoneNumber> TelephoneNumbers { get; set; } = new List<TelephoneNumber>();
    }

For the last part you will also need a TelephoneNumber - class.
Also for the []-SQL-Syntax you'll need the DataAnnotations-Package(s):

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

General Note: Postgres has difficulties with table-names that start with an uppercase letter. If you want to run a select on one of those you will have to wrap the name in double-quotes.
