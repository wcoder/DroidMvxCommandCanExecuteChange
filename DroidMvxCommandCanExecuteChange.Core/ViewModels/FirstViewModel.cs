using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace DroidMvxCommandCanExecuteChange.Core.ViewModels
{
	public class FirstViewModel : MvxViewModel
	{
		private bool _isLoading = true;

		public IMvxCommand ClickMeCommand =>
			new MvxAsyncCommand(
				async () =>
				{
					await Task.Delay(TimeSpan.FromSeconds(2));
				},
				() =>
				{
					return !IsLoading;
				});

		public bool IsLoading
		{
			get => _isLoading;
			set
			{
				SetProperty(ref _isLoading, value);
				ClickMeCommand.RaiseCanExecuteChanged();
			}
		}

		public override async void Start()
		{
			base.Start();

			await Task.Run(async () =>
			{
				await Task.Delay(TimeSpan.FromSeconds(5));

				IsLoading = false;
			});
		}
	}
}
