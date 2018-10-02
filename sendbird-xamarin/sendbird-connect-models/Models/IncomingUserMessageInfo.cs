// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: IncomingUserMessage.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/08/31
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
namespace sendbirdconnectmodels.Models
{
    public class IncomingUserMessageInfo: BaseMessageInfo
    {
        public UserInfo Sender { get; set; }
        public string Message { get; set; }



        public override MessageType GetMessageType()
        {
            return MessageType.INCOMING_USER_MESSAGE;
        }
    }
}
