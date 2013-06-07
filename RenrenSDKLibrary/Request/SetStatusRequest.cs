using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using RenrenSDKLibrary.Constants;

namespace RenrenSDKLibrary
{
    public class SetStatusRequest
    {
        /// <summary>
        /// 发布新状态
        /// </summary>
        /// <param name="rrSDK"></param>
        /// <param name="callback"></param>
        public void SetStatus(RenrenSDK rrSDK, APIRequestCompletedHandler callback, string status)
        {
            string accessToken = RenrenSDK.RenrenInfo.tokenInfo.access_token;
            string callID = String.Format("{0}", DateTime.Now.Second);

            if (status.Length > 139 * 2)        //状态最长140字
                status = status.Substring(0, 140);

            List<APIParameter> parameters = new List<APIParameter>()
            {
                new APIParameter("method", Method.SetStatus),
                new APIParameter("access_token", accessToken),
                new APIParameter("call_id", callID),
                new APIParameter("v", "1.0"),

                new APIParameter("status", status),

                new APIParameter("format", "JSON")
            };

            string sig = ApiHelper.CalSig(parameters);
            if (string.IsNullOrEmpty(sig))
                return;
            parameters.Add(new APIParameter("sig", sig));
            rrSDK.RequestAPIInterface(new APIRequestCompletedHandler(callback), parameters);
        }
    }
}
