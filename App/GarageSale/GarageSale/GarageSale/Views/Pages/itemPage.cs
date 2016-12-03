using System;
using System.Collections.Generic;
using System.Globalization;
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

		RelativeLayout relLayout = new RelativeLayout
		{
			//Margin = 0,
			Padding = 0,
			HorizontalOptions = LayoutOptions.Start,
		};

		Image profImg = new Image
		{
			HorizontalOptions = LayoutOptions.CenterAndExpand,
			HeightRequest = 150,
		};

		Label profImgLabel = new Label
		{//TODO: only enable changing this if user is administrator
			Text = "Click to change"
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

			#region prof image
			profImg.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(async () =>
				{
					var answer = await DisplayAlert("Change profile picture", "Would you like to change the picture?", "Yes", "No");
					if (answer)
					{
						//FIXME: go to change image screen
						//Device.OpenUri(new Uri("https://plus.google.com/u/0/me?tab=XX"));
					}
				}),
				NumberOfTapsRequired = 1
			});

			relLayout.Children.Add(profImg,
				Constraint.RelativeToParent((parent) =>
				{
					return parent.X;
				}), Constraint.RelativeToParent((parent) =>
				{
					return parent.Y;
				}));

			relLayout.Children.Add(profImgLabel, Constraint.RelativeToView(profImg, (parent, sibling) =>
			{
				return (sibling.Width / 2) - (profImgLabel.Width / 2);
			}), Constraint.RelativeToView(profImg, (parent, sibling) =>
			{
				return sibling.Height - 5 - profImgLabel.Height;
			}));

			#endregion

			#region basestack
			baseStack = new StackLayout
			{
				Children = {
					relLayout,
					new StackLayout {
						VerticalOptions = LayoutOptions.FillAndExpand,
						HorizontalOptions = LayoutOptions.FillAndExpand,
						Children = {
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

			//giving stars to rating
			string st = "";
			for (int j = 0; j < item.quality; j++)
			{
				st += "\u2605";
			}
			lblQuality.Text = st;
			Content = baseStack;

		}

		bool adminAlert = false;
	}

}

