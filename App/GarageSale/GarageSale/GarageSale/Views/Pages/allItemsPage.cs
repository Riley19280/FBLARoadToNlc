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
	public class allItemsPage : basePage
	{
		ListView listView;

		public allItemsPage()
		{
			Title = "All Items";
			listView = new itemListView();

			Content = new StackLayout
			{
				Children = {
					 listView
				}
			};
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			if (listView.ItemsSource == null)
			{
				await Task.Delay(1000);

				listView.ItemsSource = await App.MANAGER.YSSI.GetAllItems();
				//	Content = baseStack;
			}
		}

	}
}