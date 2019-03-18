using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using CallReminder.Core.Infrastructure;
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
        private readonly IAlarmService _alarmService;
        private bool _loading;
        private bool _removeState;

        public RangeObservableCollection<ReminderItemViewModel> Reminders { get; } = new RangeObservableCollection<ReminderItemViewModel>();

        public int QuantityToRemove
        {
            get => Reminders.Count(x => x.SelectedByRemove);
        }

        public bool Loading
        {
            get => _loading;
            set => Set(ref _loading, value);
        }

        public bool RemoveState
        {
            get => _removeState;
            set
            {
                var notEqual = _removeState != value;
                Set(ref _removeState, value);
                
                if (notEqual)
                {
                    foreach (var reminder in Reminders)
                    {
                        reminder.RemoveState = value;
                        reminder.SelectedByRemove = false;
                    }
                }
            }
        }

        public ICommand ReminderSelectedCommand => CommandProvider.Get<ReminderItemViewModel>(NavigateToDetail);

        public ICommand RefreshCommand => CommandProvider.GetForAsync(RefreshAsync);

        public ICommand RemoveCommand => CommandProvider.GetForAsync(RemoveAsync);

        public ICommand CheckedOrUncheckedAllCommand => CommandProvider.Get<bool>(CheckedOrUnCheckedReminder);

        public HomeViewModel(INavigationService navigationService, IReminderRepository reminderRepository, IAlarmService alarmService)
        {
            _navigationService = navigationService;
            _reminderRepository = reminderRepository;
            _alarmService = alarmService;
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

                foreach (var reminderModel in reminderModels)
                {
                    var itemViewModel = new ReminderItemViewModel(reminderModel, _reminderRepository, _alarmService);
                    itemViewModel.PropertyChangedWeakSubscribe((sender, args) => RaisePropertyChanged(nameof(QuantityToRemove)));
                    Reminders.Add(itemViewModel);
                }
            }
            finally
            {
                Loading = false;
            }
        }

        private async Task RemoveAsync()
        {
            try
            {
                Loading = true;
                var reminderToRemove = Reminders.Where(x => x.SelectedByRemove).ToArray();

                for (int i = 0; i < reminderToRemove.Length; i++)
                {
                    await _reminderRepository.RemoveReminderByIdTask(reminderToRemove[i].Id, CancellationToken.None);
                    Reminders.Remove(reminderToRemove[i]);
                }

                RemoveState = false;
            }
            finally
            {
                Loading = false;
            }
        }

        private void CheckedOrUnCheckedReminder(bool state)
        {
            foreach (var reminder in Reminders)
            {
                reminder.SelectedByRemove = state;
            }
        }
    }
}
