using qms.DAL;
using qms.Models;
using qms.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace qms.BLL
{
    public class BLLCustomer
    {
        public List<tblCustomer> GetAll()
        {
            DALCustomer dal = new DALCustomer();
            DataTable dt = dal.GetAll();
            return ObjectMappingList(dt);
        }
        public List<VM_Customer> GetAllCustomer()
        {
            DALCustomer dal = new DALCustomer();
            DataTable dt = dal.GetAll();
            return ObjectMappingListVM(dt);
        }
        public tblCustomer GetById(int id)
        {
            DALCustomer dal = new DALCustomer();
            DataTable dt = dal.GetById(id);
            if (dt.Rows.Count > 0)
                return ObjectMapping(dt.Rows[0]);
            else return null;
        }
        public void Create(tblCustomer customer)
        {
            DALCustomer dal = new DALCustomer();
            int customer_id = dal.Insert(customer);
            customer.customer_id = customer_id;
        }
        public void Edit(tblCustomer customer)
        {
            DALCustomer dal = new DALCustomer();
            dal.Update(customer);

        }
        public void Remove(int id)
        {
            DALCustomer dal = new DALCustomer();
            dal.Delete(id);

        }
        internal tblCustomer ObjectMapping(DataRow row)
        {

            tblCustomer customer = new tblCustomer();
            customer.customer_id = Convert.ToInt32(row["customer_id"] == DBNull.Value ? 0 : row["customer_id"]);
            customer.customer_name = (row["customer_name"] == DBNull.Value ? null : row["customer_name"].ToString());
            customer.contact_no = (row["contact_no"] == DBNull.Value ? null : row["contact_no"].ToString());
            customer.address = (row["address"] == DBNull.Value ? null : row["address"].ToString());
            customer.customer_type_id = Convert.ToInt32(row["customer_type_id"] == DBNull.Value ? null : row["customer_type_id"].ToString());



            return customer;
        }
        internal List<VM_Customer> ObjectMappingListVM(DataTable dt)
        {
            List<VM_Customer> list = new List<VM_Customer>();
            foreach (DataRow row in dt.Rows)
            {
                VM_Customer customer = new VM_Customer();
                customer.customer_id = Convert.ToInt32(row["customer_id"] == DBNull.Value ? 0 : row["customer_id"]);
                customer.customer_name = (row["customer_name"] == DBNull.Value ? null : row["customer_name"].ToString());
                customer.address = (row["address"] == DBNull.Value ? null : row["address"].ToString());
                customer.contact_no = (row["contact_no"] == DBNull.Value ? null : row["contact_no"].ToString());
                customer.customer_type_name = (row["customer_type_name"] == DBNull.Value ? null : row["customer_type_name"].ToString());

                list.Add(customer);

            }
            return list;
        }
        internal List<tblCustomer> ObjectMappingList(DataTable dt)
        {
            List<tblCustomer> list = new List<tblCustomer>();
            foreach (DataRow row in dt.Rows)
            {
                tblCustomer customer = new tblCustomer();
                customer.customer_id = Convert.ToInt32(row["customer_id"] == DBNull.Value ? 0 : row["customer_id"]);
                customer.customer_name = (row["customer_name"] == DBNull.Value ? null : row["customer_name"].ToString());
                customer.address = (row["address"] == DBNull.Value ? null : row["address"].ToString());
                customer.contact_no = (row["contact_no"] == DBNull.Value ? null : row["contact_no"].ToString());


                list.Add(customer);

            }
            return list;
        }
    }
}