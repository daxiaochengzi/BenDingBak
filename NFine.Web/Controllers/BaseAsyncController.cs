﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;


namespace NFine.Web.Controllers
{/// <summary>
/// 
/// </summary>
    public abstract class BaseAsyncController : AsyncController
    {
     /// <summary>
     /// 
     /// </summary>
     /// <param name="data"></param>
     /// <param name="contentType"></param>
     /// <param name="contentEncoding"></param>
     /// <param name="behavior"></param>
     /// <returns></returns>
        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new ToJsonResult
            {
                Data = data,
                ContentEncoding = contentEncoding,
                ContentType = contentType,
                JsonRequestBehavior = behavior,
                FormateStr = "yyyy-MM-dd HH:mm:ss",
               
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected JsonResult MyJson(object data)
        {
            return new ToJsonResult
            {
                Data = data,
                FormateStr = "yyyy-MM-dd"
            };
        }
        /// <summary>
        /// 说明：转化为Jason
        /// 作者: 
        /// </summary>
        public class ToJsonResult : JsonResult
        {
            const string error = "该请求已被封锁，因为敏感信息透露给第三方网站，这是一个GET请求时使用的。为了可以GET请求，请设置JsonRequestBehavior AllowGet。";
            /// <summary>
            /// 格式化字符串
            /// </summary>
            public string FormateStr
            {
                get;
                set;
            }
            /// <summary>
            /// 说明：重写ExecueResult方法
            /// 作者：    
            /// </summary>
            /// <param name="context"></param>
            public override void ExecuteResult(ControllerContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException("context");
                }
                if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                    String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException(error);
                }
                HttpResponseBase response = context.HttpContext.Response;

                if (!String.IsNullOrEmpty(ContentType))
                {
                    response.ContentType = ContentType;
                }
                else
                {
                    response.ContentType = "application/json";
                }
                if (ContentEncoding != null)
                {
                    response.ContentEncoding = ContentEncoding;
                }
                if (Data != null)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();

                    string jsonstring = serializer.Serialize(Data);
                 
                    //string hashOldPassword = @"\\/Date\((\param+)\+\param+\)\\/";
                    string p = @"\\/Date\(\d+\)\\/";
                    MatchEvaluator matchEvaluator = new MatchEvaluator(ConvertJsonDateToDateString);
                    Regex reg = new Regex(p);
                    jsonstring = reg.Replace(jsonstring, matchEvaluator);
                    response.Write(jsonstring);
                }
            }

          
            /// 说明：将Json序列化的时间由/Date(1294499956278+0800)转为字符串
 
           
            private string ConvertJsonDateToDateString(Match m)
            {
                string result = string.Empty;
                string p = @"\d";
                var cArray = m.Value.ToCharArray();
                StringBuilder sb = new StringBuilder();
                Regex reg = new Regex(p);
                for (int i = 0; i < cArray.Length; i++)
                {
                    if (reg.IsMatch(cArray[i].ToString()))
                    {
                        sb.Append(cArray[i]);
                    }
                }
                // reg.Replace(m.Value;
                DateTime dt = new DateTime(1970, 1, 1);
                dt = dt.AddMilliseconds(long.Parse(sb.ToString()));
                dt = dt.ToLocalTime();
                result = dt.ToString(this.FormateStr);
                return result;
            }
        }
       
    }
}
