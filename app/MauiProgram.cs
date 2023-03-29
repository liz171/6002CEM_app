global using Microsoft.Extensions.Logging;
global using System;

//global using TinyMvvm;

global using app.ViewModels;
global using app.Views;
global using app.Models;

global using CommunityToolkit.Mvvm.Input;
global using CommunityToolkit.Mvvm.ComponentModel;

global using Microsoft.Maui.Controls;
global using app.Services;
global using CommunityToolkit.Maui;

global using System.Text.Json.Serialization;


namespace app;

public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()            
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif


        //here we
        //builder.Services.AddSingleton<MyRecipeService>();
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<HomePageViewModel>();

        builder.Services.AddTransient<RecipeDetailsPage>();
        builder.Services.AddTransient<RecipeDetailsPageViewModel>();

        builder.Services.AddSingleton<RecipeService>();
        builder.Services.AddSingleton<FindRecipesPage>();
        builder.Services.AddSingleton<FindRecipesPageViewModel>();

        builder.Services.AddTransient<CreateMyRecipePage>();
        builder.Services.AddTransient<CreateMyRecipePageViewModel>();

        builder.Services.AddSingleton<ProfilePageViewModel>();
        builder.Services.AddSingleton<ProfilePage>();

        return builder.Build();
    }
}

