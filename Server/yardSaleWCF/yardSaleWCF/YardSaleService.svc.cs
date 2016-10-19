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
	public class YardSaleService : IYardSale
	{
		DatabaseAccess DBACC = new DatabaseAccess();

		public bool addComment(myDataTypes.commentWCF comment)
		{
			return DBACC.addComment(comment);
		}

		public bool createUser(myDataTypes.userWCF user)
		{
			return DBACC.createUser(user);
		}

		public bool updateUserActivity(string user_id)
		{
			return DBACC.updateUserActivity(user_id);
		}
	}
}
