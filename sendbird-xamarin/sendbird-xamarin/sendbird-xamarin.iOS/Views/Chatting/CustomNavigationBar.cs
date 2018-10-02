using CoreGraphics;
using Foundation;
using System;
using UIKit;

namespace sendbird_xamarin.iOS
{
    public partial class CustomNavigationBar : UINavigationBar
    {
        public CustomNavigationBar(IntPtr handle) : base(handle)
        {
        }


        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
            {
                foreach (var subview in this.Subviews)
                {
                    var stringFromClass = subview.Class.Name;// GetClasubview().FullName;

                //    BarBackground b = null;


                    if (stringFromClass.Contains("BarBackground"))
                    {
                        subview.Frame = this.Bounds;
                    }

                    else if (stringFromClass.Contains("BarContentView"))
                    {
                        subview.Frame = new CGRect(
                            x: subview.Frame.X, y: 24, width: subview.Frame.Size.Width, height: this.Bounds.Size.Height - 24);
                    }

                }

            }


        }

    }
}