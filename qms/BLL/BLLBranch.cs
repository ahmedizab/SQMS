using qms.DAL;
using qms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace qms.BLL
{
    public class BLLBranch 
    {
        public List<tblBranch> GetAllBranch()
        {
            DALBranch dal = new DALBranch();
            DataTable dt = dal.GetAllBranch();
            return ObjectMappingList(dt);
        }


        internal List<tblBranch> ObjectMappingList(DataTable dt)
        {
            List<tblBranch> list = new List<tblBranch>();
            foreach (DataRow row in dt.Rows)
            {
                tblBranch branch = new tblBranch();
                branch.branch_id = Convert.ToInt32(row["branch_id"] == DBNull.Value ? 0 : row["branch_id"]);
                branch.branch_name = (row["branch_name"] == DBNull.Value ? null : row["branch_name"].ToString());
                branch.contact_no = (row["contact_no"] == DBNull.Value ? null : row["contact_no"].ToString());
                branch.contact_person = (row["contact_person"] == DBNull.Value ? null : row["contact_person"].ToString());
                branch.address = (row["address"] == DBNull.Value ? null : row["address"].ToString());
                branch.static_ip = (row["static_ip"] == DBNull.Value ? null : row["static_ip"].ToString());

                branch.display_next = Convert.ToInt32(row["display_next"] == DBNull.Value ? null : row["display_next"].ToString());

                list.Add(branch);

            }
            return list;
        }
        public tblBranch GetById(int id)
        {
            DALBranch dal = new DALBranch();
            DataTable dt = dal.GetById(id);
            if (dt.Rows.Count > 0)
                return ObjectMapping(dt.Rows[0]);
            else return null;
        }
        public void Create(tblBranch branch)
        {
            DALBranch dal = new DALBranch();
            int branch_id = dal.Insert(branch);
            branch.branch_id = branch_id;
        }
        public void Edit(tblBranch branch)
        {
            DALBranch dal = new DALBranch();
            dal.Update(branch);

        }
        public void Remove(int id)
        {
            DALBranch dal = new DALBranch();
            dal.Delete(id);

        }
        //public void Dispose()
        //{
        //    Dispose(true);

        //}
        internal tblBranch ObjectMapping(DataRow row)
        {

            tblBranch branch = new tblBranch();
            branch.branch_id = Convert.ToInt32(row["branch_id"] == DBNull.Value ? 0 : row["branch_id"]);
            branch.branch_name = (row["branch_name"] == DBNull.Value ? null : row["branch_name"].ToString());
            branch.contact_no = (row["contact_no"] == DBNull.Value ? null : row["contact_no"].ToString());
            branch.contact_person = (row["contact_person"] == DBNull.Value ? null : row["contact_person"].ToString());
            branch.address = (row["address"] == DBNull.Value ? null : row["address"].ToString());
            branch.static_ip = (row["static_ip"] == DBNull.Value ? null : row["static_ip"].ToString());

            branch.display_next = Convert.ToInt32(row["display_next"] == DBNull.Value ? null : row["display_next"].ToString());


            return branch;
        }
    }
}