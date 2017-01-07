using Android.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Controls;
using XLabs.Platform.Services.Media;

namespace GarageSale.Views.Pages
{
	public class newItemPage : basePage
	{
		ExtendedEntry name;
		ExtendedEditor desc;

		ExtendedEntry price;

		Label condition;
		CustomImageView image;
		StackLayout baseStack;

		byte[] pic = new byte[0];
		int fbla_id;

		public newItemPage(int fbla_id)
		{
			Title = "New Item For sale";

			this.fbla_id = fbla_id;

			Button postBtn = new Button
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Text = "Put item for sale!",
				VerticalOptions = LayoutOptions.End
			};
			postBtn.Clicked += postBtnClicked;


			Button cameraBtn = new Button
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.End,
				Text = "Add A picture",
			};
			cameraBtn.Clicked += cameraBtnClicked;

			name = new ExtendedEntry
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Placeholder = "Enter item Name"
			};

			desc = new ExtendedEditor
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.StartAndExpand,
				HeightRequest = 50
			};

			condition = new Label
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.End,
				HorizontalTextAlignment = TextAlignment.Center,
				BackgroundColor = Constants.palette.primary_variant,
				Text = "Select Condition",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HeightRequest = 30

			};
			condition.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(async () =>
				{
					var action = await DisplayActionSheet("Select Condition", "Cancel", null, "\u2605", "\u2605\u2605", "\u2605\u2605\u2605", "\u2605\u2605\u2605\u2605", "\u2605\u2605\u2605\u2605\u2605");
					switch (action)
					{
						case "Cancel":
							condition.Text = "\u2605\u2605\u2605";
							break;
						default:
							condition.Text = action;
							break;
					}
				}),
			});

			image = new CustomImageView
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 100,
				//Aspect = Aspect.AspectFit,
			};

			price = new ExtendedEntry
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.End,
				Placeholder = "Enter Price",
				Keyboard = Keyboard.Numeric
			};

			baseStack = new StackLayout
			{
				Padding = new Thickness(25),
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Fill,
				Children = {
					name,

					new Label {
						HorizontalOptions = LayoutOptions.FillAndExpand,
						Text = "Item Description"
					},

					desc,
					image,
					price,
					condition,
					cameraBtn,
					postBtn

				}
			};

			Content = baseStack;

		}

		private async void cameraBtnClicked(object sender, EventArgs e)
		{
			var action = await DisplayActionSheet("Take or select photo", "Cancel", null, "Take Picture", "Select picture");
			MediaFile m = null;
			switch (action)
			{
				case "Take Picture":
					m = await App.MANAGER.MediaContorller.TakePicture();
					break;
				case "Select picture":
					m = await App.MANAGER.MediaContorller.SelectPicture();
					break;
			}

			if (m == null) { return; }

			IImageProcessing processer = DependencyService.Get<IImageProcessing>();


			Bitmap b = await processer.ScaleBitmap(m.Source, await processer.GetBitmapOptionsOfImageAsync(m.Source), 200, 200);
			image.SetImageBitmap(b);
			pic = processer.compress(b);
			m.Dispose();

		}

		bool posted = false;
		private async void postBtnClicked(object sender, EventArgs e)
		{

			//App.ORM.GetProfileInfo(App.CredManager.GetCredentials());
			if (!posted && !string.IsNullOrWhiteSpace(name.Text) && !string.IsNullOrWhiteSpace(desc.Text) && price.Text != null)
			{
				myDataTypes.item act = new myDataTypes.item(0, App.CredManager.GetAccountValue("G_id"), fbla_id, name.Text, desc.Text, pic, float.Parse(price.Text), condition.Text.Length > 5 ? 3 : condition.Text.Length, 0, DateTime.Now);

				bool success = await App.MANAGER.YSSI.AddItem(act);

				if (success)
				{
					await DisplayAlert("Item added sucessfully", "Your item was added sucessfully!", "OK");
					App.rootPage.menuPage.SendBackButtonPressed();

				}
				else
					await DisplayAlert("Error adding item", "There was an error adding your item. Please try again", "OK");
			}
			else
			{
				await DisplayAlert("Empty Fields", "Please add a name, description or price to your item", "OK");
			}

		}

		public byte[] ReadFully(Stream input)
		{
			byte[] buffer = new byte[16 * 1024];
			using (MemoryStream ms = new MemoryStream())
			{
				int read;
				while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
				{
					ms.Write(buffer, 0, read);
				}
				return ms.ToArray();
			}
		}

	}
}

