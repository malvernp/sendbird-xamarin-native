// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: ChannelInfoFormat.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/08/31
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Linq;
using SendBird;
using sendbirdconnect.Models;

namespace sendbirdconnect.Utils.PojoFormatters
{

    public class ChannelInfoFormat : PojoFormat<GroupChannel, ChannelInfo>
    {
        
        public ChannelInfoFormat(GroupChannel input) : base(input)
        {
        }


        public override ChannelInfo Apply()
        {
            ChannelInfo r = new ChannelInfo();
            SetName(r);
            SetMessageSummary(r);
            r.MemberCount = Convert.ToString(_input.MemberCount);
            r.AvatarUrl = _input.CoverUrl;
            r.UnreadMessageCount = _input.UnreadMessageCount < 9 ? Convert.ToString(_input.UnreadMessageCount) : "9+";
            r.ChannelUrl = _input.Url;
            r.IsTyping = _input.IsTyping();
            return r;
        
        }

        private void SetName(ChannelInfo info)
        {
            if (_input.Members.Count == 1)
            {
                info.Name = _input.Members[0].Nickname;
            }
            else
            {
                info.Name = String.Join(",",
                                        _input.Members.Where(a => a.UserId != SendBirdClient.CurrentUser.UserId).Select(b => b.Nickname)
                                  );
            }
        }


        private void SetMessageSummary(ChannelInfo info)
        {
            var lMessage = _input.LastMessage;

            if (lMessage != null) {
                
                if (lMessage is UserMessage)
                {
                    info.LastMessage = ((UserMessage)lMessage).Message;
                }
                else
                {
                    info.LastMessage = "Non text Message";
                }

                Int64 timestamp = ((UserMessage)lMessage).CreatedAt;

                DateTime? dt = null;
                DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                dt = Epoch.AddMilliseconds(timestamp).ToLocalTime();

                if (dt.Value.Year == DateTime.Now.Year &&
                    dt.Value.Month == DateTime.Now.Month &&
                    dt.Value.Day == DateTime.Now.Day)
                {

                    info.UpdatedDate = dt.Value.ToShortTimeString();

                }
                else
                {

                    info.UpdatedDate = dt.Value.ToShortDateString();

                }

            }

        }


    }

}
