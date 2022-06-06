using Onebrb.UI.Core.Auth;
using Plugin.CurrentActivity;

namespace Onebrb.UI.Platforms.Android
{
    class AndroidParentWindowLocatorService : IParentWindowLocatorService
    {
        public object GetCurrentParentWindow()
        {
            return CrossCurrentActivity.Current.Activity;
        }
    }
}
