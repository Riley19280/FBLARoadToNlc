using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace GarageSale.Views.Menu
{

	public class MenuListView : ListView
	{
		public MenuListView()
		{
			List<MenuItem> data;

			if (App.CredManager.IsLoggedIn())
			{ data = new MenuListDataPrivate(); }
			else
			{ data = new MenuListDataPublic(); }

			ItemsSource = data;
			VerticalOptions = LayoutOptions.FillAndExpand;
			BackgroundColor = Color.Transparent;
			SeparatorVisibility = SeparatorVisibility.None;

			var cell = new DataTemplate(typeof(MenuCell));

			cell.SetBinding(MenuCell.TextProperty, "Title");
			//	cell.SetBinding (MenuCell.ImageSourceProperty, "IconSource");

			ItemTemplate = cell;
		}
	}
}