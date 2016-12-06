using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;

namespace GarageSale
{
	public interface ICredentialManager
	{

		bool DeleteCredentials();
		Account GetCredentials();
		bool RequestRefreshTokenAsync(string refreshToken);
		bool UpdateAccountValue(string key, string value);		
		string GetAccountValue(string key);
		bool IsLoggedIn();
		bool AccountValueExists(string key);


	}
}
