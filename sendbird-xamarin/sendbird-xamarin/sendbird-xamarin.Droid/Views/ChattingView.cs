// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: ChattingView.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/09/13
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace sendbird_xamarin.Droid.Views
{
    [Activity(Label = "ChattingView")]
    [MvxActivityPresentation]
    public class ChattingView : BaseView
    {
        protected override int LayoutResource => Resource.Layout.ChattingView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }
    }
}
