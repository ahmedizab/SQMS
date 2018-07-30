using qms.DAL;
using qms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace qms.BLL
{
    public class BLLServiceType
    {
        public List<tblServiceType> GetAll()
        {
            DALServiceType dal = new DALServiceType();
            DataTable dt = dal.GetAll();
            return ObjectMapping(dt);
        }
        public tblServiceType GetById(int id)
        {
            DALServiceType dal = new DALServiceType();
            DataTable dt = dal.GetById(id);
            if (dt.Rows.Count > 0)
                return ObjectMapping(dt.Rows[0]);
            else return null;
        }
        public void Create(tblServiceType serviceType)
        {
            DALServiceType dal = new DALServiceType();
            int service_type_id = dal.Insert(serviceType);
            serviceType.service_type_id = service_type_id;
        }
        public void Edit(tblServiceType serviceType)
        {
            DALServiceType dal = new DALServiceType();
             dal.Update(serviceType);
            
        }
        public void Remove(int id)
        {
            DALServiceType dal = new DALServiceType();
            dal.Delete(id);

        }
        internal List<tblServiceType> ObjectMapping(DataTable dt)
        {
            List<tblServiceType> list = new List<tblServiceType>();
            foreach (DataRow row in dt.Rows)
            {
                tblServiceType serviceType = new tblServiceType();
                serviceType.service_type_id = Convert.ToInt32(row["service_type_id"] == DBNull.Value ? 0 : row["service_type_id"]);
                serviceType.service_type_name = (row["service_type_name"] == DBNull.Value ? null : row["service_type_name"].ToString());
                list.Add(serviceType);

            }
            return list;
        }

        internal tblServiceType ObjectMapping(DataRow row)
        {
            
                tblServiceType serviceType = new tblServiceType();
                serviceType.service_type_id = Convert.ToInt32(row["service_type_id"] == DBNull.Value ? 0 : row["service_type_id"]);
                serviceType.service_type_name = (row["service_type_name"] == DBNull.Value ? null : row["service_type_name"].ToString());
                

            
            return serviceType;
        }
    }  
}