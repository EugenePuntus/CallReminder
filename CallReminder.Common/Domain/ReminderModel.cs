using System;
using System.Collections.Generic;

namespace CallReminder.Core.Domain
{
    public class ReminderModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public DateTime Time { get; set; }

        public IEnumerable<DayOfWeek> DayOfWeeks { get; set; }

        public bool Repeat { get; set; }
    }
}
