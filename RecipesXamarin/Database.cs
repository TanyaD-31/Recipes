using RecipesXamarin.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RecipesXamarin
{
    public class Database
    { 

        readonly SQLiteAsyncConnection _database;

    public Database(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Recipe>().Wait();
    }

    public Task<List<Recipe>> GetRecipesAsync()
    {
        return _database.Table<Recipe>().ToListAsync();
    }

    public Task<int> SaveRecipeAsync(Recipe recipe)
    {
        if (recipe.ID != 0)
        {
            return _database.UpdateAsync(recipe);
        }
        else
        {
            return _database.InsertAsync(recipe);
        }
    }

    public Task DeleteRecipeAsync(Recipe recipe)
    {
        
            {
                // Delete record
                return _database.DeleteAsync(recipe);

            }
        }


    public Task<Recipe> GetRecipeAsync(int id)
    {
        return _database.Table<Recipe>().Where(recipe => recipe.ID == id).FirstOrDefaultAsync();
    }
}
}


