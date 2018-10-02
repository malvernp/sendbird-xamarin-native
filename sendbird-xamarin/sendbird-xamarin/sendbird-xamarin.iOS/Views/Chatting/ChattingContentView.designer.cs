// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace sendbird_xamarin.iOS
{
    [Register ("ChattingContentView")]
    partial class ChattingContentView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView chattingTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint inputContainerViewHeight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView messageTextView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView typingIndicatorContainerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint typingIndicatorContainerViewHeight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint typingIndicatorImageHeight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView typingIndicatorImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel typingIndicatorLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (chattingTableView != null) {
                chattingTableView.Dispose ();
                chattingTableView = null;
            }

            if (inputContainerViewHeight != null) {
                inputContainerViewHeight.Dispose ();
                inputContainerViewHeight = null;
            }

            if (messageTextView != null) {
                messageTextView.Dispose ();
                messageTextView = null;
            }

            if (typingIndicatorContainerView != null) {
                typingIndicatorContainerView.Dispose ();
                typingIndicatorContainerView = null;
            }

            if (typingIndicatorContainerViewHeight != null) {
                typingIndicatorContainerViewHeight.Dispose ();
                typingIndicatorContainerViewHeight = null;
            }

            if (typingIndicatorImageHeight != null) {
                typingIndicatorImageHeight.Dispose ();
                typingIndicatorImageHeight = null;
            }

            if (typingIndicatorImageView != null) {
                typingIndicatorImageView.Dispose ();
                typingIndicatorImageView = null;
            }

            if (typingIndicatorLabel != null) {
                typingIndicatorLabel.Dispose ();
                typingIndicatorLabel = null;
            }
        }
    }
}