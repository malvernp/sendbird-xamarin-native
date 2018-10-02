// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: Context.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/08/22
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using sendbirdconnect.Utils;

namespace sendbirdxamarin.Core.Services
{

    //TODO move to config
    public class Context: IContext
    {
        public Context()
        {
        }

        public string GetApplicationId()
        {
            return "9DA1B1F4-0BE6-4DA8-82C5-2E81DAB56F23";
        }

        public bool SetInfoLogging()
        {
           return true;
        }

        public string GetAppVersion() {
            return "1.0";
        }


        public string GetAppName()
        {
            return "SendBird Sample UI (Xamarin)";
        }


    }
}
