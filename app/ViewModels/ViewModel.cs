namespace app.ViewModels;

public abstract class ViewModel : TinyViewModel {
    public ViewModel() {
    }

    protected Task HandleException(Exception ex) {
        Console.Write(ex);
        return Task.CompletedTask;
    }

}
