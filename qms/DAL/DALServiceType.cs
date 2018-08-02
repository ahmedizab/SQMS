using qms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using System.Linq;
using System.Web;

namespace qms.DAL
{
    public class DALServiceType
    {
        OracleDataManager manager = new OracleDataManager();

        public DataTable GetAll()
        {
            try
            {
                OracleParameter param = new OracleParameter("po_Cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_ServiceType_SelectAll");
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
                manager.AddParameter(new OracleParameter("p_service_type_id", id));
                OracleParameter param = new OracleParameter("po_Cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_ServiceType_Edit");
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
        public int Insert(tblServiceType serviceType)
        {
            try
            {
                MapParameters(serviceType);
                long? service_type_id = manager.CallStoredProcedure_Insert("USP_ServiceType_Insert");
                if (service_type_id.HasValue) return (int) service_type_id.Value;
                else return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(tblServiceType serviceType)
        {
            try
            {
                manager.AddParameter(new OracleParameter("p_service_type_id", serviceType.service_type_id));
                MapParameters(serviceType);
                manager.CallStoredProcedure_Update("USP_ServiceType_Update");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void MapParameters(tblServiceType serviceType)
        {
            manager.AddParameter(new OracleParameter("p_service_type_name", serviceType.service_type_name));
        }
        public void Delete(int id)
        {
            try
            {
                manager.AddParameter(new OracleParameter("p_service_type_id", id));
                
                manager.CallStoredProcedure_Update("USP_ServiceType_Delete");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}