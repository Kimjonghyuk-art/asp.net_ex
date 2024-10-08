﻿using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NETMVC_test.Models;
using ASP.NETMVC_test.Dao;

namespace ASP.NETMVC_test.Dao
{
    public class UserDao
    {

        public List<UserModel> findLoginUserList()
        {
            List<UserModel> userList;
            DbAccess dbAccess = new DbAccess();
            MySqlCommand cmd = dbAccess.sqlCon.CreateCommand();

            try
            {
                //クエリ作成
                cmd.CommandText = findUserSelectQuery();

                DataTable dt = new DataTable();
                //クエリ実行
                dt = dbAccess.executeQuery(cmd);
                //datatableへ格納
                userList = this.getUserListBindDataTable(dt);
            }
            catch
            {
                throw;
            }

            return userList;
        }

    public void insertUser(UserModel userModel)
    {
      DbAccess dbAccess = new DbAccess();
      MySqlCommand cmd = dbAccess.sqlCon.CreateCommand();
      try
      {
        // 1. 먼저 최대 UserId를 구함
        cmd.CommandText = "SELECT MAX(UserId) + 1 FROM USER";
        object result = cmd.ExecuteScalar();
        int newUserId = result != DBNull.Value ? Convert.ToInt32(result) : 1;

        //クエリ作成
        cmd.CommandText = InsertUserQuery();

        cmd.Parameters.AddWithValue("@UserId", newUserId);
        cmd.Parameters.AddWithValue("@UserName", userModel.UserName);
        cmd.Parameters.AddWithValue("@Email", userModel.Email);
        cmd.Parameters.AddWithValue("@Age", userModel.Age);

        // 쿼리 실행
        dbAccess.executeQuery(cmd);
      }
      catch
      {
        throw;
      }
    }

    private string InsertUserQuery()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("INSERT INTO USER (UserId, UserName, Email, Age) ")
        .Append("VALUES (@UserId, @UserName, @Email, @Age);");

      return sb.ToString();
    }

    private string findUserSelectQuery()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT ")
              .Append("  UserId ")
              .Append("  , UserName ")
              .Append("  , Email ")
              .Append("  , Age ")
              .Append(" FROM ")
              .Append("  User ");

            return sb.ToString();
        }

        private List<UserModel> getUserListBindDataTable(DataTable dt)
        {
            List<UserModel> usertList = new List<UserModel>();
            foreach (DataRow dr in dt.Rows)
            {
                UserModel userModel = new UserModel();
                if (!(dr["UserId"] is DBNull))
                {
                    userModel.UserId = Convert.ToInt32(dr["UserID"]);
        }
                else
                {
                    userModel.UserId = 0;
                }

                if (!(dr["UserName"] is DBNull))
                {
                    userModel.UserName = Convert.ToString(dr["UserName"]);
                }
                else
                {
                    userModel.UserName = "";
                }

                if(!(dr["Email"] is DBNull))
                {
                    userModel.Email = Convert.ToString(dr["Email"]);
                }

                if (!(dr["Age"] is DBNull))
                {
                    userModel.Age = Convert.ToInt32(dr["Age"]);
                }


                usertList.Add(userModel);
            }

            return usertList;
        }

    internal void deleteUser(UserModel userModel)
    {
      DbAccess dbAccess = new DbAccess();
      MySqlCommand cmd = dbAccess.sqlCon.CreateCommand();
      try
      {
        //クエリ作成
        cmd.CommandText = DeleteUserQuery();

        cmd.Parameters.AddWithValue("@UserId", userModel.UserId);

        // 쿼리 실행
        dbAccess.executeQuery(cmd);
      }
      catch
      {
        throw;
      }
    }

    private string DeleteUserQuery()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append(" DELETE FROM USER ")
        .Append("WHERE UserId = @UserId");

      return sb.ToString();
    }
  }
}
