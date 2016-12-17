using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GarageSale.Views.ListViews
{
	class commentListView : ListView
	{
		public commentListView()
		{
			SeparatorColor = Constants.palette.divider;

			// Source of data items.
			VerticalOptions = LayoutOptions.FillAndExpand;
			HorizontalOptions = LayoutOptions.FillAndExpand;
			// Source of data items.


			RowHeight = 75;
			// Define template for displaying each item.
			// (Argument of DataTemplate constructor is called for 
			//      each item; it must return a Cell derivative.)
			ItemTemplate = new DataTemplate(() =>
			{
				// Create views with bindings for displaying each property.
				Label nameLabel = new Label(), commentLabel = new Label();
				nameLabel.SetBinding(Label.TextProperty, "user_id");
				commentLabel.SetBinding(Label.TextProperty, "comments");
				//commentLabel.TextColor = Color.Black;
				// Return an assembled ViewCell.
				return new ViewCell
				{
					View = new StackLayout
					{
						Padding = new Thickness(5, 5, 5, 5),
						VerticalOptions = LayoutOptions.Center,
						Spacing = 0,

						Children =	{
							nameLabel,
							commentLabel,
						}
					}


				};
			});





			this.ItemSelected += ((sender, eventArgs) =>
			{
				SelectedItem = null;
			});

			ItemAppearing += (s, e) =>
			{

			};
		}

	}
}

