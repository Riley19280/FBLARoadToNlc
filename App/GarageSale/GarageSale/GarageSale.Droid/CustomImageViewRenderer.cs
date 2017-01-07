using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using GarageSale.Droid;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(GarageSale.Views.CustomImageView), typeof(GarageSale.Droid.CustomImageViewRenderer))]

namespace GarageSale.Droid
{
	public class CustomImageViewRenderer : ImageRenderer
	{
		ImageView v;
		protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged(e);
			v = new ImageView(Context);
			SetNativeControl(v);
		
		}
		

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			var name = e.PropertyName;
			if (e.PropertyName == "bitmap")
				SetImageBitmap((Bitmap)(Element as Views.CustomImageView).GetValue(GarageSale.Views.CustomImageView.BitmapProperty));

		}

		public void SetImageBitmap(Bitmap b) {
			
			v.SetImageBitmap(b);
		}

	}
}
