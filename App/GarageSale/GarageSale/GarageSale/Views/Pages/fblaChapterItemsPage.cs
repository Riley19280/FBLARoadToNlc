using GarageSale.Views.ListViews;
using myDataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GarageSale.Views.Pages
{
	public class fblaChapterItemsPage : basePage
	{
		fblaChapter fbla;
		ListView view;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="v">The list view you want to display</param>
		/// <param name="fbla_id">ID of the Fbla group</param>
		/// <param name="code">The Code that corresponds with the function you want to preform</param>
		/// <param name="title">The title for the page</param>
		public fblaChapterItemsPage(fblaChapter fbla)
		{
			this.fbla = fbla;
			view = new itemListView();
			Content = new ActivityIndicator() { IsRunning = true };
			Title = "Items for sale by " + fbla.school;
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			
			view.ItemsSource = await App.MANAGER.YSSI.GetFBLAChapterItems(fbla.id);

			Content = view;
		}

	}
}