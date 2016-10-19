using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace yardSaleWCF
{
	public class myDataTypes
	{
		[DataContract]
		public class itemWCF
		{
			public itemWCF(int id, string owner_id, string name, string description, string pic_url, float price, float quality, bool sold, DateTime date_added)
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

		[DataContract]
		public class userWCF
		{
			public userWCF(string id, string name, string pic_url)
			{

				this.id = id;
				this.name = name;
				this.pic_url = pic_url;
			}

			public string id { get; protected set; }
			public string name { get; protected set; }
			public string pic_url { get; protected set; }
		}

		[DataContract]
		public class commentWCF
		{
			public commentWCF(int id, int item_id, string user_id, string comment, DateTime date_added)
			{
				this.id = id;
				this.item_id = item_id;
				this.user_id = user_id;
				this.comment = comment;
				this.date_added = date_added;
			}

			public int id { get; protected set; }
			public int item_id { get; protected set; }
			public string user_id { get; protected set; }
			public string comment { get; protected set; }
			public DateTime date_added { get; protected set; }

		}

		[DataContract]
		public class bidWCF
		{

			public bidWCF(int id, int item_id, string bidder_id, float amount)
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


	}
}