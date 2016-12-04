using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;

using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;

namespace GarageSale
{
	public class OAuthReqManager
	{
		public async Task<bool> GetProfileInfo()
		{
			try
			{
				OAuth2Request request = new OAuth2Request("GET", new Uri(Constants.UserInfoURL), null, App.CredManager.GetCredentials());

				Response response = await request.GetResponseAsync();

				if (response == null)
				{
					return false;
				}
				else
				{
					string userJson = response.GetResponseText();

					using (Stream s = GenerateStreamFromString(userJson))
					{
						DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(GoogleInfo));
						GoogleInfo gi = (GoogleInfo)ser.ReadObject(s);
						if (gi == null)
						{
							return false;
						}
						else
						{
							App.CredManager.UpdateAccountValue("G_id", gi.id);
							App.CredManager.UpdateAccountValue("G_name", gi.name);
							App.CredManager.UpdateAccountValue("G_email", gi.email);
							App.CredManager.UpdateAccountValue("G_picture", gi.picture);
						}
						return true;
					}
				}

			}
			catch (Exception ex)
			{
				throw new Exception("Failed saving google profile info\n\n\n" + ex.Message + "\n\n\n" + ex.StackTrace);
			}

		}

		Stream GenerateStreamFromString(string s)
		{
			MemoryStream stream = new MemoryStream();
			StreamWriter writer = new StreamWriter(stream);
			writer.Write(s);
			writer.Flush();
			stream.Position = 0;
			return stream;
		}
	}
}
