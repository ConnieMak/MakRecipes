using MakRecipes;
using MakRecipes.Models;
using System;
using System.Data.Entity;
using System.Linq;


namespace MakRecipes
{
    
    public class Recipes : DbContext
    {
        public Recipes()
            : base("name=Recipes")
        {

        }
        
        //My tables in the database
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<CustomRecipe > CustomRecipe { get; set; }
    }
    public class CustomRecipe
    {
        public int CustomRecipeId { get; set; }
        public int PersonId {get;set;}
        public virtual Person Person { get; set; }
    }
}