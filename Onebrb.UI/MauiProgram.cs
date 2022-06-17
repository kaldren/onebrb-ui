namespace Onebrb.UI;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("fa-brands-400.ttf", "FA-B");
                fonts.AddFont("fa-regular-400.ttf", "FA-R");
                fonts.AddFont("fa-solid-900.ttf", "FA-S");
            });


        // TODO: use central hub (config server) to get this data
        builder.Services.AddHttpClient("OnebrbClient", _ =>
        {
            _.BaseAddress = new Uri("https://onebrbapi20220617065854.azurewebsites.net/api/");
            _.DefaultRequestHeaders.Add("User-Agent", "MAUI");
        });

        return builder.Build();
    }
}
