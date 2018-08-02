using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Linq;
using System.Web;

namespace qms.DAL
{
    public class DALSMSManager
    {
        public void SendSMS(string msisdn, string message)
        {
            try
            {
                OracleDataManager manager = new OracleDataManager();
                manager.AddParameter(new OracleParameter("P_MSISDN", msisdn));
                manager.AddParameter(new OracleParameter("P_MESSAGE", message));
                manager.CallStoredProcedure("USP_SENDSMS");
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}