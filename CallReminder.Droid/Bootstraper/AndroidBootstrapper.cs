using CallReminder.Core.Bootstrappers;
using CallReminder.Core.Infrastructure;
using CallReminder.Core.Navigation;
using CallReminder.Droid.Infrastructure;
using CallReminder.Droid.Navigation;
using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;

namespace CallReminder.Droid.Bootstraper
{
    internal class AndroidBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var simpleIoc = config.GetSimpleIoc();

            SetupDependencies(simpleIoc);
        }

        private void SetupDependencies(ISimpleIoc simpleIoc)
        {
            simpleIoc.Register<INavigationService>(() => new NavigationService());
            simpleIoc.Register<IContactService>(() => new ContactService());
        }
    }
}