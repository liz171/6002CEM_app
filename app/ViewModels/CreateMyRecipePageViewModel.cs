using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.ViewModels
{
    public partial class CreateMyRecipePageViewModel : BaseViewModel
    {

        HomePageViewModel homePageViewModel;

        public CreateMyRecipePageViewModel(HomePageViewModel homePageViewModel)
        {
            this.homePageViewModel= homePageViewModel;

            newRecipe = new RecipeItem();
        }

        /// <summary>
        /// this is the newly created recipe
        /// </summary>
        [ObservableProperty]
        RecipeItem newRecipe;

        [RelayCommand]
        void AddtoMyRecipe()
        {
            if (homePageViewModel != null)
            {
                if (homePageViewModel.MyRecipes.Where(item => item.TypeName.Equals(NewRecipe.TypeName)).Count() == 0)
                {
                    homePageViewModel.MyRecipes.Add(NewRecipe);
                }
            }
        }


        [RelayCommand]
        async Task Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }


    }

   

    
}
