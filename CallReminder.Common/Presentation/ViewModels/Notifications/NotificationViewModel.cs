using System.Windows.Input;
using FlexiMvvm;
using Xamarin.Essentials;

namespace CallReminder.Core.Presentation.ViewModels.Notifications
{
    public class NotificationViewModel : ViewModelBase<NotificationParameters>
    {
        private string _name;
        private string _phone;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string Phone
        {
            get => _phone;
            set => Set(ref _phone, value);
        }

        public ICommand MoveToCallCommand => CommandProvider.Get(MoveToCall);

        protected override void Initialize(NotificationParameters parameters)
        {
            base.Initialize(parameters);

            if (parameters == null)
            {
                return;
            }
            
            Name = parameters.Name;
            Phone = parameters.Phone;
        }

        private void MoveToCall()
        {
            PhoneDialer.Open(Phone);
        }
    }
}
