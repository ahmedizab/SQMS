﻿using qms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace qms.DAL
{
    public class DALDailyBreak
    {
        OracleDataManager manager = new OracleDataManager();
        public DataTable GetAll()
        {
            try
            {

                OracleParameter param = new OracleParameter("po_cursor", OracleType.Cursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_DailyBreak_SelectAll");
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
                manager.AddParameter(new OracleParameter("p_dailyBreak_id", id));
                OracleParameter param = new OracleParameter("po_cursor", OracleType.Cursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_DailyBreak_Edit");
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
        public int Insert(tblDailyBreak dailyBreak)
        {
            try
            {
                MapParameters(dailyBreak);
                long? daily_break_id = manager.CallStoredProcedure_Insert("USP_DailyBreak_Insert");
                if (daily_break_id.HasValue) return (int)daily_break_id.Value;
                else return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(tblDailyBreak dailyBreak)
        {
            try
            {
                manager.AddParameter(new OracleParameter("p_dailyBreak_id", dailyBreak.daily_break_id));
                MapParameters(dailyBreak);
                manager.CallStoredProcedure_Update("USP_DailyBreak_Update");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void MapParameters(tblDailyBreak dailyBreak)
        {
            manager.AddParameter(new OracleParameter("p_break_type_id", dailyBreak.break_type_id));
            manager.AddParameter(new OracleParameter("p_counter_id", dailyBreak.counter_id));
            manager.AddParameter(new OracleParameter("p_start_time", dailyBreak.start_time));
            manager.AddParameter(new OracleParameter("p_end_time", dailyBreak.end_time));
           
            manager.AddParameter(new OracleParameter("p_user_id", dailyBreak.user_id));
            manager.AddParameter(new OracleParameter("p_remarks", dailyBreak.remarks));



        }
        public void Delete(int id)
        {
            try
            {
                manager.AddParameter(new OracleParameter("p_dailyBreak_id", id));

                manager.CallStoredProcedure_Update("USP_DailyBreak_Delete");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}