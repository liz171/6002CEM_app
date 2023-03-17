namespace app.ViewModels;

//partial class in order to be able to use source generators
public partial class LoginViewModel : ViewModel {
    public LoginViewModel() {
    }

    [ObservableProperty]
    private bool showLogin;

    [RelayCommand]
    private void OpenLogin() {
        ShowLogin = true;
    }

}
