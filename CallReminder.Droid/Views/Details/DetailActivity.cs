using System;
using Android.App;
using Android.Content;
using Android.OS;
using CallReminder.Core.Presentation.ViewModels.Contacts;
using CallReminder.Core.Presentation.ViewModels.Details;
using CallReminder.Core.ValueConverters;
using CallReminder.Droid.Bindings;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using FlexiMvvm.Views.V7;

namespace CallReminder.Droid.Views.Details
{
    [Activity(Label = "", Theme = "@style/AppTheme.NoActionBar")]
    public class DetailActivity : FlxBindableAppCompatActivity<DetailViewModel, ReminderDetailParameters>
    {
        private DetailActivityViewHolder ViewHolder { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_detail);

            ViewHolder = new DetailActivityViewHolder(this);
            ViewHolder.TimeReminder.ClickWeakSubscribe(TimeFromSelect_OnClick);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode != 1 || resultCode != Result.Ok)
            {
                return;
            }

            var parameters = data.GetViewModelParameters<ContactParameters>();

            ViewHolder.NameContact.EditText.Text = parameters?.Name;
            ViewHolder.PhoneContact.EditText.Text = parameters?.Phone;
        }

        public override void Bind(BindingSet<DetailViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(ViewHolder.BackButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.BackToHomeCommand);

            bindingSet.Bind(ViewHolder.PersonAdd)
                .For(v => v.ClickBinding())
                .To(vm => vm.ChangeContactCommand);

            bindingSet.Bind(ViewHolder.NameContact.EditText)
                .For(v => v.TextAndTextChangedBinding())
                .To(vm => vm.Name);

            bindingSet.Bind(ViewHolder.PhoneContact.EditText)
                .For(v => v.TextAndTextChangedBinding())
                .To(vm => vm.Phone);

            bindingSet.Bind(ViewHolder.NameContact)
                .For(v => v.ErrorBinding())
                .To(vm => vm.NameError);

            bindingSet.Bind(ViewHolder.PhoneContact)
                .For(v => v.ErrorBinding())
                .To(vm => vm.PhoneError);

            bindingSet.Bind(ViewHolder.TimeReminder)
                .For(v => v.TextBinding())
                .To(vm => vm.Time)
                .WithConvertion<TimeToTextValueConverter>()
                .TwoWay();

            bindingSet.Bind(ViewHolder.CalendarWeekDayViewHolder)
                .For(v => v.WeekdayCheckedAndCheckedChangedBinding())
                .To(vm => vm.DayOfWeeks);

            bindingSet.Bind(ViewHolder.SaveReminderButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.SaveReminderCommand);
        }

        private void TimeFromSelect_OnClick(object sender, EventArgs eventArgs)
        {
            var frag = TimePickerFragment.NewInstance(ViewModel.Time, time => ViewModel.Time = time);
            frag.Show(FragmentManager, string.Empty);
        }
    }
}