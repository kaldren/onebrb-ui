using Microsoft.Identity.Client;
using Onebrb.UI.Core.Auth;

namespace Onebrb.UI.Pages;

public partial class SignInPage : ContentPage
{
	public SignInPage()
	{
		InitializeComponent();
	}

    private async void signInBtn_Clicked(object sender, EventArgs e)
    {
        try
        {
            signInStatusLabel.Text = "Please wait a moment...";

            var userContext = await B2CAuthenticationService.Instance.SignInAsync();
            var token = userContext.AccessToken;

            // Get data from API
            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, App.ApiEndpoint);
            message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.SendAsync(message);
            string responseString = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                //lblApi.Text = $"Response from API {App.ApiEndpoint} | {responseString}";
                Navigation.PushAsync(new MainTabbedPage());
            }
            else
            {
                //lblApi.Text = $"Error calling API {App.ApiEndpoint} | {responseString}";
            }
        }
        catch (MsalUiRequiredException ex)
        {
            await DisplayAlert($"Session has expired, please sign out and back in.", ex.ToString(), "Dismiss");
        }
        catch (Exception ex)
        {
            await DisplayAlert($"Exception:", ex.ToString(), "Dismiss");
        }

    }
}