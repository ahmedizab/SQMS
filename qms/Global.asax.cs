using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Configuration;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.SqlClient;
using System;
using qms.SignalRHub;
using Microsoft.AspNet.SignalR;

namespace qms
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //RegisterNotification();
        }
        private void RegisterNotification()
        {
            //Get the connection string from the Web.Config file. Make sure that the key exists and it is the connection string for the Notification Database and the NotificationList Table that we created

            string connectionString = ConfigurationManager.ConnectionStrings["QMSConnectionString"].ConnectionString;

            //We have selected the entire table as the command, so SQL Server executes this script and sees if there is a change in the result, raise the event
            string commandText = @"
                                    Select
                                        counter_id,
                                        token_no,
                                        service_status_id                                   
                                    From
                                        tblTokenQueue                                     
                                    ";

            //Start the SQL Dependency
            SqlDependency.Start(connectionString);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    connection.Open();
                    var sqlDependency = new SqlDependency(command);


                    sqlDependency.OnChange += new OnChangeEventHandler(sqlDependency_OnChange);

                    // NOTE: You have to execute the command, or the notification will never fire.
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                    }
                }
            }
        }

       
        private void sqlDependency_OnChange(object sender, SqlNotificationEventArgs e)
        {

            if (e.Info == SqlNotificationInfo.Update)
            {
                //This is how signalrHub can be accessed outside the SignalR Hub Notification.cs file
                var context = GlobalHost.ConnectionManager.GetHubContext<NotifyDisplay>();

                context.Clients.All.response("dbchange");

            }
            //Call the RegisterNotification method again
            RegisterNotification();
        }
    }
}
