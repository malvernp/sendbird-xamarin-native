// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: LoginViewModel.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/09/14
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using sendbird_xamarin.Core;
using sendbirdxamarin.Core.Notifications;
using sendbirdxamarin.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using sendbirdconnect.Utils;

namespace sendbirdxamarin.Core.ViewModels
{
    public class LoginViewModel: MvxViewModel
    {
    

        private readonly ISendbirdConnectionService _sendbird;
        private readonly IMvxMessenger _messenger;
        private readonly IMvxNavigationService _navigationService;
        private readonly IContext _context;

    
        string userId = "";
        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

        string nickName = "";
        public string NickName
        {
            get { return nickName; }
            set { SetProperty(ref nickName, value); }
        }


        string profileUrl = "";
        public string ProfileUrl
        {
            get { return profileUrl; }
            set { SetProperty(ref profileUrl, value); }
        }


        bool showConnectProgress;
        public bool ShowConnectProgress
        {
            get { return showConnectProgress; }
            set { SetProperty(ref showConnectProgress, value); }
        }



        public string VersionInfo
        {
            get 
            {
                return String.Format("{0} / v{1} / SDK v{2}",
                                     _context.GetAppName(),
                                     _context.GetAppVersion(), 
                                     _sendbird.GetAPI().GetSDKVersion());
            }
        }

        public IMvxCommand ShowChatListViewModelCommand { get; private set; }



        public LoginViewModel(IMvxNavigationService navigationService, ISendbirdConnectionService sendBird, IMvxMessenger messenger, IContext context) : base()
        {

            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _sendbird = sendBird;
            _messenger = messenger;
            _context = context;

            ShowChatListViewModelCommand = new MvxCommand(LoginConnect);

            RegisterConnectionStatusChangeNotificationListener();
        }


        private void LoginConnect()
        {

            if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(nickName) ) {
                ShowConnectProgress = true;

                var finalProfileUrl = !string.IsNullOrEmpty(profileUrl) ? profileUrl :
                                             ("https://dummyimage.com/40x40/a1a1a1/000000.png&text=" + NickName.ToLower()[0]);
                _sendbird.GetAPI().Connect(userId, nickName, finalProfileUrl);
                LocalCache.CurrentNickName = nickName;
            }

        }


        //connection status change event
        private MvxSubscriptionToken _tokenConnectionChange;

        public void RegisterConnectionStatusChangeNotificationListener()
        {

            _tokenConnectionChange = _messenger.Subscribe<ConnectionStatusChangeNotification>(OnConnectionStatusChangeNotification);

        }

        private void OnConnectionStatusChangeNotification(ConnectionStatusChangeNotification notification)
        {

            if (notification.Status == Notifications.ConnectionStatus.OnConnectionSuccess) {
                _navigationService.Navigate<ChatListViewModel>();
            }

            else {
                //TODO handle connection failed
                Console.WriteLine(notification.Message);

            }
            ShowConnectProgress = false;

        }




    
    }
}
