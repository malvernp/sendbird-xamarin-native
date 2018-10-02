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

namespace sendbird_xamarin.iOS.Views
{
    [Register ("LoginView")]
    partial class LoginView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton connectButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView indicatorView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel nicknameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint nicknameLabelBottomMargin { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView nicknameLineView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField nicknameTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel userIdLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint userIdLabelBottomMargin { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView userIdLineView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField userIdTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel versionLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (connectButton != null) {
                connectButton.Dispose ();
                connectButton = null;
            }

            if (indicatorView != null) {
                indicatorView.Dispose ();
                indicatorView = null;
            }

            if (nicknameLabel != null) {
                nicknameLabel.Dispose ();
                nicknameLabel = null;
            }

            if (nicknameLabelBottomMargin != null) {
                nicknameLabelBottomMargin.Dispose ();
                nicknameLabelBottomMargin = null;
            }

            if (nicknameLineView != null) {
                nicknameLineView.Dispose ();
                nicknameLineView = null;
            }

            if (nicknameTextField != null) {
                nicknameTextField.Dispose ();
                nicknameTextField = null;
            }

            if (userIdLabel != null) {
                userIdLabel.Dispose ();
                userIdLabel = null;
            }

            if (userIdLabelBottomMargin != null) {
                userIdLabelBottomMargin.Dispose ();
                userIdLabelBottomMargin = null;
            }

            if (userIdLineView != null) {
                userIdLineView.Dispose ();
                userIdLineView = null;
            }

            if (userIdTextField != null) {
                userIdTextField.Dispose ();
                userIdTextField = null;
            }

            if (versionLabel != null) {
                versionLabel.Dispose ();
                versionLabel = null;
            }
        }
    }
}