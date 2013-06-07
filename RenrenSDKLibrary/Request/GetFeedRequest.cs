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
using System.IO;
using System.Text;
using System.Collections.Generic;
using RenrenSDKLibrary.Constants;
using RenrenSDKLibrary.Controls;
using Microsoft.Phone.Controls;
using System.Collections.ObjectModel;


namespace RenrenSDKLibrary
{
    public class GetFeedRequest
    {
        /// <summary>
        /// 读取新鲜事
        /// </summary>
        /// <param name="rrSDK"></param>
        /// <param name="callback"></param>
        public void GetFeed(RenrenSDK rrSDK, APIRequestCompletedHandler callback, string types="10,30")
        {
            string accessToken = RenrenSDK.RenrenInfo.tokenInfo.access_token;
            string callID = String.Format("{0}", DateTime.Now.Second);

            List<APIParameter> parameters = new List<APIParameter>()
            {
                new APIParameter("method", Method.GetFeed),
                new APIParameter("access_token", accessToken),
                new APIParameter("call_id", callID),
                new APIParameter("v", "1.0"),
                
                //new APIParameter("type", "10,20,21,30,32,33,34,40,50,51,52"),//新鲜事的类别，多个类型以逗号分隔，
                new APIParameter("type", types),//新鲜事的类别，多个类型以逗号分隔，

                new APIParameter("format", "JSON")
                //new APIParameter("page", page.ToString())
                //new APIParameter("count", count.ToString())
            };
            string sig = ApiHelper.CalSig(parameters);
            if (string.IsNullOrEmpty(sig))
                return;
            parameters.Add(new APIParameter("sig", sig));
            rrSDK.RequestAPIInterface(new APIRequestCompletedHandler(callback), parameters);
        }
    }
}
