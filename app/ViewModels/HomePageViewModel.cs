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
            MyRecipes.Add(new RecipeItem()
            {
                Name = "Spring Minestrone Soup",
                Image = "https://www.simplyrecipes.com/thmb/J0sEfuGpNA8_Q-_ju5k-KQDJagM=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2011__05__spring-minestrone-vertical-b-1600-add4ea06b70d4a409b55f3dbb5f5f0ea.jpg",
                Favorite = false,
                BriefDescription = "this is a soup",
                DetailsInformation= "Minestrone is one of my favorite soups, and it is infinitely malleable with the seasons. This version celebrates springtime, when fresh, new vegetables begin to show up at the market."
            });
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



    }
}
