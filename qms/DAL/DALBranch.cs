using qms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using System.Linq;
using System.Web;

namespace qms.DAL
{
    public class DALBranch
    {
        OracleDataManager manager = new OracleDataManager();
        public DataTable GetAllBranch()
        {
            try
            {
                
                OracleParameter param = new OracleParameter("po_Cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_Branch_SelectAll");
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
                manager.AddParameter(new OracleParameter("p_branch_id", id));
                OracleParameter param = new OracleParameter("po_cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_Branch_List_ById");
            }
            catch (Exception)
            {

                throw;
            }


        }
        public int Insert(tblBranch branch)
        {
            try
            {
                MapParameters(branch);
                long? branch_id = manager.CallStoredProcedure_Insert("USP_Branch_Insert");
                if (branch_id.HasValue) return (int)branch_id.Value;
                else return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(tblBranch branch)
        {
            try
            {
                manager.AddParameter(new OracleParameter("p_branch_id", branch.branch_id));
                MapParameters(branch);
                manager.CallStoredProcedure_Update("USP_Branch_Update");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void MapParameters(tblBranch branch)
        {
            manager.AddParameter(new OracleParameter("p_branch_name", branch.branch_name));
            manager.AddParameter(new OracleParameter("p_address", branch.address));
            manager.AddParameter(new OracleParameter("p_contact_no", branch.contact_no));
            manager.AddParameter(new OracleParameter("p_contact_person", branch.contact_person));
            manager.AddParameter(new OracleParameter("p_display_next", branch.display_next));
            manager.AddParameter(new OracleParameter("p_static_ip", branch.static_ip));



        }
        public void Delete(int id)
        {
            try
            {
                manager.AddParameter(new OracleParameter("p_branch_id", id));

                manager.CallStoredProcedure_Update("USP_Branch_Delete");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}