using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GarageSale
{

	[DataContract]
	public class GoogleInfo
	{
		[DataMember]
		public string id { get; set; }
		[DataMember]
		public string name { get; set; }
		[DataMember]
		public string email { get; set; }
		[DataMember]
		public string given_name { get; set; }
		[DataMember]
		public string family_name { get; set; }
		[DataMember]
		public string link { get; set; }
		[DataMember]
		public string picture { get; set; }
		[DataMember]
		public string locale { get; set; }

	}
}
