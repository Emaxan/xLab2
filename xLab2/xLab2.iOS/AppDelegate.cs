﻿
using Foundation;
using UIKit;

namespace xLab2.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
		    Xamarin.FormsMaps.Init();
            LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}
