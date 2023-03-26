namespace app.Views;

public partial class HomePage : ContentPage
{
	public HomePage(HomePageViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
}