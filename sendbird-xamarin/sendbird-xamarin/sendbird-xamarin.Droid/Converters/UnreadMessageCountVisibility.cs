// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: UnreadMessageCountVisibility.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/09/12
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Globalization;
using sendbirdxamarin.Core.ViewModels;
using MvvmCross.Plugin.Visibility;
using MvvmCross.UI;
using sendbirdconnect.Models;

namespace sendbird_xamarin.Droid.Converters
{
    public class UnreadMessageCountVisibility : MvxBaseVisibilityValueConverter<ChannelInfo>
    {
        public UnreadMessageCountVisibility()
        {
        }

        protected override MvxVisibility Convert(ChannelInfo e, object parameter, CultureInfo culture)
        {

                if (!string.IsNullOrEmpty(e.MemberCount) && (e.UnreadMessageCount.Trim() != "0"))
                {

                return MvxVisibility.Visible;
                }
            else {
                return MvxVisibility.Collapsed;
            }

        }
    }
}



