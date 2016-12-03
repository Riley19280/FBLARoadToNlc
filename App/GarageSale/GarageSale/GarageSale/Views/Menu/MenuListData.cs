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
				TargetType = typeof(allItemsPage)
			});

			this.Add(new MenuItem()
			{
				Title = "Search Items",
				//IconSource = "contacts.png", 
				TargetType = typeof(searchItemsPage)
			});

			this.Add(new MenuItem()
			{
				Title = "Search Users",
				//IconSource = "contacts.png", 
				TargetType = typeof(searchUsersPage)
			});

			this.Add(new MenuItem()
			{
				Title = "Add Item",
				//IconSource = "leads.png", 
				TargetType = typeof(newItemPage)//help
			});

			this.Add(new MenuItem()
			{
				Title = "FBLA Chapters",
				//IconSource = "leads.png", 
				TargetType = typeof(fblaChaptersListPage)//help
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