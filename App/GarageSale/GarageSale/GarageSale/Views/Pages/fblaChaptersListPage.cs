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

		public fblaChaptersListPage()
		{
			Title = "FBLA Chapters";
			listView = new fblaChapterListView();

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
			//TODO:ADD SEARCH BAR

				listView.ItemsSource = await App.MANAGER.YSSI.GetSearchedChapters("");
				//	Content = baseStack;
			}
		}

	}
}
