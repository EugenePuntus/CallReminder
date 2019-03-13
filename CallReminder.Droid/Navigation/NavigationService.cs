using Android.Content;
using CallReminder.Core.Navigation;
using CallReminder.Core.Presentation;
using CallReminder.Core.Presentation.ViewModels.Contacts;
using CallReminder.Core.Presentation.ViewModels.Details;
using CallReminder.Core.Presentation.ViewModels.Home;
using CallReminder.Droid.Views;
using CallReminder.Droid.Views.Contacts;
using CallReminder.Droid.Views.Details;
using CallReminder.Droid.Views.Home;
using FlexiMvvm;
using FlexiMvvm.Navigation;
using FlexiMvvm.Views;

namespace CallReminder.Droid.Navigation
{
    internal class NavigationService : NavigationServiceBase, INavigationService
    {
        public void NavigateToHome(EntryViewModel fromModel)
        {
            var splashScreenActivity = GetActivity<EntryViewModel, SplashScreenActivity>(fromModel);
            var homeIntent = new Intent(splashScreenActivity, typeof(HomeActivity));
            splashScreenActivity.NotNull().StartActivity(homeIntent);
        }

        public void NavigateToDetail(HomeViewModel fromModel, ReminderDetailParameters parameters)
        {
            var homeActivity = GetActivity<HomeViewModel, HomeActivity>(fromModel);
            var detailIntent = new Intent(homeActivity, typeof(DetailActivity));
            detailIntent.PutViewModelParameters(parameters);
            homeActivity.NotNull().StartActivity(detailIntent);
        }

        public void NavigateBackToHome(DetailViewModel fromModel)
        {
            var detatilActivity = GetActivity<DetailViewModel, DetailActivity>(fromModel);
            detatilActivity.NotNull().Finish();
        }

        public void NavigateToContact(DetailViewModel fromModel)
        {
            var detailActivity = GetActivity<DetailViewModel, DetailActivity>(fromModel);
            var contactIntent = new Intent(detailActivity, typeof(ContactActivity));
            detailActivity.NotNull().StartActivity(contactIntent);
        }

        public void NavigateBackToDetail(ContactViewModel fromModel)
        {
            var contactActivity = GetActivity<ContactViewModel, ContactActivity>(fromModel);
            contactActivity.NotNull().Finish();
        }
    }
}