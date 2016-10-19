using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace yardSaleWCF
{
	public class DatabaseAccess
	{
		public bool createUser(myDataTypes.userWCF user)
		{
			myDataTypes.userWCF u = user;
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

		public bool addComment(myDataTypes.commentWCF comment)
		{
			myDataTypes.commentWCF c = comment;
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
	}
}