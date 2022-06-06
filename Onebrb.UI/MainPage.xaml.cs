using Microsoft.Identity.Client;
using Onebrb.UI.Core.Auth;

namespace Onebrb.UI;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private async void SignInBtn_Clicked(object sender, EventArgs e)
    {
		var userContext = await B2CAuthenticationService.Instance.SignInAsync();
        UpdateSignInState(userContext);
        UpdateUserInfo(userContext);
    }

    void UpdateSignInState(UserContext userContext)
    {
        var isSignedIn = userContext.IsLoggedOn;
        btnSignInSignOut.Text = isSignedIn ? "Sign out" : "Sign in";
        btnEditProfile.IsVisible = isSignedIn;
        btnCallApi.IsVisible = isSignedIn;
        slUser.IsVisible = isSignedIn;
        lblApi.Text = "";
    }
    public void UpdateUserInfo(UserContext userContext)
    {
        lblName.Text = userContext.Name;
        lblJob.Text = userContext.JobTitle;
        lblCity.Text = userContext.City;
    }

    async void OnEditProfile(object sender, EventArgs e)
    {
        try
        {
            var userContext = await B2CAuthenticationService.Instance.EditProfileAsync();
            UpdateSignInState(userContext);
            UpdateUserInfo(userContext);
        }
        catch (Exception ex)
        {
            // Alert if any exception excluding user canceling sign-in dialog
            if (((ex as MsalException)?.ErrorCode != "authentication_canceled"))
                await DisplayAlert($"Exception:", ex.ToString(), "Dismiss");
        }
    }
    async void OnResetPassword(object sender, EventArgs e)
    {
        try
        {
            var userContext = await B2CAuthenticationService.Instance.ResetPasswordAsync();
            UpdateSignInState(userContext);
            UpdateUserInfo(userContext);
        }
        catch (Exception ex)
        {
            // Alert if any exception excluding user canceling sign-in dialog
            if (((ex as MsalException)?.ErrorCode != "authentication_canceled"))
                await DisplayAlert($"Exception:", ex.ToString(), "Dismiss");
        }
    }
    async void OnPasswordReset()
    {
        try
        {
            var userContext = await B2CAuthenticationService.Instance.ResetPasswordAsync();
            UpdateSignInState(userContext);
            UpdateUserInfo(userContext);
        }
        catch (Exception ex)
        {
            // Alert if any exception excluding user canceling sign-in dialog
            if (((ex as MsalException)?.ErrorCode != "authentication_canceled"))
                await DisplayAlert($"Exception:", ex.ToString(), "Dismiss");
        }
    }

    async void OnCallApi(object sender, EventArgs e)
    {
        try
        {
            lblApi.Text = $"Calling API {App.ApiEndpoint}";
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
                lblApi.Text = $"Response from API {App.ApiEndpoint} | {responseString}";
            }
            else
            {
                lblApi.Text = $"Error calling API {App.ApiEndpoint} | {responseString}";
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

