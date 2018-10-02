// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: ConnectionStatusChangeNotification.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/06/27
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using MvvmCross.Plugin.Messenger;

namespace sendbirdxamarin.Core.Notifications
{
    public class ConnectionStatusChangeNotification: MvxMessage
    {
        
        public ConnectionStatus Status
        {
            get;
            private set;
        }

        public string Message
        {
            get;
            private set;
        }

        public ConnectionStatusChangeNotification(object sender, ConnectionStatus connectionStatus, string message = null) : base(sender)
        {
            Status = connectionStatus;
            Message = message;
        }
    }
}
