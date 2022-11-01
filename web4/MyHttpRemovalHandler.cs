﻿using System;
using System.Web;

namespace web4
{
    public class MyHttpRemovalHandler : IHttpModule
    {
        /// <summary>
        /// You will need to configure this module in the Web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            // Below is an example of how you can handle LogRequest event and provide 
            // custom logging implementation for it
            context.LogRequest += new EventHandler(this.handle_EndRequest);
        }

        #endregion

        public void handle_EndRequest(Object sender, EventArgs e)
        {
            HttpResponse response = HttpContext.Current.Response;
            if (response != null)
            {
                var responseHeaders = response.Headers;
                if (responseHeaders != null)
                {
                    responseHeaders.Remove("X-AspNet-Version");
                    responseHeaders.Remove("Server");
                    responseHeaders.Remove("ETag");
                }
            }
            //custom logging logic can go here
        }
    }
}
