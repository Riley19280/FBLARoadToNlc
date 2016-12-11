using GarageSale.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSale.Views.Menu
{
	public class MenuListDataPrivate : List<MenuItem>
	{
		public MenuListDataPrivate()
		{
			this.Add(new MenuItem()
			{
				Title = "Log Out",
				//IconSource = "contacts.png", 
				TargetType = typeof(logOutPage)
			});

			this.Add(new MenuItem()
			{
				Title = "My Items",
				//IconSource = "contacts.png", 
				TargetType = typeof(myItemsPage)
			});

			if (App.CredManager.AccountValueExists("FBLA_chapter_id"))
				if (int.Parse(App.CredManager.GetAccountValue("FBLA_chapter_id")) > 0)
					this.Add(new MenuItem()
					{
						Title = "My FBLA",
						//IconSource = "contacts.png", 
						TargetType = typeof(fblaChapterPage),
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
				TargetType = typeof(CameraPage)//help
			});
		}
	}
}
