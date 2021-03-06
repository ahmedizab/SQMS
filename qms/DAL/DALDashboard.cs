﻿using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using System.Linq;
using System.Web;

namespace qms.DAL
{
    public class DALDashboard
    {
        OracleDataManager manager = new OracleDataManager();
        public DataSet GetBranchAdminDashboard( int branch_id)
        {
            try
            {
                manager.AddParameter(new OracleParameter("P_BRANCH_ID", branch_id));
                OracleParameter param = new OracleParameter("po_Cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                DataTable dtCounter = manager.CallStoredProcedure_Select("USP_DASHBOARD_COUNTERS");
                DataTable dtStatuses = GetBranchAdminDashboardStatus(branch_id);

                dtCounter.TableName = "COUNTERS";
                dtStatuses.TableName = "STATUSES";
                DataSet ds = new DataSet();
                ds.Tables.Add(dtCounter);
                ds.Tables.Add(dtStatuses);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataTable GetBranchAdminDashboardStatus(int branch_id)
        {
            try
            {
                manager = new OracleDataManager();
                manager.AddParameter(new OracleParameter("P_BRANCH_ID", branch_id));
                OracleParameter param = new OracleParameter("po_Cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_DASHBOARD_STATUSES");
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataTable GetAdminDashboard()
        {
            try
            {
                OracleParameter param = new OracleParameter("po_Cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_DASHBOARD_ADMIN");
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}