using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GarageSale.Views.Pages
{
	class itemPage : basePage
	{

		myDataTypes.item item;

		StackLayout baseStack;

		#region Views
		Label lblName = new Label
		{
			Text = "",
			VerticalOptions = LayoutOptions.StartAndExpand,
			HorizontalOptions = LayoutOptions.CenterAndExpand

		};

		Label lblDesc = new Label
		{
			Text = "",

			HorizontalOptions = LayoutOptions.CenterAndExpand
		};

		Label lblPrice = new Label
		{
			HorizontalOptions = LayoutOptions.CenterAndExpand,
			Text = ""
		};

		Label lblQuality = new Label
		{
			HorizontalOptions = LayoutOptions.CenterAndExpand,
			Text = ""
		};

		Image profImg = new Image
		{
			HorizontalOptions = LayoutOptions.FillAndExpand
		};

		Button viewComments = new Button
		{
			Text = "View Comments",
			BorderRadius = 0,
			//Margin = 0,
			HorizontalOptions = LayoutOptions.FillAndExpand,
		};
		#endregion

		public itemPage(myDataTypes.item i)
		{
			item = i;
			Title = i.name;

			#region basestack
			baseStack = new StackLayout
			{
				Children = {
					new StackLayout {
						VerticalOptions = LayoutOptions.FillAndExpand,
						HorizontalOptions = LayoutOptions.FillAndExpand,
						Children = {
							profImg,
							lblName,
							lblDesc,
							lblPrice,
							lblQuality,
							viewComments
						}
					}
				}
			};
			#endregion

			lblName.Text = i.name;
			lblDesc.Text = i.description;

			CultureInfo culture = new CultureInfo("en-us");
			culture.NumberFormat.CurrencyNegativePattern = 1;

			lblPrice.Text = string.Format(culture, "{0:c2}", item.price);

			profImg.Source = ImageSource.FromStream(()=>new MemoryStream(i.picture));

			//giving stars to rating
			string st = "";
			for (int j = 0; j < item.quality; j++)
			{
				st += "\u2605";
			}
			lblQuality.Text = st;
			Content = baseStack;

		}
	}

}

