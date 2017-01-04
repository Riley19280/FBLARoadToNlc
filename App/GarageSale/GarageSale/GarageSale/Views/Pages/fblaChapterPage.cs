using GarageSale.Views.ListViews;
using GarageSale.Views.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GarageSale.Views
{
	public class fblaChapterPage : basePage
	{
		myDataTypes.fblaChapter fbla;

		StackLayout baseStack;

		#region Views
		Label lblName = new Label
		{
			Text = "",
			VerticalOptions = LayoutOptions.Start,
			HorizontalOptions = LayoutOptions.CenterAndExpand
		};

		Label lblSchool = new Label
		{
			Text = "",
			VerticalOptions = LayoutOptions.Start,
			HorizontalOptions = LayoutOptions.CenterAndExpand
		};

		Label lblLocation = new Label
		{
			Text = "",
			VerticalOptions = LayoutOptions.Center,
			HorizontalOptions = LayoutOptions.CenterAndExpand
		};

		Image profImg = new Image
		{
			HorizontalOptions = LayoutOptions.FillAndExpand,
			VerticalOptions = LayoutOptions.FillAndExpand,
			HeightRequest = 300,
			Aspect = Aspect.AspectFit,
		};

		Button viewItems = new Button
		{
			Text = " View Items ",
			BorderRadius = 0,
			//Margin = 0,
			HorizontalOptions = LayoutOptions.FillAndExpand,
		};

		Button donateItem = new Button
		{
			Text = "Donate Item",
			BorderRadius = 0,
			//Margin = 0,
			HorizontalOptions = LayoutOptions.FillAndExpand,
		};
		
		Button viewMembers = new Button
		{
			Text = "View Members",
			BorderRadius = 0,
			//Margin = 0,
			HorizontalOptions = LayoutOptions.FillAndExpand,
		};

		#endregion

		public fblaChapterPage(myDataTypes.fblaChapter o)
		{
			fbla = o;

			populateProfileFields();

		}

		public fblaChapterPage()
		{
			//used forymchapterpage
			shouldGetChapter = true;
			myfblaid = int.Parse(App.CredManager.GetAccountValue("FBLA_chapter_id"));
		}

		StackLayout makeGUI()
		{
			viewItems.Command = new Command(() =>
			{
				Navigation.PushAsync(new viewListPage(new itemListView(), fbla.id, 1, "Items for sale by " + fbla.school));
			});

			viewMembers.Command = new Command(() =>
			{
				Navigation.PushAsync(new fblaMembersPage(fbla.id));
			});
				
			#region basestack
			return new StackLayout
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = {
					//lblName,
					profImg,
					lblSchool,
					lblLocation,
					donateItem,
					new StackLayout {
						HorizontalOptions = LayoutOptions.FillAndExpand,
						Orientation = StackOrientation.Horizontal,
						Padding = 0,
                        // Margin = 0,
                        Spacing = 0,
						Children = {
							viewItems,
							viewMembers
						}
					}
				}
			};
			#endregion

		}

		public void populateProfileFields()
		{
			donateItem.Clicked += (s,e) => {
				Navigation.PushAsync(new newItemPage(fbla.id));
			};


			baseStack = makeGUI();
			Title = fbla.school + " FBLA";
			lblSchool.Text = fbla.school;
			lblLocation.Text = fbla.city + ", " + fbla.state;

			profImg.Source = ImageSource.FromStream(() => new MemoryStream(fbla.picture));

			Content = baseStack;
			//TODO: do this if user is admin
			//if (Constants.AdminUsers.Contains(App.CredManager.GetAccountValue("G_id")) && !adminAlert)
			//{
			//	await Task.Delay(5000);
			//	DisplayAlert("Admin Notice:", "You are logged in as an administrative user!", "Dismiss");
			//	adminAlert = true;
			//}

		}

		bool shouldGetChapter = false;
		int myfblaid;

		protected async override void OnAppearing()
		{
			//disabling add item button if user is not logged in
			if (!App.CredManager.IsLoggedIn())
				donateItem.IsEnabled = false;
			else
				donateItem.IsEnabled = true;

			if (shouldGetChapter)
			{
				fbla = await App.MANAGER.YSSI.GetFBLAChapter(myfblaid);
				populateProfileFields();
			}
		}
	}

}

