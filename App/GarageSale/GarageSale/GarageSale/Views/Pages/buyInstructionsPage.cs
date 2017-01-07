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
					//TODO: write buy instructions, include fbla.payment email, no items shipped until payment recieve
					new Label { Text = string.Format("How it works- Upon continuing, you will recieve an email containing a payment email and contact email for this item. Payment of {0} is to be sent to the payment address via paypal in the email you delievered shortly. Any furthur issues after that point should be handled through the contact email given. No items will be shipped until payment is recieved.",item.price) },

					new Button {
						Text = "Continue",
						HorizontalOptions = LayoutOptions.FillAndExpand,
						VerticalOptions = LayoutOptions.End,
							Command = new Command(async()=> {
								//todo: send server info to distribute
								bool sucess = await App.MANAGER.YSSI.ProcessBuyRequest(App.CredManager.GetAccountValue("G_id"), item.id);
								if(sucess)
								{
									await DisplayAlert("Order placed","Your order has been placed. please check your email shortly.","Dismiss");
									Navigation.PopAsync();
								}
								else
								{
									await DisplayAlert("Error","There was an error processing your order.","Dismiss");
									Navigation.PopAsync();
								}
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

