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
    public class BLLDailyBreak
    {
        public List<VMDailyBreak> GetAll(int? branch_id, string user_id)
        {
            DALDailyBreak dal = new DALDailyBreak();
            DataTable dt = dal.GetAll(branch_id, user_id);
            return ObjectMappingListVM(dt);
        }

        public tblDailyBreak GetById(int id)
        {
            DALDailyBreak dal = new DALDailyBreak();
            DataTable dt = dal.GetById(id);
            if (dt.Rows.Count > 0)
                return ObjectMapping(dt.Rows[0]);
            else return null;
        }
        public void Create(tblDailyBreak dailyBreak)
        {
            DALDailyBreak dal = new DALDailyBreak();
            int daily_break_id = dal.Insert(dailyBreak);
            dailyBreak.daily_break_id = daily_break_id;
        }
        public void Edit(tblDailyBreak dailyBreak)
        {
            DALDailyBreak dal = new DALDailyBreak();
            dal.Update(dailyBreak);

        }
        public void Remove(int id)
        {
            DALDailyBreak dal = new DALDailyBreak();
            dal.Delete(id);

        }
        internal tblDailyBreak ObjectMapping(DataRow row)
        {

            tblDailyBreak dailyBreak = new tblDailyBreak();
            dailyBreak.counter_id = Convert.ToInt32(row["counter_id"] == DBNull.Value ? 0 : row["counter_id"]);
            dailyBreak.break_type_id = Convert.ToInt32(row["counter_no"] == DBNull.Value ? null : row["counter_no"].ToString());
            dailyBreak.start_time = Convert.ToDateTime(row["location"] == DBNull.Value ? null : row["location"].ToString());
            dailyBreak.user_id =(row["branch_id"] == DBNull.Value ? null : row["branch_id"].ToString());
            dailyBreak.end_time = Convert.ToDateTime(row["branch_id"] == DBNull.Value ? null : row["branch_id"].ToString());
            dailyBreak.remarks = (row["branch_id"] == DBNull.Value ? null : row["branch_id"].ToString());



            return dailyBreak;
        }
        internal List<tblDailyBreak> ObjectMappingList(DataTable dt)
        {
            List<tblDailyBreak> list = new List<tblDailyBreak>();
            foreach (DataRow row in dt.Rows)
            {
                tblDailyBreak dailyBreak = new tblDailyBreak();
                dailyBreak.counter_id = Convert.ToInt32(row["counter_id"] == DBNull.Value ? 0 : row["counter_id"]);
                dailyBreak.break_type_id = Convert.ToInt32(row["break_type_id"] == DBNull.Value ? null : row["break_type_id"].ToString());
                dailyBreak.start_time = Convert.ToDateTime(row["start_time"] == DBNull.Value ? null : row["start_time"].ToString());
                dailyBreak.user_id = (row["user_id"] == DBNull.Value ? null : row["user_id"].ToString());
                dailyBreak.end_time = Convert.ToDateTime(row["end_time"] == DBNull.Value ? null : row["end_time"].ToString());
                dailyBreak.remarks = (row["remarks"] == DBNull.Value ? null : row["remarks"].ToString());

                list.Add(dailyBreak);

            }
            return list;
        }

        internal List<VMDailyBreak> ObjectMappingListVM(DataTable dt)
        {
            List<VMDailyBreak> list = new List<VMDailyBreak>();
            foreach (DataRow row in dt.Rows)
            {
                VMDailyBreak dailyBreak = new VMDailyBreak();
                dailyBreak.daily_break_id = Convert.ToInt32(row["daily_break_id"] == DBNull.Value ? 0 : row["daily_break_id"]);
                dailyBreak.branch_name = (row["branch_name"] == DBNull.Value ? null : row["branch_name"].ToString());
                dailyBreak.counter_no = (row["counter_no"] == DBNull.Value ? null : row["counter_no"].ToString());
                dailyBreak.user_full_name = (row["hometown"] == DBNull.Value ? null : row["hometown"].ToString());
                dailyBreak.break_type_name = (row["break_type_name"] == DBNull.Value ? null : row["break_type_name"].ToString());
                dailyBreak.start_time = Convert.ToDateTime(row["start_time"] == DBNull.Value ? null : row["start_time"].ToString());
                if(row["end_time"] != DBNull.Value)dailyBreak.end_time = Convert.ToDateTime(row["end_time"].ToString());
                dailyBreak.remarks = (row["remarks"] == DBNull.Value ? null : row["remarks"].ToString());

                list.Add(dailyBreak);

            }
            return list;
        }
    }
}