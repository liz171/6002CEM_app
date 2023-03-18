﻿using System.Net;

namespace app.Views;

public partial class LoginView {

    private readonly LoginViewModel loginViewModel;
    private readonly string state;

    public LoginView(LoginViewModel loginViewModel) {
        InitializeComponent();
        this.loginViewModel = loginViewModel;

        BindingContext = loginViewModel;

        state = Guid.NewGuid().ToString();

        //adding a webview handler to allow login through the browser
        //different compiler instructions to handle each platform's native webview
        Microsoft.Maui.Handlers.WebViewHandler.Mapper.AppendToMapping("UserAgentLogin", (handler, webview) => {
            var userAgent = "Chrome";
#if ANDROID
            handler.PlatformView.Settings.UserAgentString = userAgent;
#elif IOS
            handler.PlatformView.CustomUserAgent = userAgent;
#endif
        });
    }

    protected override void OnAppearing() {
        base.OnAppearing();
        loginViewModel.PropertyChanged += LoginViewModel_PropertyChanged;
        LoginWeb.Navigating += LoginWeb_Navigating;
    }

    protected override void OnDisappearing() {
        base.OnDisappearing();
        loginViewModel.PropertyChanged -= LoginViewModel_PropertyChanged;
        LoginWeb.Navigating -= LoginWeb_Navigating;
    }

    private void LoginViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
        if (e.PropertyName == nameof(loginViewModel.ShowLogin)) {
            var scopes = "playlist-read-private playlist-modified-private";
            var querystring = $"response_type=code&client_id={Constants.SpotifyClientId}&scopes={WebUtility.UrlEncode(scopes)}&redirect_uri={Constants.RedirectUrl}&state={state}";
            LoginWeb.Source = $"https://accounts.spotify.com/authorize?{querystring}";
            Login.TranslationY = this.Height;
            Login.IsVisible = true;
            Login.TranslateTo(Login.X, 100, easing: Easing.Linear);
        }
    }

    private void LoginWeb_Navigating(object sender, WebNavigatingEventArgs e) {
        throw new NotImplementedException();
    }

}
