using Foundation;
using sendbirdxamarin.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using System;
using UIKit;

namespace sendbird_xamarin.iOS.Views
{
    
    [MvxFromStoryboard]
    [MvxRootPresentation(WrapInNavigationController = false)]     public partial class LoginView : MvxTableViewController<LoginViewModel>     {

        private string _isConnecting;
        public string IsConnecting
        {
            get { return _isConnecting; }
            set
            {
                if (ViewModel.ShowConnectProgress) {
                    indicatorView.StartAnimating();
                }
                else {
                    indicatorView.StopAnimating();
                }
            }
        }           public LoginView(IntPtr handle) : base(handle)         {         }          public override void ViewDidLoad()         {             base.ViewDidLoad();              var set = this.CreateBindingSet<LoginView, LoginViewModel>();              set.Bind(userIdTextField).To(vm => vm.UserId);
            set.Bind(nicknameTextField).To(vm => vm.NickName);
            set.Bind(connectButton).To(vm => vm.ShowChatListViewModelCommand);
            set.Bind(this).For(v => v.IsConnecting).To(item => item.ShowConnectProgress);
            set.Bind(versionLabel).To(vm => vm.VersionInfo);

            set.Apply();

            userIdLabel.Alpha = 0;
            nicknameLabel.Alpha = 0;


            userIdLineView.BackgroundColor = Constants.textFieldLineColorNormal();
            nicknameLineView.BackgroundColor = Constants.textFieldLineColorNormal();

            connectButton.SetBackgroundImage(Utils.imageFromColor(color: Constants.connectButtonColor()), UIControlState.Normal) ;

            indicatorView.HidesWhenStopped = true;

        }        } }