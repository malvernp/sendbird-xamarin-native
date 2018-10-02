using CoreFoundation;
using Foundation;
using sendbirdxamarin.Core.ViewModels;
using ObjCRuntime;
using System;
using UIKit;

namespace sendbird_xamarin.iOS
{
    public partial class ChattingContentView : UIView
    {

        ChattingViewModel parentViewModel;

        public ChattingContentView (IntPtr handle) : base (handle)
        {
        }


        public static ChattingContentView Create()
        {

            var arr = NSBundle.MainBundle.LoadNib("ChattingContentView", null, null);
            var v = Runtime.GetNSObject<ChattingContentView>(arr.ValueAt(0));

            //v.chattingTableView.Layer.BorderColor = UIColor.Red.CGColor;
            //v.chattingTableView.Layer.BorderWidth = 2.0f; 

            return v;
        }


        public void SetViewModel(ChattingViewModel vm) {
            parentViewModel = vm;
            ConfigureView();
        }


        private void ConfigureView() {
            typingIndicatorContainerView.Hidden = true;
            typingIndicatorContainerViewHeight.Constant = 0;
            typingIndicatorImageHeight.Constant = 0;
        }


        public void StartTypingIndicator(string text) {

            typingIndicatorContainerView.Hidden = false;
            typingIndicatorLabel.Text = text;

            typingIndicatorContainerViewHeight.Constant = 26.0f;
            typingIndicatorImageHeight.Constant = 26.0f;
            typingIndicatorContainerView.LayoutIfNeeded();


            if (!typingIndicatorImageView.IsAnimating)
            {

                var typingImages = new UIImage[50];

                for (int i = 0; i < typingImages.Length; i++)
                {
                    var imageUrl = (i + 1).ToString("00");
                    typingImages[i] = UIImage.FromBundle(imageUrl);
                }

                this.typingIndicatorImageView.AnimationImages = typingImages;
                this.typingIndicatorImageView.AnimationDuration = 1.5;

                DispatchQueue.MainQueue.DispatchAsync(() =>
                {
                    this.typingIndicatorImageView.StartAnimating();
                });

            }
        }


        public void EndTypingIndicator()
        {

            DispatchQueue.MainQueue.DispatchAsync(() =>
            {
                this.typingIndicatorImageView.StopAnimating();
            });


            typingIndicatorContainerView.Hidden = true;
            typingIndicatorContainerViewHeight.Constant = 0;
            typingIndicatorImageHeight.Constant = 0;


            typingIndicatorContainerView.LayoutIfNeeded();
        }


        public UITableView GetTableView() {
            return chattingTableView;
        }

        //func configureChattingView(channel: SBDBaseChannel?)
        //{
        //    self.channel = channel;

        //    self.initialLoading = true
        //self.lastMessageHeight = 0
        //self.scrollLock = false
        //self.stopMeasuringVelocity = false


        //self.typingIndicatorContainerView.isHidden = true
        //self.typingIndicatorContainerViewHeight.constant = 0
        //self.typingIndicatorImageHeight.constant = 0
    }
}