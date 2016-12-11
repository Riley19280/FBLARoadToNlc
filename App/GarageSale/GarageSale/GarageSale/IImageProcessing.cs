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
		Stream compressImage(Stream stream);

	}
}
