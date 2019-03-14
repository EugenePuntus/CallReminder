using System;
using Android.Support.Design.Widget;
using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace CallReminder.Droid.Bindings
{
    public static class CustomEditTextBindings
    {
        public static TargetItemBinding<TextInputLayout, string> ErrorBinding(
            [NotNull] this IItemReference<TextInputLayout> weekDayFragmentReference)
        {
            if (weekDayFragmentReference == null)
            {
                throw new ArgumentNullException(nameof(weekDayFragmentReference));
            }

            return new TargetItemOneWayCustomBinding<TextInputLayout, string>(
                weekDayFragmentReference,
                (editText, text) => editText.NotNull().Error = text,
                () => "SetError");
        }
    }
}