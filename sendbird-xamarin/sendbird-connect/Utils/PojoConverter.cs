// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: PojoCreator.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/08/21
// Author: malvern
// Description: used to convert Sendbird classes to our own 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using SendBird;
using sendbirdconnect.Models;
using sendbirdconnect.Utils.PojoFormatters;
using sendbirdconnectmodels.Models;

namespace sendbirdconnect.Utils
{
    public class PojoConverter
    {

        public static ChannelInfo Transform(GroupChannel c) {
            return new ChannelInfoFormat(c).Apply();
        }

        public static BaseMessageInfo Transform(BaseMessage  c)
        {
            return BaseMessageInfoFormat.getFormatter(c).Format();
        }


        public static List<ChannelInfo> Transform(List<GroupChannel> list) {
            List<ChannelInfo> channels = new List<ChannelInfo>();

            if (list != null && list.Count > 0)
            {
                channels.AddRange(
                    list.Select(k => Transform(k))
                );

            }

            return channels; 
            
        }


        public static List<BaseMessageInfo> Transform(List<BaseMessage> list)
        {
            List<BaseMessageInfo> messages = new List<BaseMessageInfo>();

            if (list != null && list.Count > 0)
            {
                messages.AddRange(
                    list.Select(k => Transform(k))
                );

            }

            //flag which is first message of day

            for (int i = 0; i < messages.Count; i++)
            {
                var previous = (i == 0 ? null : messages[i - 1]);
                messages[i].SetIsFirstMessageForDay(previous); 
            }

            return messages;
        }
    }

}
