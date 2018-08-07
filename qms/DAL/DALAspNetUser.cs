using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using System.Linq;
using System.Web;
using qms.Models;

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

        public DataTable GetUserBySecurityCode(string securityToken)
        {
            try
            {
                manager.AddParameter(new OracleParameter() { ParameterName = "P_SecurityToken", Value = securityToken });
                OracleParameter param = new OracleParameter("po_Cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_AspNetUser_SelectByToken");
            }
            catch (Exception)
            {

                throw;
            }


        }

        public void InsertLoginInfo(AspNetUserLogin loginInfo)
        {
            try
            {
                manager.AddParameter(new OracleParameter() { ParameterName = "P_LOGINPROVIDER", Value = loginInfo.LoginProvider });
                manager.AddParameter(new OracleParameter() { ParameterName = "P_PROVIDERKEY", Value = loginInfo.ProviderKey });
                manager.AddParameter(new OracleParameter() { ParameterName = "P_USERID", Value = loginInfo.UserId });

                manager.CallStoredProcedure_Insert("USP_AspNetUserLogin_Insert");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteLoginInfo(string loginProvider)
        {
            try
            {
                manager.AddParameter(new OracleParameter() { ParameterName = "P_loginProvider", Value = loginProvider });
                
                manager.CallStoredProcedure_Delete("USP_AspNetUserLogin_Delete");
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