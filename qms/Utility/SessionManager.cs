using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qms.Utility
{
    public class SessionManager
    {
        private HttpSessionStateBase _session;
        public SessionManager(HttpSessionStateBase session)
        {
            _session = session;
        }

        public string user_id
        {
            get
            {
                return (_session["user_id"] == null ? "" : _session["user_id"] as string);
            }
            set
            {
                _session["user_id"] = value;
            }
        }

        public string user_name
        {
            get
            {
                return (_session["user_name"] == null ? "" : _session["user_name"] as string);
            }
            set
            {
                _session["user_name"] = value;
            }
        }

        public int branch_id
        {
            get
            {
                return (_session["branch_id"] == null ? 0 : (int)_session["branch_id"]);
            }
            set
            {
                _session["branch_id"] = value;
            }
        }

        public string branch_name
        {
            get
            {
                return (_session["branch_name"] == null ? "" : _session["branch_name"] as string);
            }
            set
            {
                _session["branch_name"] = value;
            }
        }

        public string branch_static_ip
        {
            get
            {
                return (_session["branch_static_ip"] == null ? "" : _session["branch_static_ip"] as string);
            }
            set
            {
                _session["branch_static_ip"] = value;
            }
        }

        public int counter_id
        {
            get
            {
                return (_session["counter_id"] == null ? 0 :(int) _session["counter_id"]);
            }
            set
            {
                _session["counter_id"] = value;
            }
        }

        public string counter_no
        {
            get
            {
                return (_session["counter_no"] == null ? "" : _session["counter_no"] as string);
            }
            set
            {
                _session["counter_no"] = value;
            }
        }
       
        public void Close()
        {
            _session.Clear();
            _session.Abandon();
            
        }
    }
}