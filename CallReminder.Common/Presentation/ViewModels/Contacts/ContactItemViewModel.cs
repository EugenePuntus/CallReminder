using CallReminder.Core.Domain;
using FlexiMvvm;

namespace CallReminder.Core.Presentation.ViewModels.Contacts
{
    public class ContactItemViewModel : ViewModelBase
    {
        private string _name;
        private string _phone;
        private string _photoUri;

        public long Id { get; }

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

        public string PhotoUri
        {
            get => _photoUri;
            set => Set(ref _photoUri, value);
        }

        public ContactItemViewModel(ContactModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Phone = model.Phone;
            PhotoUri = model.PhotoUri;
        }
    }
}
