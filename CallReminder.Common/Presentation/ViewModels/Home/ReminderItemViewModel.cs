using System;
using CallReminder.Core.Domain;
using FlexiMvvm;
using FlexiMvvm.Collections;

namespace CallReminder.Core.Presentation.ViewModels.Home
{
    public class ReminderItemViewModel : ViewModelBase
    {
        private string _name;
        private string _phone;
        private DateTime _time;
        private RangeObservableCollection<DayOfWeek> _dayOfWeeks;
        private bool _repeat;

        public Guid Id { get; }

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

        public RangeObservableCollection<DayOfWeek> DayOfWeeks
        {
            get => _dayOfWeeks;
            set => Set(ref _dayOfWeeks, value);
        }

        public bool Repeat
        {
            get => _repeat;
            set => Set(ref _repeat, value);
        }


        public ReminderItemViewModel(ReminderModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Phone = model.Phone;
            Time = model.Time;
            DayOfWeeks = new RangeObservableCollection<DayOfWeek>(model.DayOfWeeks);
            Repeat = model.Repeat;
        }
    }
}
