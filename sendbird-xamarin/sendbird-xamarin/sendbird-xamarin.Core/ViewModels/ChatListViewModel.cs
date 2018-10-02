// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: ChatListViewModel.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/06/25
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Linq;
using sendbirdxamarin.Core.Notifications;
using sendbirdxamarin.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using sendbirdconnect.Models;

namespace sendbirdxamarin.Core.ViewModels
{
    public class ChatListViewModel : MvxViewModel
    {
        
        private readonly ISendbirdConnectionService _sendBird;
        private readonly IMvxMessenger _messenger;


        MvxObservableCollection<ChatListEntry> _chatList;
        public MvxObservableCollection<ChatListEntry> ChatList
        {
            get { return _chatList; }
            set
            {
                SetProperty(ref _chatList, value);
                RaisePropertyChanged(() => ChatList);
            }
        }


        private readonly IMvxNavigationService _navigationService;

           
        public IMvxCommand<ChatListEntry> ChattingViewCommand { get; }


        public ChatListViewModel(IMvxNavigationService navigationService, ISendbirdConnectionService sendBird, IMvxMessenger messenger): base()
        {

            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _sendBird = sendBird;
            _messenger = messenger;


            ChatList = new MvxObservableCollection<ChatListEntry>();
            RegisterChatListUpdateNotificationListener();
            RegisterIncomingMessageNotificationListener();
            RegisterTypingStatusNotificationListener();

            _sendBird.GetAPI().ListGroupChannels();

            ChattingViewCommand = new MvxCommand<ChatListEntry>(LoadChattingView);


        }

        private void LoadChattingView(ChatListEntry item)
        {
            _navigationService.Navigate<ChattingViewModel, ChannelInfo>(item.Data);
        }


        private MvxSubscriptionToken _tokenListUpdate;

        public void RegisterChatListUpdateNotificationListener()
        {

            _tokenListUpdate = _messenger.Subscribe<ChatListUpdateNotification>(OnChatListUpdateNotification);

        }

        private void OnChatListUpdateNotification(ChatListUpdateNotification notification)
        {
            ChatList.AddRange(
                notification.Channels.Select(k => new ChatListEntry(k)));

        }


        private void RefreshOrAddEntryInList(ChannelInfo newOrUpdatedChannel) {
            
            var index = ChatList.IndexOf(ChatList.First(a => a.Data.Equals(newOrUpdatedChannel)));
            index = (index == -1 ? 0 : index);
            ChatList[index] = new ChatListEntry(newOrUpdatedChannel);   

        }

        private MvxSubscriptionToken _tokenIncomingMessage;

        public void RegisterIncomingMessageNotificationListener()
        {

            _tokenIncomingMessage = _messenger.Subscribe<IncomingChatNotification>(OnMessageReceivedNotification);

        }

        private void OnMessageReceivedNotification(IncomingChatNotification notification)
        {
            RefreshOrAddEntryInList(notification.Channel);
        }



        private MvxSubscriptionToken _tokenTypingStatusUpdated;

        public void RegisterTypingStatusNotificationListener()
        {

            _tokenTypingStatusUpdated = _messenger.Subscribe<TypingStatusUpdateNotification>(OnTypingStatusNotification);

        }

        private void OnTypingStatusNotification(TypingStatusUpdateNotification notification)
        {
            RefreshOrAddEntryInList(notification.Channel);
        }


    }
}
