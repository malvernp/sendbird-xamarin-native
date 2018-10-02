using sendbird_xamarin.Core.ViewModels;
using sendbirdxamarin.Core.Services;
using sendbirdxamarin.Core.ViewModels;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using sendbirdconnect.Services;
using sendbirdconnect.Utils;

namespace sendbird_xamarin.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {

            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.LazyConstructAndRegisterSingleton<IMvxMessenger, MvxMessengerHub>();

            Mvx.LazyConstructAndRegisterSingleton<ISendBirdResultsHandler, SendBirdResultsHandler>();
            Mvx.LazyConstructAndRegisterSingleton<IContext, Context>();

            RegisterAppStart<LoginViewModel>();

            var _sendbird = Mvx.Resolve<ISendbirdConnectionService>();

            _sendbird.GetAPI().InitWithApplicationId();

        }
    }
}
