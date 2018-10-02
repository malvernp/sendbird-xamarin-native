// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: OutgoingUserMessage.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/09/06
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;

using sendbirdconnectmodels.Models;

namespace sendbirdxamarin.Core.ViewModels.Messages
{
    public class OutgoingUserMessage : ChatMessageBase
    {

        public OutgoingUserMessage(OutgoingUserMessageInfo message) : base(message)
        {
        }


        //protected override string GetDefaultMessage()
        //{
        //    return ((OutgoingUserMessageInfo)Data).Message;
        //}


    }
}