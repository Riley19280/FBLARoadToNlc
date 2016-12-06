using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GarageSale.Views.Pages
{
	public class loginPageModal : basePage
	{
		Button BackButton = new Button
		{
			Text = "Back",
			VerticalOptions = LayoutOptions.CenterAndExpand,
			HorizontalOptions = LayoutOptions.CenterAndExpand
		};

		public loginPageModal()
		{
			Title = "Login";
			BackButton.Clicked += BackButton_Clicked;

			Content = new StackLayout
			{

				Children = {
					BackButton
				}
			};
		}

		private void BackButton_Clicked(object sender, EventArgs e)
		{

			Navigation.PopModalAsync();
		}
	}
}
