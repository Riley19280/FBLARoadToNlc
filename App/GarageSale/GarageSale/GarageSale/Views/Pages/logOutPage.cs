using GarageSale.Views.Menu;

namespace GarageSale.Views.Pages
{
	public class logOutPage : basePage
	{
		public logOutPage()
		{

			App.CredManager.DeleteCredentials();
			App.rootPage.menuPage.Menu.ItemsSource = new MenuListDataPublic();
			App.rootPage.setDetail(new welcomePage());
		}
	}
}