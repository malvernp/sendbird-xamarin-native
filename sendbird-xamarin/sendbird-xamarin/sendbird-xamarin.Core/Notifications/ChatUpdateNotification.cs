// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: ChatUpdateNotification.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/09/04
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using MvvmCross.Plugin.Messenger;
using sendbirdconnectmodels.Models;

namespace sendbirdxamarin.Core.Notifications
{
    public class ChatUpdateNotification : MvxMessage
    {

        public List<BaseMessageInfo> Messages
        {
            get;
            private set;
        }

        public ChatUpdateNotification(object sender, List<BaseMessageInfo> messages) : base(sender)
        {
            Messages = messages;
        }
    }
}

