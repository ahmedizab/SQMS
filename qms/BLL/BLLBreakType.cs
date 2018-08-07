using qms.DAL;
using qms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace qms.BLL
{
    public class BLLBreakType
    {
        public List<tblBreakType> GetAll()
        {
            DALBreakType dal = new DALBreakType();
            DataTable dt = dal.GetAll();
            return ObjectMappingList(dt);
        }

        public tblBreakType GetById(int id)
        {
            DALBreakType dal = new DALBreakType();
            DataTable dt = dal.GetById(id);
            if (dt.Rows.Count > 0)
                return ObjectMapping(dt.Rows[0]);
            else return null;
        }
        public void Create(tblBreakType breakType)
        {
            DALBreakType dal = new DALBreakType();
            int break_type_id = dal.Insert(breakType);
            breakType.break_type_id = break_type_id;
        }
        public void Edit(tblBreakType breakType)
        {
            DALBreakType dal = new DALBreakType();
            dal.Update(breakType);

        }
        public void Remove(int id)
        {
            DALBreakType dal = new DALBreakType();
            dal.Delete(id);

        }
        internal tblBreakType ObjectMapping(DataRow row)
        {

            tblBreakType breakType = new tblBreakType();
            breakType.break_type_id = Convert.ToInt32(row["break_type_id"] == DBNull.Value ? 0 : row["break_type_id"]);
            breakType.break_type_name = (row["break_type_name"] == DBNull.Value ? null : row["break_type_name"].ToString());
            breakType.break_type_short_name = (row["break_type_short_name"] == DBNull.Value ? null : row["break_type_short_name"].ToString());
            breakType.duration = Convert.ToInt32(row["duration"] == DBNull.Value ? null : row["duration"].ToString());
            breakType.start_time = Convert.ToDateTime(row["start_time"] == DBNull.Value ? null : row["start_time"].ToString());
            breakType.end_time = Convert.ToDateTime(row["end_time"] == DBNull.Value ? null : row["end_time"].ToString());



            return breakType;
        }
        internal List<tblBreakType> ObjectMappingList(DataTable dt)
        {
            List<tblBreakType> list = new List<tblBreakType>();
            foreach (DataRow row in dt.Rows)
            {
                tblBreakType breakType = new tblBreakType();
                breakType.break_type_id = Convert.ToInt32(row["break_type_id"] == DBNull.Value ? 0 : row["break_type_id"]);
                breakType.break_type_name = (row["break_type_name"] == DBNull.Value ? null : row["break_type_name"].ToString());
                breakType.break_type_short_name = (row["break_type_short_name"] == DBNull.Value ? null : row["break_type_short_name"].ToString());
                breakType.duration = Convert.ToInt32(row["duration"] == DBNull.Value ? null : row["duration"].ToString());
                breakType.start_time = Convert.ToDateTime(row["start_time"] == DBNull.Value ? null : row["start_time"].ToString());
                breakType.end_time = Convert.ToDateTime(row["end_time"] == DBNull.Value ? null : row["end_time"].ToString());


                list.Add(breakType);

            }
            return list;
        }
    }
}