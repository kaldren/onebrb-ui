namespace Onebrb.UI.Pages;

public partial class SignInPage : ContentPage
{
	public SignInPage()
	{
		InitializeComponent();
	}

    private void signInBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainTabbedPage());
    }
}