namespace Onebrb.UI;

public partial class App : Application
{
    public static string ApiEndpoint = "https://onebrb.azurewebsites.net/hello";

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
