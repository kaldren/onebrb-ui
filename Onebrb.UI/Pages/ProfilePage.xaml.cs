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
        //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "Profile/2");

        var result = await httpClient.GetAsync("profiles/2");

        if (result.IsSuccessStatusCode)
        {
            profileFirstName.Text = await result.Content.ReadAsStringAsync();
            var content = await result.Content.ReadAsStringAsync();

            return;
        }
    }
}