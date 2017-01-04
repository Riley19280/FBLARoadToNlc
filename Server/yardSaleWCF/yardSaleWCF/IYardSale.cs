using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace yardSaleWCF
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
	[ServiceContract]
	public interface IYardSale
	{

		[OperationContract]
		bool UpdateUser(userWCF user);

		[OperationContract]
		bool UpdateUserActivity(string user_id);

		[OperationContract]
		bool AddComment(commentWCF comment);

		[OperationContract]
		bool AddItem(itemWCF item);
		
		[OperationContract]
		bool AddBid(bidWCF bid);

		[OperationContract]
		bidWCF GetTopBid(int item_id);

		[OperationContract]
		List<itemWCF> GetAllItems();

		[OperationContract]
		userWCF GetUser(string id);

		[OperationContract]
		List<commentWCF> GetComments(int item_id);

		[OperationContract]
		List<itemWCF> GetSearchedItems(string search);

		[OperationContract]
		List<userWCF> GetSearchedUsers(string search);

		[OperationContract]
		List<itemWCF> GetItemsAssociatedWithUser(string user_id);

		[OperationContract]
		List<itemWCF> GetFBLAChapterItems(int chapter_id);

		[OperationContract]
		List<userWCF> GetUsersByChapterStatus(int status, int chapter_id);

		[OperationContract]
		bool SetChapterStatusOfUser(int status, string user_id);

		[OperationContract]
		List<fblaChapterWCF> GetSearchedChapters(string search);

		[OperationContract]
		fblaChapterWCF GetFBLAChapter(int id);

		[OperationContract]
		bool SetFBLAChapterPicture(int id, byte[] picture);

		[OperationContract]
		int[] GetChapterInfoOfUser(string user_id);

		[OperationContract]
		bool processbuyRequest(string user_id, int item_id);
	}
}
