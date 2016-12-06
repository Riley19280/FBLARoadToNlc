using myDataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GarageSale.Views.Pages
{
	public class viewListPage : basePage
	{
		int code;
		ListView view;
		int fbla_id;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="v">The list view you want to display</param>
		/// <param name="fbla_id">ID of the Fbla group</param>
		/// <param name="code">The Code that corresponds with the function you want to preform</param>
		/// <param name="title">The title for the page</param>
		public viewListPage(ListView v,int fbla_id, int code, string title) {
			view = v;
			this.code = code;
			this.fbla_id = fbla_id;
			Title = title;
		}

		string user_id;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="v">The list view you want to display</param>
		/// <param name="user_id">ID of the user</param>
		/// <param name="title">The title for the page</param>
		public viewListPage(ListView v, string user_id, string title)
		{
			view = v;
			this.user_id = user_id;
			Title = title;
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			switch (code)
			{
				case 1:
					view.ItemsSource = await App.MANAGER.YSSI.GetFBLAChapterItems(fbla_id);
					break;
				case 2:
					view.ItemsSource = await App.MANAGER.YSSI.GetUsersByChapterStatus(-1, fbla_id);
					break;
				case 3:
					view.ItemsSource = await App.MANAGER.YSSI.GetItemsAssociatedWithUser(user_id);
					break;
			}

			Content = view;	
		}

	}
}