using qms.Models;
using qms.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using System.Linq;
using System.Web;

namespace qms.DAL
{
    public class DALServiceDetail
    {
        OracleDataManager manager = new OracleDataManager();

        public DataTable GetAll()
        {
            try
            {
                OracleDataManager manager = new OracleDataManager();
                OracleParameter param = new OracleParameter("po_Cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_ServiceDetail_SelectAll");
            }
            catch (Exception)
            {

                throw;
            }


        }
        public DataTable GetNewToken(int branch_id, int counter_id, string userid, out long token_id, out int token_no, out string contact_no, out string service_type, out DateTime start_time, out string customer_name, out string address)
        {
            try
            {
                OracleDataManager manager = new OracleDataManager();
                manager.AddParameter(new OracleParameter("P_BRANCH_ID", branch_id));
                manager.AddParameter(new OracleParameter("P_COUNTER_ID", counter_id));
                manager.AddParameter(new OracleParameter("P_USER_ID", userid));
                OracleParameter param_TOKEN_ID = new OracleParameter("PO_TOKEN_ID", OracleDbType.Decimal);
                param_TOKEN_ID.Direction = ParameterDirection.Output;
                manager.AddParameter(param_TOKEN_ID);

                OracleParameter param_TOKEN_NO = new OracleParameter("PO_TOKEN_NO", OracleDbType.Decimal);
                param_TOKEN_NO.Direction = ParameterDirection.Output;
                manager.AddParameter(param_TOKEN_NO);
                OracleParameter param_CONTACT_NO = new OracleParameter("PO_CONTACT_NO", OracleDbType.Varchar2, 32767);
                param_CONTACT_NO.Direction = ParameterDirection.Output;
                manager.AddParameter(param_CONTACT_NO);
                OracleParameter param_SERVICE_TYPE = new OracleParameter("PO_SERVICE_TYPE", OracleDbType.Varchar2, 100);
                param_SERVICE_TYPE.Direction = ParameterDirection.Output;
                manager.AddParameter(param_SERVICE_TYPE);
                OracleParameter param_START_TIME = new OracleParameter("PO_START_TIME", OracleDbType.Date);
                param_START_TIME.Direction = ParameterDirection.Output;
                manager.AddParameter(param_START_TIME);
                OracleParameter param_CUSTOMER_NAME = new OracleParameter("PO_CUSTOMER_NAME", OracleDbType.Varchar2, 500);
                param_CUSTOMER_NAME.Direction = ParameterDirection.Output;
                manager.AddParameter(param_CUSTOMER_NAME);
                OracleParameter param_ADDRESS = new OracleParameter("PO_ADDRESS", OracleDbType.Varchar2, 250);
                param_ADDRESS.Direction = ParameterDirection.Output;
                manager.AddParameter(param_ADDRESS);
                OracleParameter param = new OracleParameter("po_Cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                DataTable dt = manager.CallStoredProcedure_Select("USP_SERVICEDETAIL_NEWCALL");

                token_id = (long) ((Oracle.DataAccess.Types.OracleDecimal)param_TOKEN_ID.Value).Value;
                token_no = (int)((Oracle.DataAccess.Types.OracleDecimal)param_TOKEN_NO.Value).Value; 
                contact_no = param_CONTACT_NO.Value.ToString();
                service_type = param_SERVICE_TYPE.Value.ToString();
                start_time = ((Oracle.DataAccess.Types.OracleDate)param_START_TIME.Value).Value;
                customer_name = (((Oracle.DataAccess.Types.OracleString)param_CUSTOMER_NAME.Value).IsNull == true ? "" : param_CUSTOMER_NAME.Value.ToString());
                address = (((Oracle.DataAccess.Types.OracleString)param_ADDRESS.Value).IsNull == true ? "" : param_ADDRESS.Value.ToString());
                return dt;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public int CancelToken(long token_id)
        {
            try
            {
                OracleDataManager manager = new OracleDataManager();
                manager.AddParameter(new OracleParameter("p_token_id", token_id));

                return (int) manager.CallStoredProcedure_Insert("USP_Token_Cancel");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int Insert(VMServiceDetails servicedetail)
        {
            try
            {
                MapParameters(servicedetail);
                long? service_id = manager.CallStoredProcedure_Insert("USP_SERVICEDETAIL_INSERT");
                if (service_id.HasValue) return (int)service_id.Value;
                else return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void MapParameters(VMServiceDetails servicedetail)
        {
            manager.AddParameter(new OracleParameter("P_TOKEN_ID", servicedetail.token_id));
            manager.AddParameter(new OracleParameter("P_CONTACT_NO", servicedetail.contact_no));
            manager.AddParameter(new OracleParameter("P_START_TIME", servicedetail.start_time));
            manager.AddParameter(new OracleParameter("P_SERVICE_SUB_TYPE_ID", servicedetail.service_sub_type_id));
            manager.AddParameter(new OracleParameter("P_ISSUES", servicedetail.issues));
            manager.AddParameter(new OracleParameter("P_SOLUTIONS", servicedetail.solutions));
            manager.AddParameter(new OracleParameter("P_CUSTOMER_NAME", servicedetail.customer_name));
            manager.AddParameter(new OracleParameter("P_ADDRESS", servicedetail.address));
            manager.AddParameter(new OracleParameter("P_COUNTER_ID", servicedetail.counter_id));
            manager.AddParameter(new OracleParameter("P_USER_ID", servicedetail.user_id));



        }
    }
}