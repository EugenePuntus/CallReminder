using CallReminder.Core.Domain;

namespace CallReminder.Core.Infrastructure
{
    public interface IAlarmService
    {
        void SwitchingState(ReminderModel reminderModel);

        void Start(ReminderModel reminderModel);

        void Cancel(ReminderModel reminderModel);
    }
}
