using Android.App;
using Android.OS;
using Android.Runtime;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace sendbird_xamarin.Droid.Views
{
    [Activity(Label = "Group Channels")]
    [MvxActivityPresentation]

    public class FirstView : BaseView
    {
        protected override int LayoutResource => Resource.Layout.FirstView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
        }
    }
}
