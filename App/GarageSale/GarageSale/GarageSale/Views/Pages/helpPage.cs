using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GarageSale.Views.Pages
{
	public class helpPage : basePage
	{
		ScrollView sv;
		public helpPage()
		{
			Title = "Help";

			sv = new ScrollView() { };
			Dictionary<string, string> faq = new Dictionary<string, string>() {
				{ "What is this app? ", "This is an app for an FBLA project. It is an app which lets people donate items to sell and the money will go to the FBLA chapter of their choosing. " },
				{ "How to sign up?", "Click on the “sign in” option on the menu and then sign in with your Google account." },
				{ "How to donate an item?", "Sign in under your account. Go to the FBLA chapter that you’d like to help with fundraising under FBLA Chapters. Click on the Donate Item. Put in the name, description, price, and condition of the item. After putting in the information, click on “PUT ITEM FOR SALE!”" },
				{ "How to buy an item?", "Find the item that you would like to purchase. Click on the “BUY ITEM” button and the click “CONTINUE”. A confirmation message will be displayed. Upon continuing, you will receive an email containing contact information of the seller and the chapter advisor for this item. Contact the advisor using the contact information in order to get more instructions.  Payment is to be sent to the payment address via PayPal in the email received from the advisor. No item will be shipped until payment is received.  Please make sure to check your inbox or spam folder for a message from the advisor and reply within two - three business days so the item will be available and confirm your interest in the item." },
				{ "What if the item I bought is not what I wanted?", "We are only the developer of the app, so we cannot guarantee the expectations of the items will be met. However if there is any concern, please contact the seller/advisor before your purchase.  " },
				{ "How to sign your chapter up for the app?", "Contact you FBLA Chapter adviser and have them send an email to thefblayardsale@gmail.com. Said email should contain your schools name, city, and state. Optionally you can attach a photo to the email for your chapters’ page. The subject for the email should be “Chapter Registration”." },
				{ "My chapter is already signed up, how can we receive payments?", "Please have an advisor sign up for a PayPal account. Include the PayPal account in the email when contacting the buyer in order to receive payment.  " },
				{ "I’ve paid for the item through PayPal, what’s next?", "If you’ve paid for the item, shipping fee and sales price, please contact the advisor that the payment is made and they will ship the item to the address you provide in your message.  " },
				{ "What should I include in my email to the buyer as an advisor? ", "Here is a basic format on what to include in the email after receiving a notification that a buyer is interested in your product. Feel free to add any else that is appropriate. Include your name-should be the advisor- and FBLA chapter. The item and its amount to confirm with the buyer they are receiving a respond for the correct item. Include instructions to deposit money into your PayPal account. The amount of days the item will be on hold for. (Recommend 2-3 days for response.) Also include the shipping options for the customer.  After this step the buyer should reply if they are still interested or have paid for the item. Confirm that the payment has been made to the correct account and reply to the buyer with shipping confirmation.  I am the advisor, but I do not have the donated item in my possession? If the donated item is not with the advisor for shipment. Please contact the donor that has the item with the shipping information and directions. A prepaid shipping label is recommended. " },
				{ "Found a problem?", "If there is a problem with the app that you’d like to address, please contact us at thefblayardsale@gmail.com." }
			};

			StackLayout buttons = new StackLayout
			{
				Padding = new Thickness(10),

			};
			sv.Content = buttons;

			foreach (var item in faq)
			{
				buttons.Children.Add(new Button()
				{
					Text = item.Key,
					Command = new Command(() =>
					{
						Navigation.PushAsync(new basePage()
						{
							Title = "Help",
							Style = Style = (Style)Application.Current.Resources["contentPageStyle"],
							Resources = new ResourceDictionary(),
							Content = new StackLayout
							{
								Padding = new Thickness(10),
								Children = {
									new Label {
										HorizontalOptions = LayoutOptions.CenterAndExpand,
										VerticalOptions = LayoutOptions.Start,
										Text = item.Key,
										FontSize = Device.GetNamedSize(NamedSize.Medium,typeof(Label)),
										FontAttributes = FontAttributes.Bold
									},
									new Label {
										HorizontalOptions = LayoutOptions.StartAndExpand,
										VerticalOptions = LayoutOptions.StartAndExpand,
										Text = item.Value
									}
								}
							}

						});
					})
				});
			}

			Content = new StackLayout
			{
				Padding = new Thickness(10),
				Children = {
					new Label { Text = "FAQ", FontSize = Device.GetNamedSize(NamedSize.Large,typeof(Label)), HorizontalOptions = LayoutOptions.CenterAndExpand },
					sv
				}
			};
		}
	}
}
