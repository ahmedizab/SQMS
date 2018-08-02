using qms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using System.Linq;
using System.Web;

namespace qms.DAL
{
    public class DALToken
    {
        OracleDataManager manager = new OracleDataManager();
        public DataTable GetAll()
        {

            try
            {
                
                OracleParameter param = new OracleParameter("po_Cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_Token_SelectAll");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable GetNextTokenList(int branch_id)
        {

            try
            {
                manager.AddParameter(new OracleParameter("p_branch_id", branch_id));
                OracleParameter param = new OracleParameter("po_Cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_GetNextTokenList");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable GetProgressTokenList(int branch_id)
        {

            try
            {
                manager.AddParameter(new OracleParameter("p_branch_id", branch_id));
                OracleParameter param = new OracleParameter("cur", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_GetInProgressTokenList");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Insert(tblTokenQueue token)
        {
            try
            {
                OracleParameter param_token_id = new OracleParameter("po_token_id", OracleDbType.Decimal);
                param_token_id.Direction = ParameterDirection.Output;
                manager.AddParameter(param_token_id);
                OracleParameter param_token_no = new OracleParameter("po_token_no", OracleDbType.Decimal);
                param_token_no.Direction = ParameterDirection.Output;
                manager.AddParameter(param_token_no);
                manager.AddParameter(new OracleParameter("p_branch_id", token.branch_id));
                MapParameters(token);
                manager.CallStoredProcedure("USP_Token_Insert");

                token.token_id = (long)((Oracle.DataAccess.Types.OracleDecimal)param_token_id.Value).Value;
                token.token_no = (int)((Oracle.DataAccess.Types.OracleDecimal)param_token_no.Value).Value;

            }
            catch (Exception)
            {
                throw;
            }
        }
        private void MapParameters(tblTokenQueue token)
        {
            manager.AddParameter(new OracleParameter("p_service_type_id", token.service_type_id));
            manager.AddParameter(new OracleParameter("p_contact_no", token.contact_no));
        }
        
    }
}