// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: ChatMessageBase.cs
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
    public abstract class ChatMessageBase
    {
        
        private BaseMessageInfo _data;

        public BaseMessageInfo Data
        {
            get { return _data; }
            set
            {
                _data = value;
            }
        }

        public string CreatedDateFormatted
        {
            get {
                if (_data != null) {
                    Int64 timestamp = _data.CreatedAt;
                    DateTime? dt = null;
                    DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    dt = Epoch.AddMilliseconds(timestamp).ToLocalTime();

                    return dt.Value.ToShortTimeString(); 
                }
                else {
                    return "";
                }

            }
        }

        public string CreatedDateHeadingFormatted
        {
            get
            {
                if (_data != null)
                {
                    return 
                        (new DateTime(1970, 1, 1, 0, 0, 0, 0)).
                                                              AddMilliseconds(_data.CreatedAt).ToLocalTime()
                                                              .ToString("MMM d, yyyy");
                }
                else
                {
                    return "";
                }

            }
        }



        //public string DefaultMessage
        //{
        //    get
        //    {
        //        if (_data != null)
        //        {
        //            return GetDefaultMessage();
        //        }
        //        else
        //        {
        //            return "";
        //        }

        //    }
        //}


     //   protected abstract string GetDefaultMessage();


        public ChatMessageBase(BaseMessageInfo message)
        {
            _data = message;

        }


        public static ChatMessageBase Create(BaseMessageInfo message)
        {
            
            var messageType = message.GetMessageType();

            switch(messageType) 
            {

                case MessageType.INCOMING_USER_MESSAGE: 
                    return new IncomingUserMessage((IncomingUserMessageInfo)message);


                case MessageType.OUTGOING_USER_MESSAGE:
                    return new OutgoingUserMessage((OutgoingUserMessageInfo)message);

                default: 
                    return new IncomingUserMessage((IncomingUserMessageInfo)message);

            }

        }



        //Int64 timestamp = ((UserMessage)lMessage).CreatedAt;

        //DateTime? dt = null;
        //DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        //dt = Epoch.AddMilliseconds(timestamp).ToLocalTime();

            //if (dt.Value.Year == DateTime.Now.Year &&
            //    dt.Value.Month == DateTime.Now.Month &&
            //    dt.Value.Day == DateTime.Now.Day)
            //{

            //    info.UpdatedDate = dt.Value.ToShortTimeString();

            //}
            //else
            //{

            //    info.UpdatedDate = dt.Value.ToShortDateString();

            //}


    }
}