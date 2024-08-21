using System;
using System.Collections.Generic;
using ASP.NETMVC_test.Models;
using MySql.Data.MySqlClient;

namespace ASP.NETMVC_test.Dao
{
	public class UserDao
	{
		public UserDao()
		{
		}

		public List<User> getUsers()
		{
			List<User> list = new List<User>();
			string SQL = "SELECT * FROM USER ";
			using (MySqlConnection conn = GetConnection())
			{
				conn.Open();
				MySqlCommand cmd = new MySqlCommand(SQL, conn);

				using(var reader = cmd.ExecuteReader())
				{
					while(reader.Read())
					{
						list.Add(new Data()
						{
							UserId = Convert.ToInt32(reader["UserId"])
						});
					}
				}
			}
			conn.close();

			return list;
		}

    private MySqlConnection GetConnection()
    {
      throw new NotImplementedException();
    }
  }
}

