using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetApiWithDocker.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() {} // Construtor Padrão vazio

        public MySQLContext(DbContextOptions<MySQLContext> options) : base (options) { } // Construtor do Entity framework

        public DbSet<Person> Persons { get; set; } 
    }
}
