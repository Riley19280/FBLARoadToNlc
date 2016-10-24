using System;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;

namespace GarageSale.Views.Menu
{
	public class RootPage : MasterDetailPage
	{
		MenuPage menuPage;

		public RootPage ()
		{
			menuPage = new MenuPage();

			menuPage.Menu.ItemSelected += (sender, e) => NavigateTo (e.SelectedItem as MenuItem);

			Master = menuPage;
			Detail = new NavigationPage(new basePage())//TODO:WELCOME PAGE
			{
				//BarBackgroundColor = Constants.palette.primary_dark,
				//BarTextColor = Constants.palette.icons,
			};
		}

		void NavigateTo (MenuItem menu)
		{
			if (menu == null)
				return;

			Page displayPage = (Page)Activator.CreateInstance(menu.TargetType);
			

			Detail = new NavigationPage(displayPage) {
				//BarBackgroundColor = Constants.palette.primary_dark,
				//BarTextColor = Constants.palette.icons,
			};


			//menuPage.Menu.SelectedItem = null;
			IsPresented = false;
		}
	}
}