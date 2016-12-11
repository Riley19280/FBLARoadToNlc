using GarageSale.Views.Pages;
using System;
using System.Collections.Generic;
using System.Globalization;
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
			Label qualityLabel = null;
			Label priceLabel = null;
			Image imageView = null;
			// Source of data items.

			RowHeight = 80;
			// Define template for displaying each item.
			// (Argument of DataTemplate constructor is called for 
			//      each item; it must return a Cell derivative.)
			ItemTemplate = new DataTemplate(() =>
			{
				// Create views with bindings for displaying each property.
				Label nameLabel = new Label(), descLabel = new Label();
				priceLabel = new Label();
				qualityLabel = new Label();
				nameLabel.SetBinding(Label.TextProperty, "name");
				descLabel.SetBinding(Label.TextProperty, "description");
				//qualityLabel.SetBinding(Label.TextProperty, "quality");

				//&#9734
				imageView = new Image
				{
					HeightRequest = 100,
					WidthRequest = 100,

				};

				// Return an assembled ViewCell.
				return new ViewCell
				{
					View = new StackLayout
					{
						Padding = new Thickness(5, 5, 5, 0),
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
													qualityLabel
												}
											}

										}
									}
							}
					}
				};
			});

			ItemAppearing += (s, e) =>
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
				qualityLabel.Text = st;

				imageView.Source = ImageSource.FromStream(() => new System.IO.MemoryStream(item.picture));


			};


			IsPullToRefreshEnabled = true;

			this.Refreshing += ((sender, eventArgs) =>
		   {

			   this.IsRefreshing = false;
		   });

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
