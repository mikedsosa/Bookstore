﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Http;



namespace Mike05.Infrastructure
{
    public static class SessionExtensions
    {
        //convert cart object TO Json string file
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        //convert cart object FROM Json string file
        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);

            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
