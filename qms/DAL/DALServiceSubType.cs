using qms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace qms.DAL
{
    public class DALServiceSubType
    {
        OracleDataManager manager = new OracleDataManager();
        public DataTable GetAll()
        {
            try
            {
                
                OracleParameter param = new OracleParameter("po_cursor", OracleType.Cursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_ServiceSubType_SelectAll");
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
                manager.AddParameter(new OracleParameter("p_servicesub_type_id", id));
                OracleParameter param = new OracleParameter("po_cursor", OracleType.Cursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_ServiceSubType_Edit");
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
        public int Insert(tblServiceSubType servicesubType)
        {
            try
            {
                MapParameters(servicesubType);
                long? service_sub_type_id = manager.CallStoredProcedure_Insert("USP_ServiceSubType_Insert");
                if (service_sub_type_id.HasValue) return (int)service_sub_type_id.Value;
                else return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(tblServiceSubType servicesubType)
        {
            try
            {
                manager.AddParameter(new OracleParameter("p_servicesub_type_id", servicesubType.service_sub_type_id));
                MapParameters(servicesubType);
                manager.CallStoredProcedure_Update("USP_ServiceSubType_Update");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void MapParameters(tblServiceSubType servicesubType)
        {
            manager.AddParameter(new OracleParameter("p_servicesub_type_name", servicesubType.service_sub_type_name));
            manager.AddParameter(new OracleParameter("p_service_type_id", servicesubType.service_type_id));
            manager.AddParameter(new OracleParameter("p_max_duration", servicesubType.max_duration));



        }
        public void Delete(int id)
        {
            try
            {
                manager.AddParameter(new OracleParameter("p_servicesub_type_id", id));

                manager.CallStoredProcedure_Update("USP_ServiceSubType_Delete");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}