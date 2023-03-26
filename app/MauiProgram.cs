global using Microsoft.Extensions.Logging;
global using System;

global using TinyMvvm;

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
            .UseTinyMvvm()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddTransient<LoginView>();
        builder.Services.AddTransient<HomeView>();

        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<HomeViewModel>();

        builder.Services.AddSingleton<ISpotifyService, SpotifyService>();
        builder.Services.AddSingleton<ISecureStorageService, SecureStorageService>();

        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<HomePageViewModel>();

        return builder.Build();
    }
}

