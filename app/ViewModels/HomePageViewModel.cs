using app.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.ViewModels
{
    public partial class HomePageViewModel : BaseViewModel
    {
        /// <summary>
        /// all my recipes
        /// </summary>
        public ObservableCollection<RecipeItem> MyRecipes { get; set; } = new ObservableCollection<RecipeItem>();


        public HomePageViewModel()
        {
           
        }

        /// <summary>
        /// delete this recipe
        /// </summary>
        /// <param name="recipe"></param>
        [RelayCommand]
        void DeleteRecipe(RecipeItem recipe)
        {
            if(recipe != null && MyRecipes.Contains(recipe))
            {
                MyRecipes.Remove(recipe);
            }
        }

        /// <summary>
        /// go to this recipe details page
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        [RelayCommand]
        async Task GoToDetails(RecipeItem recipe)
        {
            if (recipe == null)
                return;

            await Shell.Current.GoToAsync(nameof(RecipeDetailsPage), true, new Dictionary<string, object>
            {
                {"CurrentRecipe", recipe }
            });
        }

        /// <summary>
        /// go to find all the recipes
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        async Task GoToFindRecipes()
        {
            await Shell.Current.GoToAsync(nameof(FindRecipesPage), true);
        }

        [RelayCommand]
        async Task GoToCreateMyRecipe()
        {
            await Shell.Current.GoToAsync(nameof(CreateMyRecipePage), true);
        }
    }
}
