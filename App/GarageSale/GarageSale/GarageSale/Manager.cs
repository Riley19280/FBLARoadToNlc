
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace GarageSale
{
	public class Manager
	{
		public YardSaleServiceImplementation YSSI;

		public mediaController MediaContorller;

		public Manager(YardSaleServiceImplementation y)
		{
			YSSI = y;
			MediaContorller = new mediaController();
		}


		}
	}

