using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GarageSale.Views.Pages
{
	class searchItems : basePage
	{
		ListView listView;
		SearchBar search;

		public searchItems()
		{
			Title = "Search Items";

			search = new SearchBar
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Placeholder = "Search for Item.."
			};

			search.SearchCommand = new Command( async() =>
			{	
					listView.ItemsSource = await App.MANAGER.YSSI.GetSearchedItems(search.Text);
			});

			listView = new itemListView();
			listView.HorizontalOptions = LayoutOptions.FillAndExpand;
			listView.VerticalOptions = LayoutOptions.FillAndExpand;

			Content = new StackLayout
			{
				Children = {
					search,
					listView
				}
			};
		}

		private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			myDataTypes.item i = e.SelectedItem as myDataTypes.item;

			//Navigation.PushAsync(new othersProfile(p.userInfo.user_id));
		}


	}
}