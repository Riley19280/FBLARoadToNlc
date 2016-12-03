using GarageSale.Views.ListViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GarageSale.Views.Pages
{
	class searchUsersPage : basePage
	{
		ListView listView;
		SearchBar search;

		public searchUsersPage()
		{
			Title = "Search Users";

			search = new SearchBar
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Placeholder = "Search for User.."
			};

			search.SearchCommand = new Command(async () =>
			{
					listView.ItemsSource = await App.MANAGER.YSSI.GetSearchedUsers(search.Text);
			});

			listView = new userListView();
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
			myDataTypes.user u = e.SelectedItem as myDataTypes.user;

			//Navigation.PushAsync(new othersProfile(p.userInfo.user_id));
		}


	}
}

