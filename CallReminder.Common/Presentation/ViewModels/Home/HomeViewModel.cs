using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using CallReminder.Core.Navigation;
using CallReminder.Core.Presentation.ViewModels.Details;
using CallReminder.Core.Repositories.Interfaces;
using FlexiMvvm;
using FlexiMvvm.Collections;

namespace CallReminder.Core.Presentation.ViewModels.Home
{
    public class HomeViewModel : ViewModelBase, IViewModelWithOperation
    {
        private readonly INavigationService _navigationService;
        private readonly IReminderRepository _reminderRepository;
        private bool _loading;

        public RangeObservableCollection<ReminderItemViewModel> Reminders { get; } = new RangeObservableCollection<ReminderItemViewModel>();

        public bool Loading
        {
            get => _loading;
            set => Set(ref _loading, value);
        }

        public ICommand ReminderSelectedCommand => CommandProvider.Get<ReminderItemViewModel>(NavigateToDetail);

        public HomeViewModel(INavigationService navigationService, IReminderRepository reminderRepository)
        {
            _navigationService = navigationService;
            _reminderRepository = reminderRepository;
        }

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            var reminders = await _reminderRepository.GetReminders(CancellationToken.None);

            Reminders.AddRange(reminders.Select(model => new ReminderItemViewModel(model)));
        }

        private void NavigateToDetail(ReminderItemViewModel param)
        {
            _navigationService.NavigateToDetail(this, new ReminderDetailParameters() {Id = param?.Id ?? Guid.Empty});
        }
    }
}
