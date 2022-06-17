using Newtonsoft.Json;
using Onebrb.UI.Models;

namespace Onebrb.UI.Pages;

public partial class ProfilePage : ContentPage
{
    private readonly IHttpClientFactory httpClientFactory;
    private readonly HttpClient httpClient;

    public ProfilePage(IHttpClientFactory httpClientFactory)
    {
        InitializeComponent();
        this.httpClientFactory = httpClientFactory;

        this.httpClient = this.httpClientFactory.CreateClient("OnebrbClient");
    }

    protected async override void OnAppearing()
    {
        //loading.Text = "Loading profile...";
    }

    private async void profileBtn_Clicked(object sender, EventArgs e)
    {
        var result = await httpClient.GetAsync("profiles/2");

        if (result.IsSuccessStatusCode)
        {
            var jsonResult = await result.Content.ReadAsStringAsync();
            var profile = JsonConvert.DeserializeObject<ProfileModel>(jsonResult);


            profileFirstName.Text = profile.FirstName;
            profileLastName.Text = profile.LastName;
            profileEmail.Text = profile.Email;
        }
    }
}