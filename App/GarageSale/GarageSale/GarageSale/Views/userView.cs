using GarageSale.Views.ListViews;
using myDataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GarageSale.Views
{
	class userView:basePage
	{
		ListView listView;

		Label lblName = new Label
		{
			Text = "",
			VerticalOptions = LayoutOptions.StartAndExpand,
			HorizontalOptions = LayoutOptions.CenterAndExpand,

		};

		Label lblRating = new Label
		{//TODO:possibly have user ratings?
			Text = "",
			VerticalOptions = LayoutOptions.StartAndExpand,
			HorizontalOptions = LayoutOptions.CenterAndExpand,
		};

		Label lblStats = new Label
		{
			HorizontalOptions = LayoutOptions.CenterAndExpand,
			Text = ""
		};

		Image profImg = new Image
		{
			WidthRequest = 150,
			HeightRequest = 150,
		};

		public userView(user u)
		{
			listView = new itemListView();
			populateProfileFields(u);

			Content = new StackLayout
			{
				Children = {
					new StackLayout {

						Orientation = StackOrientation.Horizontal,

						Children = {

							profImg,

							new StackLayout {
								VerticalOptions = LayoutOptions.FillAndExpand,
								HorizontalOptions = LayoutOptions.FillAndExpand,
								Children = {
									lblName,
									lblRating,
								}
							}
						}
					},			
					lblStats,
					listView

				}
			};
		}

		public async void populateProfileFields(user u)
		{
			
			List<item> items = await App.MANAGER.YSSI.GetItemsAssociatedWithUser(u.id);
			listView.ItemsSource = items;
			if (u != null)
			{
				lblName.Text = u.name;
				Title = u.name;
				lblStats.Text = "Items: " + items.Count.ToString();
				//TODO:profImg.Source = ImageSource.FromUri(new Uri(u.pic_url));
			
			}

		}
	}
}
