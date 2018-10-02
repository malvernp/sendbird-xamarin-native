// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: ChattingContentListSource.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/09/04
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using Foundation;
using sendbird_xamarin.iOS.Views.Chatting.Cells;
using sendbirdxamarin.Core.ViewModels.Messages;
using MvvmCross.Base;
using MvvmCross.Exceptions;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace sendbird_xamarin.iOS.Views
{
    public class ChattingContentListSource : MvxTableViewSource
    {

        private readonly Dictionary<Type, Type> _itemsTypeDictionary = new Dictionary<Type, Type>
        {
            [typeof(IncomingUserMessage)] = typeof(IncomingUserMessageTableViewCell),
            [typeof(OutgoingUserMessage)] = typeof(OutgoingUserMessageTableViewCell)
        };


        public ChattingContentListSource(UITableView tableView) : base(tableView)
        {
            RegisterCellsForReuse();
        }



        private void RegisterCellsForReuse()
        {
            foreach (var type in _itemsTypeDictionary.Values)
            {
                TableView.RegisterNibForCellReuse(UINib.FromName(type.Name, NSBundle.MainBundle), type.Name);
            }

            //
            //TableView.RegisterNibForCellReuse(UINib.FromName("ChatListCell", NSBundle.MainBundle), _taskCell);
        }


        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {


            Type cellType = null;
            if (!_itemsTypeDictionary.TryGetValue(item.GetType(), out cellType))
                throw new MvxException($"Type {item.GetType().Name} is not registered as cell. Please override RegisterCellsForReuse");

            var cell = this.TableView.DequeueReusableCell(cellType.Name, indexPath);


                var bindable = cell as IMvxDataConsumer;
                if (bindable != null)
                {
                    bindable.DataContext = item;
                }



                           /*
                           as BaseTableViewCell;

            if (indexPath.Item == ItemsSource.Count() - 5)
                FetchCommand?.Execute(null);
*/
            return cell;


        }
    }
}


