using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ServiceModel;
using myDataTypes;
using yardSaleWCF;
namespace GarageSale
{
	public class YardSaleServiceImplementation
	{
		YardSaleClient service;
		public YardSaleServiceImplementation()
		{
			try
			{
				BasicHttpBinding httpBinding = new BasicHttpBinding()
				{
					MaxReceivedMessageSize = 3000000,
					MaxBufferSize = 3000000,
					SendTimeout = TimeSpan.FromMinutes(10),
					OpenTimeout = TimeSpan.FromMinutes(10),
					ReceiveTimeout = TimeSpan.FromMinutes(10),
					CloseTimeout = TimeSpan.FromMinutes(10)
				};

				service = new YardSaleClient(
				httpBinding,
				new EndpointAddress(Constants.WCFURL));
			}
			catch (Exception e)
			{

				Debug.WriteLine(e.Message);
				Debug.WriteLine(e.StackTrace);

			}
		}

		public async Task<List<item>> GetAllItems()
		{
			List<item> Items = new List<item>();
			try
			{
				var todoItems = await Task.Factory.FromAsync(service.BeginGetAllItems, service.EndGetAllItems, null, TaskCreationOptions.None);

				foreach (var item in todoItems)
				{
					if (item != null)
						Items.Add(convertFromWCF(item));
					else
					{
						Debug.WriteLine("NULL ITEM");
					}
				}
			}
			catch (FaultException fe)
			{
				Debug.WriteLine(@"			{0} \n {1} \n {2}", fe.Message, fe.Reason, fe.StackTrace);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0} \n {1}", ex.Message, ex.StackTrace);
			}

			return Items;
		}

		public async Task<bool> UpdateUser(user u)
		{
			return await Task.Factory.FromAsync(service.BeginUpdateUser, service.EndUpdateUser, convertToWCF(u), TaskCreationOptions.None);
		}

		public async Task<bool> AddComment(comment c)
		{
			return await Task.Factory.FromAsync(service.BeginAddComment, service.EndAddComment, convertToWCF(c), TaskCreationOptions.None);
		}

		public async Task<bool> AddItem(item i)
		{
			return await Task.Factory.FromAsync(service.BeginAddItem, service.EndAddItem, convertToWCF(i), TaskCreationOptions.LongRunning);
		}

		public async Task<bool> AddBid(bid b)
		{
			return await Task.Factory.FromAsync(service.BeginAddBid, service.EndAddBid, convertToWCF(b), TaskCreationOptions.None);
		}

		public async Task<bid> GetTopBid(int item_id)
		{
			return convertFromWCF(await Task.Factory.FromAsync(service.BeginGetTopBid, service.EndGetTopBid, item_id, TaskCreationOptions.None));
		}

		public async Task<user> GetUser(string id)
		{
			return convertFromWCF(await Task.Factory.FromAsync(service.BeginGetUser, service.EndGetUser, id, TaskCreationOptions.None));
		}

		public async Task<List<comment>> GetComments(int item_id)
		{
			List<comment> comments = new List<comment>();
			try
			{
				var todoItems = await Task.Factory.FromAsync(service.BeginGetComments, service.EndGetComments, item_id, TaskCreationOptions.None);

				foreach (var item in todoItems)
				{
					if (item != null)
						comments.Add(convertFromWCF(item));
					else
					{
						Debug.WriteLine("NULL ITEM");
					}
				}
			}
			catch (FaultException fe)
			{
				Debug.WriteLine(@"			{0} \n {1} \n {2}", fe.Message, fe.Reason, fe.StackTrace);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0} \n {1}", ex.Message, ex.StackTrace);
			}

			return comments;
		}

		public async Task<bool> SellItem(int item_id)
		{
			throw new NotImplementedException();
		}

		public async Task<List<item>> GetSearchedItems(string search)
		{
			List<item> Items = new List<item>();
			try
			{
				var todoItems = await Task.Factory.FromAsync(service.BeginGetSearchedItems, service.EndGetSearchedItems, search, TaskCreationOptions.None);

				foreach (var item in todoItems)
				{
					if (item != null)
						Items.Add(convertFromWCF(item));
					else
					{
						Debug.WriteLine("NULL ITEM");
					}
				}
			}
			catch (FaultException fe)
			{
				Debug.WriteLine(@"			{0} \n {1} \n {2}", fe.Message, fe.Reason, fe.StackTrace);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0} \n {1}", ex.Message, ex.StackTrace);
			}

			return Items;
		}

		public async Task<List<user>> GetSearchedUsers(string search)
		{
			List<user> users = new List<user>();
			try
			{
				var todoItems = await Task.Factory.FromAsync(service.BeginGetSearchedUsers, service.EndGetSearchedUsers, search, TaskCreationOptions.None);

				foreach (var item in todoItems)
				{
					if (item != null)
						users.Add(convertFromWCF(item));
					else
					{
						Debug.WriteLine("NULL ITEM");
					}
				}
			}
			catch (FaultException fe)
			{
				Debug.WriteLine(@"			{0} \n {1} \n {2}", fe.Message, fe.Reason, fe.StackTrace);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0} \n {1}", ex.Message, ex.StackTrace);
			}

			return users;
		}

		public async Task<List<item>> GetItemsAssociatedWithUser(string user_id)
		{
			List<item> Items = new List<item>();
			try
			{
				var todoItems = await Task.Factory.FromAsync(service.BeginGetItemsAssociatedWithUser, service.EndGetItemsAssociatedWithUser, user_id, TaskCreationOptions.None);

				foreach (var item in todoItems)
				{
					if (item != null)
						Items.Add(convertFromWCF(item));
					else
					{
						Debug.WriteLine("NULL ITEM");
					}
				}
			}
			catch (FaultException fe)
			{
				Debug.WriteLine(@"			{0} \n {1} \n {2}", fe.Message, fe.Reason, fe.StackTrace);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0} \n {1}", ex.Message, ex.StackTrace);
			}

			return Items;
		}

		public async Task<List<item>> GetFBLAChapterItems(int chapter_id)
		{
			List<item> Items = new List<item>();
			try
			{
				var todoItems = await Task.Factory.FromAsync(service.BeginGetFBLAChapterItems, service.EndGetFBLAChapterItems, chapter_id, TaskCreationOptions.None);

				foreach (var item in todoItems)
				{
					if (item != null)
						Items.Add(convertFromWCF(item));
					else
					{
						Debug.WriteLine("NULL ITEM");
					}
				}
			}
			catch (FaultException fe)
			{
				Debug.WriteLine(@"			{0} \n {1} \n {2}", fe.Message, fe.Reason, fe.StackTrace);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0} \n {1}", ex.Message, ex.StackTrace);
			}

			return Items;
		}

		public async Task<List<user>> GetUsersByChapterStatus(int status, int chapter_id)
		{
			List<user> users = new List<user>();
			try
			{
				var todoItems = await Task.Factory.FromAsync(service.BeginGetUsersByChapterStatus, service.EndGetUsersByChapterStatus, status, chapter_id, TaskCreationOptions.None);

				foreach (var item in todoItems)
				{
					if (item != null)
						users.Add(convertFromWCF(item));
					else
					{
						Debug.WriteLine("NULL ITEM");
					}
				}
			}
			catch (FaultException fe)
			{
				Debug.WriteLine(@"			{0} \n {1} \n {2}", fe.Message, fe.Reason, fe.StackTrace);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0} \n {1}", ex.Message, ex.StackTrace);
			}

			return users;
		}

		public async Task<bool> SetChapterStatusOfUser(int status, string user_id)
		{
			return await Task.Factory.FromAsync(service.BeginSetChapterStatusOfUser, service.EndSetChapterStatusOfUser, status, user_id, TaskCreationOptions.None);
		}

		public async Task<List<fblaChapter>> GetSearchedChapters(string search)
		{
			List<fblaChapter> Items = new List<fblaChapter>();
			try
			{
				var todoItems = await Task.Factory.FromAsync(service.BeginGetSearchedChapters, service.EndGetSearchedChapters, search, TaskCreationOptions.None);

				foreach (var item in todoItems)
				{
					if (item != null)
						Items.Add(convertFromWCF(item));
					else
					{
						Debug.WriteLine("NULL ITEM");
					}
				}
			}
			catch (FaultException fe)
			{
				Debug.WriteLine(@"			{0} \n {1} \n {2}", fe.Message, fe.Reason, fe.StackTrace);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0} \n {1}", ex.Message, ex.StackTrace);
			}

			return Items;
		}

		public async Task<fblaChapter> GetFBLAChapter(int id)
		{
			return convertFromWCF(await Task.Factory.FromAsync(service.BeginGetFBLAChapter, service.EndGetFBLAChapter, id, TaskCreationOptions.None));
		}

		public async Task<int[]> GetChapterInfoOfUser(string user_id) {
			return await Task.Factory.FromAsync(service.BeginGetChapterInfoOfUser, service.EndGetChapterInfoOfUser, user_id, TaskCreationOptions.None);
		}
		#region From
		public item convertFromWCF(itemWCF i)
		{
			return new item(i.id, i.owner_id,i.chapter_id, i.name, i.description, i.picture, i.price, i.quality, i.sold, i.date_added);
		}
		public user convertFromWCF(userWCF u)
		{
			return new user(u.id, u.name, u.email, u.pic_url);
		}
		public comment convertFromWCF(commentWCF c)
		{
			return new comment(c.id, c.item_id, c.user_id, c.comment, c.date_added);
		}
		public bid convertFromWCF(bidWCF b)
		{
			return new bid(b.id, b.item_id, b.bidder_id, b.amount);
		}
		public fblaChapter convertFromWCF(fblaChapterWCF f)
		{
			return new fblaChapter(f.id, f.name, f.state, f.city, f.school, f.contact_email, f.payment_email, f.picture);
		}

		#endregion

		#region TO

		public itemWCF convertToWCF(item i)
		{
			itemWCF item = new itemWCF();

			item.id = i.id;
			item.owner_id = i.owner_id;
			item.chapter_id = i.chapter_id;
			item.name = i.name;
			item.description = i.description;
			item.picture = i.picture;
			item.price = i.price;
			item.quality = i.quality;
			item.sold = i.sold;
			item.date_added = i.date_added;

			return item;
		}
		public userWCF convertToWCF(user u)
		{
			userWCF user = new userWCF();

			user.id = u.id;
			user.name = u.name;
			user.email = u.email;
			user.pic_url = u.pic_url;
			
			return user;
		}
		public commentWCF convertToWCF(comment c)
		{
			commentWCF comment = new commentWCF();

			comment.id = c.id;
			comment.item_id = c.item_id;
			comment.user_id = c.user_id;
			comment.comment = c.comments;
			comment.date_added = c.date_added;

			return comment;
		}
		public bidWCF convertToWCF(bid b)
		{
			bidWCF bid = new bidWCF();

			bid.id = b.id;
			bid.item_id = b.item_id;
			bid.bidder_id = b.bidder_id;
			bid.amount = b.amount;


			return bid;
		}
		public fblaChapterWCF convertToWCF(fblaChapter f)
		{
			fblaChapterWCF fbla = new fblaChapterWCF();

			fbla.id = f.id;
			fbla.name = f.name;
			fbla.state = f.state;
			fbla.city = f.city;
			fbla.school = f.school;
			fbla.contact_email = f.contact_email;
			fbla.payment_email = f.payment_email;
			fbla.picture = f.picture;


			return fbla;
		}

		#endregion



	}
}
