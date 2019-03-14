using System;
using System.Diagnostics;
using Android.Support.Design.Widget;
using Android.Views;
using CallReminder.Core.Infrastructure;

namespace CallReminder.Droid.Infrastructure
{
    internal class AndroidDialogService : IDialogService
    {
        public void ShowError(Exception error)
        {
            Debug.WriteLine(error.Message);
        }

        public void ShowNotification(object sender, string message)
        {
            var view = sender as View;

            if (view == null)
            {
                Debug.WriteLine(message);
                return;
            }

            Snackbar.Make(view, message,
                    Snackbar.LengthLong)
                .Show();
        }
    }
}