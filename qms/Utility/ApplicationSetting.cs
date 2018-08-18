using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace qms.Utility
{
    public class ApplicationSetting
    {
        public static string DisplayPath
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("DisplayPath");
            }
        }

        public static int PaddingLeft
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings.Get("PaddingLeft"));
            }
        }

        public static string dispalyFooterAdd
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("dispalyFooterAdd");
            }
        }

        public static string dispalyWelcome
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("dispalyWelcome");
            }
        }

        public static string dispalyVideo
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("dispalyVideo");
            }
        }

        public static string CounterText
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("CounterText");
            }
        }

        public static string TokenText
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("TokenText");
            }
        }

        public static string voiceText
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("voiceText");
            }
        }

        public static string DisplayWhenEmptyToken
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("DisplayWhenEmptyToken");
            }
        }
    }
}