using qms.DAL;
using qms.Models;
using qms.Utility;
using qms.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace qms.BLL
{
    public class BLLToken
    {
        public List<VMTokenQueue> GetAll()
        {
            DALToken dal = new DALToken();
            DataTable dt = dal.GetAll();
            return ObjectMappingList(dt);
        }

        public List<VMTokenSkipped> GetSkipped(int? branch_id, string user_id)
        {
            DALToken dal = new DALToken();
            DataTable dt = dal.GetSkipped(branch_id, user_id);
            return ObjectMappingList_SkippedList(dt);
        }

        public List<VMTokenQueue> GetByBranchId(int branch_id)
        {
            DALToken dal = new DALToken();
            DataTable dt = dal.GetByBranchId(branch_id);
            return ObjectMappingList(dt);
        }

        public List<tblTokenQueue> GetAllToken()
        {
            DALToken dal = new DALToken();
            DataTable dt = dal.GetAll();
            return ObjectMappingListToken(dt);
        }
        public List<VMNextToken> GetNextTokenList(int branch_id)
        {
            DALToken dal = new DALToken();
            DataTable dt = dal.GetNextTokenList(branch_id);
            return ObjectMappingList_GetNextTokenList(dt);
        }
        public List<VMTokenProgress> GetProgressTokenList(int branch_id)
        {
            DALToken dal = new DALToken();
            DataTable dt = dal.GetProgressTokenList(branch_id);
            return ObjectMappingList_ProgressTokenList(dt);
        }
        internal List<VMTokenQueue> ObjectMappingList(DataTable dt)
        {
            List<VMTokenQueue> list = new List<VMTokenQueue>();
            foreach (DataRow row in dt.Rows)
            {
                VMTokenQueue token = new VMTokenQueue();
                token.token_id = Convert.ToInt64(row["token_id"] == DBNull.Value ? 0 : row["token_id"]);
                token.token_no = Convert.ToInt32(row["token_no"] == DBNull.Value ? null : row["token_no"].ToString());
                token.branch_name = (row["branch_name"] == DBNull.Value ? null : row["branch_name"].ToString());
                token.contact_no = (row["contact_no"] == DBNull.Value ? null : row["contact_no"].ToString());
                token.service_date = Convert.ToDateTime(row["service_date"] == DBNull.Value ? null : row["service_date"].ToString());
                
                token.service_status = (row["service_status"] == DBNull.Value ? null : row["service_status"].ToString());
               

                list.Add(token);

            }
            return list;
        }
        internal List<tblTokenQueue> ObjectMappingListToken(DataTable dt)
        {
            List<tblTokenQueue> list = new List<tblTokenQueue>();
            foreach (DataRow row in dt.Rows)
            {
                tblTokenQueue token = new tblTokenQueue();
                token.token_id = Convert.ToInt64(row["token_id"] == DBNull.Value ? 0 : row["token_id"]);
                token.token_no = Convert.ToInt32(row["token_no"] == DBNull.Value ? null : row["token_no"].ToString());
                
                token.contact_no = (row["contact_no"] == DBNull.Value ? null : row["contact_no"].ToString());
                token.service_date = Convert.ToDateTime(row["service_date"] == DBNull.Value ? null : row["service_date"].ToString());
                


                list.Add(token);

            }
            return list;
        }
        internal List<VMNextToken> ObjectMappingList_GetNextTokenList(DataTable dt)
        {
            List<VMNextToken> list = new List<VMNextToken>();
            foreach (DataRow row in dt.Rows)
            {
                VMNextToken token = new VMNextToken();
                token.token_no = Convert.ToInt64(row["token_no"] == DBNull.Value ? null : row["token_no"]);
                token.display_next = Convert.ToInt32(row["display_next"] == DBNull.Value ? null : row["display_next"]);
                token.static_ip = (row["static_ip"] == DBNull.Value ? null : row["static_ip"].ToString());

                list.Add(token);

            }
            return list;
        }
        internal List<VMTokenProgress> ObjectMappingList_ProgressTokenList(DataTable dt)
        {
            List<VMTokenProgress> list = new List<VMTokenProgress>();
            foreach (DataRow row in dt.Rows)
            {
                VMTokenProgress token = new VMTokenProgress();
                
                token.token_no = (row["token_no"] == DBNull.Value ? ApplicationSetting.DisplayWhenEmptyToken : row["token_no"].ToString());
                
                token.counter_no = (row["counter_no"] == DBNull.Value ? null : row["counter_no"].ToString());
               
                token.static_ip = (row["static_ip"] == DBNull.Value ? null : row["static_ip"].ToString());

                list.Add(token);

            }
            return list;
        }

        internal List<VMTokenSkipped> ObjectMappingList_SkippedList(DataTable dt)
        {
            List<VMTokenSkipped> list = new List<VMTokenSkipped>();
            foreach (DataRow row in dt.Rows)
            {
                VMTokenSkipped token = new VMTokenSkipped();

                token.token_id = Convert.ToInt64(row["token_id"] == DBNull.Value ? 0 : row["token_id"]);
                token.token_no = Convert.ToInt32(row["token_no"] == DBNull.Value ? null : row["token_no"].ToString());
                token.branch_name = (row["branch_name"] == DBNull.Value ? null : row["branch_name"].ToString());
                token.counter_no = (row["counter_no"] == DBNull.Value ? null : row["counter_no"].ToString());
                token.service_date = Convert.ToDateTime(row["service_date"] == DBNull.Value ? null : row["service_date"].ToString());
                token.service_status_id = Convert.ToInt16(row["service_status_id"] == DBNull.Value ? 0 : row["service_status_id"]);
                token.service_status = (row["service_status"] == DBNull.Value ? null : row["service_status"].ToString());
                token.contact_no = (row["contact_no"] == DBNull.Value ? null : row["contact_no"].ToString());
                token.customer_name = (row["customer_name"] == DBNull.Value ? null : row["customer_name"].ToString());
                token.cancel_time = Convert.ToDateTime(row["cancel_time"] == DBNull.Value ? null : row["cancel_time"].ToString());
                token.user_full_name = (row["HOMETOWN"] == DBNull.Value ? null : row["HOMETOWN"].ToString());

                list.Add(token);

            }
            return list;
        }


        public void Create(tblTokenQueue token)
        {
            DALToken dal = new DALToken();
            dal.Insert(token);
        }

        public void ReInitiate(long token_id)
        {
            DALToken dal = new DALToken();
            dal.ReInitiate(token_id);
        }
        public void AssignToMe(long token_id,int counter_id)
        {
            DALToken dal = new DALToken();
            dal.AssignToMe(token_id,counter_id);
        }
        public void SendSMS(string msisdn, string message)
        {
            DALSMSManager dal = new DALSMSManager();
            dal.SendSMS(msisdn, message);
        }
    }
}