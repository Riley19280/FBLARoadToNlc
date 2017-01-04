using myDataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GarageSale.Views.Pages
{
	public class buyInstructionsPage : basePage
	{
		item item;
		fblaChapter fbla;
		public buyInstructionsPage(item i)
		{
			this.item = i;
			Content = new StackLayout
			{
				Children = {
					//TODO: write buy instructions, include fbla.payment email, no items shipped until payment recieved
					new Label { Text = "WRITE INSTRUCTIONS HERE" },
					new Button {
						Text = "Continue",
						HorizontalOptions = LayoutOptions.FillAndExpand,
						VerticalOptions = LayoutOptions.End,
							Command = new Command(()=> {
								//todo: send server info to distribute
								//Device.OpenUri(new Uri("mailto:"+fbla.contact_email+"?subject=Buy Request: " + item.name + "&body=Hello! I would like to buy "+item.name+" from your yardsale. The item is listed for "+item.price+"dollars. I would like it shipped to <b>[you should enter a shipping address here]</b>."));
							})
					},
					new Button {
						Text = "Cancel",
						HorizontalOptions = LayoutOptions.FillAndExpand,
						VerticalOptions = LayoutOptions.End,
						Command = new Command(()=> {
							Navigation.PopAsync();
						})
					}
				}
			};
		}

		protected async override void OnAppearing()
		{
			fbla = await App.MANAGER.YSSI.GetFBLAChapter(item.chapter_id);
		}

	}
}

