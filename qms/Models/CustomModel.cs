using qms.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace qms.Models
{
    public class CustomModel
    {
        private qmsEntities db = new qmsEntities();

        public List<VMServiceDetails> GetCustomerServiceSummary(int? branchID, DateTime? startDate, DateTime? endDate)
        {
            SqlParameter branchId = new SqlParameter("@branch", branchID);
            SqlParameter sdate = new SqlParameter("@StartDate", startDate);
            SqlParameter edate = new SqlParameter("@EndDate", endDate);
            var result = db.Database.SqlQuery<VMServiceDetails>("GetCustomerServiceSummary @branch,@StartDate,@EndDate", branchId,sdate,edate).ToList();
            return result;
        }

        public List<VMServiceDetails> GetCustomerServiceDetails(int? counter , int? token)
        {
            SqlParameter p1 = new SqlParameter("@counter", counter);
            SqlParameter p2 = new SqlParameter("@token", token);
            var result = db.Database.SqlQuery<VMServiceDetails>("GetCustomerServiceDetails @counter , @token", p1,p2).ToList();
            return result;
        }

        public List<VMServiceDetails> GetCustomerServiceDetailsALL(int? CounterID)
        {
            SqlParameter p1 = new SqlParameter("@counter", CounterID);
            var result = db.Database.SqlQuery<VMServiceDetails>("GetCustomerServiceDetailsALL @counter", p1).ToList();
            return result;
        }
    }
}