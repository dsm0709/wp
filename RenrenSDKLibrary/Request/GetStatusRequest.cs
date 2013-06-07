﻿using System;
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
    public class GetStatusRequest
    {
        /// <summary>
        /// 读取状态
        /// </summary>
        /// <param name="rrSDK"></param>
        /// <param name="callback"></param>
        public void GetStatus(RenrenSDK rrSDK, APIRequestCompletedHandler callback, string status_id, string owner_id = null)
        {
            string accessToken = RenrenSDK.RenrenInfo.tokenInfo.access_token;
            string callID = String.Format("{0}", DateTime.Now.Second);

            List<APIParameter> parameters = new List<APIParameter>()
            {
                new APIParameter("method", Method.GetStatus),
                new APIParameter("access_token", accessToken),
                new APIParameter("call_id", callID),
                new APIParameter("v", "1.0"),

                new APIParameter("status_id", "status_id"),

                new APIParameter("format", "JSON")
            };

            //状态信息所属用户id，不指定则根据sk判断为当前用户
            if (owner_id != null)
            {
                parameters.Add(new APIParameter("owner_id", owner_id));
            }

            string sig = ApiHelper.CalSig(parameters);
            if (string.IsNullOrEmpty(sig))
                return;
            parameters.Add(new APIParameter("sig", sig));
            rrSDK.RequestAPIInterface(new APIRequestCompletedHandler(callback), parameters);
        }
    }
}
