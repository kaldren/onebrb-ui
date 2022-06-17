using Onebrb.UI.Pages;

namespace Onebrb.UI;

public partial class App : Application
{
    public static string ApiEndpoint = "https://onebrbapi20220607132206.azurewebsites.net/weatherforecast";

    public App(IHttpClientFactory client)
    {
        InitializeComponent();

        //MainPage = new NavigationPage(new SignInPage());
        MainPage = new NavigationPage(new ProfilePage(client));

    }
}
