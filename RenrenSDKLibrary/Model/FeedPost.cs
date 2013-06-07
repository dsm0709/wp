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
using System.Linq;
using System.Configuration;
using System.Windows.Data;

namespace RenrenSDKLibrary
{
    /// <summary>
    /// 新鲜事 by Myself
    /// </summary>
    public class FeedPost
    {
        public Int64 actor_id { get; set; }

        public string actor_type { get; set; }  //e.g. user

        public Int64 source_id { get; set; }

        public int feed_type { get; set; }//e.g.10, 新鲜事的类型！改成Enum

        public List<Feed_Media> attachment { get; set; }

        public Int64 post_id { get; set; }

        public string headurl { get; set; }

        public string message { get; set; }

        public string title { get; set; }

        public string update_time { get; set; }//e.g.2010-01-01 12:21:49

        public string description { get; set; } //日志描述

        public Likes likes { get; set; }

        public string name { get; set; }

        public string prefix { get; set; }  //"发表了一篇日志\"

        public string href { get; set; }    //日志链接

        public Comments comments { get; set; }

        /////////////////////////

        public string attachment0_src
        {
            get
            {
                if (attachment == null || attachment.Count == 0) return null;
                return attachment[0].src;
            }
        }
        public string attachment0_content
        {
            get
            {
                if (attachment == null || attachment.Count == 0) return null;
                return attachment[0].content;
            }
        }
    }

    public class Feed_Media
    {
        public string content;
        public string raw_src;
        public string media_type;       //e.g. photo???
        public string owner_name;   //???
        public Int64 media_id;
        public Int64 owner_id;
        public string src;
        public string href;
    }

    public class Comment
    {
        public Int64 uid;
        public Int64 comment_id;
        public string time;
        public string text;
        public string name;
        public string headurl;
    }

    public class Comments
    {
        public int count;
        public List<Comment> comment = new List<Comment>();
    }

    public class Likes
    {
        public int friend_count;
        public int user_like;
        public int total_count;
    }

    //public class Source
    //{
    //    public string text;
    //    public string href;
    //}

    //public class Place
    //{
    //    public Int64 lbs_id;
    //    public string name;
    //    public string address;
    //    public string url;
    //    public float longitude;
    //    public float latitude;
    //}


    /// <summary>
    /// 类型转换器
    /// </summary>
    //[ValueConversion(typeof(Color), typeof(SolidColorBrush))]
    public class FeedPostToIsImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility isImage = Visibility.Visible;
            switch ((int)value) //feed_type
            {
                case 10: isImage = Visibility.Collapsed; break;
                case 30: isImage = Visibility.Visible; break; //发图片
            }
            return isImage;
        }//Visibility

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }


}
