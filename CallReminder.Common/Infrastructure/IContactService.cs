using System.Collections.Generic;
using CallReminder.Core.Domain;

namespace CallReminder.Core.Infrastructure
{
    public interface IContactService
    {
        IEnumerable<ContactModel> GetContacts();

        ContactModel GetContactById(int id);
    }
}
