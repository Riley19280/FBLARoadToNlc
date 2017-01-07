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
using GarageSale;
using GarageSale.Droid;
using Java.Nio;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(ImageProcessing))]
namespace GarageSale.Droid
{
	class ImageProcessing : IImageProcessing
	{


		public byte[] compress(Bitmap b)
		{
			MemoryStream ms = new MemoryStream();
			b.Compress(Bitmap.CompressFormat.Jpeg, 80, ms);
			byte[] bytes = ms.ToArray();
			ms.Dispose();

			return bytes;
		}


		public async Task<BitmapFactory.Options> GetBitmapOptionsOfImageAsync(Stream stream)
		{
			BitmapFactory.Options options = new BitmapFactory.Options
			{
				InJustDecodeBounds = true
			};

			// The result will be null because InJustDecodeBounds == true.
			Bitmap result = await BitmapFactory.DecodeStreamAsync(stream, new Rect(), options);

			int imageHeight = options.OutHeight;
			int imageWidth = options.OutWidth;

			return options;
		}

		public async Task<BitmapFactory.Options> GetBitmapOptionsOfImageAsync(byte[] bytes)
		{
			BitmapFactory.Options options = new BitmapFactory.Options
			{
				InJustDecodeBounds = true
			};

			// The result will be null because InJustDecodeBounds == true.
			Bitmap result = await BitmapFactory.DecodeByteArrayAsync(bytes,0, bytes.Length, options);

			int imageHeight = options.OutHeight;
			int imageWidth = options.OutWidth;

			return options;
		}


		public int CalculateInSampleSize(BitmapFactory.Options options, int reqWidth, int reqHeight)
		{
			// Raw height and width of image
			float height = options.OutHeight;
			float width = options.OutWidth;
			double inSampleSize = 1D;

			if (height > reqHeight || width > reqWidth)
			{
				int halfHeight = (int)(height / 2);
				int halfWidth = (int)(width / 2);

				// Calculate a inSampleSize that is a power of 2 - the decoder will use a value that is a power of two anyway.
				while ((halfHeight / inSampleSize) > reqHeight && (halfWidth / inSampleSize) > reqWidth)
				{
					inSampleSize *= 2;
				}
			}

			return (int)inSampleSize;
		}

		public async Task<Bitmap> ScaleBitmap(Stream stream, BitmapFactory.Options options, int reqWidth, int reqHeight)
		{
			// Calculate inSampleSize
			options.InSampleSize = CalculateInSampleSize(options, reqWidth, reqHeight);

			// Decode bitmap with inSampleSize set
			options.InJustDecodeBounds = false;

			return await BitmapFactory.DecodeStreamAsync(stream, new Rect(), options);
		}

		public async Task<Bitmap> ScaleBitmap(byte[] bytes, BitmapFactory.Options options, int reqWidth, int reqHeight)
		{
			// Calculate inSampleSize
			options.InSampleSize = CalculateInSampleSize(options, reqWidth, reqHeight);

			// Decode bitmap with inSampleSize set
			options.InJustDecodeBounds = false;

			return await BitmapFactory.DecodeByteArrayAsync(bytes, 0,bytes.Length, options);
		}


	}
}