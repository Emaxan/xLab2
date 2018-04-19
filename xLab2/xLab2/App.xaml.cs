using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace xLab2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var rl = new ResourceLoader(xLab2.Resources.Locale.ResourceManager);

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = new MainPage();
            else
                MainPage = new NavigationPage(new MainPage());
        }
    }
}