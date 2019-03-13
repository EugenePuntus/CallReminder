using System;
using System.Collections.Generic;
using System.Globalization;
using FlexiMvvm.ValueConverters;

namespace CallReminder.Core.ValueConverters
{
    public class WeekdayToWeekdayValueConverter : ValueConverter<IEnumerable<DayOfWeek>, IEnumerable<DayOfWeek>>
    {
        protected override ConversionResult<IEnumerable<DayOfWeek>> Convert(IEnumerable<DayOfWeek> value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<IEnumerable<DayOfWeek>>.SetValue(value);
        }

        protected override ConversionResult<IEnumerable<DayOfWeek>> ConvertBack(IEnumerable<DayOfWeek> value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<IEnumerable<DayOfWeek>>.SetValue(value);
        }
    }
}
