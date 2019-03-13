using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace CallReminder.Droid.Views.Details
{
    internal class TimePickerFragment : DialogFragment,
        TimePickerDialog.IOnTimeSetListener
    {
        private DateTime _currentDate;
        private Action<DateTime> _dateSelectedHandler;

        public static TimePickerFragment NewInstance(DateTime currentDate, Action<DateTime> onDateSelected)
        {
            TimePickerFragment frag = new TimePickerFragment
            {
                _currentDate = currentDate,
                _dateSelectedHandler = onDateSelected
            };
            return frag;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            DateTime currently = _currentDate;
            TimePickerDialog dialog = new TimePickerDialog(Activity,
                this,
                currently.Hour,
                currently.Minute,
                false);
            return dialog;
        }

        public void OnTimeSet(TimePicker view, int hourOfDay, int minute)
        {
            DateTime selectedDate = new DateTime(1990, 1, 1, hourOfDay, minute, 0);
            _dateSelectedHandler?.Invoke(selectedDate);
        }
    }
}
