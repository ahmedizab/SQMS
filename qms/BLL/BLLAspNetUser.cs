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
    public class BLLAspNetUser
    {
        public List<AspNetUser> GetAllUser()
        {
            DALAspNetUser dal = new DALAspNetUser();
            DataTable dt = dal.GetAllUser();
            return ObjectMappingList(dt);
        }

        public VMSessionInfo GetSessionInfoByUserName(string userName)
        {
            DALAspNetUser dal = new DALAspNetUser();
            DataTable dt = dal.GetSessionInfoByUserName(userName);
            return ObjectMappingSession(dt);
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

        internal VMSessionInfo ObjectMappingSession(DataTable dt)
        {
            if(dt.Rows.Count>0)
            {
                DataRow row = dt.Rows[0];
                VMSessionInfo sessionInfo = new VMSessionInfo();
                sessionInfo.user_id = (row["user_id"] == DBNull.Value ? null : row["user_id"].ToString());
                sessionInfo.user_name = (row["user_name"] == DBNull.Value ? null : row["user_name"].ToString());
                sessionInfo.role_name = (row["role_name"] == DBNull.Value ? null : row["role_name"].ToString());
                sessionInfo.branch_id = (row["branch_id"] == DBNull.Value ? 0 : (int)row["branch_id"]);
                sessionInfo.branch_name = (row["branch_name"] == DBNull.Value ? null : row["branch_name"].ToString());
                sessionInfo.branch_static_ip = (row["branch_static_ip"] == DBNull.Value ? null : row["branch_static_ip"].ToString());
                return sessionInfo;

            }
            return null;
        }
    }
}