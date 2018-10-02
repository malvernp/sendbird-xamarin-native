// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: IncomingUserMessage.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/09/04
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using sendbirdconnectmodels.Models;

namespace sendbirdxamarin.Core.ViewModels.Messages
{
    public class IncomingUserMessage : ChatMessageBase
    {

        public IncomingUserMessage(IncomingUserMessageInfo message) : base(message)
        {
        }

        //protected override string GetDefaultMessage()
        //{
        //    return ((IncomingUserMessageInfo)Data).Message;
        //}
    }
}
