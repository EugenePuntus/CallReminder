using System;
using System.Diagnostics;
using Android.App;
using Android.Support.Design.Widget;
using Android.Views;
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

        public void ShowNotification(object sender, string message)
        {
            var view = sender as View;
            Debug.WriteLine(message);

            if (view == null)
            {
                Toast.MakeText(Application.Context, message, ToastLength.Long);
                return;
            }

            Snackbar.Make(view, message,
                    Snackbar.LengthLong)
                .Show();
        }
    }
}