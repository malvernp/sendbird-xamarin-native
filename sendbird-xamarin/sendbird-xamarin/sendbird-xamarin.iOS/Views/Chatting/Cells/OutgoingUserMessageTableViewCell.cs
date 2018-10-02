// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: OutgoingUserMessageTableViewCell.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/09/06
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;

using Foundation;
using sendbirdxamarin.Core.ViewModels.Messages;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using sendbirdconnectmodels.Models;
using UIKit;

namespace sendbird_xamarin.iOS.Views.Chatting.Cells
{
    public partial class OutgoingUserMessageTableViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("OutgoingUserMessageTableViewCell");
        public static readonly UINib Nib;

        static OutgoingUserMessageTableViewCell()
        {
            Nib = UINib.FromName("OutgoingUserMessageTableViewCell", NSBundle.MainBundle);
        }

        private string _dateSeperatorLabelVisibility;
        public string DateSeperatorLabelVisibility
        {
            get { return _dateSeperatorLabelVisibility; }
            set
            {
                ChatMessageBase e = (ChatMessageBase)DataContext;

                dateSeperatorContainerView.Hidden = !e.Data.IsFirstMessageForDay;

                //TODO fix when implementing sending status 
                messageDateLabel.Hidden = false;
            }
        }



        protected OutgoingUserMessageTableViewCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<OutgoingUserMessageTableViewCell, OutgoingUserMessage>();

                set.Bind(dateSeperatorLabel).To(item => item.CreatedDateHeadingFormatted);
                set.Bind(this).For(v => v.DateSeperatorLabelVisibility).To(item => item.Data.IsFirstMessageForDay);
                set.Bind(messageDateLabel).To(item => item.CreatedDateFormatted);

                set.Bind(messageLabel).To(item =>
                                              ((OutgoingUserMessageInfo)item.Data).Message);


                set.Apply();
                SetNeedsUpdateConstraints();
            });

        }



    }
}
