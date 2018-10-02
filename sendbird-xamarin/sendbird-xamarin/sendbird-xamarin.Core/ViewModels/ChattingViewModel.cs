// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: ChattingViewModel.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/08/24
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Linq;
using sendbirdxamarin.Core.Notifications;
using sendbirdxamarin.Core.Services;
using sendbirdxamarin.Core.ViewModels.Messages;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using sendbirdconnect.Models;
using sendbirdconnectmodels.Models;

namespace sendbirdxamarin.Core.ViewModels
{
    public class ChattingViewModel : MvxViewModel<ChannelInfo>
    {
        
        private readonly IMvxNavigationService _navigationService;
        private readonly ISendbirdConnectionService _sendBird;


        ChannelInfo _channel;
        public ChannelInfo Channel
        {
            get { return _channel; }
            set
            {
                SetProperty(ref _channel, value);
                RaisePropertyChanged(() => Channel);
            }
        }


        MvxObservableCollection<ChatMessageBase> _chatMessages;
        public MvxObservableCollection<ChatMessageBase> ChatMessages
        {
            get { return _chatMessages; }
            set
            {
                SetProperty(ref _chatMessages, value);
                RaisePropertyChanged(() => ChatMessages);
            }
        }




        private readonly IMvxMessenger _messenger;

        public ChattingViewModel(IMvxNavigationService navigationService, ISendbirdConnectionService sendBird, IMvxMessenger messenger) : base()
        {

            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _sendBird = sendBird;
            _messenger = messenger;

            ChatMessages = new MvxObservableCollection<ChatMessageBase>();

            RegisterTypingStatusNotificationListener();

            RegisterChatMessagesUpdateNotificationListener();

        }


        //messages update events
        private MvxSubscriptionToken _tokenListUpdate;

        public void RegisterChatMessagesUpdateNotificationListener()
        {

            _tokenListUpdate = _messenger.Subscribe<ChatUpdateNotification>(OnChatMessagesUpdateNotification);

        }

        private void OnChatMessagesUpdateNotification(ChatUpdateNotification notification)
        {
            ChatMessages.AddRange(
                notification.Messages.Select(k => ChatMessageBase.Create(k)));

        }



        //typing events
        private MvxSubscriptionToken _tokenTypingStatusUpdated;

        public void RegisterTypingStatusNotificationListener()
        {

            _tokenTypingStatusUpdated = _messenger.Subscribe<TypingStatusUpdateNotification>(OnTypingStatusNotification);

        }

        private void OnTypingStatusNotification(TypingStatusUpdateNotification notification)
        {
            if (notification.Channel != null && notification.Channel.Equals(_channel)) {
                Channel = notification.Channel;
            }

        }


        public override void Prepare(ChannelInfo parameter)
        {
            _channel = parameter;
            _sendBird.GetAPI().ListGroupChannelMessages(_channel);
        }
    }
}
