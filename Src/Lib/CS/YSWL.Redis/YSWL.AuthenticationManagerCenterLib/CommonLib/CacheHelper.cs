using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSWL.AuthenticationManagerCenterLib.CommonLib
{
    public class CacheHelper
    {
        /// <summary>
        /// 获取指定缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetObject<T>(string key) where T : class
        {
            return YSWL.RedisClient.RedisBase.GetValue<T>(key);
        }

        /// <summary>
        /// 缓存指定泛型对象
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="key">key</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static bool SetObject<T>(string key, T value) where T : class
        {
            return YSWL.RedisClient.RedisBase.SetValue<T>(key, value);
        }

        /// <summary>
        /// 设置缓存并指定有效时间
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static bool SetObject<T>(string key, T value, TimeSpan ts) where T : class
        {
            return YSWL.RedisClient.RedisBase.SetValue<T>(key, value, ts);
        }

        /// <summary>
        /// 设置过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="ts"></param>
        public static void SetExpireIn(string key, TimeSpan ts)
        {
            YSWL.RedisClient.RedisBase.SetExpireIn(key, ts);
        }

        /// <summary>
        /// 移除指定的key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Remove(string key)
        {
            return YSWL.RedisClient.RedisBase.Remove(key);
        }

        /// <summary>
        /// 将json串转为对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="jsonStr">json串</param>
        /// <returns></returns>
        public static T ConvertJsonToObject<T>(string jsonStr)
        {
            return YSWL.RedisClient.RedisBase.ConvertJsonToObject<T>(jsonStr);
        }

        /// <summary>
        /// 将对象转换为json串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ConvertObjectToJson<T>(T obj)
        {
            return YSWL.RedisClient.RedisBase.ConvertObjectToJson<T>(obj);
        }
    }
}
