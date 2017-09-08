using Android.App;
using Android.OS;
using Android.Widget;
using DroidMvxCommandCanExecuteChange.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Views;

namespace DroidMvxCommandCanExecuteChange.Views
{
	[Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxActivity<FirstViewModel>
	{
		private Button _clickMeBtn;

		protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);



	        _clickMeBtn = FindViewById<Button>(Resource.Id.clickMeBtn);



	        var bindingSet = this.CreateBindingSet<FirstView, FirstViewModel>();

	        bindingSet.Bind(_clickMeBtn)
		        .To(vm => vm.ClickMeCommand);

	        bindingSet.Apply();

		}
    }
}
