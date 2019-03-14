using Android.App;
using Android.OS;
using CallReminder.Core.Bootstrappers;
using CallReminder.Core.Presentation.ViewModels;
using CallReminder.Droid.Bootstraper;
using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;
using FlexiMvvm.Views.V7;
using Plugin.CurrentActivity;

namespace CallReminder.Droid.Views
{
    [Activity(Theme = "@style/AppTheme.SplashScreen",
        MainLauncher = true,
        NoHistory = true)]
    public class SplashScreenActivity : FlxAppCompatActivity<EntryViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            CrossCurrentActivity.Current.Init(this, savedInstanceState);

            var config = new BootstrapperConfig();
            config.SetSimpleIoc(new SimpleIoc());

            var compositeBootstrapper = new CompositeBootstrapper(
                new CoreBootstrapper(),
                new AndroidBootstrapper());

            compositeBootstrapper.Execute(config);

            base.OnCreate(savedInstanceState);
        }
    }
}