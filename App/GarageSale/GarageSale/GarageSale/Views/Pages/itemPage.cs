using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GarageSale.Views.Pages
{
	class itemPage : basePage
	{

		myDataTypes.item item;

		StackLayout baseStack;

		#region Views

		Label lblDesc = new Label
		{
			Text = "Description:\n",

			HorizontalOptions = LayoutOptions.CenterAndExpand
		};

		Label lblPrice = new Label
		{
			HorizontalOptions = LayoutOptions.CenterAndExpand,
			Text = ""
		};

		Label lblCondition = new Label
		{
			HorizontalOptions = LayoutOptions.CenterAndExpand,
			Text = "Condition: "
		};

		CustomImageView profImg = new CustomImageView
		{
			HorizontalOptions = LayoutOptions.FillAndExpand,
			VerticalOptions = LayoutOptions.FillAndExpand,
			HeightRequest = 300,
			Aspect = Aspect.AspectFit,
		};

		Button viewComments = new Button
		{
			Text = "View Comments",
			BorderRadius = 0,
			//Margin = 0,
			HorizontalOptions = LayoutOptions.FillAndExpand
		};

		Button buyBtn = new Button
		{
			Text = "Buy Item",
			BorderRadius = 0,
			//Margin = 0,
			IsEnabled = false,
			HorizontalOptions = LayoutOptions.FillAndExpand,

		};

		#endregion

		public itemPage(myDataTypes.item i)
		{
			item = i;
			Title = i.name;


			if (App.CredManager.IsLoggedIn())
			{
				int fblaid = -1;
				int.TryParse(App.CredManager.GetAccountValue("FBLA_chapter_id"), out fblaid);

				if (fblaid == item.chapter_id)
				{
					if (int.Parse(App.CredManager.GetAccountValue("FBLA_status")) > 5)
					{
						addToolbarItem();
					}
				}
				if (App.CredManager.GetAccountValue("G_id") == item.owner_id)
				{
					addToolbarItem();
				}

			}
			viewComments.Clicked += (s, e) =>
			{
				Navigation.PushAsync(new commentPage(i.id));
			};

			buyBtn.Clicked += (s, e) =>
			{
				Navigation.PushAsync(new buyInstructionsPage(i));
			};

			#region basestack
			baseStack = new StackLayout
			{
				Padding = new Thickness(10),
				Children = {
					new StackLayout {
						VerticalOptions = LayoutOptions.FillAndExpand,
						HorizontalOptions = LayoutOptions.FillAndExpand,
						Children = {
							profImg,
							lblDesc,
							lblPrice,
							lblCondition,
							buyBtn,
							viewComments
						}
					}
				}
			};
			#endregion

			lblDesc.Text += i.description;

			CultureInfo culture = new CultureInfo("en-us");
			culture.NumberFormat.CurrencyNegativePattern = 1;

			lblPrice.Text = string.Format(culture, "{0:c2}", item.price);







			//profImg.Source = ImageSource.FromStream(() => new MemoryStream(i.picture));

			//giving stars to rating
			string st = "";
			for (int j = 0; j < item.quality; j++)
			{
				st += "\u2605";
			}
			lblCondition.Text += st;
			Content = baseStack;

		}

		bool toolbarDeleteItemAdded = false;
		void addToolbarItem()
		{
			if (toolbarDeleteItemAdded)
				return;
			toolbarDeleteItemAdded = true;
			ToolbarItems.Add(new ToolbarItem("Delete Item", "@drawable/x", async () =>
			{
				bool answer = await DisplayAlert("Delete Item", "Are you sure you want to delete this Item?", "Yes", "No");
				if (answer)
				{
					App.MANAGER.YSSI.DeleteItem(item.id);
					Navigation.PopAsync();

				}
			}));
		}



		protected override async void OnAppearing()
		{

			IImageProcessing processer = DependencyService.Get<IImageProcessing>();
			profImg.SetImageBitmap(await processer.ScaleBitmap(item.picture, await processer.GetBitmapOptionsOfImageAsync(item.picture), 200, 200));

			if (App.CredManager.IsLoggedIn())
			{
				buyBtn.IsEnabled = true;
				buyBtn.Text = "Buy Item";
			}
			else
			{
				buyBtn.IsEnabled = false;
				buyBtn.Text = "Log in to buy Item";
			}
		}
	}

}

