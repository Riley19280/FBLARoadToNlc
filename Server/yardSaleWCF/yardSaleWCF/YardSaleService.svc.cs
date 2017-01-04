using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace yardSaleWCF
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	[ServiceBehavior(IgnoreExtensionDataObject = true)]
	public class YardSaleService : IYardSale
	{
		DatabaseAccess DBACC = new DatabaseAccess();

		public bool AddComment(commentWCF comment)
		{
			return DBACC.AddComment(comment);
		}

		public bool UpdateUser(userWCF user)
		{
			return DBACC.UpdateUser(user);
		}

		public bool UpdateUserActivity(string user_id)
		{
			return DBACC.UpdateUserActivity(user_id);
		}

		public List<itemWCF> GetAllItems()
		{
			return DBACC.GetAllItems();
		}

		public bool AddItem(itemWCF item)
		{
			return DBACC.AddItem(item);
		}

		public bool AddBid(bidWCF bid)
		{
			return DBACC.AddBid(bid);
		}

		public bidWCF GetTopBid(int item_id)
		{
			return DBACC.GetTopBid(item_id);
		}

		public userWCF GetUser(string id)
		{
			return DBACC.GetUser(id);
		}

		public List<commentWCF> GetComments(int item_id)
		{
			return DBACC.GetComments(item_id);
		}

		public List<itemWCF> GetSearchedItems(string search)
		{
			return DBACC.GetSearchedItems(search);
		}

		public List<userWCF> GetSearchedUsers(string search)
		{
			return DBACC.GetSearchedUsers(search);
		}

		public List<itemWCF> GetItemsAssociatedWithUser(string user_id)
		{
			return DBACC.GetItemsAssociatedWithUser(user_id);
		}

		public List<itemWCF> GetFBLAChapterItems(int chapter_id)
		{
			return DBACC.GetFBLAChapterItems(chapter_id);
		}

		public List<userWCF> GetUsersByChapterStatus(int status, int chapter_id)
		{
			return DBACC.GetUsersByChapterStatus(status, chapter_id);
		}

		public bool SetChapterStatusOfUser(int status, string user_id)
		{
			return DBACC.SetChapterStatusOfUser(status, user_id);
		}

		public List<fblaChapterWCF> GetSearchedChapters(string search)
		{
			return DBACC.GetSearchedChapters(search);
		}

		public fblaChapterWCF GetFBLAChapter(int id)
		{
			return DBACC.GetFBLAChapter(id);
		}

		public bool SetFBLAChapterPicture(int id, byte[] picture)
		{
			return DBACC.SetFBLAChapterPicture(id, picture);
		}

		public int[] GetChapterInfoOfUser(string user_id)
		{
			return DBACC.GetChapterInfoOfUser(user_id);
		}

		public bool processbuyRequest(string user_id, int item_id )
		{

			itemWCF item = DBACC.GetItem(item_id);
			userWCF owner = GetUser(item.owner_id);
			userWCF client = GetUser(user_id);//the user buying the item	
			fblaChapterWCF fbla = GetFBLAChapter(item.chapter_id);

			string clientMailingMessage = string.Format("You are recieving this message because you showed an intrest in buying an item on The FBLA Fundraising app.\nItem Name: {0} \nItem Description: {1}  \nItem Price: ${2} \nItem Quality: {3} \n\nIn Order to proceed with your order, a payment of ${2} is required to be sent to the following Paypal address: \n\nPaypal Address: {4} \nContact Address: {5} \n\nAny furthur questions should be sent to the contact email listed above, as any emails sent to this addres will not be replied to.", item.name, item.description, item.price, item.quality, fbla.payment_email, fbla.contact_email);
			string ownerMailingMessage = string.Format("You are recieving this message because someone purchased an item that you listed on The FBLA Fundraising App \nItem Name: {0} \nItem Description: {1}  \nItem Price: ${2} \nItem Quality: {3} \n If your FBLA Chapter advisor is in posession of this item, you can ignore this message. Otherwise, look for an email from The FBLA Chapter of which you have donated this item for a shipping address, and be prepared to ship this item. ", item.name, item.description, item.price, item.quality);
			string adviserMailingMessage = string.Format("You are recieving this message because someone purchased an item from your FBLA Chapter on The FBLA Fundraising App \nItem Name: {0} \nItem Description: {1}  \nItem Price: ${2} \nItem Quality: {3} \n\nAs the chapter adviser of {4} FBLA, you are responsible for getting the item to the person who bought it. You should check the paypal account at <b>{5}</b> to confirm that adequate payment has been made before shipping the items to the adress listed in the paypal reciept message. In the case that you are not in posession of the item, you should sent the shipping address to the item owner at {6} to allow them to ship the item.", item.name, item.description, item.price, item.quality, fbla.school, fbla.payment_email, owner.email);

			string apptitle = "FBLA NLC Fundraising";

			//send email to client
			mailing.sendMail(client.email, "Item on "+apptitle, clientMailingMessage);
			//sent email to item owner 
			mailing.sendMail(owner.email, "Items on " + apptitle + " bougnt.", ownerMailingMessage);
			//send email to chapter adviser
			//mailing.sendMail(fbla.contact_email, "Items on " + apptitle + " bougnt.", adviserMailingMessage);

			DBACC.setItemSellStatus(item.id, 1);
			return true;
		}
	}
}
