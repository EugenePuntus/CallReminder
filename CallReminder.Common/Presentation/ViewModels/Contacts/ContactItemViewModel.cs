using System.Diagnostics;
using CallReminder.Core.Domain;
using FlexiMvvm;

namespace CallReminder.Core.Presentation.ViewModels.Contacts
{
    public class ContactItemViewModel : ViewModelBase
    {
        private string _name;
        private string _phone;
        private string _photoUri;
        private long _photoFileId;

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

        public long PhotoFileId
        {
            get => _photoFileId;
            set => Set(ref _photoFileId, value);
        }

        public ContactItemViewModel(ContactModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Phone = model.Phone;
            PhotoUri = model.PhotoUri;
            PhotoFileId = model.PhotoFileId;

            Debug.WriteLine(PhotoUri);
            Debug.WriteLine(PhotoFileId);
        }
    }
}
