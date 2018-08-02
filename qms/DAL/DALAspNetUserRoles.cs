using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using System.Linq;
using System.Web;

namespace qms.DAL
{
    public class DALAspNetUserRoles
    {
        OracleDataManager manager = new OracleDataManager();
        public DataTable GetAllUser()
        {
            try
            {

                OracleParameter param = new OracleParameter("po_Cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_AspNetRoles_SelectAll");
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataTable GetRolesByUserId(string userId)
        {
            try
            {
                manager.AddParameter(new OracleParameter("p_user_id", userId));
                OracleParameter param = new OracleParameter("po_Cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_AspNetRoles_SelectByUserId");
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}