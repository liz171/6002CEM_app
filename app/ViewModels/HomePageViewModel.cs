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
        /// service to save my recipes
        /// </summary>
        //MyRecipeService myRecipeService;

        /// <summary>
        /// all my recipes
        /// </summary>
        public ObservableCollection<RecipeItem> MyRecipes { get; set; } = new ObservableCollection<RecipeItem>();


        public HomePageViewModel()
        {
           
        }

        public async Task AddRecipe(RecipeItem recipe)
        {
            if(recipe!= null && MyRecipes.Where(item=>item.FullName.Equals(recipe.FullName)).Count() == 0)
            {
                MyRecipes.Add(recipe);
                var service = await MyRecipeService.Instance;
                await service.SaveRecipe(recipe);                
            }
        }

        /// <summary>
        /// delete this recipe
        /// </summary>
        /// <param name="recipe"></param>
        [RelayCommand]
        async Task DeleteRecipe(RecipeItem recipe)
        {
            if(recipe != null && MyRecipes.Contains(recipe))
            {
                MyRecipes.Remove(recipe);
                var service = await MyRecipeService.Instance;
                await service.DeleteRecipe(recipe.FullName);                
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
