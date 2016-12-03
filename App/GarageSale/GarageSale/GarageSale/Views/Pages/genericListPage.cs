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
		public viewListPage(ListView v,int fbla_id, int code) {
			view = v;
			this.code = code;
			this.fbla_id = fbla_id;
		
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
			}

			Content = view;	
		}

	}
}