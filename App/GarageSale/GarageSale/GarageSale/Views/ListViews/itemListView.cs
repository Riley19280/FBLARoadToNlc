using GarageSale.Views.Pages;
using myDataTypes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GarageSale.Views.ListViews
{
	class itemListView : ListView
	{
		public itemListView()
		{
			SeparatorColor = Constants.palette.divider;

			Label conditionLabel = null;
			Label priceLabel = null;
			CustomImageView imageView = null;
			// Source of data items.

			RowHeight = 80;
			// Define template for displaying each item.
			// (Argument of DataTemplate constructor is called for 
			//      each item; it must return a Cell derivative.)
			ItemTemplate = new DataTemplate(() =>
			{
				// Create views with bindings for displaying each property.
				Label nameLabel = new Label() { LineBreakMode = LineBreakMode.TailTruncation }, descLabel = new Label() { LineBreakMode = LineBreakMode.TailTruncation };
				priceLabel = new Label();
				conditionLabel = new Label();
				nameLabel.SetBinding(Label.TextProperty, "name");
				descLabel.SetBinding(Label.TextProperty, "description");



				//&#9734
				imageView = new CustomImageView
				{
					HeightRequest = 100,
					WidthRequest = 100,

				};

				// Return an assembled ViewCell.
				return new ViewCell
				{
					View = new StackLayout
					{
						Padding = new Thickness(5, 5, 5, 5),
						Orientation = StackOrientation.Horizontal,
						Children =
							{
									imageView,
									new StackLayout
									{
										VerticalOptions = LayoutOptions.Center,
										//Spacing = 0,
										Children =
										{
											nameLabel,
											descLabel,
											new StackLayout {
												//Spacing = 0,
												Orientation = StackOrientation.Horizontal,
												Children = {
													priceLabel,
													conditionLabel
												}
											}

										}
									}
							}
					}
				};
			});

			ItemAppearing +=async (s, e) =>
			{
				myDataTypes.item item = e.Item as myDataTypes.item;
				//formatting price to money
				CultureInfo culture = new CultureInfo("en-us");
				culture.NumberFormat.CurrencyNegativePattern = 1;

				priceLabel.Text = string.Format(culture, "{0:c2}", item.price);

				//giving stars to rating
				string st = "";
				for (int i = 0; i < item.quality; i++)
				{
					st += "\u2605";
				}
				conditionLabel.Text = st;

				IImageProcessing processer = DependencyService.Get<IImageProcessing>();
				imageView.SetImageBitmap(await processer.ScaleBitmap(item.picture, await processer.GetBitmapOptionsOfImageAsync(item.picture), 200, 200));

			};

			this.ItemSelected += ((sender, eventArgs) =>
			{
				if (this.SelectedItem != null)
				{
					var itemView = new itemPage(SelectedItem as myDataTypes.item);

					this.SelectedItem = null;
					Navigation.PushAsync(itemView);
				}
			});



		}

	}
}
