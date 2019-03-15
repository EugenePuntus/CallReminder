using System;
using System.Globalization;
using Android.Views;
using FlexiMvvm.ValueConverters;

namespace CallReminder.Droid.ValueConverters
{
    internal class BoolToVisibilityInverseValueConverter : ValueConverter<bool, ViewStates>
    {
        protected override ConversionResult<ViewStates> Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            var viewState = value ? ViewStates.Gone : ViewStates.Visible;

            return ConversionResult<ViewStates>.SetValue(viewState);
        }
    }
}