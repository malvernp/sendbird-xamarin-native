// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: UserInfo.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/08/31
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
namespace sendbirdconnectmodels.Models
{
    public class UserInfo
    {
        public string Name { get; set; }
        public string UserId { get; set; }

        public bool Equals(UserInfo info)
        {
            return UserId == info.UserId;
        }


        public UserInfo()
        {
        }
    }
}
