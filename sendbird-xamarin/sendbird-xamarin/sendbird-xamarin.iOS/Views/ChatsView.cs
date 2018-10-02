using Foundation;
using sendbird_xamarin.iOS.Views;
using sendbirdxamarin.Core.Services;
using sendbirdxamarin.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using System;
using System.Threading.Tasks;
using UIKit;

namespace sendbird_xamarin.iOS
{
  //  [MvxRootPresentation(WrapInNavigationController = true)]
    [MvxModalPresentation(WrapInNavigationController = true)]
    public partial class ChatsView : MvxViewController<ChatListViewModel>
    {

        private const int ItemHeight = 98;
        private ChatListSource _source;
        //private MvxUIRefreshControl _refreshControl;


        public ChatsView(){
            
        }

        public ChatsView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SetCollectionViewSource();

            var set = this.CreateBindingSet<ChatsView, ChatListViewModel>();

            //set.Bind(SearchBar).For(v => v.Text).To(vm => vm.SearchQuery).TwoWay();
            //set.Bind(_refreshControl).For(r => r.RefreshCommand).To(vm => vm.Paging.RefreshItemsCommand);
            //set.Bind(_refreshControl).For(r => r.IsRefreshing).To(vm => vm.RefreshNotifier.IsNotCompleted).WithFallback(false);
            //set.Bind(this).For(v => v.RefreshListView).To(vm => vm.Refresh);
            set.Bind(_source).For(v => v.ItemsSource).To(vm => vm.ChatList);

            set.Apply();
          //  Task.Run(() => ViewModel.UpdateTest().ConfigureAwait(false));   
//            await Task.Run(() => ViewModel.UpdateTest());   
            //ViewModel.UpdateTest();



            var listDelegate = new ChatListDelegate(View);
            TableView.Delegate = listDelegate;
            listDelegate.ViewChattingViewCommand = ViewModel.ChattingViewCommand;


            NavigationItem.Title = String.Format("Group Channels ({0})", LocalCache.CurrentNickName);

        }


        private void SetCollectionViewSource()
        {
            // _refreshControl = new MvxUIRefreshControl();

            _source = new ChatListSource(TableView);
            TableView.Source = _source;
            TableView.RowHeight = ItemHeight;
//            CustomersList.AddSubview(_refreshControl);

            _source.ItemsSource = ViewModel.ChatList;
            TableView.ReloadData();
        }
    }
}