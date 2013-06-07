//  Copyright 2011年 Renren Inc. All rights reserved.
//  - Powered by Team Pegasus. -

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
    /// 照片，Modified by Myself     http://wiki.dev.renren.com/wiki/Photos.upload
    /// </summary>
    public class Photo
    {
        public int comment_count { get; set; }

        public Int64 uid { get; set; }

        public string time { get; set; }

        public string url_large { get; set; }

        public string url_head { get; set; }

        //public Source source { get; set; }

        public string caption { get; set; }

        public string url_tiny { get; set; }

        public Int64 pid { get; set; }

        public Int64 aid { get; set; }

        public string url_main { get; set; }

        public int view_count { get; set; }

        ////

        public string src_small { get; set; }


        public string src { get; set; }


        public string src_big { get; set; }
    }


    public class Source
    {
        public string text { get; set; }
        public string href { get; set; }
    }
}
