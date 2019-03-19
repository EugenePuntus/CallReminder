using Android.App;
using Android.Content;
using CallReminder.Core.Domain;
using CallReminder.Core.Infrastructure;
using CallReminder.Core.Presentation.ViewModels.Notifications;
using CallReminder.Droid.Services;
using FlexiMvvm.Views;
using Java.Util;

namespace CallReminder.Droid.Infrastructure
{
    internal class AlarmService : IAlarmService
    {
        private readonly IDialogService _dialogService;

        public AlarmService(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public void SwitchingState(ReminderModel reminderModel)
        {
            if(reminderModel.Repeat)
            {
                Start(reminderModel);
            }
            else
            {
                Cancel(reminderModel);
            }
        }

        public void Start(ReminderModel reminderModel)
        {
            var context = Application.Context;

            var alarmIntent = new Intent(context, typeof(ReminderReceiver));
            alarmIntent.PutViewModelParameters(
                new NotificationParameters()
                {
                    Phone = reminderModel.Phone,
                    Name = reminderModel.Name
                });

            var pendingIntent = PendingIntent.GetBroadcast(context, reminderModel.Id.GetHashCode(), alarmIntent, PendingIntentFlags.CancelCurrent);

            var manager = (AlarmManager)context.GetSystemService(Context.AlarmService);
            var intervalMillis = 86400000;

            var cal = Calendar.Instance;
            cal.TimeInMillis = Java.Lang.JavaSystem.CurrentTimeMillis();
            cal.Set(CalendarField.HourOfDay, reminderModel.Time.Hour);
            cal.Set(CalendarField.Minute, reminderModel.Time.Minute);
            cal.Set(CalendarField.Second, 0);

            manager.SetInexactRepeating(AlarmType.RtcWakeup, cal.TimeInMillis, intervalMillis, pendingIntent);

            _dialogService.ShowNotification($"Reminder set: {reminderModel.Name}");
        }

        public void Cancel(ReminderModel reminderModel)
        {
            var context = Application.Context;

            var alarmIntent = new Intent(context, typeof(ReminderReceiver));
            var pendingIntent = PendingIntent.GetBroadcast(context, reminderModel.Id.GetHashCode(), alarmIntent, 0);

            var manager = (AlarmManager) context.GetSystemService(Context.AlarmService);
            manager.Cancel(pendingIntent);
        }
    }
}