using qms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using System.Linq;
using System.Web;

namespace qms.DAL
{
    public class DALBranchUsers
    {
        OracleDataManager manager = new OracleDataManager();
        public DataTable GetAll()
        {
            try
            {
               
                OracleParameter param = new OracleParameter("po_Cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_BranchUsers_SelectAll");
            }
            catch (Exception)
            {

                throw;
            }


        }
        public DataTable GetById(int id)
        {
            try
            {
                manager.AddParameter(new OracleParameter("p_branchuser_id", id));
                OracleParameter param = new OracleParameter("po_Cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_BranchUser_Edit");
            }
            catch (Exception)
            {

                throw;
            }


        }
        public int Insert(tblBranchUser branchuser)
        {
            try
            {
                MapParameters(branchuser);
                long? branch_id = manager.CallStoredProcedure_Insert("USP_BranchUser_Insert");
                if (branch_id.HasValue) return (int)branch_id.Value;
                else return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(tblBranchUser branchuser)
        {
            try
            {
                manager.AddParameter(new OracleParameter("p_branchuser_id", branchuser.user_branch_id));
                MapParameters(branchuser);
                manager.CallStoredProcedure_Update("USP_Branch_Update");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void MapParameters(tblBranchUser branchuser)
        {
            manager.AddParameter(new OracleParameter("p_branch_id", branchuser.branch_id));
            manager.AddParameter(new OracleParameter("p_user_id", branchuser.user_id));
           



        }
        public void Delete(int id)
        {
            try
            {
                manager.AddParameter(new OracleParameter("p_branchuser_id", id));

                manager.CallStoredProcedure_Update("USP_BranchUser_Delete");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}