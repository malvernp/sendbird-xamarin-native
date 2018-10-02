// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// FileName: ChattingView.cs
// Project: SendbirdXamarinUI
// Date Created: 2018/08/27
// Author: malvern
// Description: 
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using CoreGraphics;
using Foundation;
using sendbirdxamarin.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using UIKit;

namespace sendbird_xamarin.iOS.Views.Chatting
{
    [MvxModalPresentation] 
    public partial class ChattingView : MvxViewController<ChattingViewModel>

    {

        ChattingContentView contentView;

        private string _typingStatusChange;
        public string TypingStatusChange
        {
            get { return _typingStatusChange; }
            set
            {
                UpdateTypingAnimation();
            }
        }


        private void UpdateTypingAnimation()
        {


            ChattingViewModel e = (ChattingViewModel)DataContext;

            string label = e.Channel.Name + " is typing...";

            if (e.Channel.IsTyping) {
                contentView.StartTypingIndicator(label);
            }
            else {
                contentView.EndTypingIndicator();
            }

        }

        private ChattingContentListSource _source;
        private const int ItemHeight = 80;



        public ChattingView() : base("ChattingView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            navItem.Title = "TITLE";

           contentView = ChattingContentView.Create();
           // contentView.BackgroundColor = UIColor.Brown;


            navItem.LeftBarButtonItem =  new UIBarButtonItem("Back", UIBarButtonItemStyle.Plain, null);

            navItem.LeftBarButtonItem.Clicked += (sender, e) => {
                //DismissModalViewController(true); 
                ViewModel.NavigationService.Close(ViewModel);
            };

            NavigationItem.Title = "Title";


           //contentView.Layer.BorderColor = UIColor.Blue.CGColor;
            //contentView.Layer.BorderWidth = 2.0f; 

           // chattingView.Layer.BorderColor = UIColor.Blue.CGColor;
            //chattingView.Layer.BorderWidth = 2.0f; 

            //contentView.Frame = chattingView.Frame;
            //chattingView.BackgroundColor = UIColor.Black;

            chattingView.AddSubview(contentView);
            chattingView.BringSubviewToFront(contentView);

            var views = new NSMutableDictionary();
            views.Add(new NSString("contentView"), contentView);

            // Define format and assemble constraints
            contentView.TranslatesAutoresizingMaskIntoConstraints = false;
            chattingView.TranslatesAutoresizingMaskIntoConstraints = false;

            var format = "|-[contentView]-|";
            var constraints = NSLayoutConstraint.FromVisualFormat(format, NSLayoutFormatOptions.AlignAllTop, null, views);

            chattingView.AddConstraints(
                NSLayoutConstraint.FromVisualFormat("H:|[contentView]|", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, views)
            );

            chattingView.AddConstraints(
                NSLayoutConstraint.FromVisualFormat("V:|[contentView]|", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, views)
            );

            SetCollectionViewSource();

            var set = this.CreateBindingSet<ChattingView, ChattingViewModel>();
            set.Bind(this).For(v => v.TypingStatusChange).To(item => item.Channel.IsTyping);
            set.Bind(_source).For(v => v.ItemsSource).To(vm => vm.ChatMessages);

            //set.Bind(SearchBar).For(v => v.Text).To(vm => vm.SearchQuery).TwoWay();
            //set.Bind(_refreshControl).For(r => r.RefreshCommand).To(vm => vm.Paging.RefreshItemsCommand);
            //set.Bind(_refreshControl).For(r => r.IsRefreshing).To(vm => vm.RefreshNotifier.IsNotCompleted).WithFallback(false);
            //set.Bind(this).For(v => v.RefreshListView).To(vm => vm.Refresh);
           // set.Bind(_source).For(v => v.ItemsSource).To(vm => vm.ChatList);

            set.Apply();

            // Apply constraints
          //  NSLayoutConstraint.ActivateConstraints(constraints);


        }



        private void SetCollectionViewSource()
        {
            // _refreshControl = new MvxUIRefreshControl();

            var TableView = contentView.GetTableView();
            _source = new ChattingContentListSource(TableView);
            TableView.Source = _source;
            //TableView.RowHeight = ItemHeight;

            TableView.RowHeight = UITableView.AutomaticDimension;
            TableView.EstimatedRowHeight = ItemHeight;

            //            CustomersList.AddSubview(_refreshControl);

            _source.ItemsSource = ViewModel.ChatMessages;
            TableView.ReloadData();

            //TableView.Layer.BorderColor = UIColor.Black.CGColor;
            //TableView.Layer.BorderWidth = 2.0f;
                

        }
    

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }


        //public override void ViewDidLayoutSubviews()
        //{
        //    base.ViewDidLayoutSubviews();
        //    navItem.
        //    var navBa = NavigationController.NavigationBar;
        //    if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
        //    {
        //        foreach (var subview in navBar.Subviews)
        //        {
        //            var stringFromClass = subview.GetType().FullName;

        //            if (stringFromClass.Contains("BarBackground")) {
        //                subview.Frame = navBar.Bounds;
        //            }

        //            else if (stringFromClass.Contains("BarContentView")) {
        //                subview.Frame = new CGRect(
        //                    x: subview.Frame.X, y: 24, width: subview.Frame.Size.Width, height: navBar.Bounds.Size.Height - 24);
        //            }

        //            //let stringFromClass = NSStringFromClass(subview.classForCoder)
        //            //var stringFromClass = new NSString(F)//.FromClass(subview.ClassForCoder);
                        
        //        //if stringFromClass.contains("BarBackground") {
        //        //        subview.frame = self.bounds
        //        //}

        //        }

        //    }
        //    //custom nav babr stuff

        //}
    }
}

