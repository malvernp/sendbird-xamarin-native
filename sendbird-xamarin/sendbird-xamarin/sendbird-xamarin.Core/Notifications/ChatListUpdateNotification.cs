// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: ChatListUpdateNotification.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/06/27
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections.Generic;
using MvvmCross.Plugin.Messenger;
using sendbirdconnect.Models;

namespace sendbirdxamarin.Core.Notifications
{
    public class ChatListUpdateNotification : MvxMessage
    {

        public List<ChannelInfo> Channels
        {
            get;
            private set;
        }

        public ChatListUpdateNotification(object sender, List<ChannelInfo> channels) : base(sender)
        {
            Channels = channels;
        }
    }
}
