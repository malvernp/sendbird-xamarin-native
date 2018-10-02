// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: ChatListSource.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/06/25
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using Foundation;
using MvvmCross.Base;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace sendbird_xamarin.iOS.Views
{
    public class ChatListSource: MvxTableViewSource
    {
        readonly NSString _taskCell = new NSString("ChatListCell");

        public ChatListSource(UITableView tableView) : base(tableView)
        {
            RegisterCellsForReuse();
        }



        private void RegisterCellsForReuse()
        {
            TableView.RegisterNibForCellReuse(UINib.FromName("ChatListCell", NSBundle.MainBundle), _taskCell);
        }


        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var cell = TableView.DequeueReusableCell(_taskCell, indexPath);

            var bindable = cell as IMvxDataConsumer;
            if (bindable != null)
            {
                bindable.DataContext = item;
            }

            return cell;
        }
    }
}
