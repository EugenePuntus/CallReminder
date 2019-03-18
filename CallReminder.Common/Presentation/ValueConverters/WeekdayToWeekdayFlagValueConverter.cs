using System;
using System.Collections.Generic;
using System.Globalization;
using FlexiMvvm.ValueConverters;

namespace CallReminder.Core.Presentation.ValueConverters
{
    [Flags]
    public enum DayOfWeeksFlags
    {
        None = 1,
        Sunday = 2,
        Monday = 4,
        Tuesday = 8,
        Wednesday = 16,
        Thursday = 32,
        Friday = 64,
        Saturday = 128
    }

    public class WeekdayToWeekdayFlagValueConverter : ValueConverter<IEnumerable<DayOfWeek>, DayOfWeeksFlags>
    {
        protected override ConversionResult<DayOfWeeksFlags> Convert(IEnumerable<DayOfWeek> value, Type targetType, object parameter, CultureInfo culture)
        {
            DayOfWeeksFlags dayOfWeekFlags = DayOfWeeksFlags.None;

            if (value == null)
            {
                return ConversionResult<DayOfWeeksFlags>.SetValue(dayOfWeekFlags);
            }

            foreach (var dayOfWeek in value)
            {
                switch (dayOfWeek)
                {
                    case DayOfWeek.Monday:
                        dayOfWeekFlags = dayOfWeekFlags | DayOfWeeksFlags.Monday;
                        break;

                    case DayOfWeek.Thursday:
                        dayOfWeekFlags = dayOfWeekFlags | DayOfWeeksFlags.Thursday;
                        break;

                    case DayOfWeek.Tuesday:
                        dayOfWeekFlags = dayOfWeekFlags | DayOfWeeksFlags.Tuesday;
                        break;

                    case DayOfWeek.Wednesday:
                        dayOfWeekFlags = dayOfWeekFlags | DayOfWeeksFlags.Wednesday;
                        break;

                    case DayOfWeek.Friday:
                        dayOfWeekFlags = dayOfWeekFlags | DayOfWeeksFlags.Friday;
                        break;

                    case DayOfWeek.Sunday:
                        dayOfWeekFlags = dayOfWeekFlags | DayOfWeeksFlags.Sunday;
                        break;

                    case DayOfWeek.Saturday:
                        dayOfWeekFlags = dayOfWeekFlags | DayOfWeeksFlags.Saturday;
                        break;
                }
            }

            return ConversionResult<DayOfWeeksFlags>.SetValue(dayOfWeekFlags);
        }

        protected override ConversionResult<IEnumerable<DayOfWeek>> ConvertBack(DayOfWeeksFlags value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = new List<DayOfWeek>();

            if(value.HasFlag(DayOfWeeksFlags.Monday))
            {
                list.Add(DayOfWeek.Monday);
            }

            if (value.HasFlag(DayOfWeeksFlags.Tuesday))
            {
                list.Add(DayOfWeek.Tuesday);
            }

            if (value.HasFlag(DayOfWeeksFlags.Wednesday))
            {
                list.Add(DayOfWeek.Wednesday);
            }

            if (value.HasFlag(DayOfWeeksFlags.Thursday))
            {
                list.Add(DayOfWeek.Thursday);
            }

            if (value.HasFlag(DayOfWeeksFlags.Friday))
            {
                list.Add(DayOfWeek.Friday);
            }

            if (value.HasFlag(DayOfWeeksFlags.Saturday))
            {
                list.Add(DayOfWeek.Saturday);
            }

            if (value.HasFlag(DayOfWeeksFlags.Sunday))
            {
                list.Add(DayOfWeek.Sunday);
            }

            return ConversionResult<IEnumerable<DayOfWeek>>.SetValue(list);
        }
    }
}
