﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace Mike05.Infrastructure
{
    public static class UrlExtensions
    {
        //http request comes in. updated string URL comes out of this statement to let the browser know that the cart has been updated
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
    }
}
