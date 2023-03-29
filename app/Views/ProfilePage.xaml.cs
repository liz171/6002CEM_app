namespace app.Views;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfilePageViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext=viewmodel;
	}
}