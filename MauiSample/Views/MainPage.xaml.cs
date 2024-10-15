using Plugin.Firebase.CloudMessaging;

namespace MauiSample.Views;

public partial class MainPage : ContentPage
{
    private readonly MainPageViewModel _vm;
    int count = 0;

    public MainPage(MainPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
        _vm = vm;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        await _vm.LoadAsync();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        await CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
        var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();
        await DisplayAlert("FCM token", token, "OK");
    }
}

