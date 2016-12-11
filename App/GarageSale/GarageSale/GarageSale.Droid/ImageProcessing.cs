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
using Android.Graphics;
using System.IO;

namespace GarageSale.Droid
{
	class ImageProcessing : IImageProcessing
	{
		public Stream compressImage(Stream stream)
		{
			try
			{
				using (stream)
				{
					Bitmap bitmap = BitmapFactory.DecodeStream(stream);

					Stream outStream = new FileStream(System.IO.Path.GetTempPath(), FileMode.OpenOrCreate);

					bitmap.Compress(Bitmap.CompressFormat.Jpeg, 30, outStream);
					return outStream;
				}
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("ERROR: \n{0}\n{1}", e.InnerException, e.StackTrace);
			}
			return null;
		}
	}
}