namespace app.Views;

public partial class CreateMyRecipePage : ContentPage
{
	public CreateMyRecipePage(CreateMyRecipePageViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext=viewmodel;
	}
}