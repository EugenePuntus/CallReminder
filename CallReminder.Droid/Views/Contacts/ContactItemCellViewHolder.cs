using Android.Views;
using CallReminder.Core.Presentation.ViewModels.Contacts;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;

// ReSharper disable once CheckNamespace
namespace CallReminder.Droid.Views
{
    public partial class ContactItemCellViewHolder : RecyclerViewBindableItemViewHolder<ContactViewModel, ContactItemViewModel>
    {
        public ContactItemCellViewHolder(View itemView)
            : base(itemView)
        {

        }

        public override void Bind(BindingSet<ContactItemViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(ContactName)
                .For(v => v.TextBinding())
                .To(vm => vm.Name);

            bindingSet.Bind(ContactPhone)
                .For(v => v.TextBinding())
                .To(vm => vm.Phone);
        }
    }
}