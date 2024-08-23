using ShanaiKanri.DataModels;
using ShanaiKanri.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShanaiKanri.Dao
{
    public class AAAKimTestDao
    {

        public List<AAAKimTestModel> findLoginUserList()
        {
            List<AAAKimTestModel> userList;
            DbAccess dbAccess = new DbAccess();
            SqlCommand cmd = dbAccess.sqlCon.CreateCommand();

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


        private string findUserSelectQuery()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT ")
              .Append("  ENG_ID ")
              .Append("  , COMP_CODE ")
              .Append("  , ENG_NAME ")
              .Append("  , ENG_INITIAL ")
              .Append(" FROM ")
              .Append("  Engineer ");

            return sb.ToString();
        }

        private List<AAAKimTestModel> getUserListBindDataTable(DataTable dt)
        {
            List<AAAKimTestModel> usertList = new List<AAAKimTestModel>();
            foreach (DataRow dr in dt.Rows)
            {
                AAAKimTestModel aAAKimTestModel = new AAAKimTestModel();
                if (!(dr["COMP_CODE"] is DBNull))
                {
                    aAAKimTestModel.CompCode = Convert.ToString(dr["COMP_CODE"]);
                }
                else
                {
                    aAAKimTestModel.CompCode = "";
                }

                if (!(dr["ENG_ID"] is DBNull))
                {
                    aAAKimTestModel.EngId = Convert.ToInt32(dr["ENG_ID"]);
                }
                else
                {
                    aAAKimTestModel.EngId = 9999;
                }

                if(!(dr["ENG_NAME"] is DBNull))
                {
                    aAAKimTestModel.EngName = Convert.ToString(dr["ENG_NAME"]);
                }

                if (!(dr["ENG_INITIAL"] is DBNull))
                {
                    aAAKimTestModel.EngInitial = Convert.ToString(dr["ENG_INITIAL"]);
                }


                usertList.Add(aAAKimTestModel);
            }

            return usertList;
        }


    }
}
