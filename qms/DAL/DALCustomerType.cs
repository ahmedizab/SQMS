using qms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using System.Linq;
using System.Web;

namespace qms.DAL
{
    public class DALCustomerType
    {
        OracleDataManager manager = new OracleDataManager();

        public DataTable GetAll()
        {
            try
            {
                OracleParameter param = new OracleParameter("po_cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_CustomerType_SelectAll");
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
                manager.AddParameter(new OracleParameter("p_Customer_type_id", id));
                OracleParameter param = new OracleParameter("po_Cursor", OracleDbType.RefCursor);
                param.Direction = ParameterDirection.Output;
                manager.AddParameter(param);

                return manager.CallStoredProcedure_Select("USP_CustomerType_List_ById");
            }
            catch (Exception)
            {

                throw;
            }


        }
        /// <summary>
        /// Call only for New Customer Type Insert
        /// Return Customer_type_id
        /// </summary>
        /// <param name="CustomerType">Customer Type Object</param>
        /// <returns>Return Customer_type_id</returns>
        public int Insert(tblCustomerType CustomerType)
        {
            try
            {
                MapParameters(CustomerType);
                long? Customer_type_id = manager.CallStoredProcedure_Insert("USP_CustomerType_Insert");
                if (Customer_type_id.HasValue) return (int) Customer_type_id.Value;
                else return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(tblCustomerType CustomerType)
        {
            try
            {
                manager.AddParameter(new OracleParameter("p_Customer_type_id", CustomerType.customer_type_id));
                MapParameters(CustomerType);
                manager.CallStoredProcedure_Update("USP_CustomerType_Update");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void MapParameters(tblCustomerType CustomerType)
        {
            manager.AddParameter(new OracleParameter("p_Customer_type_name", CustomerType.customer_type_name));
            manager.AddParameter(new OracleParameter("p_priority", CustomerType.priority));
        }
        public void Delete(int id)
        {
            try
            {
                manager.AddParameter(new OracleParameter("p_Customer_type_id", id));
                
                manager.CallStoredProcedure_Update("USP_CustomerType_Delete");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}