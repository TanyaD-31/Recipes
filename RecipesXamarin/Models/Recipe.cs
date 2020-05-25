using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipesXamarin.Models
{
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Directions { get; set; }
    }
}
