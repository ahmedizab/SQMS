using qms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using System.Linq;
using System.Web;

namespace qms.DAL
{
    public class DALCustomer
    {
        OracleDataManager manager = new OracleDataManager();
        public DataTable GetAll()
        {
            
            try
            {
               
                OracleParameter param = new OracleParameter("po_Cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_Customer_SelectAll");
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
                manager.AddParameter(new OracleParameter("p_Customer_id", id));
                OracleParameter param = new OracleParameter("po_Cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_Customer_Edit");
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
        public int Insert(tblCustomer customer)
        {
            try
            {
                MapParameters(customer);
                long? customer_id = manager.CallStoredProcedure_Insert("USP_Customer_Insert");
                if (customer_id.HasValue) return (int)customer_id.Value;
                else return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(tblCustomer customer)
        {
            try
            {
                manager.AddParameter(new OracleParameter("p_customer_id", customer.customer_id));
                MapParameters(customer);
                manager.CallStoredProcedure_Update("USP_Customer_Update");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void MapParameters(tblCustomer customer)
        {
            manager.AddParameter(new OracleParameter("p_customer_name", customer.customer_name));
            manager.AddParameter(new OracleParameter("p_contact_no", customer.contact_no));
            manager.AddParameter(new OracleParameter("p_address", customer.address));
            manager.AddParameter(new OracleParameter("p_customer_type_id", customer.customer_type_id));



        }
        public void Delete(int id)
        {
            try
            {
                manager.AddParameter(new OracleParameter("p_customer_id", id));

                manager.CallStoredProcedure_Update("USP_Customer_Delete");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}