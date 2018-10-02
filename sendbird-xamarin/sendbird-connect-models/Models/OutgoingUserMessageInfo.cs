// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: OutgoingUserMessageInfo.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/09/05
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
namespace sendbirdconnectmodels.Models
{
    public class OutgoingUserMessageInfo : BaseMessageInfo
    {
        public UserInfo Sender { get; set; }
        public string Message { get; set; }



        public override MessageType GetMessageType()
        {
            return MessageType.OUTGOING_USER_MESSAGE;
        }
    }
}
