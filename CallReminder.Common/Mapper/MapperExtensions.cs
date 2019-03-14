using CallReminder.Core.Domain;
using CallReminder.Core.Orm;
using CallReminder.Core.ValueConverters;

namespace CallReminder.Core.Mapper
{
    internal static class MapperExtensions
    {
        public static ReminderOrm ToOrm(this ReminderModel model)
        {
            return new ReminderOrm()
            {
                Id = model.Id,
                Phone = model.Phone,
                Name = model.Name,
                Time = model.Time,
                Repeat = model.Repeat,
                DayOfWeeks = (int)model.DayOfWeeks
            };
        }

        public static ReminderModel ToModel(this ReminderOrm orm)
        {
            return new ReminderModel()
            {
                Id = orm.Id,
                Phone = orm.Phone,
                Name = orm.Name,
                Time = orm.Time,
                Repeat = orm.Repeat,
                DayOfWeeks = (DayOfWeeksFlags) orm.DayOfWeeks
            };
        }
    }
}
