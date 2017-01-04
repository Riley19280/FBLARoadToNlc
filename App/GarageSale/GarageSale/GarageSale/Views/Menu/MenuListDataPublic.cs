using System;
using Xamarin.Forms;
using System.Collections.Generic;
using GarageSale.Views.Pages;


namespace GarageSale.Views.Menu
{

	public class MenuListDataPublic : List<MenuItem>
	{
		public MenuListDataPublic ()
		{
			this.Add(new MenuItem()
			{
				Title = "Log In",
				//IconSource = "contacts.png", 
				TargetType = typeof(loginPageModal)
			});

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
				Title = "FBLA Chapters",
				//IconSource = "leads.png", 
				TargetType = typeof(fblaChaptersListPage)//help
			});

			this.Add(new MenuItem()
			{
				Title = "Help",
				//IconSource = "leads.png", 
				TargetType = typeof(CameraPage)//help
			});


		}
	}
}