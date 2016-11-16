using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ServiceModel;
using myDataTypes;
using yardSaleWCF;
namespace GarageSale
{
	public class YardSaleServiceImplementation
	{
		YardSaleClient service;

		public YardSaleServiceImplementation() {
			try
			{
				YardSaleClient c = new YardSaleClient(
				new BasicHttpBinding(),
				new EndpointAddress(Constants.WCFURL));
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
				Debug.WriteLine(e.StackTrace);

			}
		}

		public async Task<List<item>> GetAllItems() {
			List<item> Items = new List<item>();

			try
			{
				var todoItems = await Task.Factory.FromAsync(service.BeginGetAllItems,service.EndGetAllItems, null, TaskCreationOptions.None);

				foreach (var item in todoItems)
				{
					if (item != null)
						Items.Add(convertFromWCF(item));
					else
					{
						Debug.WriteLine("NULL ITEM");
					}
				}
			}
			catch (FaultException fe)
			{
				Debug.WriteLine(@"			{0} \n {1} \n {2}", fe.Message, fe.Reason, fe.StackTrace);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0} \n {1}", ex.Message, ex.StackTrace);
			}

			return Items;
		}



		#region From
		item convertFromWCF(itemWCF i)
		{
			return new item(i.id, i.owner_id, i.name, i.description, i.pic_url, i.price, i.quality, i.sold, i.date_added);
		}
		user convertFromWCF(userWCF u)
		{
			return new user(u.id, u.name, u.pic_url);
		}
		comment convertFromWCF(commentWCF c)
		{
			return new comment(c.id, c.item_id, c.user_id, c.comment, c.date_added);
		}
		#endregion

		#region TO

		itemWCF convertToWCF(item i)
		{
			itemWCF item = new itemWCF();

			item.id = i.id;
			item.owner_id = i.owner_id;
			item.name = i.name;
			item.description = i.description;
			item.pic_url = i.pic_url;
			item.price = i.price;
			item.quality = i.quality;
			item.sold = i.sold;
			item.date_added = i.date_added;

			return item;
		}
		userWCF convertToWCF(user u)
		{
			userWCF user = new userWCF();

			user.id = u.id;
			user.name = u.name;
			user.pic_url = u.pic_url;

			return user;
		}
		commentWCF convertToWCF(comment c)
		{
			commentWCF comment = new commentWCF();

			comment.id = c.id;
			comment.item_id = c.item_id;
			comment.user_id = c.user_id;
			comment.comment = c.comments;
			comment.date_added = c.date_added;

			return comment;
		}
		#endregion

	}
}
