// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: IncomingChatNotification.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/08/23
// Author: malvern
// Description: a new message received - represented by the channel update ( new or existing update)
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using MvvmCross.Plugin.Messenger;
using sendbirdconnect.Models;

namespace sendbirdxamarin.Core.Notifications
{
    public class IncomingChatNotification : MvxMessage
    {
        public ChannelInfo Channel
        {
            get;
            private set;
        }

        public IncomingChatNotification(object sender, ChannelInfo channel) : base(sender)
        {
            Channel = channel;
        }
    }
}
