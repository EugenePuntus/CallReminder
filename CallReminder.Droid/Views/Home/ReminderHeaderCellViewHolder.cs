using Android.Views;
using CallReminder.Core.Presentation.ViewModels.Home;
using FlexiMvvm.Collections;

// ReSharper disable once CheckNamespace
namespace CallReminder.Droid.Views
{
    public partial class ReminderHeaderCellViewHolder
        : RecyclerViewBindableHeaderFooterViewHolder<HomeViewModel>
    {
        public ReminderHeaderCellViewHolder(View itemView)
            : base(itemView)
        {

        }
    }
}