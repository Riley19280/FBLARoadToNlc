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

		CustomImageView profImg = new CustomImageView
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
				Navigation.PushAsync(new fblaChapterItemsPage(fbla));
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
			donateItem.Clicked += (s, e) =>
			{
				Navigation.PushAsync(new newItemPage(fbla.id));
			};

			if (App.CredManager.IsLoggedIn())
			{
				int myid = -1;
				int.TryParse(App.CredManager.GetAccountValue("FBLA_chapter_id"), out myid);

				if (fbla.id == myid)//is part of this chapter
					if (int.Parse(App.CredManager.GetAccountValue("FBLA_status")) > 5)
						ToolbarItems.Add(new ToolbarItem("Settings", "@drawable/book", () =>
						{
							Navigation.PushAsync(new pendingMembersPage(fbla.id));
						}));
				if (myid == -1)
				{
					ToolbarItems.Add(new ToolbarItem("Settings", "@drawable/book", async () =>
					{
						bool yes = await DisplayAlert("Apply to join chapter?", "Would you like to apply to join this chapter?", "Yes", "No");
						if (yes)
						{
							bool sucess = await App.MANAGER.YSSI.SetChapterStatusOfUser(0, App.CredManager.GetAccountValue("G_id"));
							if (sucess)
								DisplayAlert("You have applied.", "You have applied to join this chapter. Once an administrator has accepted you you will be a part of " + fbla.school + " FBLA.", "OK");
						}
					}));
				}
			}

			baseStack = makeGUI();
			Title = fbla.school + " FBLA";
			lblSchool.Text = fbla.school;
			lblLocation.Text = fbla.city + ", " + fbla.state;

			Task.Run(async () =>
			{
				IImageProcessing processer = DependencyService.Get<IImageProcessing>();
				profImg.SetImageBitmap(await processer.ScaleBitmap(fbla.picture, await processer.GetBitmapOptionsOfImageAsync(fbla.picture), 200, 200));
			});

			Content = baseStack;

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
				if (fbla == null)
				{
					fbla = await App.MANAGER.YSSI.GetFBLAChapter(myfblaid);
					populateProfileFields();
				}
			}
		}


	}
}



