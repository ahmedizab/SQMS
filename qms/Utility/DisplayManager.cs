using qms.Models;
using qms.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace qms.Utility
{
    public class DisplayManager
    {
        private qmsEntities db = new qmsEntities();
        private BLL.BLLToken dbManager = new BLL.BLLToken();
        public void CreateTextFile(int branch_id, string static_ip)
        {
            string textFileValue = GetInProgressTokens(branch_id);
            string nextTokens = GetNextTokens(branch_id);

            if (nextTokens.Length > 0)
                textFileValue = textFileValue + "\n" + nextTokens;

            string filePath = Path.Combine(ApplicationSetting.DisplayPath, static_ip + ".txt");
            StreamWriter sw = File.CreateText(filePath);
            sw.Write(textFileValue);
            sw.Close();
        }

        public string GetInProgressTokens(int branch_id)
        {
            List<VMTokenProgress> progressingTokenList = GetInProgressTokenList(branch_id);

            StringBuilder sb = new StringBuilder();
            if (progressingTokenList.Any())
            {
                foreach (var token in progressingTokenList)
                {
                    sb.Append(token.token_no + "\t");
                }
            }


            return sb.ToString().TrimEnd('\t');
        }

        public List<VMTokenProgress> GetInProgressTokenList(int branch_id)
        {
            try
            {

                List<VMTokenProgress> progressingTokens = dbManager.GetProgressTokenList(branch_id).ToList();
                //db.GetInProgressTokenList(branch_id)
                //                        .Select(s => new VMTokenProgress
                //                            {
                //                                static_ip = s.static_ip,
                //                                counter_no = s.counter_no,
                //                                token_no = (s.token_no=="ON" ? s.token_no : s.token_no.PadLeft(ApplicationSetting.PaddingLeft,'0'))
                //                            }
                //                        ).ToList();
                return progressingTokens;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public string GetNextTokens(int branch_id)
        {
            StringBuilder sb = new StringBuilder();

            List<VMNextToken> nextTokenList = GetNextTokenList(branch_id);

            if (nextTokenList.Any())
            {
                int display_next = nextTokenList.FirstOrDefault().display_next;
                foreach (VMNextToken token in nextTokenList.Take(display_next))
                {
                    sb.Append(token.token_no.ToString().PadLeft(ApplicationSetting.PaddingLeft, '0') + ", ");
                }
            }

            string nextTokens = sb.ToString().TrimEnd(' ');
            if (nextTokens.Length > 0)
                nextTokens = nextTokens.Remove(nextTokens.Length - 1);

            return nextTokens;
        }

        public List<VMNextToken> GetNextTokenList(int branch_id)
        {
            List<VMNextToken> nextTokens = dbManager.GetNextTokenList(branch_id);
            //var nextTokens =
            //    (from b in db.tblBranches
            //     join t in db.tblTokenQueues on b.branch_id equals t.branch_id
            //     where t.service_status_id == 1 
            //        && b.branch_id == branch_id
            //        && t.service_date.Day==DateTime.Now.Day
            //        && t.service_date.Month == DateTime.Now.Month
            //        && t.service_date.Year == DateTime.Now.Year
            //     select new VMNextToken
            //     {
            //         static_ip = b.static_ip,
            //         display_next = b.display_next,
            //         token_no = t.token_no

            //     }).ToList();

            return nextTokens;
        }



        //// Not need yet
        //public List<VMNextToken> GetNextTokenCounter(int branch_id)
        //{
        //    var CounterTokens =
        //        (from b in db.tblBranches
        //         join t in db.tblTokenQueues on b.branch_id equals t.branch_id
        //         where t.service_status_id == 2 && b.branch_id == branch_id
        //         select new VMNextToken
        //         {
        //             static_ip = b.static_ip,
        //             display_next = b.display_next,
        //             token_no = t.token_no

        //         }).ToList();

        //    return CounterTokens;
        //}
        //public List<VMNextToken> GetNextTokenListCounter(int branch_id)
        //{
        //    var nextTokensCounter =
        //        (from b in db.tblBranches
        //         join t in db.tblTokenQueues on b.branch_id equals t.branch_id
        //         where t.service_status_id == 2 && b.branch_id == branch_id
        //         select new VMNextToken
        //         {
        //             static_ip = b.static_ip,
        //             display_next = b.display_next,
        //             token_no = t.token_no

        //         }).ToList();

        //    return nextTokensCounter;
        //}
        //public string GetNextTokensCounter(int branch_id)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    List<VMNextToken> nextTokenList = GetNextTokenCounter(branch_id);

        //    if (nextTokenList.Any())
        //    {
        //        int display_next = nextTokenList.FirstOrDefault().display_next;
        //        foreach (VMNextToken token in nextTokenList.Take(display_next))
        //        {
        //            sb.Append(token.token_no.ToString().PadLeft(ApplicationSetting.PaddingLeft, '0') + ", ");
        //        }
        //    }

        //    string tokenInProgress = sb.ToString().TrimEnd(' ');
        //    if (tokenInProgress.Length > 0)
        //        tokenInProgress = tokenInProgress.Remove(tokenInProgress.Length - 1);

        //    return tokenInProgress;
        //}
        //public List<VMServiceDetails> DateListService(DateTime month)
        //{
        //    SqlParameter date = new SqlParameter("@date", month);

        //    var result = db.Database.SqlQuery<VMServiceDetails>("sp_DateListService @date", date).ToList();
        //    return result;
        //}
        //public List<VMTokenQueue> DateListToken(DateTime month)
        //{
        //    SqlParameter date = new SqlParameter("@date", month);

        //    var result = db.Database.SqlQuery<VMTokenQueue>("sp_DateListToken @date", date).ToList();
        //    return result;
        //}
        
        //public int SendSms(int tokenId)
        //{
        //    try
        //    {
        //        SqlParameter token = new SqlParameter("@token_id", tokenId);
        //        db.Database.ExecuteSqlCommand("spINSERT_dbo_SmsLog @token_id", token);
        //        db.SaveChanges();
        //        return 1;

        //    }
        //    catch (Exception ex)
        //    {
        //        //throw new Exception ex.Message.ToString();
        //        return 0;
        //    }
            
        //}
    }
}