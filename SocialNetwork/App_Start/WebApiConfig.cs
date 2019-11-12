﻿using System.Web.Http;
using System.Web.Http.Cors;

namespace SocialNetwork
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.MapHttpAttributeRoutes();
        }
    }
}
