using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GarageSale.Views.Pages
{
	public class newItemPage : basePage
	{
		Entry name;
		Editor desc;

		Entry price;

		Picker quality;

		StackLayout baseStack;

		public newItemPage()
		{
			Title = "New Item For sale";

			Button postBtn = new Button
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Text = "Put item for sale!",
			};
			postBtn.Clicked += postBtnClicked;

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
					price,
					quality,
					postBtn

				}
			};

			Content = baseStack;

		}

		bool posted = false;
		private void postBtnClicked(object sender, EventArgs e)
		{

			//App.ORM.GetProfileInfo(App.CredManager.GetCredentials());
			if (!posted && !string.IsNullOrWhiteSpace(name.Text) && !string.IsNullOrWhiteSpace(desc.Text))
			{//FIXME:SET OWNER ID FOR ADD ITEM HERE
				myDataTypes.item act = new myDataTypes.item(0,App.CredManager.GetAccountValue("G_id"),name.Text,desc.Text,"picurl",float.Parse(price.Text),quality.SelectedIndex+1,false,DateTime.Now);
				App.MANAGER.YSSI.AddItem(act);
				posted = true;
				Navigation.PopAsync();

			}
			else
			{
				DisplayAlert("Empty Fields", "Please add a name and/or description to your item", "OK");
			}

		}
	}
}

