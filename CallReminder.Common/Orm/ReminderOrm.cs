using System;
using SQLite;

namespace CallReminder.Core.Orm
{
    [Table("Reminders")]
    internal class ReminderOrm : IModelOrm
    {
        [PrimaryKey]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("time")]
        public DateTime Time { get; set; }

        [Column("dayOfWeeks")]
        public int DayOfWeeks { get; set; }

        [Column("repeat")]
        public bool Repeat { get; set; }
    }
}
