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

namespace sendbird_xamarin.iOS.Views.Chatting
{
    [Register ("ChattingView")]
    partial class ChattingView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint bottomMargin { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView chattingView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView imageViewerLoadingIndicator { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView imageViewerLoadingView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationItem imageViewerLoadingViewNavItem { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint navigationBarHeight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationItem navItem { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (bottomMargin != null) {
                bottomMargin.Dispose ();
                bottomMargin = null;
            }

            if (chattingView != null) {
                chattingView.Dispose ();
                chattingView = null;
            }

            if (imageViewerLoadingIndicator != null) {
                imageViewerLoadingIndicator.Dispose ();
                imageViewerLoadingIndicator = null;
            }

            if (imageViewerLoadingView != null) {
                imageViewerLoadingView.Dispose ();
                imageViewerLoadingView = null;
            }

            if (imageViewerLoadingViewNavItem != null) {
                imageViewerLoadingViewNavItem.Dispose ();
                imageViewerLoadingViewNavItem = null;
            }

            if (navigationBarHeight != null) {
                navigationBarHeight.Dispose ();
                navigationBarHeight = null;
            }

            if (navItem != null) {
                navItem.Dispose ();
                navItem = null;
            }
        }
    }
}