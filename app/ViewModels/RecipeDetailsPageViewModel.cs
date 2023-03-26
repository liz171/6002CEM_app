using app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.ViewModels
{
    /// <summary>
    /// this is the viewmodel for recipe detials page
    /// </summary>
    [QueryProperty(nameof(CurrentRecipe), "CurrentRecipe")]
    public partial class RecipeDetailsPageViewModel : BaseViewModel
    {

        [ObservableProperty]
        RecipeItem currentRecipe;


        /// <summary>
        /// go to this recipe details page
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        [RelayCommand]
        async Task Goback(RecipeItem recipe)
        {
            if (recipe == null)
                return;

            await Shell.Current.GoToAsync("..");
        }
    }
}
