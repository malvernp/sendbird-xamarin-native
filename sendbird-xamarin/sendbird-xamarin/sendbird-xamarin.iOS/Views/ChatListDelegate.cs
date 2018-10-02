// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: ChatListDelegate.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/08/27
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using Foundation;
using sendbirdxamarin.Core.ViewModels;
using MvvmCross.Commands;
using MvvmCross.Platforms.Ios.Binding.Views;
using sendbirdconnect.Models;
using UIKit;

namespace sendbird_xamarin.iOS.Views
{
    public class ChatListDelegate : UITableViewDelegate
    {
        public IMvxCommand<ChatListEntry> ViewChattingViewCommand { get; set; }


        private UIView _parentView;

        public ChatListDelegate(UIView parentView)
        {
            _parentView = parentView;
        }


        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            ChatListEntry channel = (ChatListEntry)((MvxTableViewCell)tableView.CellAt(indexPath)).DataContext;
            ViewChattingViewCommand.Execute(channel);
        }

    }
}

