using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Platform.Services.Media;

namespace GarageSale.Views.Pages
{
	public class newItemPage : basePage
	{
		Entry name;
		Editor desc;

		Entry price;

		Picker quality;
		Image image;
		StackLayout baseStack;

		byte[] pic = new byte[0];

		public newItemPage()
		{
			Title = "New Item For sale";

			Button postBtn = new Button
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Text = "Put item for sale!",
			};
			postBtn.Clicked += postBtnClicked;


			Button cameraBtn = new Button
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Text = "Add A picture",
			};
			cameraBtn.Clicked += cameraBtnClicked;

			name = new Entry
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Placeholder = "Enter item Name"
			};

			desc = new Editor
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand

			};

			quality = new Picker
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Title = "Quality",
			};
			quality.Items.Add("\u2605");
			quality.Items.Add("\u2605\u2605");
			quality.Items.Add("\u2605\u2605\u2605");
			quality.Items.Add("\u2605\u2605\u2605\u2605");
			quality.Items.Add("\u2605\u2605\u2605\u2605\u2605");

			image = new Image
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				WidthRequest= 300,
				HeightRequest= 300
			};

			price = new Entry
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Placeholder = "Enter Price",
				Keyboard = Keyboard.Numeric
			};

			baseStack = new StackLayout
			{
				Padding = new Thickness(25),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = {
					name,

					new Label {
						HorizontalOptions = LayoutOptions.FillAndExpand,
						Text = "Item Description"
					},

					desc,
					image,
					price,
					quality,
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


			image.Source = ImageSource.FromStream(() => m.Source);
			pic = ReadFully(m.Source);
			
		}

		bool posted = false;
		private void postBtnClicked(object sender, EventArgs e)
		{

			//App.ORM.GetProfileInfo(App.CredManager.GetCredentials());
			if (!posted && !string.IsNullOrWhiteSpace(name.Text) && !string.IsNullOrWhiteSpace(desc.Text))
			{//FIXME:SET OWNER ID FOR ADD ITEM HERE
				myDataTypes.item act = new myDataTypes.item(0, App.CredManager.GetAccountValue("G_id"), name.Text, desc.Text, pic, float.Parse(price.Text), quality.SelectedIndex + 1, false, DateTime.Now);
				App.MANAGER.YSSI.AddItem(act);
				//todo:posted = true;
				//Navigation.PopAsync();

			}
			else
			{
				DisplayAlert("Empty Fields", "Please add a name and/or description to your item", "OK");
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

