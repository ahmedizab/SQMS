using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace qms.DAL
{
    public class DALAspNetRole
    {
        OracleDataManager manager = new OracleDataManager();
        public DataTable GetAllRoles()
        {
            try
            {

                OracleParameter param = new OracleParameter("po_cursor", OracleType.Cursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_AspNetRoles_SelectAll");
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}