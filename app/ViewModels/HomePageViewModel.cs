using Android.OS;
using app.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
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
            string targetFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "my recipe.json");
            if(File.Exists(targetFile))
            {
                using var stream = File.OpenRead(targetFile);
                using var reader = new StreamReader(stream);
                var contents = reader.ReadToEnd();
                try
                {
                    var recipeList = JsonSerializer.Deserialize<List<RecipeItem>>(contents);
                    if (recipeList != null && recipeList.Count > 0)
                    {
                        foreach (var item in recipeList)
                        {
                            MyRecipes.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        File.Delete(targetFile);
                    }
                    catch (Exception ex2)
                    {

                    }                    
                }                
            }           
        }

        private async Task SavetoFIle()
        {
            try
            {
                var content = JsonSerializer.Serialize(MyRecipes);
                // Write the file content to the app data directory
                string targetFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "my recipe.json");
                using FileStream outputStream = System.IO.File.Open(targetFile, FileMode.Create);
                using StreamWriter streamWriter = new StreamWriter(outputStream);
                await streamWriter.WriteAsync(content);
            }
            catch (Exception ex)
            {
               //maybe display some toast later to tell use that the config file write failed
            }            
        }

        public async Task AddRecipe(RecipeItem recipe)
        {
            if(recipe!= null && MyRecipes.Where(item=>item.FullName.Equals(recipe.FullName)).Count() == 0)
            {
                MyRecipes.Add(recipe);
                await SavetoFIle();
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
                await SavetoFIle();
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
