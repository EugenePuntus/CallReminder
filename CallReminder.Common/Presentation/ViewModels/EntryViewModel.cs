using CallReminder.Core.Navigation;
using FlexiMvvm;

namespace CallReminder.Core.Presentation.ViewModels
{
    public class EntryViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public EntryViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        protected override void Initialize()
        {
            base.Initialize();

            _navigationService.NavigateToHome(this);
        }
    }
}
