using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GarageSale.Views.ListViews
{
	class userListView : ListView
	{
		public userListView()
		{

			// Source of data items.

			RowHeight = 80;
			// Define template for displaying each item.
			// (Argument of DataTemplate constructor is called for 
			//      each item; it must return a Cell derivative.)
			ItemTemplate = new DataTemplate(() =>
			{
				// Create views with bindings for displaying each property.
				Label nameLabel = new Label { FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),VerticalOptions = LayoutOptions.CenterAndExpand,HorizontalOptions = LayoutOptions.CenterAndExpand }, bioLabel = new Label();
				nameLabel.SetBinding(Label.TextProperty, "name");
				//bioLabel.SetBinding(Label.TextProperty, "bio");

				Image imageView = new Image
				{
					HeightRequest = 75,
					WidthRequest = 75,

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
										//VerticalOptions = LayoutOptions.Center,
										Spacing = 5,
										Children =
										{
											nameLabel,
											bioLabel,
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
					var userView = new userView(SelectedItem as myDataTypes.user);
					this.SelectedItem = null;
					Navigation.PushAsync(userView);
				}
			});

		}

	}
}
