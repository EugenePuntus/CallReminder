using Android.App;
using Android.Content;
using Android.Widget;
using CallReminder.Core.Domain;
using CallReminder.Core.Infrastructure;
using CallReminder.Core.Presentation.ViewModels.Notifications;
using CallReminder.Droid.Services;
using FlexiMvvm.Views;

namespace CallReminder.Droid.Infrastructure
{
    internal class AlarmService : IAlarmService
    {
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

            Intent alarmIntent = new Intent(context, typeof(ReminderReceiver));
            alarmIntent.PutViewModelParameters(
                new NotificationParameters()
                {
                    Phone = reminderModel.Phone,
                    Name = reminderModel.Name
                });

            var pendingIntent = PendingIntent.GetBroadcast(context, reminderModel.Id.GetHashCode(), alarmIntent, PendingIntentFlags.UpdateCurrent);

            AlarmManager manager = (AlarmManager)context.GetSystemService(Context.AlarmService);
            int interval = 86400000;

            Java.Util.Calendar cal = Java.Util.Calendar.Instance;
            cal.TimeInMillis = Java.Lang.JavaSystem.CurrentTimeMillis();
            cal.Set(Java.Util.CalendarField.HourOfDay, reminderModel.Time.Hour);
            cal.Set(Java.Util.CalendarField.Minute, reminderModel.Time.Minute);
            cal.Set(Java.Util.CalendarField.Second, 0);

            manager.SetRepeating(AlarmType.RtcWakeup, cal.TimeInMillis, interval, pendingIntent);
            Toast.MakeText(context, $"Reminder set: {reminderModel.Name}", ToastLength.Short).Show();
        }

        public void Cancel(ReminderModel reminderModel)
        {
            var context = Application.Context;

            Intent alarmIntent = new Intent(context, typeof(ReminderReceiver));
            var pendingIntent = PendingIntent.GetBroadcast(context, reminderModel.Id.GetHashCode(), alarmIntent, 0);

            AlarmManager manager = (AlarmManager)context.GetSystemService(Context.AlarmService);
            manager.Cancel(pendingIntent);
            Toast.MakeText(context, "Alarm Canceled", ToastLength.Short).Show();
        }
    }
}