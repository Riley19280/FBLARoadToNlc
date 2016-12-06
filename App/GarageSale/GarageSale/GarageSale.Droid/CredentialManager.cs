using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Auth;

[assembly: Xamarin.Forms.Dependency(typeof(GarageSale.Droid.CredentialManager))]
namespace GarageSale.Droid
{
	public class CredentialManager : ICredentialManager
	{
		public bool AccountValueExists(string key)
		{
			Account acct = GetCredentials();

			if (acct == null)
				return false;
			if (!acct.Properties.ContainsKey(key))
				return false;
			else
				return true;

		}

		public bool DeleteCredentials()
		{
			List<Account> accounts = AccountStore.Create(Forms.Context).FindAccountsForService(Constants.AppName).ToList();

			accounts.ForEach(delegate (Account a)
			{
				AccountStore.Create(Forms.Context).Delete(a, Constants.AppName);
			});

			return true;
		}

		public string GetAccountValue(string key)
		{
			Account acct = GetCredentials();
			string s = (acct != null) ? acct.Properties[key] : null;
			return s;
		}

		public Account GetCredentials()
		{
			Account a = AccountStore.Create(Forms.Context).FindAccountsForService(Constants.AppName).FirstOrDefault();
			return a;
		}

		public bool IsLoggedIn()
		{
			Account acct = GetCredentials();
			if (acct != null)
			{
				if (acct.Properties.ContainsKey("G_id"))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		public bool RequestRefreshTokenAsync(string refreshToken)
		{
			return false;
			var queryValues = new Dictionary<string, string>{
				{"refresh_token", refreshToken},
				{"client_id", Constants.ClientId},
				{"grant_type", "refresh_token"}};

			if (!string.IsNullOrEmpty(Constants.ClientSecret))
			{
				queryValues["client_secret"] = Constants.ClientSecret;
			}

			var c = GetCredentials().Properties["access_token"];

		}

		public bool UpdateAccountValue(string key, string value)
		{
			Account acct = GetCredentials();

			if (acct == null)
				return false;
			if (!acct.Properties.ContainsKey(key))
			{
				acct.Properties.Add(key, value.ToString());

			}
			else
			{
				acct.Properties[key] = value.ToString();
			}
			AccountStore.Create(Forms.Context).Save(acct, Constants.AppName);
			return true;
		}
	}
}