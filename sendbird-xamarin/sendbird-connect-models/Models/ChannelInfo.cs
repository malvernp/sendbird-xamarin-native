// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: ChannelInfo.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/08/21
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
namespace sendbirdconnect.Models
{
    public class ChannelInfo
    {
        public string Name { get; set; }
        public string MemberCount { get; set; }
        public string LastMessage { get; set; }
        public string UpdatedDate { get; set; }
        public string AvatarUrl { get; set; }
        public string UnreadMessageCount { get; set; }    
        public string ChannelUrl { get; set; }    //unique id for sbd channel
        public bool IsTyping  { get; set; } 

        public bool Equals(ChannelInfo info) {
            return ChannelUrl == info.ChannelUrl;
        }

    }
}
