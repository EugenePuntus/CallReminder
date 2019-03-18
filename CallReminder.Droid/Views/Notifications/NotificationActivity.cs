using Android.App;
using Android.OS;
using CallReminder.Core.Presentation.ViewModels.Notifications;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views.V7;

namespace CallReminder.Droid.Views.Notifications
{
    [Activity(Label = "NotificationActivity")]
    public class NotificationActivity : FlxBindableAppCompatActivity<NotificationViewModel, NotificationParameters>
    {
        private NotificationActivityViewHolder ViewHolder { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_notification);

            ViewHolder = new NotificationActivityViewHolder(this);
        }

        public override void Bind(BindingSet<NotificationViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(ViewHolder.NameTextView)
                .For(v => v.TextBinding())
                .To(vm => vm.Name);

            bindingSet.Bind(ViewHolder.PhoneTextView)
                .For(v => v.TextBinding())
                .To(vm => vm.Phone);

            bindingSet.Bind(ViewHolder.CallByPhoneButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.MoveToCallCommand);
        }
    }
}