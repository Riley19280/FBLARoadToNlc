using System;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using GarageSale.Views.Pages;

namespace GarageSale.Views.Menu
{
	public class RootPage : MasterDetailPage
	{
		public MenuPage menuPage;

		public RootPage()
		{
			App.rootPage = this;

			menuPage = new MenuPage();

			menuPage.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as MenuItem);

			Master = menuPage;
			Detail = new NavigationPage(new welcomePage()) { BarBackgroundColor = Constants.palette.barColor };

		}

		public void setDetail(Page page)
		{
			Detail = new NavigationPage(page) { BarBackgroundColor = Constants.palette.barColor };
			IsPresented = false;
		}

		void NavigateTo(MenuItem menu)
		{
			if (menu == null)
				return;

			Page displayPage = (Page)Activator.CreateInstance(menu.TargetType);


			Detail = new NavigationPage(displayPage)
			{
				BarBackgroundColor = Constants.palette.barColor,
				//BarTextColor = Constants.palette.icons,
			};


			//menuPage.Menu.SelectedItem = null;
			IsPresented = false;
		}
	}
}