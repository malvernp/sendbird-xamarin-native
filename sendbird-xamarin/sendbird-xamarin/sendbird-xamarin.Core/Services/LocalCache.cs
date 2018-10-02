// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: LocalCache.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/09/18
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
namespace sendbirdxamarin.Core.Services
{

    //TODO implement cache
    public class LocalCache
    {
        
        public LocalCache()
        {
        }


        private static string _currentNickName = "";
        public static string CurrentNickName
        {
            get { return _currentNickName; }
            set { 
                _currentNickName = value; 
            }
        }

    }
}
