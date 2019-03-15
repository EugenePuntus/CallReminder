using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using CallReminder.Core.Presentation.ViewModels.Contacts;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views.V7;

namespace CallReminder.Droid.Views.Contacts
{
    [Activity(Label = "", Theme = "@style/AppTheme.NoActionBar")]
    internal class ContactActivity : FlxBindableAppCompatActivity<ContactViewModel>
    {
        private ContactActivityViewHolder ViewHolder { get; set; }

        private ContactAdapter ContactAdapter { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_contact);

            ViewHolder = new ContactActivityViewHolder(this);

            ContactAdapter = new ContactAdapter(ViewHolder.ContactRecyclerView, ViewModel)
            {
                Items = ViewModel.Contacts
            };

            ViewHolder.ContactRecyclerView.SetAdapter(ContactAdapter);
            ViewHolder.ContactRecyclerView.SetLayoutManager(new LinearLayoutManager(this, 1, false));
        }

        public override void Bind(BindingSet<ContactViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(ViewHolder.BackButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.BackToDetailCommand);

            bindingSet.Bind(ViewHolder.ApplyButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.ApplyContactCommand);

            bindingSet.Bind(ContactAdapter)
                .For(v => v.ItemClickedBinding())
                .To(vm => vm.ChangeContactCommand);
        }
    }
}