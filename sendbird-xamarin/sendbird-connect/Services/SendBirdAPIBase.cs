// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: SendBirdAPIBase.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/08/23
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using sendbirdconnect.Utils;

namespace sendbirdconnect.Services
{
    public class SendBirdAPIBase
    {

        protected ISendBirdResultsHandler _completionHandler;

        protected IContext _context;


        public SendBirdAPIBase(IContext context, ISendBirdResultsHandler completionHandler)
        {
            _context = context;
            _completionHandler = completionHandler;

        }


        protected void LogMessage(String message)
        {

            _completionHandler.LogMessage("SendbirdAPI: " + message);

        }

        protected void HandleException(Exception e)
        {

            _completionHandler.HandleException(e);

        }

    }
}
