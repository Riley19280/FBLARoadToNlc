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
	public class fblaChaptersPage : basePage
	{
		ListView listView;

		public fblaChaptersPage()
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
			

				listView.ItemsSource = await App.MANAGER.YSSI.GetSearchedChapters("");
				//	Content = baseStack;
			}
		}

	}
}
