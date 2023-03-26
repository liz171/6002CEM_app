using Microsoft.Maui.Networking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.ViewModels
{
    public partial class FindRecipesPageViewModel : BaseViewModel
    {
        RecipeService recipeService;
        HomePageViewModel homePageViewModel;
        public FindRecipesPageViewModel(RecipeService recipeService,HomePageViewModel homePageViewModel)
        {
            this.recipeService= recipeService;
            this.homePageViewModel= homePageViewModel;            
        }

        public ObservableCollection<RecipeItem> AllRecipes { get; set; } = new ObservableCollection<RecipeItem>();

        [ObservableProperty]
        bool isRefreshing;

        [RelayCommand]
        async Task GetAllRecipesAsync()
        {
            if (IsBusy)
                return;

            try
            {
                //if (connectivity.NetworkAccess != NetworkAccess.Internet)
                //{
                //    await Shell.Current.DisplayAlert("No connectivity!",
                //        $"Please check internet and try again.", "OK");
                //    return;
                //}

                IsBusy = true;
                var recipelist = await recipeService.GetRecipes();

                foreach (var recipe in recipelist)
                {
                    if(AllRecipes.Where(item=>item.TypeName.Equals(recipe.TypeName)).Count() == 0)
                    {
                        AllRecipes.Add(recipe);
                    }
                }                    

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get recipes: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }

        }

        [RelayCommand]
        async Task AddtoMyRecipe(RecipeItem recipe)
        {
            if(homePageViewModel!= null)
            {
                await homePageViewModel.AddRecipe(recipe);
            }
        }


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
