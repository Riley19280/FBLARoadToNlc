using Xamarin.Forms;

namespace GarageSale.Views.Pages
{
	public class welcomePage : basePage
	{
		public welcomePage()
		{
			Title = "Welcome!";
			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(10),
				Children = {

					new Label {
						Text = "Welcome to my FBLA Fundraising app", FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
						VerticalOptions = LayoutOptions.StartAndExpand,
						HorizontalOptions =LayoutOptions.CenterAndExpand
					}

				}
			};


		}
	}
}