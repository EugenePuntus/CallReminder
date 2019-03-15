using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;

namespace CallReminder.Core.ValueConverters
{
    public class IntToTextValueConverter : ValueConverter<int, string>
    {
        protected override ConversionResult<string> Convert(int value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<string>.SetValue(value.ToString());
        }

        protected override ConversionResult<int> ConvertBack(string value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return ConversionResult<int>.SetValue(int.Parse(value));
        }
    }
}
