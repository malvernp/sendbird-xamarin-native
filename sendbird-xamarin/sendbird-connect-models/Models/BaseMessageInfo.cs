// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: BaseMessage.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/08/30
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
namespace sendbirdconnectmodels.Models
{
    public abstract class BaseMessageInfo
    {

        public abstract MessageType GetMessageType();

        public long MessageId { get; set; }

        public Int64 CreatedAt { get; set; }

        public bool IsFirstMessageForDay { get; set; }

        public bool Equals(BaseMessageInfo info)
        {
            return MessageId == info.MessageId;
        }



        public void SetIsFirstMessageForDay(BaseMessageInfo previous){
            
            if (previous != null) {
                
                DateTime dtCurrent = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddMilliseconds(CreatedAt).ToLocalTime();
                DateTime dtPrevious = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddMilliseconds(previous.CreatedAt).ToLocalTime();

                if (dtCurrent.Year == dtPrevious.Year && 
                    dtCurrent.Month == dtPrevious.Month &&
                    dtCurrent.Day == dtPrevious.Day) {

                    IsFirstMessageForDay = false;
                }
                else {
                    IsFirstMessageForDay = true;
                }

            }
            else {
                IsFirstMessageForDay = true;
            }


        }


    }


    public enum MessageType {
        INCOMING_USER_MESSAGE,
        OUTGOING_USER_MESSAGE
    }
}
