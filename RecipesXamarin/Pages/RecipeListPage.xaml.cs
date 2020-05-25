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
    public partial class RecipeListPage : ContentPage
    {

        public RecipeListPage()
        {
            InitializeComponent();

            recipesList.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem != null)
                {
                    var detailPage = new RecipeDetailPage(e.SelectedItem as Recipe);

                    await Navigation.PushAsync(detailPage);

                    recipesList.SelectedItem = null;
                }
            };
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            recipesList.ItemsSource = await App.Database.GetRecipesAsync();
         }

        async void Add_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RecipeEditPage());
        }
    }
}