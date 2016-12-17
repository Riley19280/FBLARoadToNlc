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

		Label lblDesc = new Label
		{
			Text = "Description:\n",

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
			Text = "Quality: "
		};

		Image profImg = new Image
		{
			HorizontalOptions = LayoutOptions.FillAndExpand,
			VerticalOptions = LayoutOptions.FillAndExpand,
			HeightRequest = 300,
			Aspect = Aspect.AspectFit,
		};

		Button viewComments = new Button
		{
			Text = "View Comments",
			BorderRadius = 0,
			//Margin = 0,
			HorizontalOptions = LayoutOptions.FillAndExpand
		};

		#endregion

		public itemPage(myDataTypes.item i)
		{
			item = i;
			Title = i.name;

			viewComments.Clicked += (s, e) =>
			{
				Navigation.PushAsync(new commentPage(i.id));
			};

			#region basestack
			baseStack = new StackLayout
			{
				Children = {
					new StackLayout {
						VerticalOptions = LayoutOptions.FillAndExpand,
						HorizontalOptions = LayoutOptions.FillAndExpand,
						Children = {
							profImg,
							lblDesc,
							lblPrice,
							lblQuality,
							viewComments
						}
					}
				}
			};
			#endregion

			lblDesc.Text += i.description;

			CultureInfo culture = new CultureInfo("en-us");
			culture.NumberFormat.CurrencyNegativePattern = 1;

			lblPrice.Text = string.Format(culture, "{0:c2}", item.price);

			profImg.Source = ImageSource.FromStream(() => new MemoryStream(i.picture));

			//giving stars to rating
			string st = "";
			for (int j = 0; j < item.quality; j++)
			{
				st += "\u2605";
			}
			lblQuality.Text += st;
			Content = baseStack;

		}
	}

}

