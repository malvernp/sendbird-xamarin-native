// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: MainApplication.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/09/10
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using Android.App;
using Android.Runtime;
using sendbird_xamarin.Core;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace sendbird_xamarin.Droid
{
    [Application]
    public class MainApplication : MvxAppCompatApplication<Setup, App>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
    }
}