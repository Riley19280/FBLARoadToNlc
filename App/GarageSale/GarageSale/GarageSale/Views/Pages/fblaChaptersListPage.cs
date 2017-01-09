using GarageSale.Views.ListViews;
using myDataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GarageSale.Views.Pages
{
	public class fblaChaptersListPage : basePage
	{
		ListView listView;
		SearchBar search;
		ContentView cv;
		ActivityIndicator ai;
		public fblaChaptersListPage()
		{
			Title = "FBLA Chapters";
			listView = new fblaChapterListView();

			search = new SearchBar
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Placeholder = "Search for FBLA Chapter.."
			};

			search.SearchCommand = new Command(async () =>
			{
				cv.Content = ai;
				listView.ItemsSource = await App.MANAGER.YSSI.GetSearchedChapters(search.Text);
				cv.Content = listView;
			});

			cv = new ContentView();
			ai = new ActivityIndicator() { IsRunning = true, HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.Center };
			cv.Content = ai;

			Content = new StackLayout
			{
				Children = {
					search,
					cv
				}
			};
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			if (listView.ItemsSource == null)
			{
				listView.ItemsSource = await App.MANAGER.YSSI.GetSearchedChapters("");
				cv.Content = listView;
			}
		}

	}
}
