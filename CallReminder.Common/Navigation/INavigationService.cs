using CallReminder.Core.Presentation;
using CallReminder.Core.Presentation.ViewModels.Contacts;
using CallReminder.Core.Presentation.ViewModels.Details;
using CallReminder.Core.Presentation.ViewModels.Home;

namespace CallReminder.Core.Navigation
{
    public interface INavigationService
    {
        void NavigateToHome(EntryViewModel fromModel);

        void NavigateToDetail(HomeViewModel fromModel, ReminderDetailParameters parameters);

        void NavigateBackToHome(DetailViewModel fromModel);

        void NavigateToContact(DetailViewModel fromModel);

        void NavigateBackToDetail(ContactViewModel fromModel);

        void NavigateBackToDetail(ContactViewModel fromModel, ContactParameters parameters);
    }
}
