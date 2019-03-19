using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using CallReminder.Core.Presentation.ViewModels.Notifications;
using CallReminder.Droid.Views.Notifications;
using CallReminder.Core.Resourses;
using FlexiMvvm.Views;

namespace CallReminder.Droid.Services
{
    [BroadcastReceiver]
    internal class ReminderReceiver : BroadcastReceiver
    {
        private string ChannelId { get; } = "CHANNEL_REMINDER";

        private string ChannelName { get; } = "channel_reminder";

        private string ChannelDescription { get; } = "channel by notification reminder";

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

            var builder = new NotificationCompat.Builder(context, ChannelId)
                .SetAutoCancel(true)
                .SetContentTitle(Strings.ReminderCallTo)
                .SetSmallIcon(Resource.Drawable.notifications_active)
                .SetContentText(parameters.Name)
                .AddAction(Resource.Drawable.abc_ic_clear_material, Strings.CancelActionNotification, pending)
                .AddAction(Resource.Drawable.baseline_call, Strings.CallActionNotification, pending)
                .SetContentIntent(pending);

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

            var channel = new NotificationChannel(ChannelId, ChannelName, NotificationImportance.Default)
            {
                Description = ChannelDescription
            };

            var notificationManager = (NotificationManager)Application.Context.GetSystemService(Context.NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }
    }
}