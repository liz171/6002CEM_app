using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace app.Services
{
    public class RecipeService
    {
        HttpClient httpClient;
        public RecipeService()
        {
            this.httpClient = new HttpClient();
        }

        List<RecipeItem> recipeList;
        public async Task<List<RecipeItem>> GetRecipes()
        {
            if (recipeList?.Count > 0)
                return recipeList;

            // Online,not finished
            //var response = await httpClient.GetAsync("https://www.simplyrecipes.com/");
            //if (response.IsSuccessStatusCode)
            //{
            //    recipeList = await response.Content.ReadFromJsonAsync<List<RecipeItem>>();
            //}
            // Offline
            using var stream = await FileSystem.OpenAppPackageFileAsync("recipedata.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            recipeList = JsonSerializer.Deserialize<List<RecipeItem>>(contents);

            return recipeList;
        }
    }

    

}
