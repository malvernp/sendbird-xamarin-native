// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: Utils.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/09/18
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using CoreGraphics;
using UIKit;

namespace sendbird_xamarin.iOS
{
    public class Utils
    {
    
    
    
        public static UIImage imageFromColor(UIColor color)  {
            var rect = new CGRect(x: 0, y: 0, width: 1, height: 1);
            UIGraphics.BeginImageContextWithOptions(rect.Size, false, 0.0f);
            color.SetFill();
            UIGraphics.RectFill(rect);
            var image = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            return image;
    }


    }
}
