using System;
using Xamarin.Forms;
using System.Collections.Generic;


namespace GarageSale.Views.Menu
{

	public class MenuListData : List<MenuItem>
	{
		public MenuListData ()
		{
			this.Add (new MenuItem () { 
				Title = "Definitions", 
				//IconSource = "contacts.png", 
				TargetType = typeof(basePage)
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