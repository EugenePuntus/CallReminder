using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using CallReminder.Core.Presentation.ViewModels.Home;
using CallReminder.Core.ValueConverters;
using CallReminder.Droid.Bindings;
using CallReminder.Droid.ValueConverters;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views.V7;

namespace CallReminder.Droid.Views.Home
{
    [Activity(Label = "HomeActivity", Theme = "@style/AppTheme.NoActionBar")]
    public class HomeActivity : FlxBindableAppCompatActivity<HomeViewModel>
    {
        private HomeActivityViewHolder ViewHolder { get; set; }

        private ReminderAdapter ReminderAdapter { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_home);

            ViewHolder = new HomeActivityViewHolder(this);

            ReminderAdapter = new ReminderAdapter(
                ViewHolder.ReminderRecyclerView,
                ViewModel)
            {
                Items = ViewModel.Reminders
            };

            ViewHolder.ReminderRecyclerView.SetAdapter(ReminderAdapter);
            ViewHolder.ReminderRecyclerView.SetLayoutManager(new LinearLayoutManager(this, 1, false));

            ViewHolder.SwipeRefresh.SetColorSchemeResources(Resource.Color.colorAccent);
        }

        public override void Bind(BindingSet<HomeViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(ViewHolder.MainToolbar)
                .For(v => v.Visibility)
                .To(vm => vm.RemoveState)
                .WithConvertion<BoolToVisibilityInverseValueConverter>();

            bindingSet.Bind(ViewHolder.RemoveToolbar)
                .For(v => v.Visibility)
                .To(vm => vm.RemoveState)
                .WithConvertion<BoolToVisibilityValueConverter>();

            bindingSet.Bind(ViewHolder.CheckedAll)
                .For(v => v.TextBinding())
                .To(vm => vm.QuantityToRemove)
                .WithConvertion<QuantityToTextValueConverter>();

            bindingSet.Bind(ViewHolder.CheckedAll)
                .For(v => v.CheckedAndCheckedChangeBinding())
                .To(vm => vm.CheckedOrUncheckedAllCommand);

            bindingSet.Bind(ViewHolder.RemoveButton)
                .For(v => v.Visibility)
                .To(vm => vm.QuantityToRemove)
                .WithConvertion<QuantityToVisibleValueConverter>();

            bindingSet.Bind(ViewHolder.RemoveButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.RemoveCommand);

            bindingSet.Bind(ReminderAdapter)
                .For(v => v.ItemClickedBinding())
                .To(vm => vm.ReminderSelectedCommand);

            bindingSet.Bind(ViewHolder.AddNewReminder)
                .For(v => v.ClickBinding())
                .To(vm => vm.ReminderSelectedCommand);

            bindingSet.Bind(ViewHolder.SwipeRefresh)
                .For(v => v.BeginRefreshingBinding())
                .To(vm => vm.Loading);

            bindingSet.Bind(ViewHolder.SwipeRefresh)
                .For(v => v.EndRefreshingBinding())
                .To(vm => vm.Loading);

            bindingSet.Bind(ViewHolder.SwipeRefresh)
                .For(v => v.ValueChangedBinding())
                .To(vm => vm.RefreshCommand);
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            if (ViewModel.RemoveState)
            {
                ViewModel.RemoveState = false;
                return false;
            }

            return base.OnKeyDown(keyCode, e);
        }
    }
}