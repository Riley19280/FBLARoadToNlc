using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace GarageSale.Views.Pages
{
	public class allItems : ContentPage
	{
		public allItems()
		{
			ListView l = new itemListView();
			l.ItemsSource = App.MANAGER.GetAllItems();

			Content = new StackLayout
			{
				Children = {
					new Label { Text = "All Items"},
					l
				}
			};
		}
	}
}
