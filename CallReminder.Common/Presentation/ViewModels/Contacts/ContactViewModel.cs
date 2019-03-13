using System.Linq;
using System.Windows.Input;
using CallReminder.Core.Infrastructure;
using CallReminder.Core.Navigation;
using FlexiMvvm;
using FlexiMvvm.Collections;

namespace CallReminder.Core.Presentation.ViewModels.Contacts
{
    public class ContactViewModel : ViewModelBase, IViewModelWithOperation
    {
        private readonly INavigationService _navigationService;
        private readonly IContactService _contactService;
        private bool _login;

        public bool Loading
        {
            get => _login;
            set => Set(ref _login, value);
        }

        public RangeObservableCollection<ContactItemViewModel> Contacts = new RangeObservableCollection<ContactItemViewModel>();

        public ICommand BackToDetailCommand => CommandProvider.Get(BackToDetail);

        public ICommand ApplyContactCommand => CommandProvider.Get(ApplyContact);

        public ContactViewModel(INavigationService navigationService, IContactService contactService)
        {
            _navigationService = navigationService;
            _contactService = contactService;
        }

        protected override void Initialize()
        {
            base.Initialize();

            Contacts.AddRange(_contactService.GetContacts().Select(model => new ContactItemViewModel(model)));
        }

        private void BackToDetail()
        {
            _navigationService.NavigateBackToDetail(this);
        }

        private void ApplyContact()
        {
            //TODO apply contact

            _navigationService.NavigateBackToDetail(this);
        }
    }
}
