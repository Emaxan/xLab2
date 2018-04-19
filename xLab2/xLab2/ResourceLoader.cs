using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using Xamarin.Forms;

namespace xLab2
{
    public class ResourceLoader
    {

        public ResourceLoader(ResourceManager resourceManager)
        {
            
            this.manager = resourceManager;
            Instance = this;
            this.cultureInfo = new CultureInfo((string)Application.Current.Resources["Localization"]);
        }

        private readonly ResourceManager manager;
        private CultureInfo cultureInfo;

        private readonly List<StringResource> resources = new List<StringResource>();

        public static ResourceLoader Instance { get; private set; }

        public StringResource this[string key]
        {
            get { return this.GetString(key); }
        }

        public StringResource GetString(string resourceName)
        {
            string stringRes = this.manager.GetString(resourceName, this.cultureInfo);
            var stringResource = new StringResource(resourceName, stringRes);
            this.resources.Add(stringResource);
            return stringResource;
        }

        public void SetCultureInfo(CultureInfo cultureInfo)
        {
            Application.Current.Resources["Localization"] = cultureInfo.Name;
            this.cultureInfo = cultureInfo;
            foreach (StringResource stringResource in this.resources)
            {
                stringResource.Value = this.manager.GetString(stringResource.Key, cultureInfo);
            }
        }

    }
}