using qms.BLL;
using qms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qms.Utility
{
    public class ApiManager
    {
        public static AspNetUser ValidUserBySecurityToken(string securityToken)
        {
            try
            {
                string loginProvider = Cryptography.Decrypt(securityToken, true);
                BLLAspNetUser dbUser = new BLLAspNetUser();
                AspNetUser user = dbUser.GetUserBySecurityCode(loginProvider);
                if (user != null)
                {

                    return user;
                }
                throw new Exception("Invalid security token");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}