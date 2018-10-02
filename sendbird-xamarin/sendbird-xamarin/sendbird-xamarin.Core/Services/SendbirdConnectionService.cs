// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: SendbirdConnectionManager.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/06/22
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using sendbirdxamarin.Core.ViewModels;
using sendbirdxamarin.Core.Notifications;
using sendbirdconnect.Services;
using sendbirdconnect.Utils;

namespace sendbirdxamarin.Core.Services
{
    public class SendbirdConnectionService : ISendbirdConnectionService
    {


        private static SendBirdAPI _sendBirdAPI;


        private readonly ISendBirdResultsHandler _resultsHandler;

        private readonly IContext _context;

        public SendbirdConnectionService(ISendBirdResultsHandler resultsHandler, IContext context)
        {
            _resultsHandler = resultsHandler;
            _context = context;
            _sendBirdAPI = new SendBirdAPI(context, _resultsHandler);

        }

        public SendBirdAPI GetAPI() {
            return _sendBirdAPI;
        }

    }



}


