using RecipesXamarin.Models;
using RecipesXamarin.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipesXamarin
{
     public partial class App : Application
    {
        public static System.Collections.Generic.List<Recipe> AllRecipes { get; set; }
        static Database database;
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Recipes.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
 
            var np = new NavigationPage(new RecipeListPage());
            np.BarBackgroundColor = Color.FromHex("#01487E");
            np.BarTextColor = Color.White;
            MainPage = np;
        }

        protected override void OnStart()
        {
            // Handle when your app starts

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}