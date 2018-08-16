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
    public class BLLServiceSubType
    {
        public List<VMServiceType> GetAll()
        {
            DALServiceSubType dal = new DALServiceSubType();
            DataTable dt = dal.GetAll();
            return ObjectMappingListVM(dt);
        }

        public List<VMServiceType> GetByTypeId(int service_type_id)
        {
            DALServiceSubType dal = new DALServiceSubType();
            DataTable dt = dal.GetByTypeId(service_type_id);
            return ObjectMappingListVM(dt);
        }

        public tblServiceSubType GetById(int id)
        {
            DALServiceSubType dal = new DALServiceSubType();
            DataTable dt = dal.GetById(id);
            if (dt.Rows.Count > 0)
                return ObjectMapping(dt.Rows[0]);
            else return null;
        }
        public void Create(tblServiceSubType servicesubType)
        {
            DALServiceSubType dal = new DALServiceSubType();
            int service_sub_type_id = dal.Insert(servicesubType);
            servicesubType.service_sub_type_id = service_sub_type_id;
        }
        public void Edit(tblServiceSubType servicesubType)
        {
            DALServiceSubType dal = new DALServiceSubType();
            dal.Update(servicesubType);

        }
        public void Remove(int id)
        {
            DALServiceSubType dal = new DALServiceSubType();
            dal.Delete(id);

        }
        internal tblServiceSubType ObjectMapping(DataRow row)
        {

            tblServiceSubType servicesubType = new tblServiceSubType();
            servicesubType.service_sub_type_id = Convert.ToInt32(row["service_sub_type_id"] == DBNull.Value ? 0 : row["service_sub_type_id"]);
            servicesubType.service_sub_type_name = (row["service_sub_type_name"] == DBNull.Value ? null : row["service_sub_type_name"].ToString());
            servicesubType.service_type_id = Convert.ToInt32(row["service_type_id"] == DBNull.Value ? null : row["service_type_id"].ToString());
            servicesubType.max_duration = Convert.ToInt32(row["max_duration"] == DBNull.Value ? null : row["max_duration"].ToString());
           

            return servicesubType;
        }

        internal List<tblServiceSubType> ObjectMappingListTBL(DataTable dt)
        {
            List<tblServiceSubType> list = new List<tblServiceSubType>();
            foreach (DataRow row in dt.Rows)
            {
                tblServiceSubType services = new tblServiceSubType();
                services.service_sub_type_id = Convert.ToInt32(row["service_sub_type_id"] == DBNull.Value ? 0 : row["service_sub_type_id"]);
                services.service_sub_type_name = (row["service_sub_type_name"] == DBNull.Value ? null : row["service_sub_type_name"].ToString());
                services.max_duration = Convert.ToInt32(row["max_duration"] == DBNull.Value ? null : row["max_duration"].ToString());
                services.service_type_id = Convert.ToInt32(row["service_type_id"] == DBNull.Value ? null : row["service_type_id"].ToString());
                list.Add(services);

            }
            return list;
        }

        internal List<VMServiceType> ObjectMappingListVM(DataTable dt)
        {
            List<VMServiceType> list = new List<VMServiceType>();
            foreach (DataRow row in dt.Rows)
            {
                VMServiceType services = new VMServiceType();
                services.service_sub_type_id = Convert.ToInt32(row["service_sub_type_id"] == DBNull.Value ? 0 : row["service_sub_type_id"]);
                services.service_sub_type_name = (row["service_sub_type_name"] == DBNull.Value ? null : row["service_sub_type_name"].ToString());
                services.max_duration = Convert.ToInt32(row["max_duration"] == DBNull.Value ? null : row["max_duration"].ToString());
                services.service_type_name = (row["service_type_name"] == DBNull.Value ? null : row["service_type_name"].ToString());

                list.Add(services);

            }
            return list;
        }
    }
}