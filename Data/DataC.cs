using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace recipe_server
{
    public class DataC : DbContext
    {
        public DataC(DbContextOptions<DataC> options) : base(options)
        {
         Database.EnsureCreated();
        }



        public DbSet<Recipe> Recipes => Set<Recipe>();
        // public DbSet<User> Users => Set<User>();

    }
}