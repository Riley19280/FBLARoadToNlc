using Android.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GarageSale.Views
{
	public class CustomImageView : Image
	{
		public static readonly BindableProperty BitmapProperty = BindableProperty.Create("bitmap", typeof(Bitmap), typeof(Bitmap));


		public CustomImageView() {

		}
		public int test;

		public void SetImageBitmap(Bitmap b)
		{
			SetValue(BitmapProperty, b);
		}
		}
}
