using Onebrb.UI.Pages;

namespace Onebrb.UI;

public partial class App : Application
{
    public static string ApiEndpoint = "https://onebrbapi20220607132206.azurewebsites.net/weatherforecast";

    public App()
	{
		InitializeComponent();

        MainPage = new NavigationPage(new SignInPage());

    }
}
