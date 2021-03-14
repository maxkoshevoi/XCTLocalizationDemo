using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;
using XCTLocalizationDemo.Resx;

namespace XCTLocalizationDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            LocalizationResourceManager.Current.PropertyChanged += (_, _) => AppResources.Culture = LocalizationResourceManager.Current.CurrentCulture;
            LocalizationResourceManager.Current.Init(AppResources.ResourceManager);

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
