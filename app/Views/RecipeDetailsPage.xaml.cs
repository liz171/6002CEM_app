namespace app.Views;

public partial class RecipeDetailsPage : ContentPage
{
	public RecipeDetailsPage(RecipeDetailsPageViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
    }
}