using System;
using Xamarin.Forms;
using System.Collections.Generic;
using GarageSale.Views.Pages;


namespace GarageSale.Views.Menu
{

	public class MenuListData : List<MenuItem>
	{
		public MenuListData ()
		{
			this.Add (new MenuItem () { 
				Title = "All Items", 
				//IconSource = "contacts.png", 
				TargetType = typeof(allItems)
			});

			this.Add(new MenuItem()
			{
				Title = "Search Items",
				//IconSource = "contacts.png", 
				TargetType = typeof(searchItems)
			});

			this.Add(new MenuItem()
			{
				Title = "Search Users",
				//IconSource = "contacts.png", 
				TargetType = typeof(searchUsers)
			});

			this.Add(new MenuItem()
			{
				Title = "Help",
				//IconSource = "leads.png", 
				TargetType = typeof(basePage)//help
			});


		}
	}
}