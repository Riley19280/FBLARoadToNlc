using GarageSale.Views.ListViews;
using myDataTypes;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Xamarin.Forms;
#pragma warning disable 4014
namespace GarageSale.Views.Pages
{
	public class fblaMembersPage : basePage
	{
		userListView listView;
		int fbla_id;


		public fblaMembersPage(int fbla_id)
		{
			this.fbla_id = fbla_id;
			listView = new userListView();
			Title = "FBLA Members";

			listView.removeEventHandlers();
		
			listView.ItemSelected += async (s, e) =>
			{
				if (listView.SelectedItem == null || (e.SelectedItem as user).id == App.CredManager.GetAccountValue("G_id"))
					return;

				if (int.Parse(App.CredManager.GetAccountValue("FBLA_status")) >= 9)
				{
					var answer = await DisplayActionSheet("Choose Action", "Cancel", null, "View User", "Set Roles");
					if (answer == "View User")
					{
						var userView = new userView(e.SelectedItem as myDataTypes.user);

						Navigation.PushAsync(userView);
					}
					else if (answer == "Set Roles")
					{
						doActionSheet(e.SelectedItem as user);
					}
				}
				else {
					var userView = new userView(e.SelectedItem as myDataTypes.user);

					Navigation.PushAsync(userView);
				}
				listView.SelectedItem = null;
			};


			Content = new StackLayout
			{
				Children = {
					listView
				}
			};
		}

		async void doActionSheet(user u)
		{

			var action = await DisplayActionSheet("Select a role for " + u.name, "Cancel", null, "Remove User From FBLA", "Administrator", "President", "Vice-President", "Secretary", "Treasurer", "Parliamentarian", "Member");

			switch (action)
			{
				case "Administrator":
					App.MANAGER.YSSI.SetChapterStatusOfUser(10, u.id);
					break;
				case "President":
					App.MANAGER.YSSI.SetChapterStatusOfUser(6, u.id);
					break;
				case "Vice-President":
					App.MANAGER.YSSI.SetChapterStatusOfUser(5, u.id);
					break;
				case "Secretary":
					App.MANAGER.YSSI.SetChapterStatusOfUser(4, u.id);
					break;
				case "Treasurer":
					App.MANAGER.YSSI.SetChapterStatusOfUser(3, u.id);
					break;
				case "Parliamentarian":
					App.MANAGER.YSSI.SetChapterStatusOfUser(2, u.id);
					break;
				case "Member":
					App.MANAGER.YSSI.SetChapterStatusOfUser(1, u.id);
					break;
				case "Remove User From FBLA":
					bool answer = await DisplayAlert("Remove User", "Are you sure you would like to remove " + u.name + " from your FBLA chapter?", "Yes", "Cancel");
					if (answer)
						App.MANAGER.YSSI.SetChapterStatusOfUser(-1, u.id);
					break;
			}

		}

		protected async override void OnAppearing()
		{
			listView.ItemsSource = await App.MANAGER.YSSI.GetUsersByChapterStatus(-1, fbla_id);
		}
	}
}
