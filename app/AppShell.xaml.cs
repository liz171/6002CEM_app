namespace app;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(RecipeDetailsPage), typeof(RecipeDetailsPage));
        Routing.RegisterRoute(nameof(FindRecipesPage), typeof(FindRecipesPage));
        Routing.RegisterRoute(nameof(CreateMyRecipePage), typeof(CreateMyRecipePage));
        Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
    }
}

