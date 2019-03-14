using CallReminder.Core.Orm;
using CallReminder.Core.Presentation;
using CallReminder.Core.Repositories;
using CallReminder.Core.Repositories.Interfaces;
using FlexiMvvm;
using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;

namespace CallReminder.Core.Bootstrappers
{
    public class CoreBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var simpleIoc = config.GetSimpleIoc();

            SetupDependencies(simpleIoc);
            SetupViewModelLocator(simpleIoc);
        }

        private void SetupDependencies(ISimpleIoc simpleIoc)
        {
            simpleIoc.Register<IReminderDatabase>(() => new ReminderDatabase());
            simpleIoc.Register<IReminderRepository>(() => new ReminderRepository(simpleIoc.Get<IReminderDatabase>()));
        }

        private void SetupViewModelLocator(IDependencyProvider dependencyProvider)
        {
            ViewModelLocator.SetLocator(new CallReminderViewModelLocator(dependencyProvider));
        }
    }
}
