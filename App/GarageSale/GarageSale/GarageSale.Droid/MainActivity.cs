using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services;

namespace GarageSale.Droid
{
	[Activity(Label = "FBLA_Garage_Sale", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		bool resolved = false;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			#region Resolver Init
			if (!resolved)
			{
				SimpleContainer container = new SimpleContainer();
				container.Register<IDevice>(t => AndroidDevice.CurrentDevice);
				container.Register<IDisplay>(t => t.Resolve<IDevice>().Display);
				container.Register<INetwork>(t => t.Resolve<IDevice>().Network);

				Resolver.SetResolver(container.GetResolver());
				resolved = true;

			}
			#endregion
			global::Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication(new App());
		}
	}
}

