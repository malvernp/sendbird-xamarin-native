// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: SendbirdAPI.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/08/21
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using SendBird;
using sendbirdconnect.Models;
using sendbirdconnect.Utils;
using sendbirdconnectmodels.Models;

namespace sendbirdconnect.Services
{
    public class SendBirdAPI : SendBirdAPIBase
    {
        private SendBirdCache _cache;

        public SendBirdAPI(IContext context, ISendBirdResultsHandler completionHandler): base(context, completionHandler)
        {
            _cache = new SendBirdCache();
        }

        public void InitWithApplicationId()
        {
            SendBirdClient.Init(_context.GetApplicationId());

            if (_context.SetInfoLogging()) {
                SendBirdClient.LoggerLevel = SendBirdClient.LOGGER_INFO;
            }


            SendBirdClient.ConnectionHandler ch = new SendBirdClient.ConnectionHandler();

            ch.OnReconnectFailed = () => {
                // Auto reconnecting failed. Call `connect` to reconnect to SendBird.

                LogMessage("OnReconnectFailed");
                _completionHandler.OnReconnectFailed();

            };

            ch.OnReconnectStarted = () => {
                // Network has been disconnected. Auto reconnecting starts.

                LogMessage("OnReconnectStarted");
                _completionHandler.OnReconnectStarted();

            };

            ch.OnReconnectSucceeded = () => {
                
                LogMessage("OnReconnectSucceeded");
                _completionHandler.OnReconnectSucceeded();

            };

            SendBirdClient.AddConnectionHandler("UNIQUE_HANDLER_ID", ch);

            (new SendBirdAPIChannelHandler(_context, _completionHandler, _cache)).AddChannelHandler();


            //SBD
        }


        public string GetSDKVersion() {
            return SendBirdClient.SDKVersion;
        }

        public void Connect(string userId, string nickName= "", string profileUrl = "")
        {
            SendBirdClient.Connect(userId, (User user, SendBirdException e) =>
            {
                if (e != null)
                {

                    LogMessage("OnConnectionFailed - " + e.Message);
                    HandleException(e);
                    _completionHandler.OnConnectionFailed(e.Message);

                    return;
                }
                else
                {
                    //update cache entries

                    LogMessage("OnConnectionSuccess");
                    _completionHandler.OnConnectionSuccess();



                    if ( !string.IsNullOrEmpty(nickName) || !string.IsNullOrEmpty(profileUrl) ) {
                        UpdateCurrentUserInfo(nickName, profileUrl);
                    }

                }
            });

        }

        private void UpdateCurrentUserInfo(string nickName, string profileUrl)
        {
            SendBirdClient.UpdateCurrentUserInfo(nickName, profileUrl, (SendBirdException e) =>
            {
                if (e != null)
                {

                    LogMessage("UpdateCurrentUserInfo failed - " + e.Message);
                    return;
                }
                else
                {
                    LogMessage("UpdateCurrentUserInfo success");

                }
            });

        }



        public void Disconnect()
        {

            LogMessage("Disconnecting - current status " + SendBirdClient.GetConnectionState().ToString());

            SendBirdClient.Disconnect(() => {
                LogMessage("OnDisconnect");
                _completionHandler.OnDisconnect(
                    SendBirdClient.GetConnectionState() == SendBirdClient.ConnectionState.CLOSING ||
                    SendBirdClient.GetConnectionState() == SendBirdClient.ConnectionState.CLOSED 
                );

            });
        }




        public void ListGroupChannels()
        {

            _cache.GroupChannels.Clear(); //TODO - build reuse functionality for refreshing - when required


            //TODO check connection state and try to login again if connection closed

            List<ChannelInfo> _channels = new List<ChannelInfo>();
            GroupChannelListQuery mQuery = GroupChannel.CreateMyGroupChannelListQuery();
            mQuery.IncludeEmpty = true;
            mQuery.Next((List<GroupChannel> list, SendBirdException e1) =>
            {

                if (e1 != null)
                {
                    HandleException(e1);
                    return; //TODO check if we need to flag an error event here - incase any waiting services
                }


                _channels.AddRange(PojoConverter.Transform(list));

                _cache.GroupChannels.AddRange(list);

                LogMessage("OnListGroupChannels");
                _completionHandler.OnListGroupChannels(_channels);

            });

        }



        //TODO for now just doing initial 30 - must still do paging and caching of query
        public void ListGroupChannelMessages(ChannelInfo channelInfo)
        {
            //TODO check connection state and try to login again if connection closed

            GroupChannel ch = _cache.GetGroupChannelForUrl(channelInfo.ChannelUrl);

            List<BaseMessageInfo> _messages = new List<BaseMessageInfo>();

            PreviousMessageListQuery mPrevMessageListQuery = ch.CreatePreviousMessageListQuery();
            //100
            mPrevMessageListQuery.Load(30, false, (List<BaseMessage> messages, SendBirdException e) =>
            {
                if (e != null)
                {
                    HandleException(e);
                    return;
                }

                //_cache.GroupChannels.AddRange(list);
                //_cache.RefreshOrAddEntryInList


                _messages.AddRange(PojoConverter.Transform(messages));
                LogMessage("OnListGroupChannelMessages");
                _completionHandler.OnListGroupChannelMessages(_messages);


            });


            //self.groupChannel.getPreviousMessages(byTimestamp: timestamp, limit: 30, reverse: !initial, messageType: SBDMessageTypeFilter.all, customType: "")

            //ch.CreatePreviousMessageListQuery()
            // timestamp = Int64.max
            //ch.Create
           // MessageListQuery query = ch.CreateMessageListQuery();

          //  query.Load()


            //List<ChannelInfo> _channels = new List<ChannelInfo>();
            //GroupChannelListQuery mQuery = GroupChannel.CreateMyGroupChannelListQuery();
            //mQuery.IncludeEmpty = true;
            //mQuery.Next((List<GroupChannel> list, SendBirdException e1) =>
            //{

            //    if (e1 != null)
            //    {
            //        HandleException(e1);
            //        return; //TODO check if we need to flag an error event here - incase any waiting services
            //    }


            //    _channels.AddRange(PojoConverter.Transform(list));

            //    LogMessage("OnConnectionSuccess");
            //    _completionHandler.OnListGroupChannels(_channels);

            //});

        }




    }
}
