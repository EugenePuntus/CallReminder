using System;
using FlexiMvvm;

namespace CallReminder.Core.Presentation.ViewModels.Details
{
    public class ReminderDetailParameters : ViewModelBundleBase
    {
        public Guid Id
        {
            get => Guid.Parse(Bundle.GetString(key: nameof(Id)) ?? throw new InvalidOperationException());
            set => Bundle.SetString(value.ToString(), nameof(Id));
        }
    }
}
