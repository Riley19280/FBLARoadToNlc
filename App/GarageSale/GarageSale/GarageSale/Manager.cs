using System;
using System.Collections.Generic;
using System.Linq;
using myDataTypes;
using System.Threading.Tasks;

namespace GarageSale
{
	public class Manager
	{
		private YardSaleServiceImplementation YSS;

		public Manager(YardSaleServiceImplementation y) {
			YSS = y;
		}

		public Task<List<item>> GetAllItems() {
			return YSS.GetAllItems();
		}

	}
}
