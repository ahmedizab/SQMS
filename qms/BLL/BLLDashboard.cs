using qms.DAL;
using qms.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace qms.BLL
{
    public class BLLDashboard
    {
        public List<VMDashboardAdmin> GetAdminDashboard()
        {
            DALDashboard dal = new DALDashboard();
            DataTable dt = dal.GetAdminDashboard();
            return ObjectMappingListAdmin(dt);
        }

        public List<VMDashboardBranchAdminCounters> GetBranchAdminDashboard(int branch_id, List<VMDashboardBranchAdminStatuses> statuses)
        {
            DALDashboard dal = new DALDashboard();
            DataSet ds = dal.GetBranchAdminDashboard(branch_id);
            ObjectMappingListStatuses(ds.Tables["STATUSES"], statuses);
            return ObjectMappingListCounters(ds.Tables["COUNTERS"]);
        }

        internal List<VMDashboardAdmin> ObjectMappingListAdmin(DataTable dt)
        {
            List<VMDashboardAdmin> list = new List<VMDashboardAdmin>();
            foreach (DataRow row in dt.Rows)
            {
                VMDashboardAdmin dashboard = new VMDashboardAdmin();
                dashboard.branch_name = (row["branch_name"] == DBNull.Value ? null : row["branch_name"].ToString());
                dashboard.tokens = (row["tokens"] == DBNull.Value ? 0 : Convert.ToInt32(row["tokens"]));
                dashboard.services = (row["services"] == DBNull.Value ? 0 : Convert.ToInt32(row["services"]));


                list.Add(dashboard);

            }
            return list;
        }

        internal List<VMDashboardBranchAdminCounters> ObjectMappingListCounters(DataTable dt)
        {
            List<VMDashboardBranchAdminCounters> list = new List<VMDashboardBranchAdminCounters>();
            foreach (DataRow row in dt.Rows)
            {
                VMDashboardBranchAdminCounters dashboard = new VMDashboardBranchAdminCounters();
                dashboard.counter_no = (row["counter_no"] == DBNull.Value ? null : row["branch_name"].ToString());
                dashboard.tokens = (row["tokens"] == DBNull.Value ? 0 : Convert.ToInt32(row["tokens"]));
                dashboard.services = (row["services"] == DBNull.Value ? 0 : Convert.ToInt32(row["services"]));


                list.Add(dashboard);

            }
            return list;
        }

        internal void ObjectMappingListStatuses(DataTable dt, List<VMDashboardBranchAdminStatuses> statuses)
        {
            foreach (DataRow row in dt.Rows)
            {
                VMDashboardBranchAdminStatuses dashboard = new VMDashboardBranchAdminStatuses();
                dashboard.service_status = (row["counter_no"] == DBNull.Value ? null : row["branch_name"].ToString());
                dashboard.tokens = (row["tokens"] == DBNull.Value ? 0 : Convert.ToInt32(row["tokens"]));


                statuses.Add(dashboard);

            }
        }
    }
}