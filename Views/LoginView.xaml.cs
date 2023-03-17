namespace app.Views;

public partial class LoginView {

    private readonly LoginViewModel loginViewModel;

    public LoginView(LoginViewModel loginViewModel) {
        InitializeComponent();
        this.loginViewModel = loginViewModel;

        BindingContext = loginViewModel;
    }

    protected override void OnAppearing() {
        base.OnAppearing();
        loginViewModel.PropertyChanged += LoginViewModel_PropertyChanged;
    }


    protected override void OnDisappearing() {
        base.OnDisappearing();
        loginViewModel.PropertyChanged -= LoginViewModel_PropertyChanged;
    }

    private void LoginViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
        throw new NotImplementedException();
    }

}
