using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GarageSale
{
	public class Constants
	{

		public static string WCFURL = "http://192.168.1.101:9618/YardSaleService.svc";
		//public static string WCFURL = "http://ec2-54-175-167-4.compute-1.amazonaws.com:9617/YardSaleService.svc";


		public static class palette
		{
			public static Color primary = Color.FromHex("#5974FF");
			public static Color primary_variant = Color.FromHex("#3A5BFF");
			public static Color primary_dark = Color.FromHex("#303F9F");
			public static Color primary_light = Color.FromHex("#C5CAE9");
			public static Color accent = Color.FromHex("#4CAF50");
			public static Color primary_text = Color.FromHex("#0A0A0A");
			public static Color secondary_text = Color.FromHex("#727272");
			public static Color icons = Color.FromHex("#FFFFFF");
			public static Color divider = Color.FromHex("#B6B6B6");
		}
	}
}
