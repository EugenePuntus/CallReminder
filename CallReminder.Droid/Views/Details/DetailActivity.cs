using Android.App;
using Android.OS;
using CallReminder.Core.Presentation.ViewModels.Details;
using FlexiMvvm.Bindings;
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

            SetSupportActionBar(ViewHolder.ActionToolbar);
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
        }
    }
}