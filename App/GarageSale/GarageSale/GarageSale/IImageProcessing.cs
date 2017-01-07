using Android.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSale
{
	public interface IImageProcessing
	{
		byte[] compress(Bitmap b);

		Task<Bitmap> ScaleBitmap(Stream stream, BitmapFactory.Options options, int reqWidth, int reqHeight);
		Task<Bitmap> ScaleBitmap(byte[] bytes, BitmapFactory.Options options, int reqWidth, int reqHeight);
		int CalculateInSampleSize(BitmapFactory.Options options, int reqWidth, int reqHeight);
		Task<BitmapFactory.Options> GetBitmapOptionsOfImageAsync(Stream stream);
		Task<BitmapFactory.Options> GetBitmapOptionsOfImageAsync(byte[] bytes);
	}
}
