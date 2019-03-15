using System;
using System.Globalization;
using Android.Views;
using FlexiMvvm.ValueConverters;

namespace CallReminder.Droid.ValueConverters
{
    internal class QuantityToVisibleValueConverter : ValueConverter<int, ViewStates>
    {
        protected override ConversionResult<ViewStates> Convert(int value, Type targetType, object parameter, CultureInfo culture)
        {
            var viewState = value > 0 ? ViewStates.Visible : ViewStates.Gone;

            return ConversionResult<ViewStates>.SetValue(viewState);
        }
    }
}