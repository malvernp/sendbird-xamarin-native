// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: TypingIndicator.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/09/13
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using Android.Animation;
using Android.OS;
using Android.Support.Annotation;
using Android.Views.Animations;
using Android.Widget;

namespace sendbird_xamarin.Droid.Controls
{
    public class TypingIndicator
    {
    
    
    
        List<ImageView> mImageViewList;
        private int mAnimDuration;

        private AnimatorSet mAnimSet;

        public TypingIndicator(List<ImageView> imageViews, int duration)
        {
            mImageViewList = imageViews;
            mAnimDuration = duration;
        }

        /*
         * Animates all dots in sequential order.
         */

        [RequiresApi(Value = (int)BuildVersionCodes.Honeycomb)]
    public void animate()
        {
            int startDelay = 0;

            mAnimSet = new AnimatorSet();

            for (int i = 0; i < mImageViewList.Count; i++)
            {
                ImageView dot = mImageViewList[i];
                //            ValueAnimator bounce = ObjectAnimator.ofFloat(dot, "y", mAnimMagnitude);
                ValueAnimator fadeIn = ObjectAnimator.OfFloat(dot, "alpha", 1f, 0.5f);
                ValueAnimator scaleX = ObjectAnimator.OfFloat(dot, "scaleX", 1f, 0.7f);
                ValueAnimator scaleY = ObjectAnimator.OfFloat(dot, "scaleY", 1f, 0.7f);

                fadeIn.SetDuration(mAnimDuration);
                fadeIn.SetInterpolator(new AccelerateDecelerateInterpolator());
                fadeIn.RepeatMode = ValueAnimatorRepeatMode.Reverse;
                fadeIn.RepeatCount = ValueAnimator.Infinite;

                scaleX.SetDuration(mAnimDuration);
                scaleX.SetInterpolator(new AccelerateDecelerateInterpolator());
                fadeIn.RepeatMode = ValueAnimatorRepeatMode.Reverse;
                fadeIn.RepeatCount = ValueAnimator.Infinite;

                scaleY.SetDuration(mAnimDuration);
                scaleY.SetInterpolator(new AccelerateDecelerateInterpolator());
                fadeIn.RepeatMode = ValueAnimatorRepeatMode.Reverse;
                fadeIn.RepeatCount = ValueAnimator.Infinite;

                mAnimSet.Play(fadeIn).After(startDelay);
                mAnimSet.Play(scaleX).With(fadeIn);
                mAnimSet.Play(scaleY).With(fadeIn);

                mAnimSet.StartDelay = 500;

                startDelay += (mAnimDuration / (mImageViewList.Count - 1));
            }

            mAnimSet.Start();
        }

        [RequiresApi(Value = (int)BuildVersionCodes.Honeycomb)]
    public void stop()
        {

            if (mAnimSet == null)
            {
                return;
            }

            mAnimSet.End();
        }
    
    
    }
}
