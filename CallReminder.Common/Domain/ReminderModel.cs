using System;
using CallReminder.Core.Presentation.ValueConverters;

namespace CallReminder.Core.Domain
{
    public class ReminderModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public DateTime Time { get; set; }

        public DayOfWeeksFlags DayOfWeeks { get; set; }

        public bool Repeat { get; set; }
    }
}
