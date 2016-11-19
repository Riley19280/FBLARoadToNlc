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
		 YardSaleServiceImplementation YSSI;

		public Manager(YardSaleServiceImplementation y) {
			YSSI = y;
			
		}

		public Task<List<myDataTypes.item>> GetAllItems()
		{
			return YSSI.GetAllItems();
		}

	}
}
