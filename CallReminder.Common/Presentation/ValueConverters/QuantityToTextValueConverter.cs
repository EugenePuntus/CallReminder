using System;
using System.Globalization;
using CallReminder.Core.Resourses;
using FlexiMvvm.ValueConverters;

namespace CallReminder.Core.Presentation.ValueConverters
{
    public class QuantityToTextValueConverter : ValueConverter<int, string>
    {
        protected override ConversionResult<string> Convert(int value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = value == 0 ? Strings.SelectFields : value.ToString();

            return ConversionResult<string>.SetValue(text);
        }
    }
}
