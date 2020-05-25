using RecipesXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipesXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeEditPage : ContentPage
    {

        Recipe TheRecipe { get; set; }
        bool IsNew { get; set; }

        public RecipeEditPage()
        {
            InitializeComponent();

            TheRecipe = new Recipe();
            IsNew = true;

            InitializePage();
        }

        public RecipeEditPage(Recipe recipe)
        {
            InitializeComponent();

            TheRecipe = recipe;
            IsNew = false;

            InitializePage();
        }

        void InitializePage()
        {
            Title = TheRecipe.Name ?? "New Recipe";

            recipeNameCell.Text = TheRecipe.Name;
            ingredientsCell.Text = TheRecipe.Ingredients;
            directionsCell.Text = TheRecipe.Directions;

            saveButton.Clicked += async (sender, args) =>
            {
                SaveRecipe();
                await CloseWindow();
            };

            deleteButton.Clicked += async (sender, args) =>
            {
                DeleteRecipe();
                await CloseWindow();
            };

            cancelButton.Clicked += async (sender, args) =>
            {
                await CloseWindow();
            };
        }

        async Task CloseWindow()
        {
           await Navigation.PushAsync(new RecipeListPage());
  
        }

       async void SaveRecipe()
        {
   
            if (!string.IsNullOrWhiteSpace(recipeNameCell.Text))
            {
                await App.Database.SaveRecipeAsync(new Recipe
                {
                    ID = TheRecipe.ID,
                    Name = recipeNameCell.Text,
                    Ingredients = ingredientsCell.Text,
                    Directions = directionsCell.Text
                });

            }
        }

        async void DeleteRecipe()
        {
             if (!IsNew)
            {
                await App.Database.DeleteRecipeAsync(new Recipe
                {
                    ID = TheRecipe.ID,
                    Name = recipeNameCell.Text,
                    Ingredients = ingredientsCell.Text,
                    Directions = directionsCell.Text
                });

            }
        }

    }
    }
 