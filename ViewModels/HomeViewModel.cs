using System;
namespace app.ViewModels;

public partial class HomeViewModel : ViewModel {
    public HomeViewModel() {
    }

    [ObservableProperty]
    private bool isSearching;

    [RelayCommand]
    private void StartSearch() {
        IsSearching = true;
    }
}


