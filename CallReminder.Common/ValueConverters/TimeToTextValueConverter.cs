using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;

namespace CallReminder.Core.ValueConverters
{
    public class TimeToTextValueConverter : ValueConverter<DateTime, string>
    {
        protected override ConversionResult<string> Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = value.ToShortTimeString();

            return ConversionResult<string>.SetValue(result);
        }
    }
}
