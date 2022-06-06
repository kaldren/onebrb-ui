using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Microsoft.Identity.Client;
using Microsoft.Maui.Controls.Compatibility;
using Onebrb.UI.Core.Auth;
using Onebrb.UI.Platforms.Android;
using Plugin.CurrentActivity;

using Plugin.CurrentActivity;

namespace Onebrb.UI;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle bundle)
    {
        CrossCurrentActivity.Current.Init(this, bundle);
        DependencyService.Register<IParentWindowLocatorService, AndroidParentWindowLocatorService>();


        base.OnCreate(bundle);
    }

    protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
    {
        base.OnActivityResult(requestCode, resultCode, data);
        AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(requestCode, resultCode, data);
    }
}
