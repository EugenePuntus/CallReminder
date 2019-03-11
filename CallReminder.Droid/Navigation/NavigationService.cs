using Android.Content;
using CallReminder.Core.Navigation;
using CallReminder.Core.Presentation;
using CallReminder.Core.Presentation.ViewModels.Details;
using CallReminder.Core.Presentation.ViewModels.Home;
using CallReminder.Droid.Views;
using CallReminder.Droid.Views.Details;
using CallReminder.Droid.Views.Home;
using FlexiMvvm;
using FlexiMvvm.Navigation;
using FlexiMvvm.Views;

namespace CallReminder.Droid.Navigation
{
    internal class NavigationService : NavigationServiceBase, INavigationService
    {
        public void NavigateToHome(EntryViewModel model)
        {
            var splashScreenActivity = GetActivity<EntryViewModel, SplashScreenActivity>(model);
            var homeIntent = new Intent(splashScreenActivity, typeof(HomeActivity));
            splashScreenActivity.NotNull().StartActivity(homeIntent);
        }

        public void NavigateToDetail(HomeViewModel model, ReminderDetailParameters parameters)
        {
            var homeActivity = GetActivity<HomeViewModel, HomeActivity>(model);
            var detailIntent = new Intent(homeActivity, typeof(DetailActivity));
            detailIntent.PutViewModelParameters(parameters);
            homeActivity.NotNull().StartActivity(detailIntent);
        }

        public void NavigateBackToHome(DetailViewModel model)
        {
            var detatilActivity = GetActivity<DetailViewModel, DetailActivity>(model);
            detatilActivity.NotNull().Finish();
        }
    }
}