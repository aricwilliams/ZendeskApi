using Api.Models.DBUsers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        //pass to the base class our options, this will have the connection string located in appsetting.json (aric williams)
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //this dbset is for adding tickets to the database (aric williams)
        public DbSet<Tickets> Tickets { get; set; }
    }
}

//this is for making out database connection into an object (aric williams)