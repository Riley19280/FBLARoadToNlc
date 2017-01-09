using GarageSale.Views.ListViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GarageSale.Views.Pages
{
	class searchItemsPage : basePage
	{
		ListView listView;
		SearchBar search;
		StackLayout baseStack;
		ContentView cv;
		ActivityIndicator ai;
		public searchItemsPage()
		{
			Title = "Search Items";

			search = new SearchBar
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Placeholder = "Search for Item.."
			};

			search.SearchCommand = new Command(async () =>
		   {
			   cv.Content = ai;
			   listView.ItemsSource = await App.MANAGER.YSSI.GetSearchedItems(search.Text);
			   cv.Content = listView;
		   });

			listView = new itemListView();
			listView.HorizontalOptions = LayoutOptions.FillAndExpand;
			listView.VerticalOptions = LayoutOptions.FillAndExpand;

			cv = new ContentView();
			ai = new ActivityIndicator() { IsRunning = true, HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.Center };
			cv.Content = ai;

			baseStack = new StackLayout
			{
				Children = {
					search,
					cv

				}
			};

			Content = baseStack;
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			if (listView.ItemsSource == null)
			{
				listView.ItemsSource = await App.MANAGER.YSSI.GetAllItems();
				cv.Content = listView;
			}
		}

	}
}