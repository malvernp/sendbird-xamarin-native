// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: ChattingViewTemplateSelector.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/09/13
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using sendbirdxamarin.Core.ViewModels.Messages;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;

namespace sendbird_xamarin.Droid.TemplateSelectors
{
    public class ChattingViewTemplateSelector: IMvxTemplateSelector
    {
    
    
    
        private readonly Dictionary<Type, int> _itemsTypeDictionary = new Dictionary<Type, int>
        {
            [typeof(IncomingUserMessage)] = Resource.Layout.chattingview_item_incoming_usermessage,
            [typeof(OutgoingUserMessage)] = Resource.Layout.chattingview_item_outgoing_usermessage
        };

        public int ItemTemplateId { get; set; }

        public int GetItemLayoutId(int fromViewType)
        {
            return fromViewType;
        }

        public int GetItemViewType(object forItemObject)
        {
            return _itemsTypeDictionary[forItemObject.GetType()];
        }
    
    
    }
}


