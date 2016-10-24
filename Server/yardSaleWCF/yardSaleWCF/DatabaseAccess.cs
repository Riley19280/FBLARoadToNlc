using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace yardSaleWCF
{
	public class DatabaseAccess
	{
		public bool createUser(userWCF user)
		{
			userWCF u = user;
			int affected = 0;


			using (SqlConnection connection = new SqlConnection(Constants.SQLConnectionString))

			using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.users(id,name,pic_url,account_created,last_activity,lastLogon) VALUES(@id, @name,@pic_url, SYSDATETIME() ,SYSDATETIME() ,SYSDATETIME())", connection))
			{
				cmd.Parameters.AddWithValue("@id", u.id);
				cmd.Parameters.AddWithValue("@name", u.name);
				cmd.Parameters.AddWithValue("@pic_url", u.pic_url);

				connection.Open();
				affected = cmd.ExecuteNonQuery();

			}
			if (affected > 0)
				return true;
			else
				return false;
		}

		public bool updateUserActivity(string user_id)
		{
			string id = user_id;
			int affected = 0;

			using (SqlConnection connection = new SqlConnection(Constants.SQLConnectionString))

			using (SqlCommand cmd = new SqlCommand("UPDATE dbo.users SET last_activity = SYSDATETIME() where id =  @id", connection))
			{
				cmd.Parameters.AddWithValue("@id", id);

				connection.Open();
				affected = cmd.ExecuteNonQuery();

			}
			if (affected > 0)
				return true;
			else
				return false;
		}

		public bool addComment(commentWCF comment)
		{
			commentWCF c = comment;
			int affected = 0;


			using (SqlConnection connection = new SqlConnection(Constants.SQLConnectionString))

			using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.comments(id,item_id,user_id,comment,date_added) VALUES(@id, @item_id,@user_id, @comment ,SYSDATETIME())", connection))
			{
				cmd.Parameters.AddWithValue("@id", c.id);
				cmd.Parameters.AddWithValue("@item_id", c.item_id);
				cmd.Parameters.AddWithValue("@user_id", c.user_id);
				cmd.Parameters.AddWithValue("@comment", c.comment);

				connection.Open();
				affected = cmd.ExecuteNonQuery();

			}
			if (affected > 0)
				return true;
			else
				return false;
		}

		public bool addItem(itemWCF item)
		{
			itemWCF i = item;
			int affected = 0;

			using (SqlConnection connection = new SqlConnection(Constants.SQLConnectionString))

			using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.items(owner_id,name,description,pic_url,price,quality,sold,date_added) VALUES(@owner_id,@name,@description,@pic_url,@price,@quality,@sold,SYSDATETIME())", connection))
			{
				cmd.Parameters.AddWithValue("@owner_id", i.owner_id);
				cmd.Parameters.AddWithValue("@name", i.name);
				cmd.Parameters.AddWithValue("@description", i.description);
				cmd.Parameters.AddWithValue("@pic_url", i.pic_url);
				cmd.Parameters.AddWithValue("@price", i.price);
				cmd.Parameters.AddWithValue("@quality", i.quality);
				cmd.Parameters.AddWithValue("@sold", i.sold ? 1 : 0);

				connection.Open();
				affected = cmd.ExecuteNonQuery();

			}
			if (affected > 0)
				return true;
			else
				return false;
		}

		public bool addBid(bidWCF bid)
		{
			bidWCF b = bid;
			int affected = 0;

			using (SqlConnection connection = new SqlConnection(Constants.SQLConnectionString))

			using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.bids(item_id,bidder_id,amount,date_added) VALUES(@item_id,@bidder_id,@amount,SYSDATETIME())", connection))
			{
				cmd.Parameters.AddWithValue("@item_id", b.item_id);
				cmd.Parameters.AddWithValue("@bidder_id", b.bidder_id);
				cmd.Parameters.AddWithValue("@amount", b.amount);

				connection.Open();
				affected = cmd.ExecuteNonQuery();

			}
			if (affected > 0)
				return true;
			else
				return false;
		}

		public bidWCF getTopBid(int item_id)
		{

			using (SqlConnection connection = new SqlConnection(Constants.SQLConnectionString))
			{

				using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 * from dbo.bids WHERE item_id = @item_id ORDER BY amount DESC", connection))
				{
					cmd.Parameters.AddWithValue("item_id", item_id);
					connection.Open();
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						// Check is the reader has any rows at all before starting to read.
						if (reader.HasRows)
						{
							// Read advances to the next row.
							//TODO: chekc fvalues for null
							while (reader.Read())
							{
								bidWCF b = new bidWCF(
									 reader.GetInt32(reader.GetOrdinal("id")),
									 reader.GetInt32(reader.GetOrdinal("item_id")),
									 reader.GetString(reader.GetOrdinal("bidder_id")),
									 reader.GetFloat(reader.GetOrdinal("amount"))
									);

								return b;
							}
						}
					}
				}
			}
			return null;

		}

		public List<itemWCF> getAllItems()
		{
			List<itemWCF> items = new List<itemWCF>();

			using (SqlConnection connection = new SqlConnection(Constants.SQLConnectionString))
			{

				using (SqlCommand cmd = new SqlCommand("SELECT * from dbo.items ORDER BY date_added DESC", connection))
				{					
					connection.Open();
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						// Check is the reader has any rows at all before starting to read.
						if (reader.HasRows)
						{
							while (reader.Read())
							{
					
								itemWCF i = new itemWCF(
								 reader.GetInt32(reader.GetOrdinal("id")),
								 reader.GetString(reader.GetOrdinal("owner_id")),
								 reader.GetString(reader.GetOrdinal("name")),
								 reader.GetString(reader.GetOrdinal("description")),
								 reader.GetString(reader.GetOrdinal("pic_url")),
							     (float)reader.GetDouble(reader.GetOrdinal("price")),
								 (float)reader.GetDouble(reader.GetOrdinal("quality")),
								 reader.GetBoolean(reader.GetOrdinal("sold")),
								 reader.GetDateTime(reader.GetOrdinal("date_added"))
								);

								items.Add(i);
							}
						}
					}
				}
			}
			return items;
		}

		public userWCF getUser(string id) {

			using (SqlConnection connection = new SqlConnection(Constants.SQLConnectionString))
			{

				using (SqlCommand cmd = new SqlCommand("SELECT * from dbo.users WHERE id = @id", connection))
				{
					cmd.Parameters.AddWithValue("id", id);
					connection.Open();
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						// Check is the reader has any rows at all before starting to read.
						if (reader.HasRows)
						{
							
							while (reader.Read())
							{
								userWCF u = new userWCF(
									 reader.GetString(reader.GetOrdinal("id")),
									 reader.GetString(reader.GetOrdinal("name")),
									 reader.GetString(reader.GetOrdinal("pic_url"))								
									);

								return u;
							}
						}
					}
				}
			}
			return null;
		}

		public List<commentWCF> getComments(int item_id) {
			List<commentWCF> comments = new List<commentWCF>();

			using (SqlConnection connection = new SqlConnection(Constants.SQLConnectionString))
			{

				using (SqlCommand cmd = new SqlCommand("SELECT * from dbo.comments ORDER BY date_added DESC", connection))
				{
					connection.Open();
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						// Check is the reader has any rows at all before starting to read.
						if (reader.HasRows)
						{
							while (reader.Read())
							{
								commentWCF c = new commentWCF(
									 reader.GetInt32(reader.GetOrdinal("id")),
									 reader.GetInt32(reader.GetOrdinal("item_id")),
									 reader.GetString(reader.GetOrdinal("user_id")),
									 reader.GetString(reader.GetOrdinal("comment")),
									 reader.GetDateTime(reader.GetOrdinal("date_added"))
							  		 );

								comments.Add(c);
							}
						}
					}
				}
			}
			return comments;
		}

	}
}