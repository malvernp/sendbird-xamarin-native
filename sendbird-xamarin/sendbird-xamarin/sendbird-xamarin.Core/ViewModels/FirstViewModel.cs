using System;
using sendbirdxamarin.Core.ViewModels;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace sendbird_xamarin.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        string hello = "Hello MvvmCross";
        public string Hello
        {
            get { return hello; }
            set { SetProperty(ref hello, value); }
        }

        public IMvxAsyncCommand ShowChatsViewModelCommand { get; private set; }

        private readonly IMvxNavigationService _navigationService;

        public FirstViewModel(IMvxNavigationService navigationService) : base()
        {

            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            ShowChatsViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<ChatListViewModel>());
        }

    }
}


