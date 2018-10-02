// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: SwipeRefreshLayoutIsRefreshingTargetBinding.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/09/10
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.ComponentModel;
using Android.Support.V4.Widget;
using MvvmCross.Binding;
using MvvmCross.Logging;
using MvvmCross.Platforms.Android.Binding.Target;
using MvvmCross.ViewModels;
using MvvmCross.WeakSubscription;

namespace sendbird_xamarin.Droid.MvxBindings
{
    public class SwipeRefreshLayoutIsRefreshingTargetBinding : MvxAndroidTargetBinding
    {
        protected SwipeRefreshLayout SwipeRefreshLayout => (SwipeRefreshLayout)this.Target;

        public SwipeRefreshLayoutIsRefreshingTargetBinding(SwipeRefreshLayout swipeRefreshLayout)
            : base(swipeRefreshLayout)
        {
        }

        public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

        public override Type TargetType => typeof(MvxNotifyTask);

        protected override void SetValueImpl(object target, object value)
        {
            if (!(value is MvxNotifyTask))
            {
                return;
            }

            var taskCompletion = (MvxNotifyTask)value;
            taskCompletion.WeakSubscribe(HandlePropertyChanged);

            SwipeRefreshLayout.Post(() => SwipeRefreshLayout.Refreshing = taskCompletion.IsNotCompleted);
        }

        private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MvxNotifyTask.IsNotCompleted))
            {
                SwipeRefreshLayout.Post(() => SwipeRefreshLayout.Refreshing = ((MvxNotifyTask)sender).IsNotCompleted);
            }
        }
    }
}
