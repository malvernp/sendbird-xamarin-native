// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace sendbird_xamarin.iOS.Views
{
    [Register ("ChatListCell")]
    partial class ChatListCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView avatarViewContainer { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel channelNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel dateLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lastMessageLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView typingImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel typingLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView unreadMessageCountContainerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel unreadMessageCountLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (avatarViewContainer != null) {
                avatarViewContainer.Dispose ();
                avatarViewContainer = null;
            }

            if (channelNameLabel != null) {
                channelNameLabel.Dispose ();
                channelNameLabel = null;
            }

            if (dateLabel != null) {
                dateLabel.Dispose ();
                dateLabel = null;
            }

            if (lastMessageLabel != null) {
                lastMessageLabel.Dispose ();
                lastMessageLabel = null;
            }

            if (typingImageView != null) {
                typingImageView.Dispose ();
                typingImageView = null;
            }

            if (typingLabel != null) {
                typingLabel.Dispose ();
                typingLabel = null;
            }

            if (unreadMessageCountContainerView != null) {
                unreadMessageCountContainerView.Dispose ();
                unreadMessageCountContainerView = null;
            }

            if (unreadMessageCountLabel != null) {
                unreadMessageCountLabel.Dispose ();
                unreadMessageCountLabel = null;
            }
        }
    }
}