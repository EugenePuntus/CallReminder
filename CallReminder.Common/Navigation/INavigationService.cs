using CallReminder.Core.Presentation;
using CallReminder.Core.Presentation.ViewModels.Details;
using CallReminder.Core.Presentation.ViewModels.Home;

namespace CallReminder.Core.Navigation
{
    public interface INavigationService
    {
        void NavigateToHome(EntryViewModel model);

        void NavigateToDetail(HomeViewModel model, ReminderDetailParameters parameters);

        void NavigateBackToHome(DetailViewModel model);
    }
}
