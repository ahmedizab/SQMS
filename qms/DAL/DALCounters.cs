using qms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace qms.DAL
{
    public class DALCounters
    {
        OracleDataManager manager = new OracleDataManager();
        public DataTable GetAll()
        {
            try
            {
                
                OracleParameter param = new OracleParameter("po_cursor", OracleType.Cursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_Counters_SelectAll");
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
                manager.AddParameter(new OracleParameter("p_Counter_id", id));
                OracleParameter param = new OracleParameter("po_cursor", OracleType.Cursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_Counters_Edit");
            }
            catch (Exception)
            {

                throw;
            }


        }
        /// <summary>
        /// Call only for New Service Type Insert
        /// Return service_type_id
        /// </summary>
        /// <param name="serviceType">Service Type Object</param>
        /// <returns>Return service_type_id</returns>
        public int Insert(tblCounter counter)
        {
            try
            {
                MapParameters(counter);
                long? counter_id = manager.CallStoredProcedure_Insert("USP_Counters_Insert");
                if (counter_id.HasValue) return (int)counter_id.Value;
                else return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(tblCounter counter)
        {
            try
            {
                manager.AddParameter(new OracleParameter("p_Counter_id", counter.counter_id));
                MapParameters(counter);
                manager.CallStoredProcedure_Update("USP_Counters_Update");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void MapParameters(tblCounter counter)
        {
            manager.AddParameter(new OracleParameter("p_counter_no", counter.counter_no));
            manager.AddParameter(new OracleParameter("p_branch_id", counter.branch_id));
            manager.AddParameter(new OracleParameter("p_location", counter.location));
           

        }
        public void Delete(int id)
        {
            try
            {
                manager.AddParameter(new OracleParameter("p_Counter_id", id));

                manager.CallStoredProcedure_Update("USP_Counters_Delete");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}