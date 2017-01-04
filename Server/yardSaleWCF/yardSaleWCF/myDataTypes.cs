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
	//2:Parliamentarian
	//3:Treasurer
	//4:Secretary
	//5:Vice-President
	//6:President
	//10:Admin

	[DataContract]
	public class itemWCF
	{

		public itemWCF(int id, string owner_id,int chapter_id, string name, string description, byte[] picture, float price, float quality, int sold, DateTime date_added)
		{
			this.id = id;
			this.owner_id = owner_id;
			this.chapter_id = chapter_id;
			this.name = name;
			this.description = description;
			this.picture = picture;
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
		public int chapter_id { get; protected set; }
		[DataMember]
		public string name { get; protected set; }
		[DataMember]
		public string description { get; protected set; }
		[DataMember]
		public byte[] picture { get; set; }
		[DataMember]
		public float price { get; protected set; }
		[DataMember]
		public float quality { get; protected set; }
		[DataMember]
		public int sold { get; protected set; }
		[DataMember]
		public DateTime date_added { get; protected set; }
	}

	[DataContract]
	public class userWCF
	{
		public userWCF(string id, string name, string email, string pic_url)
		{
			this.id = id;
			this.name = name;
			this.email = email;
			this.pic_url = pic_url;		
		}
		[DataMember]
		public string id { get; protected set; }
		[DataMember]
		public string name { get; protected set; }
		[DataMember]
		public string email { get; protected set; }
		[DataMember]
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

		public fblaChapterWCF(int id, string name, string state, string city, string school, string contact_email, string payment_email, byte[] picture)
		{
			this.id = id;
			this.name = name;
			this.state = state;
			this.city = city;
			this.school = school;
			this.contact_email = contact_email;
			this.payment_email = payment_email;
			this.picture = picture;
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
		public byte[] picture;
	}
}