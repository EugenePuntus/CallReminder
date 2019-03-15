using Android.Support.V7.Widget;
using Android.Views;
using CallReminder.Core.Presentation.ViewModels.Home;
using FlexiMvvm.Collections;

namespace CallReminder.Droid.Views.Home
{
    internal class ReminderAdapter : RecyclerViewObservablePlainAdapterBase
    {
        public ReminderAdapter(RecyclerView recyclerView, HomeViewModel itemsContext) : base(recyclerView)
        {
            ItemsContext = itemsContext;
        }

        protected override RecyclerViewObservableViewHolder OnCreateItemViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cell_reminder_item, parent, false);
            var item = new ReminderItemCellViewHolder(view);

            view.SetOnLongClickListener(item);

            return item;
        }

        protected override RecyclerViewObservableViewHolder OnCreateHeaderViewHolder(ViewGroup parent)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cell_reminder_header, parent, false);

            return new ReminderHeaderCellViewHolder(view);
        }
    }
}