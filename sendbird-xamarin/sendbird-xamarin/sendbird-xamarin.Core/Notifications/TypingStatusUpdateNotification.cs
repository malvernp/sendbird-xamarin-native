// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: TypingStatusUpdateNotification.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/08/24
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using MvvmCross.Plugin.Messenger;
using sendbirdconnect.Models;

namespace sendbirdxamarin.Core.Notifications
{
    public class TypingStatusUpdateNotification : MvxMessage
    {
        public ChannelInfo Channel
        {
            get;
            private set;
        }

        public TypingStatusUpdateNotification(object sender, ChannelInfo channel) : base(sender)
        {
            Channel = channel;
        }
    }
}
