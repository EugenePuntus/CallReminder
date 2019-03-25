using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;
using Uri = Android.Net.Uri;

namespace CallReminder.Droid.ValueConverters
{
    internal class StringToUriValueConverter : ValueConverter<string, Uri>
    {
        protected override ConversionResult<Uri> Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            var uri = Uri.Parse(value);

            return ConversionResult<Uri>.SetValue(uri);
        }
    }
}