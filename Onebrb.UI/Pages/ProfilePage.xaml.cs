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
        //var profileId = profileIdEntry.Text;
        //var result = await httpClient.GetAsync($"profiles/{profileId}");

        //if (result.IsSuccessStatusCode)
        //{
        //    var jsonResult = await result.Content.ReadAsStringAsync();
        //    var profile = JsonConvert.DeserializeObject<ProfileModel>(jsonResult);


        //    profileFirstName.Text = profile.FirstName;
        //    profileLastName.Text = profile.LastName;
        //    profileEmail.Text = profile.Email;
        //}

        var profileModel = new ProfileModel
        {
            About = "Hairdresser located in LA",
            FirstName = "John",
            LastName = "Doe",
            Email = "john@example.com",
            Phone = "+359 888 123 456"
        };

        profileName.Text = $"{profileModel.FirstName} {profileModel.LastName}";
        profileAbout.Text = profileModel.About;
        profileEmail.Text = profileModel.Email;
        profilePhone.Text = profileModel.Phone;
    }
}