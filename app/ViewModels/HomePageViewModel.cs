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
            Title = "My Recipes";            
        }

        [RelayCommand]
        void AddRecipe()
        {
            MyRecipes.Add(new RecipeItem()
            {
                Name = "Spring Minestrone Soup",
                Image = "https://www.simplyrecipes.com/thmb/J0sEfuGpNA8_Q-_ju5k-KQDJagM=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2011__05__spring-minestrone-vertical-b-1600-add4ea06b70d4a409b55f3dbb5f5f0ea.jpg",
                Favorite = false,
                BriefDescription = "Spring Soup"
            });
        }

    }
}
