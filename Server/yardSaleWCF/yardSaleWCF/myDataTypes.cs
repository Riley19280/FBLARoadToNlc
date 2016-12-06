using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace yardSaleWCF
{
	//member status:
	//0:pending membership
	//1:member
	//2:secritary
	//3:VP
	//4:Pres
	//10:Admin

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
		[DataMember]
		public int id { get; protected set; }
		[DataMember]
		public string owner_id { get; protected set; }
		[DataMember]
		public string name { get; protected set; }
		[DataMember]
		public string description { get; protected set; }
		[DataMember]
		public string pic_url { get; protected set; }
		[DataMember]
		public float price { get; protected set; }
		[DataMember]
		public float quality { get; protected set; }
		[DataMember]
		public bool sold { get; protected set; }
		[DataMember]
		public DateTime date_added { get; protected set; }
	}

	[DataContract]
	public class userWCF
	{
		public userWCF(string id, string name, string email, string pic_url,int FBLA_chapter_id=-1)
		{

			this.id = id;
			this.name = name;
			this.email = email;
			this.pic_url = pic_url;
			this.FBLA_chapter_id = FBLA_chapter_id;
		}
		[DataMember]
		public string id { get; protected set; }
		[DataMember]
		public string name { get; protected set; }
		[DataMember]
		public string email { get; protected set; }
		[DataMember]
		public string pic_url { get; protected set; }
		[DataMember]
		public int FBLA_chapter_id { get; protected set; }

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
		[DataMember]
		public int id { get; protected set; }
		[DataMember]
		public int item_id { get; protected set; }
		[DataMember]
		public string user_id { get; protected set; }
		[DataMember]
		public string comment { get; protected set; }
		[DataMember]
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
		[DataMember]
		public int id { get; protected set; }
		[DataMember]
		public int item_id { get; protected set; }
		[DataMember]
		public string bidder_id { get; protected set; }
		[DataMember]
		public float amount { get; protected set; }

	}

	[DataContract]
	public class fblaChapterWCF
	{

		public fblaChapterWCF(int id, string name, string state, string city, string school, string contact_email, string payment_email, string pic_url)
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
		[DataMember]
		public int id;
		[DataMember]
		public string name;
		[DataMember]
		public string state;
		[DataMember]
		public string city;
		[DataMember]
		public string school;
		[DataMember]
		public string contact_email;
		[DataMember]
		public string payment_email;
		[DataMember]
		public string pic_url;
	}
}