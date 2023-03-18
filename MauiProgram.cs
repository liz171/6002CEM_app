global using Microsoft.Extensions.Logging;
global using System;

global using TinyMvvm;

global using app.ViewModels;
global using app.Views;

global using CommunityToolkit.Mvvm.Input;
global using CommunityToolkit.Mvvm.ComponentModel;

global using Microsoft.Maui.Controls;


namespace app;

public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddTransient<LoginView>();
        builder.Services.AddTransient<LoginViewModel>();
        return builder.Build();
    }
}

