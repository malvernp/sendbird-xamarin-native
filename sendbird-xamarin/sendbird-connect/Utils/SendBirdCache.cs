// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: SendBirdCache.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/08/30
// Author: malvern
// Description: The idea of this class is to handle caching and potentially caching on disk as well
// (Not final as i'm not entirely convinced yet whether it should be done on this level or implementation level)
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using SendBird;
using sendbirdconnectmodels.Models;

namespace sendbirdconnect.Utils
{
    public class SendBirdCache
    {
        public List<GroupChannel> GroupChannels { get; set; }

        public Dictionary<string, List<BaseMessageInfo>> GroupChannelMessages { get; set; }

        public SendBirdCache()
        {
            
            GroupChannels = new List<GroupChannel>();
            GroupChannelMessages = new Dictionary<string, List<BaseMessageInfo>>();
        
        }

        public void RefreshOrAddEntryInList(GroupChannel newOrUpdatedChannel)
        {

            var index = GroupChannels.IndexOf(GroupChannels.Find(a => a.Url == newOrUpdatedChannel.Url));
            index = (index == -1 ? 0 : index);
            GroupChannels[index] = newOrUpdatedChannel;

        }

        public GroupChannel GetGroupChannelForUrl(string url) {
            return GroupChannels.Find(a => a.Url == url);
        }


        public List<BaseMessageInfo> GetGroupChannelMessages(string groupChannelUrl)
        {
            List<BaseMessageInfo> res = new List<BaseMessageInfo>();
            GroupChannelMessages.TryGetValue(groupChannelUrl, out res);
            return res;

        }



    }
}
