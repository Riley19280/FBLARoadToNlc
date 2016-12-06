using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Auth;
using GarageSale.Droid;
using GarageSale.Views.Pages;

[assembly: ExportRenderer(typeof(loginPageModal), typeof(LoginPageRenderer))]

namespace GarageSale.Droid
{

	public class LoginPageRenderer : PageRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);

			// this is a ViewGroup - so should be able to load an AXML file and FindView<>
			var activity = this.Context as Activity;
			AccountStore store = AccountStore.Create(this.Context);
			try
			{
				OAuth2Authenticator auth = new OAuth2Authenticator(
					Constants.ClientId, // your OAuth2 client id
					Constants.Scope, // the scopes for the particular API you're accessing, delimited by "+" symbols
					new Uri(Constants.AuthorizeUrl), // the auth URL for the service
					new Uri(Constants.RedirectUrl)); // the redirect URL for the service

				auth.Completed += (sender, eventArgs) =>
				{
					if (eventArgs.IsAuthenticated)
					{
						// Use eventArgs.Account to do wonderful things
						//App.CredManager.DeleteCredentials();
						store.Save(eventArgs.Account, Constants.AppName);
						
						App.SuccessfulLoginAction.Invoke();

					}
					else // Authentication failed
					{
						Toast.MakeText(this.Context, "Authentication Failed", ToastLength.Long).Show();
					
					}
				};

				
				Account savedAccount = store.FindAccountsForService(Constants.AppName).FirstOrDefault();
				if (savedAccount != null)
				{
					//TODO: check tokens expired? may not be needed bc this is the login page so they couldnt be. should check for login at login button click

				}
				else
				{		
					activity.StartActivity(auth.GetUI(activity));
				};

			}
			catch (Exception ex)
			{
				Toast.MakeText(this.Context, "Error logging in", ToastLength.Long).Show();
				
			}



		}
	}
}