﻿using GarageSale.Views.ListViews;
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
			VerticalOptions = LayoutOptions.StartAndExpand,
			HorizontalOptions = LayoutOptions.CenterAndExpand

		};

		Label lblState = new Label
		{
			Text = "",

			HorizontalOptions = LayoutOptions.CenterAndExpand
		};

		Label lblCity = new Label
		{
			HorizontalOptions = LayoutOptions.CenterAndExpand,
			Text = ""
		};

		Label lblSchool = new Label
		{
			HorizontalOptions = LayoutOptions.CenterAndExpand,
			Text = ""
		};

		RelativeLayout relLayout = new RelativeLayout
		{
			//Margin = 0,
			Padding = 0,
			HorizontalOptions = LayoutOptions.Start,
		};

		Image profImg = new Image
		{
			HorizontalOptions = LayoutOptions.CenterAndExpand,
			HeightRequest = 150,
		};

		Label profImgLabel = new Label
		{//TODO: only enable changing this if user is administrator
			Text = "Click to change"
		};

		Button viewItems = new Button
		{
			Text = " View Items ",
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
			shouldGetChapter = true;
			fblaid = int.Parse(App.CredManager.GetAccountValue("FBLA_chapter_id"));
		}

		StackLayout makeGUI()
		{
			viewItems.Command = new Command(() =>
			{
				Navigation.PushAsync(new viewListPage(new itemListView(), fbla.id, 1, "Items for sale by " + fbla.school));
			});

			viewMembers.Command = new Command(() =>
			{
				Navigation.PushAsync(new viewListPage(new userListView(), fbla.id, 2, " FBLA Members " + fbla.school));
			});

			#region prof image
			profImg.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(async () =>
				{
					var answer = await DisplayAlert("Change profile picture", "Would you like to change the picture?", "Yes", "No");
					if (answer)
					{
						//FIXME: go to change image screen
						//Device.OpenUri(new Uri("https://plus.google.com/u/0/me?tab=XX"));
					}
				}),
				NumberOfTapsRequired = 1
			});

			relLayout.Children.Add(profImg,
				Constraint.RelativeToParent((parent) =>
				{
					return parent.X;
				}), Constraint.RelativeToParent((parent) =>
				{
					return parent.Y;
				}));

			relLayout.Children.Add(profImgLabel, Constraint.RelativeToView(profImg, (parent, sibling) =>
			{
				return (sibling.Width / 2) - (profImgLabel.Width / 2);
			}), Constraint.RelativeToView(profImg, (parent, sibling) =>
			{
				return sibling.Height - 5 - profImgLabel.Height;
			}));

			#endregion

			#region basestack
			return new StackLayout
			{
				Children = {
					relLayout,
					new StackLayout {
						VerticalOptions = LayoutOptions.FillAndExpand,
						HorizontalOptions = LayoutOptions.FillAndExpand,
						Children = {
							lblName,
							lblSchool,
							lblCity,
							lblState,
							new StackLayout {
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
					}
				}
			};
			#endregion

		}

		public void populateProfileFields()
		{
			baseStack = makeGUI();
			Title = fbla.school + " FBLA";
			lblName.Text = fbla.name;
			lblState.Text = fbla.state;
			lblCity.Text = fbla.city;
			lblSchool.Text = fbla.school;

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
		int fblaid;

		protected async override void OnAppearing()
		{
			if (shouldGetChapter)
			{
				fbla = await App.MANAGER.YSSI.GetFBLAChapter(fblaid);
				populateProfileFields();
			}
		}
	}

}

