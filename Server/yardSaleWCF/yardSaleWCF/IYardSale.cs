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
		bool createUser(myDataTypes.userWCF user);

		[OperationContract]
		bool updateUserActivity(string user_id);

		[OperationContract]
		bool addComment(myDataTypes.commentWCF comment);

	}

}
