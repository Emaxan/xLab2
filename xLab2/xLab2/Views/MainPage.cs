using System;
using xLab2.Views;
using Xamarin.Forms;

namespace xLab2
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page citiesPage, mapPage, settingsPage = null;
            Binding citiesBinding, mapBinding, settingsBinding;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    citiesPage = new NavigationPage(new Views.MasterDetailPage());
                    citiesBinding = new Binding() { Source = ResourceLoader.Instance, Path = "[Cities].Value"};
                    citiesPage.SetBinding(NavigationPage.TitleProperty, citiesBinding);

                    mapPage = new NavigationPage(new AboutPage());
                    mapBinding = new Binding() { Source = ResourceLoader.Instance, Path = "[Map].Value" };
                    mapPage.SetBinding(NavigationPage.TitleProperty, mapBinding);

                    settingsPage = new NavigationPage(new SettingsPage());
                    settingsBinding = new Binding() { Source = ResourceLoader.Instance, Path = "[Settings].Value" };
                    settingsPage.SetBinding(NavigationPage.TitleProperty, settingsBinding);
                    citiesPage.Icon = "tab_feed.png";
                    mapPage.Icon = "tab_about.png";
                    settingsPage.Icon = "tab_about.png";
                    break;
                default:
                    citiesPage = new Views.MasterDetailPage();
                    citiesBinding = new Binding() { Source = ResourceLoader.Instance, Path = "[Cities].Value" };
                    citiesPage.SetBinding(Views.MasterDetailPage.TitleProperty, citiesBinding);

                    mapPage = new AboutPage();
                    mapBinding = new Binding() { Source = ResourceLoader.Instance, Path = "[Map].Value" };
                    mapPage.SetBinding(AboutPage.TitleProperty, mapBinding);

                    settingsPage = new SettingsPage();
                    settingsBinding = new Binding() { Source = ResourceLoader.Instance, Path = "[Settings].Value" };
                    settingsPage.SetBinding(SettingsPage.TitleProperty, settingsBinding);
                    break;
            }

            Children.Add(citiesPage);
            Children.Add(mapPage);
            Children.Add(settingsPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
