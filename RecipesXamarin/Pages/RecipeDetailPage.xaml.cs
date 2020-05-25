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
    public partial class RecipeDetailPage : ContentPage
    {
        Recipe TheRecipe { get; set; }

        public RecipeDetailPage()
        {
            InitializeComponent();
        }

        public RecipeDetailPage(Recipe recipe)
        {
            InitializeComponent();

            TheRecipe = recipe;

            BindingContext = TheRecipe;
        }

        async void Edit_Clicked(object sender, System.EventArgs e)
        {
            var editPage = new RecipeEditPage(TheRecipe);

               await Navigation.PushAsync(editPage);
        }
    }
}