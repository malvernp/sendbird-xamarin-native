// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: SendBirdResultsHandler.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/08/21
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using sendbirdxamarin.Core.Notifications;
using MvvmCross.Plugin.Messenger;
using sendbirdconnect.Models;
using sendbirdconnect.Services;
using sendbirdconnectmodels.Models;

namespace sendbirdxamarin.Core.Services
{
    public class SendBirdResultsHandler: ISendBirdResultsHandler
    {

        private readonly IMvxMessenger _messenger;

        public SendBirdResultsHandler(IMvxMessenger messenger)
        {
            _messenger = messenger;

        }


        public void HandleException(Exception e)
        {
            LogMessage(e.StackTrace);
        }

        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void OnConnectionFailed(string reason)
        {
            var message = new ConnectionStatusChangeNotification(this, ConnectionStatus.OnConnectionFailed, reason);
            _messenger.Publish(message);
        }

        public void OnConnectionSuccess()
        {
            var message = new ConnectionStatusChangeNotification(this, ConnectionStatus.OnConnectionSuccess);
            _messenger.Publish(message);
        }

        public void OnDisconnect(bool success)
        {
            //TODO create event if needed
        }

        public void OnListGroupChannels(List<ChannelInfo> channels)
        {
            var message = new ChatListUpdateNotification(this, channels);
            _messenger.Publish(message);
        }

        public void OnReconnectFailed()
        {
            var message = new ConnectionStatusChangeNotification(this, ConnectionStatus.OnReconnectFailed);
            _messenger.Publish(message);
        }

        public void OnReconnectStarted()
        {
            var message = new ConnectionStatusChangeNotification(this, ConnectionStatus.OnReconnectStarted);
            _messenger.Publish(message);
        }

        public void OnReconnectSucceeded()
        {
            var message = new ConnectionStatusChangeNotification(this, ConnectionStatus.OnReconnectSucceeded);
            _messenger.Publish(message);
        }

        public void OnMessageReceived(ChannelInfo channelInfo)
        {
            var message = new IncomingChatNotification(this, channelInfo);
            _messenger.Publish(message);
        }

        public void OnTypingStatusUpdated(ChannelInfo channelInfo)
        {
            var message = new TypingStatusUpdateNotification(this, channelInfo);
            _messenger.Publish(message);
        }

        public void OnListGroupChannelMessages(List<BaseMessageInfo> messages)
        {
            var message = new ChatUpdateNotification(this, messages);
            _messenger.Publish(message);
        }
    }
}
