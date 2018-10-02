// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: ChatsView.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/09/07
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
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using sendbird_xamarin.Core.ViewModels;
using sendbird_xamarin.Droid.Extensions;
using sendbirdxamarin.Core.Services;
using sendbirdxamarin.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace sendbird_xamarin.Droid.Views   
{
    
    [MvxFragmentPresentation(typeof(FirstViewModel), Resource.Id.content_frame, false)]
    [Register(nameof(ChatsView))]
    public class ChatsView : MvxFragment<ChatListViewModel>
    {

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.ChatsView, null);
            view.SetBackgroundColor(Color.White);

            Activity.Title = String.Format("Group Channels ({0})", LocalCache.CurrentNickName);

            return view;

        }



    }



}
