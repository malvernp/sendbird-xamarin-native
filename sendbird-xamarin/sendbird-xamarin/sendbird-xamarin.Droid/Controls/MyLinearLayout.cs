// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: MyLinearLayout.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/09/13
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Binding.Views;

namespace sendbird_xamarin.Droid.Controls
{
    public class MyLinearLayout : LinearLayout
    {

        //public MyLinearLayout()
        //{
        //}
        protected MyLinearLayout(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }



        public MyLinearLayout(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public override ViewStates Visibility { get => base.Visibility; set => base.Visibility = value; }

        public ViewStates VisibilityCustom
        {
            get => base.Visibility;

            set
            {
                base.Visibility = value;

                if (Visibility == ViewStates.Visible)
                {

                        List<ImageView> indicatorImages = new List<ImageView>();
                        indicatorImages.Add((ImageView)FindViewById(Resource.Id.typing_indicator_dot_1));
                        indicatorImages.Add((ImageView)FindViewById(Resource.Id.typing_indicator_dot_2));
                        indicatorImages.Add((ImageView)FindViewById(Resource.Id.typing_indicator_dot_3));
                        TypingIndicator indicator = new TypingIndicator(indicatorImages, 600);

                    indicator.animate();
                }
            }

        }
    }
}