using FlexiMvvm;

namespace CallReminder.Core.Presentation.ViewModels.Notifications
{
    public class NotificationParameters : ViewModelBundleBase
    {
        public string Name
        {
            get => Bundle.GetString(key: nameof(Name));
            set => Bundle.SetString(value, nameof(Name));
        }

        public string Phone
        {
            get => Bundle.GetString(key: nameof(Phone));
            set => Bundle.SetString(value, nameof(Phone));
        }
    }
}
