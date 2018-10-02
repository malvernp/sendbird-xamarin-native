// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: ISendBirdResultsHandler.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/08/21
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using sendbirdconnect.Models;
using sendbirdconnectmodels.Models;

namespace sendbirdconnect.Services
{
    public interface ISendBirdResultsHandler
    {

        void LogMessage(String message);  

        void HandleException(Exception e);


        //all events

        void OnReconnectFailed();

        void OnReconnectStarted();

        void OnReconnectSucceeded();

        void OnConnectionFailed(string reason);

        void OnConnectionSuccess();

        void OnDisconnect(bool success);

        void OnListGroupChannels(List<ChannelInfo> channels);

        void OnListGroupChannelMessages(List<BaseMessageInfo> messages);

        //message events

        void OnMessageReceived(ChannelInfo channelInfo);

        void OnTypingStatusUpdated(ChannelInfo channelInfo);

    }
}
