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
    public class BLLBranchUsers
    {
        public List<VMBranchLogin> GetAll()
        {
            DALBranchUsers dal = new DALBranchUsers();
            DataTable dt = dal.GetAll();
            return ObjectMappingList(dt);
        }


        internal List<VMBranchLogin> ObjectMappingList(DataTable dt)
        {
            List<VMBranchLogin> list = new List<VMBranchLogin>();
            foreach (DataRow row in dt.Rows)
            {
                VMBranchLogin branchuser = new VMBranchLogin();
                branchuser.user_branch_id = Convert.ToInt32(row["user_branch_id"] == DBNull.Value ? 0 : row["user_branch_id"]);
               
                branchuser.branch_name = (row["branch_name"] == DBNull.Value ? null : row["branch_name"].ToString());
                branchuser.Hometown = (row["Hometown"] == DBNull.Value ? null : row["Hometown"].ToString());
                branchuser.UserName = (row["UserName"] == DBNull.Value ? null : row["UserName"].ToString());
                branchuser.Name = (row["Name"] == DBNull.Value ? null : row["Name"].ToString());
                list.Add(branchuser);

            }
            return list;
        }
        public tblBranchUser GetById(int id)
        {
            DALBranchUsers dal = new DALBranchUsers();
            DataTable dt = dal.GetById(id);
            if (dt.Rows.Count > 0)
                return ObjectMapping(dt.Rows[0]);
            else return null;
        }
        public void Create(tblBranchUser branchuser)
        {
            DALBranchUsers dal = new DALBranchUsers();
            int user_branch_id = dal.Insert(branchuser);
            branchuser.user_branch_id = user_branch_id;
        }
        public void Edit(tblBranchUser branchuser)
        {
            DALBranchUsers dal = new DALBranchUsers();
            dal.Update(branchuser);

        }
        public void Remove(int id)
        {
            DALBranchUsers dal = new DALBranchUsers();
            dal.Delete(id);

        }
        internal tblBranchUser ObjectMapping(DataRow row)
        {

            tblBranchUser branchuser = new tblBranchUser();
            branchuser.branch_id = Convert.ToInt32(row["branch_id"] == DBNull.Value ? 0 : row["branch_id"]);
            branchuser.user_id = (row["user_id"] == DBNull.Value ? null : row["user_id"].ToString());


            return branchuser;
        }
    }
}