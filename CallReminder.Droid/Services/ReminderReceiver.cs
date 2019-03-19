using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using CallReminder.Core.Presentation.ViewModels.Notifications;
using CallReminder.Droid.Views.Notifications;
using FlexiMvvm.Views;

namespace CallReminder.Droid.Services
{
    [BroadcastReceiver]
    internal class ReminderReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            CreateNotificationChannel();

            var parameters = intent.GetViewModelParameters<NotificationParameters>();

            if (parameters == null)
            {
                return;
            }

            var resultIntent = new Intent(context, typeof(NotificationActivity));
            resultIntent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            resultIntent.PutViewModelParameters(parameters);

            var pending = PendingIntent.GetActivity(context, 0,
                resultIntent,
                PendingIntentFlags.CancelCurrent);
            
            var builder = new NotificationCompat.Builder(context, "CHANNEL_ID_MY")
                .SetAutoCancel(true)
                .SetContentTitle("Reminder call to")
                .SetSmallIcon(Resource.Drawable.notifications_active)
                .SetContentText(parameters.Name);

            builder.SetContentIntent(pending);
            builder.AddAction(Resource.Drawable.abc_ic_clear_material, "Cancel", pending);
            builder.AddAction(Resource.Drawable.baseline_call, "Call", pending);

            var notification = builder.Build();

            const int notificationId = 0;
            var manager = NotificationManager.FromContext(context);
            manager.Notify(notificationId, notification);
        }

        private void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                return;
            }

            var channelName = "test_chanel";
            var channelDescription = "test_chanel_description";
            var channel = new NotificationChannel("CHANNEL_ID_MY", channelName, NotificationImportance.Default)
            {
                Description = channelDescription
            };

            var notificationManager = (NotificationManager)Application.Context.GetSystemService(Context.NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }
    }
}