using System;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;

namespace GarageSale.Views.Menu
{
	public class MenuPage : ContentPage
	{
		public ListView Menu { get; set; }

		public MenuPage ()
		{
			

			Icon = "settings.png";
			Title = "menu"; // The Title property must be set.

			Menu = new MenuListView();

			var menuLabel = new ContentView {
				Padding = new Thickness (10, 36, 0, 5),
				Content = new Label {
					
					Text = "MENU", 
				}
			};

			var layout = new StackLayout { 
				Spacing = 0, 
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			layout.Children.Add (menuLabel);
			layout.Children.Add (Menu);

			Content = layout;
		}
	}
}