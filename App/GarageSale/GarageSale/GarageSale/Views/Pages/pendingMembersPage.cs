using GarageSale.Views.ListViews;
using myDataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GarageSale.Views.Pages
{
	public class pendingMembersPage : basePage
	{
		userListView listView;
		int fbla_id;
		List<user> users;

		public pendingMembersPage(int fbla_id)
		{
			this.fbla_id = fbla_id;
			Title = "Pending Members";

			listView = new userListView();
			listView.removeEventHandlers();
			listView.ItemSelected +=async (s, e) => {
				if (e.SelectedItem == null)
					return;
				string descision = await DisplayActionSheet("Accept Member?","Cancel",null,"Accept","Decline");
				int index=0;
				for (int i = 0; i < users.Count; i++)
				{
					if (users.ElementAt(i).id == (e.SelectedItem as user).id)
						index = i;
				}

				switch (descision)
				{
					case "Accept":
						App.MANAGER.YSSI.SetChapterStatusOfUser(1, (e.SelectedItem as user).id);				
						users.RemoveAt(index);
						
						break;
					case "Decline":
						App.MANAGER.YSSI.SetChapterStatusOfUser(-1, (e.SelectedItem as user).id);
						users.RemoveAt(index);
						break;
					case "Cancel":
						break;
				}
				listView.BeginRefresh();
				listView.ItemsSource = users;
				listView.EndRefresh();
				
				listView.SelectedItem = null;
				
			};

			Content = new ActivityIndicator() { IsRunning = true, HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.Center };
		}

		protected async override void OnAppearing()
		{
			users = await App.MANAGER.YSSI.GetUsersByChapterStatus(0, fbla_id);
			listView.ItemsSource = users;
			Content = listView;
		}
	}
}
