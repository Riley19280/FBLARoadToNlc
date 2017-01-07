using GarageSale.Views.Menu;
using GarageSale.Views.Pages;
using myDataTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace GarageSale
{
	public class App : Application
	{

		public static Page mainPage;
		public static RootPage rootPage;

		public static Manager MANAGER;
		public static ICredentialManager CredManager;
		public static OAuthReqManager ORM;

		public App()
		{
			#region Style
			Resources = new ResourceDictionary();
			var contentPageStyle = new Style(typeof(ContentPage))
			{
				Setters = {
					new Setter { Property = ContentPage.BackgroundColorProperty, Value = Constants.palette.primary },
				}
			};
			Resources.Add("contentPageStyle", contentPageStyle);

			var labelStyle = new Style(typeof(Label))
			{
				Setters = {
					new Setter { Property = Label.TextColorProperty, Value = Constants.palette.primary_text },
				}
			};
			Resources.Add(labelStyle);

			var editorStyle = new Style(typeof(ExtendedEditor))
			{
				Setters = {
					new Setter { Property = ExtendedEditor.TextColorProperty, Value = Constants.palette.primary_text },
					new Setter { Property = ExtendedEditor.BackgroundColorProperty, Value = Constants.palette.primary_variant },
				}
			};
			Resources.Add(editorStyle);

			var entryStyle = new Style(typeof(ExtendedEntry))
			{
				Setters = {
					new Setter { Property = ExtendedEntry.TextColorProperty, Value = Constants.palette.primary_text },
					new Setter { Property = ExtendedEntry.BackgroundColorProperty, Value = Constants.palette.primary_variant },
					new Setter { Property = ExtendedEntry.PlaceholderTextColorProperty, Value = Constants.palette.secondary_text },
				}
			};
			Resources.Add(entryStyle);

			var searchStyle = new Style(typeof(SearchBar))
			{
				Setters = {
			//	new Setter { Property = SearchBar.TextColorProperty, Value = Constants.palette.primary_text },
				new Setter { Property = SearchBar.BackgroundColorProperty, Value = Constants.palette.barColor },
				new Setter { Property = SearchBar.CancelButtonColorProperty, Value = Constants.palette.primary_text },

				}
			};
			Resources.Add(searchStyle);


			var buttonStyle = new Style(typeof(Button))
			{
				Setters = {
				new Setter { Property = Button.TextColorProperty, Value = Color.FromHex("#FFFFFF") },
				new Setter { Property = Button.BackgroundColorProperty, Value = Constants.palette.primary_dark_variant },
				}
			};
			Resources.Add(buttonStyle);

			var activityIndicatorStyle = new Style(typeof(ActivityIndicator))
			{
				Setters = {
				new Setter { Property = ActivityIndicator.ColorProperty, Value = Constants.palette.primary_dark_variant },
				}
			};
			Resources.Add(activityIndicatorStyle);

			var listViewStyle = new Style(typeof(ListView))
			{
				Setters = {
				new Setter { Property = ListView.SeparatorColorProperty, Value = Constants.palette.divider },
				}
			};
			Resources.Add(listViewStyle);


			#endregion

			MANAGER = new Manager(new YardSaleServiceImplementation());
			CredManager = DependencyService.Get<ICredentialManager>();
			ORM = new OAuthReqManager();

			//TODO:Do this in load page before main page load so that the private list adds fbla correctly
			if (CredManager.IsLoggedIn())
			{
				try
				{
					var task = Task.Run( async() =>
						{
							//TODO: check membership fo chapter, could have changed, we may be technicall doing this?
							int[] fblaInfo = await MANAGER.YSSI.GetChapterInfoOfUser(CredManager.GetAccountValue("G_id"));
							CredManager.UpdateAccountValue("FBLA_chapter_id", fblaInfo[0].ToString());
							CredManager.UpdateAccountValue("FBLA_status", fblaInfo[1].ToString());
						});
					task.Wait();
				}
				catch (Exception e)
				{
					CredManager.UpdateAccountValue("FBLA_chapter_id", "-1");
					CredManager.UpdateAccountValue("FBLA_status", "-1");
					Debug.WriteLine("ERROR: "+e.Message + "\n" + e.StackTrace);
				}
			}

			mainPage = new RootPage();
			MainPage = mainPage;

		}

		public static Action SuccessfulLoginAction
		{
			get
			{
				return new Action(async () =>
				{
					try
					{
						//navigation.PopModalAsync();

						if (!await ORM.GetProfileInfo())
						{
							await mainPage.DisplayAlert("Error completing  login", "Error completing  login, Please try again", "Dismiss");

							CredManager.DeleteCredentials();
							return;
						}


						MANAGER.YSSI.UpdateUser(new myDataTypes.user(CredManager.GetAccountValue("G_id"), CredManager.GetAccountValue("G_name"), CredManager.GetAccountValue("G_email"), CredManager.GetAccountValue("G_picture")));
						try
						{
							int[] fblaInfo = await MANAGER.YSSI.GetChapterInfoOfUser(CredManager.GetAccountValue("G_id"));
							CredManager.UpdateAccountValue("FBLA_chapter_id", fblaInfo[0].ToString());
							CredManager.UpdateAccountValue("FBLA_status", fblaInfo[1].ToString());
						}
						catch (Exception e)
						{
							CredManager.UpdateAccountValue("FBLA_chapter_id", "-1");
							CredManager.UpdateAccountValue("FBLA_status", "-1");
							Debug.WriteLine(e.Message + "\n" + e.StackTrace);
						}

						rootPage.menuPage.Menu.ItemsSource = new MenuListDataPrivate();
						rootPage.setDetail(new welcomePage());

						rootPage.menuPage.setMenuText("Welcome\n" + App.CredManager.GetAccountValue("G_name"));
					}
					catch (Exception e)
					{
						await mainPage.DisplayAlert("Error completing  login", "Error completing  login, Please try again", "Dismiss");
						Debug.WriteLine(e.Message + "\n" + e.StackTrace);
					}

				});
			}
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
