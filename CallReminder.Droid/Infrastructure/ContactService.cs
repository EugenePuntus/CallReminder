using System;
using System.Collections.Generic;
using Android.App;
using Android.Database;
using Android.Provider;
using Android.Support.V4.Content;
using CallReminder.Core.Domain;
using CallReminder.Core.Infrastructure;

namespace CallReminder.Droid.Infrastructure
{
    internal class ContactService : IContactService
    {
        private readonly ICursor _cursor;
        private readonly string[] _projections;

        public ContactService()
        {
            var uri = ContactsContract.CommonDataKinds.Phone.ContentUri;
            _projections = new []
            {
                ContactsContract.Contacts.InterfaceConsts.Id,
                ContactsContract.Contacts.InterfaceConsts.DisplayName,
                ContactsContract.Contacts.InterfaceConsts.PhotoId,
                ContactsContract.Contacts.InterfaceConsts.HasPhoneNumber,
                ContactsContract.CommonDataKinds.Phone.Number
            };

            var loader = new CursorLoader(Application.Context, uri, _projections, null, null, null);
            _cursor = (ICursor)loader.LoadInBackground();
        }

        public IEnumerable<ContactModel> GetContacts()
        {
            var contactList = new List<ContactModel>();

            if (!_cursor.MoveToFirst())
            {
                return contactList;
            }

            do
            {
                var hasPhoneNumber = _cursor.GetShort(_cursor.GetColumnIndex(_projections[3]));

                if (hasPhoneNumber == 1)
                {
                    contactList.Add(new ContactModel()
                    {
                        Id = _cursor.GetLong(_cursor.GetColumnIndex(_projections[0])),
                        Name = _cursor.GetString(_cursor.GetColumnIndex(_projections[1])),
                        PhotoId = _cursor.GetString(_cursor.GetColumnIndex(_projections[2])),
                        Phone = _cursor.GetString(_cursor.GetColumnIndex(_projections[4]))
                    });
                }
            } while (_cursor.MoveToNext());

            return contactList;
        }

        public ContactModel GetContactById(int id)
        {
            throw new NotImplementedException();
        }
    }
}