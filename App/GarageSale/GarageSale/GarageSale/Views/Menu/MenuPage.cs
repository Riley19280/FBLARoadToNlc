using System;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;

namespace GarageSale.Views.Menu
{
	public class MenuPage : ContentPage
	{
		public ListView Menu { get; set; }
		public Label lbl { get; set; }

		public MenuPage()
		{


			Icon = "settings.png";
			Title = "menu"; // The Title property must be set.

			Menu = new MenuListView();

			lbl = new Label
			{
				TextColor = Color.FromHex("AAAAAA"),
				Text = "MENU",
				HorizontalTextAlignment = TextAlignment.Center
			};

			var menuLabel = new ContentView
			{
				Padding = new Thickness(10, 36, 0, 5),
				Content = lbl
			};

			var layout = new StackLayout
			{
				Spacing = 0,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			layout.Children.Add(menuLabel);
			layout.Children.Add(Menu);

			Content = layout;
		}

		public void setMenuText(string title)
		{
			lbl.Text = title;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (App.CredManager.IsLoggedIn())
				setMenuText("Welcome\n" + App.CredManager.GetAccountValue("G_name"));
		}
	}
}