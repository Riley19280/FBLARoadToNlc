using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myDataTypes
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
		public user(string id, string name, string email, string pic_url, int FBLA_chapter_id = -1)
		{

			this.id = id;
			this.name = name;
			this.email = email;
			this.pic_url = pic_url;
			this.FBLA_chapter_id = FBLA_chapter_id;
		}

		public string id { get; protected set; }
		public string name { get; protected set; }
		public string email { get; protected set; }
		public string pic_url { get; protected set; }
		public int FBLA_chapter_id { get; protected set; }
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

	public class bid
	{

		public bid(int id, int item_id, string bidder_id, float amount)
		{
			this.id = id;
			this.item_id = item_id;
			this.bidder_id = bidder_id;
			this.amount = amount;
		}
		public int id { get; protected set; }
		public int item_id { get; protected set; }
		public string bidder_id { get; protected set; }
		public float amount { get; protected set; }

	}

	public class fblaChapter
	{

		public fblaChapter(int id, string name, string state, string city, string school, string contact_email, string payment_email, string pic_url)
		{
			this.id = id;
			this.name = name;
			this.state = state;
			this.city = city;
			this.school = school;
			this.contact_email = contact_email;
			this.payment_email = payment_email;
			this.pic_url = pic_url;
		}

		public int id;

		public string name;

		public string state;

		public string city;

		public string school;

		public string contact_email;

		public string payment_email;

		public string pic_url;
	}

}
