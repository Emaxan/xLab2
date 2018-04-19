using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xLab2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        private const double MinTextSize = 10;

        public SettingsPage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            TextSizeSlider.Value = (double)Application.Current.Resources["FontSize"] - MinTextSize;
            base.OnAppearing();
        }

        private void Slider_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            Application.Current.Resources["FontSize"] = Math.Round(e.NewValue) + MinTextSize;
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Application.Current.Resources["FontColor"] = ((Button)sender).BackgroundColor;
        }

        private void RuButton_OnClicked(object sender, EventArgs e)
        {
            ResourceLoader.Instance.SetCultureInfo(new CultureInfo("ru-RU"));
        }


        private void EnButton_OnClicked(object sender, EventArgs e)
        {
            ResourceLoader.Instance.SetCultureInfo(new CultureInfo("en-US"));
        }
    }
}