using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using System.Linq;
using System.Web;

namespace qms.DAL
{
    public class DALStatus
    {
        public DataTable GetAll()
        {
            try
            {
                OracleDataManager manager = new OracleDataManager();
                OracleParameter param = new OracleParameter("po_Cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_Status_SelectAll");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}