using System;
using System.Diagnostics;
using Android.App;
using Android.Widget;
using CallReminder.Core.Infrastructure;

namespace CallReminder.Droid.Infrastructure
{
    internal class AndroidDialogService : IDialogService
    {
        public void ShowError(Exception error)
        {
            Debug.WriteLine(error.Message);
        }

        public void ShowNotification(string message)
        {
            Debug.WriteLine(message);

            Toast.MakeText(Application.Context, message, ToastLength.Long)
                .Show();
        }
    }
}