// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: IncomingUserMessageTableViewCell.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/09/04
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
    public partial class IncomingUserMessageTableViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("IncomingUserMessageTableViewCell");
        public static readonly UINib Nib;

        static IncomingUserMessageTableViewCell()
        {
            Nib = UINib.FromName("IncomingUserMessageTableViewCell", NSBundle.MainBundle);
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

        }

        private string _dateSeperatorLabelVisibility;
        public string DateSeperatorLabelVisibility
        {
            get { return _dateSeperatorLabelVisibility; }
            set
            {
                ChatMessageBase e = (ChatMessageBase)DataContext;

                dateSeperatorView.Hidden = !e.Data.IsFirstMessageForDay;
            }
        }


        protected IncomingUserMessageTableViewCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<IncomingUserMessageTableViewCell, IncomingUserMessage>();

                set.Bind(dateSeperatorLabel).To(item => item.CreatedDateHeadingFormatted);
                set.Bind(this).For(v => v.DateSeperatorLabelVisibility).To(item => item.Data.IsFirstMessageForDay);
                set.Bind(messageDateLabel).To(item => item.CreatedDateFormatted);

                set.Bind(messageLabel).To(item =>
                                              ((IncomingUserMessageInfo)item.Data).Message);


                set.Apply();
                SetNeedsUpdateConstraints();
            });

        }

    }
}
