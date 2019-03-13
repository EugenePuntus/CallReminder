using CallReminder.Core.Domain;
using FlexiMvvm;

namespace CallReminder.Core.Presentation.ViewModels.Contacts
{
    public class ContactItemViewModel : ViewModelBase
    {
        private string _name;
        private string _phone;
        private string _photoId;

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

        public string PhotoId
        {
            get => _photoId;
            set => Set(ref _photoId, value);
        }

        public ContactItemViewModel(ContactModel model)
        {
            Name = model.Name;
            Phone = model.Phone;
            PhotoId = model.PhotoId;
        }
    }
}
