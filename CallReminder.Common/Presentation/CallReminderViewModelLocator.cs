using CallReminder.Core.Infrastructure;
using CallReminder.Core.Navigation;
using CallReminder.Core.Presentation.ViewModels.Contacts;
using CallReminder.Core.Presentation.ViewModels.Details;
using CallReminder.Core.Presentation.ViewModels.Home;
using CallReminder.Core.Repositories.Interfaces;
using FlexiMvvm;
using FlexiMvvm.Ioc;

namespace CallReminder.Core.Presentation
{
    internal class CallReminderViewModelLocator : ViewModelLocatorBase
    {
        private readonly IDependencyProvider _dependencyProvider;

        public CallReminderViewModelLocator(IDependencyProvider dependencyProvider)
        {
            _dependencyProvider = dependencyProvider;
        }

        protected override void SetupFactory(ViewModelFactory factory)
        {
            factory.Register(() => new EntryViewModel(_dependencyProvider.Get<INavigationService>()));
            factory.Register(() => new HomeViewModel(_dependencyProvider.Get<INavigationService>(), _dependencyProvider.Get<IReminderRepository>()));
            factory.Register(() => new DetailViewModel(_dependencyProvider.Get<INavigationService>(), _dependencyProvider.Get<IReminderRepository>()));
            factory.Register(() => new ContactViewModel(_dependencyProvider.Get<INavigationService>(), _dependencyProvider.Get<IContactService>()));
        }
    }
}
