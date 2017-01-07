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
						VerticalOptions = LayoutOptions.Start,
						HorizontalOptions =LayoutOptions.CenterAndExpand
					},
					new Image() {
						HorizontalOptions = LayoutOptions.FillAndExpand,
						VerticalOptions = LayoutOptions.FillAndExpand,
						HeightRequest = 256,
						Aspect = Aspect.AspectFit,
						Source =ImageSource.FromResource("GarageSale.logo512.png"),
						
					}

				}
			};


		}
	}
}