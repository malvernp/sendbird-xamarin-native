// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: BaseMessageInfoFormat.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/08/31
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using SendBird;
using sendbirdconnectmodels.Models;

namespace sendbirdconnect.Utils.PojoFormatters
{
    public class BaseMessageInfoFormat
    {

        private BaseMessage _baseMessage;

        public BaseMessageInfoFormat(BaseMessage msg)
        {
            _baseMessage = msg;
        }

        public static BaseMessageInfoFormat getFormatter(BaseMessage channel)
        {
            return new BaseMessageInfoFormat(channel);
        }


        //TODO flesh out all the messages 
        public BaseMessageInfo Format()
        {
            BaseMessageInfo result = null;

            if (_baseMessage is UserMessage) {
                var inUserMsg = (UserMessage)_baseMessage;

                if (SendBirdClient.CurrentUser.UserId != inUserMsg.Sender.UserId) {
                    IncomingUserMessageInfo outUserMsg  = new IncomingUserMessageInfo();
                    outUserMsg.Message = inUserMsg.Message;
                    outUserMsg.CreatedAt = inUserMsg.CreatedAt;
                    result = outUserMsg;
                }
                //just for now
                else
                {
                    OutgoingUserMessageInfo outUserMsg = new OutgoingUserMessageInfo();
                    outUserMsg.Message = inUserMsg.Message;
                    outUserMsg.CreatedAt = inUserMsg.CreatedAt;
                    result = outUserMsg;

                }

            }
            else {
                IncomingUserMessageInfo outUserMsg = new IncomingUserMessageInfo();
                outUserMsg.Message = "Other message type ** to impl **";
                result = outUserMsg;

            }

            return result;

            //Message
           // if ( _baseMessage is  )
            //for now we treat everything as 
           // BaseMessageInfo r = new IncomingUserMessageInfo();
         //   return r;
        }

 
    
    }
}


