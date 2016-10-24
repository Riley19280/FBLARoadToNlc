using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageSale.YardSaleServiceRefrence;

namespace GarageSale
{
	public class myDataTypes
	{
		public class item
		{
			public item(int id, string owner_id, string name, string description, string pic_url, float price, float quality, bool sold, DateTime date_added)
			{
				this.id = id;
				this.owner_id = owner_id;
				this.name = name;
				this.description = description;
				this.pic_url = pic_url;
				this.price = price;
				this.quality = quality;
				this.sold = sold;
				this.date_added = date_added;

			}

			public int id { get; protected set; }
			public string owner_id { get; protected set; }
			public string name { get; protected set; }
			public string description { get; protected set; }
			public string pic_url { get; protected set; }
			public float price { get; protected set; }
			public float quality { get; protected set; }
			public bool sold { get; protected set; }
			public DateTime date_added { get; protected set; }
		}

		public class user
		{
			public user(string id, string name, string pic_url)
			{

				this.id = id;
				this.name = name;
				this.pic_url = pic_url;
			}

			public string id { get; protected set; }
			public string name { get; protected set; }
			public string pic_url { get; protected set; }
		}

		public class comment
		{
			public comment(int id, int item_id, string user_id, string comment, DateTime date_added)
			{
				this.id = id;
				this.item_id = item_id;
				this.user_id = user_id;
				this.comments = comment;
				this.date_added = date_added;
			}

			public int id { get; protected set; }
			public int item_id { get; protected set; }
			public string user_id { get; protected set; }
			public string comments { get; protected set; }
			public DateTime date_added { get; protected set; }

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
			return new comment(c.id, c.item_id,c.user_id, c.comment, c.date_added);
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
