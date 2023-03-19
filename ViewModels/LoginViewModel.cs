namespace app.ViewModels;

//partial class in order to be able to use source generators
public partial class LoginViewModel : ViewModel {

    private readonly ISpotifyService spotifyService;

    public LoginViewModel(ISpotifyService spotifyService) {
        this.spotifyService = spotifyService;
    }

    [ObservableProperty]
    private bool showLogin;


    [RelayCommand]
    private void OpenLogin() {
        ShowLogin = true;
    }

    public async Task HandleAuthCode(string authCode) {
        await spotifyService.Initialize(authCode);
    }

}
