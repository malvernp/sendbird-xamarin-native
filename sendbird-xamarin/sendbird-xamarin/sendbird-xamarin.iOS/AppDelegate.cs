using Foundation;
using sendbird_xamarin.Core;
using MvvmCross.Platforms.Ios.Core;
using UIKit;

namespace sendbird_xamarin.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
    
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            var result = base.FinishedLaunching(application, launchOptions);

            return result;
        }

    
    }
}
