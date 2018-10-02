// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: Constants.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/09/18
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using UIKit;

namespace sendbird_xamarin.iOS
{

    //TODO - all these can be pulled into commons to share cross platform 
    public class Constants
    {
        public Constants()
        {
        }


//        static func navigationBarTitleColor() -> UIColor {
//        return UIColor(red: 128.0/255.0, green: 90.0/255.0, blue: 255.0/255.0, alpha: 1)
//    }

//    static func navigationBarSubTitleColor() -> UIColor {
//        return UIColor(red: 142.0/255.0, green: 142.0/255.0, blue: 142.0/255.0, alpha: 1)
//    }

//static func navigationBarTitleFont() -> UIFont {
    //    return UIFont(name: "HelveticaNeue", size: 16.0)!
    //}
    
    //static func navigationBarSubTitleFont() -> UIFont {
    //    return UIFont(name: "HelveticaNeue-LightItalic", size: 10.0)!
    //}
    
        public static UIColor textFieldLineColorNormal() {
            return new UIColor(red: (float)(217.0 / 255.0), green: (float)(217.0 / 255.0), blue: (float)(217.0 / 255.0), alpha: 1f);
    }

        //static func textFieldLineColorSelected() -> UIColor {
        //    return UIColor(red: 140.0/255.0, green: 109.0/255.0, blue: 238.0/255.0, alpha: 1)
        //}

        //static func nicknameFontInMessage() -> UIFont {
        //    return UIFont(name: "HelveticaNeue", size: 12.0)!
        //}

        //static func nicknameColorInMessageNo0() -> UIColor {
        //    return UIColor(red: 45.0/255.0, green: 27.0/255.0, blue: 225.0/255.0, alpha: 1)
        //}

        //static func nicknameColorInMessageNo1() -> UIColor {
        //    return UIColor(red: 53.0/255.0, green: 163.0/255.0, blue: 251.0/255.0, alpha: 1)
        //}

        //static func nicknameColorInMessageNo2() -> UIColor {
        //    return UIColor(red: 128.0/255.0, green: 90.0/255.0, blue: 255.0/255.0, alpha: 1)
        //}

        //static func nicknameColorInMessageNo3() -> UIColor {
        //    return UIColor(red: 207.0/255.0, green: 72.0/255.0, blue: 251.0/255.0, alpha: 1)
        //}

        //static func nicknameColorInMessageNo4() -> UIColor {
        //    return UIColor(red: 226.0/255.0, green: 27.0/255.0, blue: 225.0/255.0, alpha: 1)
        //}

        //static func messageDateFont() -> UIFont {
        //    return UIFont(name: "HelveticaNeue", size: 10.0)!
        //}

        //static func messageDateColor() -> UIColor {
        //    return UIColor(red: 191.0/255.0, green: 191.0/255.0, blue: 191.0/255.0, alpha: 1)
        //}

        //static func incomingFileImagePlaceholderColor() -> UIColor {
        //    return UIColor(red: 238.0/255.0, green: 241.0/255.0, blue: 246.0/255.0, alpha: 1)
        //}

        //static func messageFont() -> UIFont {
        //    return UIFont(name: "HelveticaNeue", size: 16.0)!
        //}

        //static func outgoingMessageColor() -> UIColor {
        //    return UIColor(red: 255.0/255.0, green: 255.0/255.0, blue: 255.0/255.0, alpha: 1)
        //}

        //static func incomingMessageColor() -> UIColor {
        //    return UIColor(red: 0.0/255.0, green: 0.0/255.0, blue: 0.0/255.0, alpha: 1)
        //}

        //static func outgoingFileImagePlaceholderColor() -> UIColor {
        //    return UIColor(red: 128.0/255.0, green: 90.0/255.0, blue: 255.0/255.0, alpha: 1)
        //}

        //static func openChannelLineColorNo0() -> UIColor {
        //    return UIColor(red: 45.0/255.0, green: 227.0/255.0, blue: 255.0/255.0, alpha: 1)
        //}

        //static func openChannelLineColorNo1() -> UIColor {
        //    return UIColor(red: 53.0/255.0, green: 163.0/255.0, blue: 251.0/255.0, alpha: 1)
        //}

        //static func openChannelLineColorNo2() -> UIColor {
        //    return UIColor(red: 128.0/255.0, green: 90.0/255.0, blue: 255.0/255.0, alpha: 1)
        //}

        //static func openChannelLineColorNo3() -> UIColor {
        //    return UIColor(red: 207.0/255.0, green: 72.0/255.0, blue: 251.0/255.0, alpha: 1)
        //}

        //static func openChannelLineColorNo4() -> UIColor {
        //    return UIColor(red: 226.0/255.0, green: 72.0/255.0, blue: 195.0/255.0, alpha: 1)
        //}

        //static func leaveButtonColor() -> UIColor {
        //    return UIColor.red
        //}

        //static func hideButtonColor() -> UIColor {
        //    return UIColor(red: 116.0/255.0, green: 127.0/255.0, blue: 145.0/255.0, alpha: 1)
        //}

        //static func leaveButtonFont() -> UIFont {
        //        return new UIFont("HelveticaNeue", 16.0);
        //}

        //static func hideButtonFont() -> UIFont {
        //    return UIFont(name: "HelveticaNeue", size: 16.0)!
        //}

        //static func distinctButtonSelected() -> UIFont {
        //    return UIFont(name: "HelveticaNeue-Medium", size: 18.0)!
        //}

        //static func distinctButtonNormal() -> UIFont {
        //    return UIFont(name: "HelveticaNeue", size: 18.0)!
        //}

        //static func navigationBarButtonItemFont() -> UIFont {
        //    return UIFont(name: "HelveticaNeue", size: 16.0)!
        //}

        //static func memberOnlineTextColor() -> UIColor {
        //    return UIColor(red: 41.0/255.0, green: 197.0/255.0, blue: 25.0/255.0, alpha: 1)
        //}

        //static func memberOfflineDateTextColor() -> UIColor {
        //    return UIColor(red: 142.0/255.0, green: 142.0/255.0, blue: 142.0/255.0, alpha: 1)
        //}

        public static UIColor connectButtonColor()
        {
            return new UIColor(red: (float)(123.0 / 255.0), green: (float)(95.0 / 255.0), blue: (float)(217.0 / 255.0), alpha: 1f);
        }
    
    //static func urlPreviewDescriptionFont() -> UIFont {
    //    return UIFont(name: "HelveticaNeue-Light", size: 12.0)!
    //}







    }
}
