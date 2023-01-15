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

        }


        public DbSet<Recipe> Recipes => Set<Recipe>();
        // public DbSet<Ingredient> Ingredients => Set<Ingredient>();
        public DbSet<Dietary> Dietaries => Set<Dietary>();
        public DbSet<User> Users => Set<User>();
        public DbSet<NutritionalInformation> NutritionalInformations => Set<NutritionalInformation>();
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Recipe>()
        //     .HasOne(r => r.NutritionalInformation)
        //     .WithOne(i => i.Recipe)
        //     .HasForeignKey<NutritionalInformation>(i => i.RecipeId);

        //     base.OnModelCreating(modelBuilder);
        // }

    }
}