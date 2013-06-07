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
    public class GetPhotosRequest
    {
        /// <summary>
        /// 读取状态
        /// </summary>
        /// <param name="rrSDK"></param>
        /// <param name="callback"></param>
        public void GetPhotos(RenrenSDK rrSDK, APIRequestCompletedHandler callback, string uid, string pids, string aid)
        {
            string accessToken = RenrenSDK.RenrenInfo.tokenInfo.access_token;
            string callID = String.Format("{0}", DateTime.Now.Second);

            List<APIParameter> parameters = new List<APIParameter>()
            {
                new APIParameter("method", Method.GetPhotos),
                new APIParameter("access_token", accessToken),
                new APIParameter("call_id", callID),
                new APIParameter("v", "1.0"),

                new APIParameter("uid", uid),

                new APIParameter("format", "JSON")
            };

            //状态信息所属用户id，不指定则根据sk判断为当前用户
            if (!string.IsNullOrEmpty(pids))
            {
                parameters.Add(new APIParameter("pids", pids));
            }
            if (!string.IsNullOrEmpty(aid))
            {
                parameters.Add(new APIParameter("aid", aid));
            }

            string sig = ApiHelper.CalSig(parameters);
            if (string.IsNullOrEmpty(sig))
                return;
            parameters.Add(new APIParameter("sig", sig));
            rrSDK.RequestAPIInterface(new APIRequestCompletedHandler(callback), parameters);
        }
    }
}
