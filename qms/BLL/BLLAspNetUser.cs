using qms.DAL;
using qms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace qms.BLL
{
    public class BLLAspNetUser
    {
        public List<AspNetUser> GetAllUser()
        {
            DALAspNetUser dal = new DALAspNetUser();
            DataTable dt = dal.GetAllUser();
            return ObjectMappingList(dt);
        }


        internal List<AspNetUser> ObjectMappingList(DataTable dt)
        {
            List<AspNetUser> list = new List<AspNetUser>();
            foreach (DataRow row in dt.Rows)
            {
                AspNetUser user = new AspNetUser();
                user.Id = (row["Id"] == DBNull.Value ? null : row["Id"].ToString());
                user.PhoneNumber = (row["PhoneNumber"] == DBNull.Value ? null : row["PhoneNumber"].ToString());
                user.UserName = (row["UserName"] == DBNull.Value ? null : row["UserName"].ToString());
                user.Email = (row["Email"] == DBNull.Value ? null : row["Email"].ToString());
                user.Hometown = (row["Hometown"] == DBNull.Value ? null : row["Hometown"].ToString());
                

                list.Add(user);

            }
            return list;
        }
    }
}