using System;
using FlexiMvvm;

namespace CallReminder.Core.Presentation.ViewModels.Details
{
    public class ReminderDayOfWeekParameters : ViewModelBundleBase
    {
        public ReminderDayOfWeekParameters(DayOfWeek dayOfWeek)
        {
            DayOfWeek = dayOfWeek;
        }

        public DayOfWeek DayOfWeek
        {
            get => (DayOfWeek) Bundle.GetInt();
            set => Bundle.SetInt((int)value);
        }
    }
}
