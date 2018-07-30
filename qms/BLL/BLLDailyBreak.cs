using qms.DAL;
using qms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace qms.BLL
{
    public class BLLDailyBreak
    {
        public List<tblDailyBreak> GetAll()
        {
            DALCounters dal = new DALCounters();
            DataTable dt = dal.GetAll();
            return ObjectMappingList(dt);
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
                dailyBreak.break_type_id = Convert.ToInt32(row["counter_no"] == DBNull.Value ? null : row["counter_no"].ToString());
                dailyBreak.start_time = Convert.ToDateTime(row["location"] == DBNull.Value ? null : row["location"].ToString());
                dailyBreak.user_id = (row["branch_id"] == DBNull.Value ? null : row["branch_id"].ToString());
                dailyBreak.end_time = Convert.ToDateTime(row["branch_id"] == DBNull.Value ? null : row["branch_id"].ToString());
                dailyBreak.remarks = (row["branch_id"] == DBNull.Value ? null : row["branch_id"].ToString());

                list.Add(dailyBreak);

            }
            return list;
        }
    }
}