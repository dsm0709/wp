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

namespace RenrenSDKLibrary
{
    /// <summary>
    /// 状态 by Myslef        //http://wiki.dev.renren.com/wiki/Status.get
    /// </summary>
    public class Status //若数据有place信息会崩溃么？
    {
        public Int64 uid { get; set; }
        public int comment_count { get; set; }
        public string source_url { get; set; }
        public string forward_message { get; set; }
        public Int64 status_id { get; set; }
        public Int64 root_uid { get; set; }
        public string message { get; set; }
        public string time { get; set; }
        public int forward_count { get; set; }
        public string source_name { get; set; }
        public Int64 root_status_id { get; set; }
        public string root_message { get; set; }
        public string root_username { get; set; }
    }
}
