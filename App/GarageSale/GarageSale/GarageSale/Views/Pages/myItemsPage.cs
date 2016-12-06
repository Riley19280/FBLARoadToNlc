using GarageSale.Views.ListViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GarageSale.Views.Pages
{
	public class myItemsPage : basePage
	{
		ListView view;
		public myItemsPage()
		{
			Title = "My Items";

			view = new itemListView();


			Content = view;
		}


		protected async override void OnAppearing()
		{
			view.ItemsSource = await App.MANAGER.YSSI.GetItemsAssociatedWithUser(App.CredManager.GetAccountValue("G_id"));
		}
	}
}