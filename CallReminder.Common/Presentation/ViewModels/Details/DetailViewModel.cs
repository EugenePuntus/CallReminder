using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CallReminder.Core.Domain;
using CallReminder.Core.Navigation;
using CallReminder.Core.Repositories.Interfaces;
using FlexiMvvm;
using FlexiMvvm.Collections;
using ICommand = System.Windows.Input.ICommand;

namespace CallReminder.Core.Presentation.ViewModels.Details
{
    public class DetailViewModel : ViewModelBase<ReminderDetailParameters>
    {
        private readonly INavigationService _navigationService;
        private readonly IReminderRepository _reminderRepository;
        private Guid _id;
        private string _name;
        private string _phone;
        private DateTime _time;
        private bool _repeat;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string Phone
        {
            get => _phone;
            set => Set(ref _phone, value);
        }

        public DateTime Time
        {
            get => _time;
            set => Set(ref _time, value);
        }

        public bool Repeat
        {
            get => _repeat;
            set => Set(ref _repeat, value);
        }

        public RangeObservableCollection<ReminderDayOfWeekParameters> DayOfWeeks { get; }

        public ICommand BackToHomeCommand => CommandProvider.Get(BackToHome);

        public ICommand ChangeContactCommand => CommandProvider.Get(ChangeContact);

        public ICommand SaveReminderCommand => CommandProvider.GetForAsync(SaveReminder);

        public DetailViewModel(INavigationService navigationService, IReminderRepository reminderRepository)
        {
            _navigationService = navigationService;
            _reminderRepository = reminderRepository;

            DayOfWeeks = new RangeObservableCollection<ReminderDayOfWeekParameters>(
                Enum.GetValues(typeof(DayOfWeek))
                    .Cast<DayOfWeek>()
                    .Select(dayOfWeek => new ReminderDayOfWeekParameters(dayOfWeek)));
        }

        protected override async Task InitializeAsync(ReminderDetailParameters parameters)
        {
            await base.InitializeAsync(parameters);

            ReminderModel reminder ;

            if (parameters != null && parameters.Id != Guid.Empty)
            {
                reminder = await _reminderRepository.GetReminderById(parameters.Id, CancellationToken.None);
            }
            else
            {
                reminder = new ReminderModel()
                {
                    Id = Guid.Empty,
                    DayOfWeeks = new DayOfWeek[] { },
                    Repeat = false,
                    Time = DateTime.Now,
                    Name = string.Empty,
                    Phone = string.Empty
                };
            }

            _id = reminder.Id;
            Name = reminder.Name;
            Phone = reminder.Phone;
            Time = reminder.Time;
            Repeat = reminder.Repeat;
            //TODO selected daysOfWeek
        }

        private void BackToHome()
        {
            _navigationService.NavigateBackToHome(this);
        }

        private void ChangeContact()
        {
            _navigationService.NavigateToContact(this);
        }

        private async Task SaveReminder()
        {
            var model = new ReminderModel()
            {
                Id = _id,
                Time = Time,
                Repeat = Repeat,
                Phone = Phone,
                Name = Name,
                DayOfWeeks = DayOfWeeks.Select(x => x.DayOfWeek)
            };

            await _reminderRepository.CreateOrUpdateReminderAsync(model, CancellationToken.None);
        }
    }
}
