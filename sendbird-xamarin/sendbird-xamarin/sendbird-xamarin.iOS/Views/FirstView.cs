using System;
using MvvmCross.Binding.BindingContext;
using sendbird_xamarin.Core.ViewModels;
using MvvmCross.Platforms.Ios.Views;

namespace sendbird_xamarin.iOS.Views
{
    [MvxFromStoryboard]

    public partial class FirstView : MvxViewController
    {
        public FirstView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(Label).To(vm => vm.Hello);
            set.Bind(TextField).To(vm => vm.Hello);
            set.Bind(chatButton).To(vm => vm.ShowChatsViewModelCommand);
            set.Apply();
        }
    }
}
