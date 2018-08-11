using qms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using System.Linq;
using System.Web;

namespace qms.DAL
{
    public class DALBreakType
    {
        OracleDataManager manager = new OracleDataManager();
        public DataTable GetAll()
        {
            try
            {

                OracleParameter param = new OracleParameter("po_Cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_BreakType_SelectAll");
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
                manager.AddParameter(new OracleParameter("p_breakType_id", id));
                OracleParameter param = new OracleParameter("po_Cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_BreakType_SelectList_ById");
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
        public int Insert(tblBreakType breaktype)
        {
            try
            {
                MapParameters(breaktype);
                long? break_type_id = manager.CallStoredProcedure_Insert("USP_BreakType_Insert");
                if (break_type_id.HasValue) return (int)break_type_id.Value;
                else return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(tblBreakType breaktype)
        {
            try
            {
                manager.AddParameter(new OracleParameter("p_breakType_id", breaktype.break_type_id));
                MapParameters(breaktype);
                manager.CallStoredProcedure_Update("USP_BreakType_Update");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void MapParameters(tblBreakType breaktype)
        {
            manager.AddParameter(new OracleParameter("p_break_type_name", breaktype.break_type_name));
            manager.AddParameter(new OracleParameter("p_break_type_short_name", breaktype.break_type_short_name));
            manager.AddParameter(new OracleParameter("p_duration", breaktype.duration));
            manager.AddParameter(new OracleParameter("p_start_time", breaktype.start_time));
            manager.AddParameter(new OracleParameter("p_end_time", breaktype.end_time));
           
        }
        public void Delete(int id)
        {
            try
            {
                manager.AddParameter(new OracleParameter("p_breakType_id", id));

                manager.CallStoredProcedure_Update("USP_BreakType_Delete");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}