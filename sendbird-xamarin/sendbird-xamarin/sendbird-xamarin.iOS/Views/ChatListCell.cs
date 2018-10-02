// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: ChatListCell.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/06/26
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Text.RegularExpressions;
using CoreFoundation;
using Foundation;
using sendbirdxamarin.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace sendbird_xamarin.iOS.Views
{
    public partial class ChatListCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("ChatListCell");
        public static readonly UINib Nib;

        //static ChatListCell()
        //{
        //    Nib = UINib.FromName("ChatListCell", NSBundle.MainBundle);
        //}


        private string _unreadMessageCountChange;
        public string UnreadMessageCountChange
        {
            get { return _unreadMessageCountChange; }
            set
            {
                UpdateMessageCount();
            }
        }

        private string _typingStatusChange;
        public string TypingStatusChange
        {
            get { return _typingStatusChange; }
            set
            {
                UpdateTypingAnimation();
            }
        }


        private void UpdateTypingAnimation()
        {

            ChatListEntry e = (ChatListEntry)DataContext;
            if (e.Data.IsTyping) {
                this.typingLabel.Text = e.Data.Name +" is typing...";

                if (!typingImageView.IsAnimating)
                {

                    var typingImages = new UIImage[50];

                    for (int i = 0; i < typingImages.Length; i++)
                    {
                        var imageUrl = (i + 1).ToString("00");
                        typingImages[i] = UIImage.FromBundle(imageUrl);
                    }

                    this.typingImageView.AnimationImages = typingImages;
                    this.typingImageView.AnimationDuration = 1.5;

                    DispatchQueue.MainQueue.DispatchAsync(() =>
                    {
                        this.typingImageView.StartAnimating();
                    });

                }
                this.lastMessageLabel.Hidden = true;
                this.typingImageView.Hidden = false;
                this.typingLabel.Hidden = false;

            }

            else {
                
                this.lastMessageLabel.Hidden = false;
                this.typingImageView.Hidden = true;
                this.typingLabel.Hidden = true;

            }

        }

        private void UpdateMessageCount() {
            ChatListEntry e  = (ChatListEntry)DataContext;

            if ( !string.IsNullOrEmpty(e.Data.MemberCount) && (e.Data.UnreadMessageCount.Trim() != "0") ) {
                
                this.unreadMessageCountContainerView.Hidden = false;
                unreadMessageCountLabel.Text = e.Data.UnreadMessageCount.Trim();
            }

            else {
                
                this.unreadMessageCountContainerView.Hidden = true;
                unreadMessageCountLabel.Text = "";

            }
        }

        protected ChatListCell(IntPtr handle) : base(handle)
        {


            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<ChatListCell, ChatListEntry>();

                set.Bind(channelNameLabel).To(item => item.Data.Name);
                set.Bind(dateLabel).To(item => item.Data.UpdatedDate);
                set.Bind(lastMessageLabel).To(item => item.Data.LastMessage);
                set.Bind(this).For(v => v.UnreadMessageCountChange).To(item => item.Data.UnreadMessageCount);
                set.Bind(this).For(v => v.TypingStatusChange).To(item => item.Data.IsTyping);

                set.Apply();


                typingImageView.Hidden = true;
                typingLabel.Hidden = true;

                foreach (var sub in this.unreadMessageCountContainerView.Subviews)
                {
                    if (sub is UIImageView) {
                        sub.BackgroundColor = Constants.connectButtonColor();
                        break;
                    }

                }

                SetNeedsUpdateConstraints();

            });
        }
    }
}
