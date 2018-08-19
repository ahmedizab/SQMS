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
    public class BLLCounters
    {
        public List<VMCounter> GetAll()
        {
            DALCounters dal = new DALCounters();
            DataTable dt = dal.GetAll();
            return ObjectMappingListVM(dt);
        }
        public List<tblCounter> GetAllCounter()
        {
            DALCounters dal = new DALCounters();
            DataTable dt = dal.GetAll();
            return ObjectMappingList(dt);
        }
        public tblCounter GetById(int id)
        {
            DALCounters dal = new DALCounters();
            DataTable dt = dal.GetById(id);
            if (dt.Rows.Count > 0)
                return ObjectMapping(dt.Rows[0]);
            else return null;
        }
        public void Create(tblCounter counter)
        {
            DALCounters dal = new DALCounters();
            int counter_id = dal.Insert(counter);
            counter.counter_id = counter_id;
        }
        public void Edit(tblCounter counter)
        {
            DALCounters dal = new DALCounters();
            dal.Update(counter);

        }
        public void Remove(int id)
        {
            DALCounters dal = new DALCounters();
            dal.Delete(id);

        }
        internal tblCounter ObjectMapping(DataRow row)
        {

            tblCounter counter = new tblCounter();
            counter.counter_id = Convert.ToInt32(row["counter_id"] == DBNull.Value ? 0 : row["counter_id"]);
            counter.counter_no = (row["counter_no"] == DBNull.Value ? null : row["counter_no"].ToString());
            counter.location = (row["location"] == DBNull.Value ? null : row["location"].ToString());
            counter.branch_id = Convert.ToInt32(row["branch_id"] == DBNull.Value ? null : row["branch_id"].ToString());


            return counter;
        }
        internal List<VMCounter> ObjectMappingListVM(DataTable dt)
        {
            List<VMCounter> list = new List<VMCounter>();
            foreach (DataRow row in dt.Rows)
            {
                VMCounter counter = new VMCounter();
                counter.counter_id = Convert.ToInt32(row["counter_id"] == DBNull.Value ? 0 : row["counter_id"]);
                counter.counter_no = (row["counter_no"] == DBNull.Value ? null : row["counter_no"].ToString());
                counter.branch_name = (row["branch_name"] == DBNull.Value ? null : row["branch_name"].ToString());
                counter.location = (row["location"] == DBNull.Value ? null : row["location"].ToString());
                
                list.Add(counter);

            }
            return list;
        }
        internal List<tblCounter> ObjectMappingList(DataTable dt)
        {
            List<tblCounter> list = new List<tblCounter>();
            foreach (DataRow row in dt.Rows)
            {
                tblCounter counter = new tblCounter();
                counter.counter_id = Convert.ToInt32(row["counter_id"] == DBNull.Value ? 0 : row["counter_id"]);
                counter.counter_no = (row["counter_no"] == DBNull.Value ? null : row["counter_no"].ToString());
                counter.branch_id= Convert.ToInt32(row["branch_id"] == DBNull.Value ? 0 : row["branch_id"]);
                counter.location = (row["location"] == DBNull.Value ? null : row["location"].ToString());

                list.Add(counter);

            }
            return list;
        }
    }
}