// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: SendBirdChannelHandler.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/08/23
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using SendBird;
using sendbirdconnect.Utils;

namespace sendbirdconnect.Services
{
    public class SendBirdAPIChannelHandler : SendBirdAPIBase
    {
        private SendBirdCache _cache;

        public SendBirdAPIChannelHandler(IContext context, ISendBirdResultsHandler completionHandler, SendBirdCache cache) : base(context, completionHandler)
        {
            _cache = cache;
        }



        public void AddChannelHandler() {

            SendBirdClient.ChannelHandler ch = new SendBirdClient.ChannelHandler();  
                                                            
            ch.OnMessageReceived = (BaseChannel baseChannel, BaseMessage baseMessage) => {
                
                // Received a chat message.
                LogMessage("OnMessageReceived");

                if (baseChannel.IsGroupChannel()) //we only deal with group channel (1 on 1 conversations)
                {
                    
                    _cache.RefreshOrAddEntryInList((GroupChannel)baseChannel);
                          
                    _completionHandler.OnMessageReceived(
                        PojoConverter.Transform((GroupChannel)baseChannel)
                    );
                    
                }
            };


            ch.OnTypingStatusUpdated = (GroupChannel baseChannel) => {

                // Received a chat message.
                LogMessage("OnTypingStatusUpdated");
                                    
                _cache.RefreshOrAddEntryInList(baseChannel);

                _completionHandler.OnTypingStatusUpdated(
                    PojoConverter.Transform(baseChannel)

                );
            };


            SendBirdClient.AddChannelHandler("UNIQUE_HANDLER_ID1", ch);
        }

    }
}
