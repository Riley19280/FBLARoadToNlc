using GarageSale.Views.ListViews;
using myDataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GarageSale.Views.Pages
{
	class userPage : basePage
	{
		ListView listView;
		StackLayout basestack;


		#region Views
		Label lblName = new Label
		{
			Text = "",
			VerticalOptions = LayoutOptions.CenterAndExpand,
			HorizontalOptions = LayoutOptions.CenterAndExpand,
			FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
		};

		Label lblTitle = new Label
		{//TODO:possibly have user ratings?
			Text = "",
			VerticalOptions = LayoutOptions.StartAndExpand,
			HorizontalOptions = LayoutOptions.CenterAndExpand,
		};

		Label lblStats = new Label
		{
			HorizontalOptions = LayoutOptions.CenterAndExpand,
			Text = ""
		};

		Image profImg = new Image
		{
			WidthRequest = 150,
			HeightRequest = 150,
		};
		#endregion

		public userPage(user u)
		{
			Content = new ActivityIndicator() { IsRunning = true };
			listView = new itemListView();
			populateProfileFields(u);

			basestack = new StackLayout
			{
				Children = {
					new StackLayout {

						Orientation = StackOrientation.Horizontal,

						Children = {

							profImg,

							new StackLayout {
								VerticalOptions = LayoutOptions.FillAndExpand,
								HorizontalOptions = LayoutOptions.FillAndExpand,
								Children = {
									lblName,
									lblTitle,
								}
							}
						}
					},
					lblStats,
					listView

				}
			};
		}

		public async void populateProfileFields(user u)
		{

			List<item> items = await App.MANAGER.YSSI.GetItemsAssociatedWithUser(u.id);

			int[] fblastatus = await App.MANAGER.YSSI.GetChapterInfoOfUser(u.id);
			if (fblastatus[0] != -1)
			{
				fblaChapter f = await App.MANAGER.YSSI.GetFBLAChapter(fblastatus[0]);
				lblTitle.Text = Constants.DecodeFBLAStatus(fblastatus[1]) + "\n" + f.school + " FBLA";
			}


			listView.ItemsSource = items;
			if (u != null)
			{
				lblName.Text = u.name;
				Title = u.name;
				lblStats.Text = "Donated Items: " + items.Count.ToString();
				try
				{
					profImg.Source = ImageSource.FromUri(new Uri(u.pic_url));
				}
				catch (Exception e)
				{
					System.Diagnostics.Debug.WriteLine("Error: Unable to display profile image!\n{0}\n{1}", e.Message, e.StackTrace);

				}

			}

			Content = basestack;
		}
	}
}

