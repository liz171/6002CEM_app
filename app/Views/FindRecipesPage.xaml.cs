namespace app.Views;

public partial class FindRecipesPage : ContentPage
{
	public FindRecipesPage(FindRecipesPageViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
    }
}