using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using WebAPI.Lib;
using Dapper;

namespace WebAPI.Filter
{
    public class Login : Attribute, IAuthorizationFilter
    {
        bool isDev = true;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (isDev)
            {
                context.HttpContext.Items["UID"] = 1;
            }


            /* <summary>
                * custom your authorization program here
                * </summary> */
        }
    }
}
