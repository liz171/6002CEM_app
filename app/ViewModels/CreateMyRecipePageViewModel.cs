using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            newRecipe = new RecipeItem() 
            { 
              Image= "https://www.simplyrecipes.com/thmb/IK39FdCt7aQUEztXVBUrx0BzzH0=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/SR-LEAD-OPTION-001b-cc24c120a74749748365ec053509ebc9.jpg",
              TypeName="Custom",
              FullName="My secret Recipe",
              BriefDescription="this is my secret recipe created by me",
              CookTime="45 min",
              Steps=new ObservableCollection<StepModel>() 
              { 
                 new StepModel()
                 { 
                   Image="https://www.simplyrecipes.com/thmb/ivE1Fp-yQSBq_k2rGbu15y_iGwY=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/Primary-Image-best-pescatarian-meal-delivery-services-of-2023-7367997-f43c10514b2d40af853cc6bc8eff554a.jpg",
                   Index=1,
                   FirstStep="please enter the main step description",
                   SecondStep="please enter the detailed descripton"
                 }
              }              
            };
        }

        /// <summary>
        /// this is the newly created recipe
        /// </summary>
        [ObservableProperty]
        RecipeItem newRecipe;

        [RelayCommand]
        async Task AddtoMyRecipe()
        {
            if (homePageViewModel != null)
            {
                if (homePageViewModel.MyRecipes.Where(item => item.TypeName.Equals(NewRecipe.TypeName)).Count() == 0)
                {
                    await homePageViewModel.AddRecipe(NewRecipe);
                    await Shell.Current.GoToAsync("..");
                }
            }
        }


        [RelayCommand]
        async Task Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        void AddStep()
        {
            NewRecipe.Steps.Add(new StepModel() { Index = NewRecipe.Steps.Count+1, Image = "", FirstStep = "enter brief description", SecondStep = "enter detailed description" });
        }


    }

   

    
}
