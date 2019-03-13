using Android.Support.V7.Widget;
using Android.Views;
using CallReminder.Core.Presentation.ViewModels.Contacts;
using FlexiMvvm.Collections;

namespace CallReminder.Droid.Views.Contacts
{
    internal class ContactAdapter : RecyclerViewObservablePlainAdapterBase
    {
        public ContactAdapter(RecyclerView recyclerView, ContactViewModel itemsContext) : base(recyclerView)
        {
            ItemsContext = itemsContext;
        }

        protected override RecyclerViewObservableViewHolder OnCreateItemViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cell_contact_item, parent, false);

            return new ContactItemCellViewHolder(view);
        }
    }
}