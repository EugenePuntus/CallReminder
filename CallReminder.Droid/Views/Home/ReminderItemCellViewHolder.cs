using Android.Views;
using CallReminder.Core.Presentation.ViewModels.Home;
using CallReminder.Core.ValueConverters;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;

// ReSharper disable once CheckNamespace
namespace CallReminder.Droid.Views
{
    public partial class ReminderItemCellViewHolder 
        : RecyclerViewBindableItemViewHolder<HomeViewModel, ReminderItemViewModel>,
          View.IOnLongClickListener
    {
        public ReminderItemCellViewHolder(View itemView) 
            : base(itemView)
        {

        }

        public override void Bind(BindingSet<ReminderItemViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(ReminderName)
                .For(v => v.TextBinding())
                .To(vm => vm.Name);

            bindingSet.Bind(ReminderTime)
                .For(v => v.TextBinding())
                .To(vm => vm.Time)
                .WithConvertion<TimeToTextValueConverter>();

            bindingSet.Bind(ReminderActive)
                .For(v => v.CheckedAndCheckedChangeBinding())
                .To(vm => vm.Repeat);
        }

        public bool OnLongClick(View v)
        {
            return true;
        }
    }
}