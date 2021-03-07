namespace DotNetCenter.Beyond.Web.Core.Utils
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Text.Json;
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value) => session.SetString(key, JsonSerializer.Serialize(value));
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) :
            JsonSerializer.Deserialize<T>(value);
        }
        public static void SetBoolean(this ISession session, string key, bool value) => session.Set(key, BitConverter.GetBytes(value));
        public static bool? GetBoolean(this ISession session, string key)
        {
            var data = session.Get(key);
            if (data == null)
                return null;
            return BitConverter.ToBoolean(data, 0);
        }
        public static void SetDouble(this ISession session, string key, double value) => session.Set(key, BitConverter.GetBytes(value));
        public static double? GetDouble(this ISession session, string key)
        {
            var data = session.Get(key);
            if (data == null)
            {
                return null;
            }
            return BitConverter.ToDouble(data, 0);
        }
    }
}