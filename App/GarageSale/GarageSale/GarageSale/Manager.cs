using System;
using System.Collections.Generic;
using System.Linq;
using myDataTypes;
using System.Threading.Tasks;
using yardSaleWCF;

namespace GarageSale
{
	public class Manager
	{
		public YardSaleServiceImplementation YSSI;

		public mediaController MediaContorller;

		public Manager(YardSaleServiceImplementation y) {
			YSSI = y;
			MediaContorller = new mediaController();
		}

	}
}
