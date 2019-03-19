using System;
using System.Globalization;
using Android.Content;
using Android.Provider;
using FlexiMvvm.ValueConverters;
using Uri = Android.Net.Uri;

namespace CallReminder.Droid.ValueConverters
{

    internal class PhotoFileIdToUriValueConverter : ValueConverter<long, Uri>
    {
        protected override ConversionResult<Uri> Convert(long value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == 0)
            {
                return null;
            }

            var contactUri = ContentUris.WithAppendedId(ContactsContract.DisplayPhoto.ContentUri, value);

            return ConversionResult<Uri>.SetValue(contactUri);
        }
    }

    internal class StringToUriValueConverter : ValueConverter<string, Uri>
    {
        protected override ConversionResult<Uri> Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            var uri = Uri.Parse(value);

            return ConversionResult<Uri>.SetValue(uri);
        }
    }
}