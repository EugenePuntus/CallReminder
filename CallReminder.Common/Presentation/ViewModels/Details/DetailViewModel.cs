using System;
using System.Threading;
using System.Threading.Tasks;
using CallReminder.Core.Domain;
using CallReminder.Core.Infrastructure;
using CallReminder.Core.Navigation;
using CallReminder.Core.Presentation.ValueConverters;
using CallReminder.Core.Repositories.Interfaces;
using CallReminder.Core.Resourses;
using FlexiMvvm;
using ICommand = System.Windows.Input.ICommand;

namespace CallReminder.Core.Presentation.ViewModels.Details
{
    public class DetailViewModel : ViewModelBase<ReminderDetailParameters>
    {
        private readonly INavigationService _navigationService;
        private readonly IReminderRepository _reminderRepository;
        private readonly IDialogService _dialogService;
        private Guid _id;
        private string _name;
        private string _nameError;
        private string _phone;
        private string _phoneError;
        private DateTime _time;
        private bool _repeat;
        private DayOfWeeksFlags _dayOfWeeks;

        public string Name
        {
            get => _name;
            set
            {
                Set(ref _name, value);
                NameError = string.Empty;
            }
        }

        public string NameError
        {
            get => _nameError;
            set => Set(ref _nameError, value);
        }

        public string Phone
        {
            get => _phone;
            set
            {
                Set(ref _phone, value);
                PhoneError = string.Empty;
            }
        }

        public string PhoneError
        {
            get => _phoneError;
            set => Set(ref _phoneError, value);
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

        public DayOfWeeksFlags DayOfWeeks
        {
            get => _dayOfWeeks;
            set
            {
                if (_dayOfWeeks != value)
                {
                    Set(ref _dayOfWeeks, value);
                }
            }
        }

        public ICommand BackToHomeCommand => CommandProvider.Get(BackToHome);

        public ICommand ChangeContactCommand => CommandProvider.Get(ChangeContact);

        public ICommand SaveReminderCommand => CommandProvider.GetForAsync(SaveReminder);

        public DetailViewModel(INavigationService navigationService, IReminderRepository reminderRepository, IDialogService dialogService)
        {
            _navigationService = navigationService;
            _reminderRepository = reminderRepository;
            _dialogService = dialogService;
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
                    DayOfWeeks = DayOfWeeksFlags.None,
                    Repeat = false,
                    Time = new DateTime(1990, 1, 1, 9, 0, 0),
                    Name = string.Empty,
                    Phone = string.Empty
                };
            }

            _id = reminder.Id;
            Name = reminder.Name;
            Phone = reminder.Phone;
            Time = reminder.Time;
            Repeat = reminder.Repeat;
            DayOfWeeks = reminder.DayOfWeeks;
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
                DayOfWeeks = DayOfWeeks
            };

            if(string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Phone))
            {
                _dialogService.ShowNotification(Strings.FillRequiredField);

                NameError = string.IsNullOrWhiteSpace(Name) ? Strings.RequiredFieldError : string.Empty;
                PhoneError = string.IsNullOrWhiteSpace(Phone) ? Strings.RequiredFieldError : string.Empty;

                return;
            }

            await _reminderRepository.CreateOrUpdateReminderAsync(model, CancellationToken.None);
            BackToHome();
        }
    }
}
