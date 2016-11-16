using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GarageSale.Views
{
	class itemListView : ListView
	{
		public itemListView()
		{

			// Source of data items.

			RowHeight = 80;
			// Define template for displaying each item.
			// (Argument of DataTemplate constructor is called for 
			//      each item; it must return a Cell derivative.)
			ItemTemplate = new DataTemplate(() =>
			{
				// Create views with bindings for displaying each property.
				Label nameLabel = new Label(), descLabel = new Label(), priceLabel = new Label(), qualityLabel = new Label();
				nameLabel.SetBinding(Label.TextProperty, "name");
				descLabel.SetBinding(Label.TextProperty, "description");
				priceLabel.SetBinding(Label.TextProperty, "price");
				qualityLabel.SetBinding(Label.TextProperty, "quality");


				Image imageView = new Image
				{
					HeightRequest = 100,
					WidthRequest = 100,

				};
				imageView.SetBinding(Image.SourceProperty, "pic_url");

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
										Spacing = 0,
										Children =
										{
											nameLabel,
											descLabel,
											new StackLayout {
												Spacing = 0,
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


			IsPullToRefreshEnabled = true;

			this.Refreshing += ((sender, eventArgs) =>
		   {

			   this.IsRefreshing = false;
		   });

			this.ItemSelected += ((sender, eventArgs) =>
			{
				if (this.SelectedItem != null)
				{
					//var actView = new activityView(listView.SelectedItem as myDataTypes.activity);

					this.SelectedItem = null;
					//Navigation.PushAsync(actView);
				}
			});

		}

	}
}
