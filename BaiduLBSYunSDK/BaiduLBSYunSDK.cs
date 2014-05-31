using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Globalization;
using System.Threading;
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;

using BaiduLBSYunSDK.Structs;

namespace BaiduLBSYunSDK
{
    /// <summary>
    /// Baidu LBSYun SDK
    /// API: http://developer.baidu.com/map/
    /// author: Rex Zhang
    /// company: 19Where.com
    /// </summary>
    public partial class BaiduLBSYunSDK
    {
        private const string API_DOMAIN = "api.map.baidu.com/geodata/v3";
        private const string DL = "/";
        private readonly string _ak;
        private readonly string _sn;
        private readonly string _host;
        public const string ApiVersion = "3.0";
        public const string Version = "1.0.0";


        public BaiduLBSYunSDK(string ak, string sn, string host)
        {
            this._ak = ak;
            this._sn = sn;
            this._host = host;
        }
        #region geotable
        #region Post
        public BadiuLBSYunResult geotableCreate(string geotableName, int geoType, int isPublished, UInt32 timestamp)
        {
            string paraUrlCoded = "name=" + geotableName + "&geotype=" + geoType + "&is_published=" + isPublished + "&timestamp=" + timestamp + "&ak=" + _ak;
            if (!String.IsNullOrEmpty(_sn))
            {
                paraUrlCoded += ("&sn=" + _sn);
            }
            byte[] postData = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            HttpWebResponse response = netWork(
                method: BadiuLBSYunMethods.POST,
                entity: BadiuLBSYunEntitys.GEOTABLE,
                operation: BadiuLBSYunOperations.CREATE,
                postData: postData
                );
            Stream s = response.GetResponseStream();
            StreamReader sr = new StreamReader(s);
            string json = sr.ReadToEnd();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            BadiuLBSYunResult re = jss.Deserialize<BadiuLBSYunResult>(json);
            return re;
        }
        public BadiuLBSYunResult geotableUpdate(int geotableId, int isPublished, string geoTableName = null)
        {
            string paraUrlCoded = "id=" + geotableId + "&is_published=" + isPublished + "&ak=" + _ak;
            if (!String.IsNullOrEmpty(_sn))
            {
                paraUrlCoded += ("&sn=" + _sn);
            }
            if (!String.IsNullOrEmpty(geoTableName))
            {
                paraUrlCoded += ("&name=" + geoTableName);
            }
            byte[] postData = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            HttpWebResponse response = netWork(
                method: BadiuLBSYunMethods.POST,
                entity: BadiuLBSYunEntitys.GEOTABLE,
                operation: BadiuLBSYunOperations.UPDATE,
                postData: postData
                );
            Stream s = response.GetResponseStream();
            StreamReader sr = new StreamReader(s);
            string json = sr.ReadToEnd();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            BadiuLBSYunResult re = jss.Deserialize<BadiuLBSYunResult>(json);
            return re;
        }
        public BadiuLBSYunResult geotableDelete(int geotableId)
        {
            string paraUrlCoded = "id=" + geotableId + "&ak=" + _ak;
            if (!String.IsNullOrEmpty(_sn))
            {
                paraUrlCoded += ("&sn=" + _sn);
            }

            byte[] postData = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            HttpWebResponse response = netWork(
                method: BadiuLBSYunMethods.POST,
                entity: BadiuLBSYunEntitys.GEOTABLE,
                operation: BadiuLBSYunOperations.DELETE,
                postData: postData
                );
            Stream s = response.GetResponseStream();
            StreamReader sr = new StreamReader(s);
            string json = sr.ReadToEnd();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            BadiuLBSYunResult re = jss.Deserialize<BadiuLBSYunResult>(json);
            return re;
        }
        #endregion
        #region Get
        public BadiuLBSYunResult geotableList(string geotableName)
        {
            string paraUrlCoded = "ak=" + _ak;
            if (!string.IsNullOrEmpty(geotableName))
            {
                paraUrlCoded += ("&name=" + geotableName);
            }

            if (!String.IsNullOrEmpty(_sn))
            {
                paraUrlCoded += ("&sn=" + _sn);
            }
            string getData = "?" + paraUrlCoded;
            HttpWebResponse response = netWork(
                method: BadiuLBSYunMethods.GET,
                entity: BadiuLBSYunEntitys.GEOTABLE,
                operation: BadiuLBSYunOperations.LIST,
                getData: getData
                );
            Stream s = response.GetResponseStream();
            StreamReader sr = new StreamReader(s);
            string json = sr.ReadToEnd();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            BadiuLBSYunResult re = jss.Deserialize<BadiuLBSYunResult>(json);
            return re;
        }
        public BadiuLBSYunResult geotableDetail(int geotableId)
        {
            string paraUrlCoded = "ak=" + _ak + "&id=" + geotableId.ToString();

            if (!String.IsNullOrEmpty(_sn))
            {
                paraUrlCoded += ("&sn=" + _sn);
            }
            string getData = "?" + paraUrlCoded;
            HttpWebResponse response = netWork(
                method: BadiuLBSYunMethods.GET,
                entity: BadiuLBSYunEntitys.GEOTABLE,
                operation: BadiuLBSYunOperations.DETAIL,
                getData: getData
                );
            Stream s = response.GetResponseStream();
            StreamReader sr = new StreamReader(s);
            string json = sr.ReadToEnd();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            BadiuLBSYunResult re = jss.Deserialize<BadiuLBSYunResult>(json);
            return re;
        }
        #endregion
        #endregion
        #region network
        private HttpWebResponse netWork(string method, string entity, string operation, byte[] postData = null, string getData = null, Hashtable headers = null)
        {
            if (getData != null)
            {
                operation += getData;
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://" + API_DOMAIN + DL + entity + DL + operation);
            request.Method = method;
            request.ContentType = "application/x-www-form-urlencoded";
            if (String.IsNullOrEmpty(_host))
            {
                //request.Host = _host;
            }
            if (headers != null)
            {
                foreach (DictionaryEntry var in headers)
                {
                    request.Headers.Add(var.Key.ToString(), var.Value.ToString());
                }
            }
            switch (method)
            {
                case BadiuLBSYunMethods.POST:
                    if (postData != null)
                    {
                        Stream dataStream = request.GetRequestStream();
                        dataStream.Write(postData, 0, postData.Length);
                        dataStream.Close();
                    }
                    break;
                case BadiuLBSYunMethods.GET:
                    break;
            }

            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                //this.tmp_infos = new Hashtable();
                //foreach (var hl in response.Headers)
                //{
                //    string name = (string)hl;
                //    if (name.Length > 7 && name.Substring(0, 7) == "x-upyun")
                //    {
                //        this.tmp_infos.Add(name, response.Headers[name]);
                //    }
                //}
            }
            catch (Exception e)
            {
                throw e;
            }

            return response;
        }
        #endregion

        #region Utils
        /// <summary>  
        /// Get Unix TimeSpan 
        /// </summary>  
        /// <param name="time"> </param>
        /// <returns></returns>  
        public static UInt32 GetUnixTimeStamp(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (UInt32)(time - startTime).TotalSeconds;
        }
        /// <summary>
        /// Get DateTime
        /// </summary>
        /// <param name="unixTimeStamp"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(UInt32 unixTimeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            TimeSpan toNow = new TimeSpan(unixTimeStamp);
            return dtStart.Add(toNow);
        }
        #endregion

    }
}
