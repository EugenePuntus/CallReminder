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

        public ICommand RefreshCommand => CommandProvider.GetForAsync(RefreshAsync);

        public HomeViewModel(INavigationService navigationService, IReminderRepository reminderRepository)
        {
            _navigationService = navigationService;
            _reminderRepository = reminderRepository;
        }

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            await RefreshAsync();
        }

        private void NavigateToDetail(ReminderItemViewModel param)
        {
            _navigationService.NavigateToDetail(this, new ReminderDetailParameters() {Id = param?.Id ?? Guid.Empty});
        }

        private async Task RefreshAsync()
        {
            try
            {
                Loading = true;

                var reminderModels = await _reminderRepository.GetRemindersAsync(CancellationToken.None);
                Reminders.Clear();
                Reminders.AddRange(reminderModels.Select(vacation => new ReminderItemViewModel(vacation)));
            }
            finally
            {
                Loading = false;
            }
        }
    }
}
