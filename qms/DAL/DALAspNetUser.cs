using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using System.Linq;
using System.Web;

namespace qms.DAL
{
    public class DALAspNetUser
    {
        OracleDataManager manager = new OracleDataManager();
        public DataTable GetAllUser()
        {
            try
            {

                OracleParameter param = new OracleParameter("po_Cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_AspNetUser_SelectAll");
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataTable GetSessionInfoByUserName(string userName)
        {
            try
            {
                manager.AddParameter(new OracleParameter("P_USER_NAME", userName));
                OracleParameter param = new OracleParameter("po_Cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_SessionInfo_ByUserName");
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}