// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: ChatListEntry.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/06/25
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using sendbirdconnect.Models;

namespace sendbirdxamarin.Core.ViewModels
{
    public class ChatListEntry
    {
        private ChannelInfo _data;

        public ChannelInfo Data
        {
            get { return _data; }
            set
            {
                _data = value;
            }
        }


        public ChatListEntry(ChannelInfo channelInfo)
        {
            _data = channelInfo;
        }

    }
}
