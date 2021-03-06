﻿//  Copyright 2011年 Renren Inc. All rights reserved.
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

namespace RenrenSDKLibrary.Constants
{
    public static class Method
    {
        public static string CreateAlbum = "photos.createAlbum";
        public static string GetAlbums = "photos.getAlbums";
        public static string GetFriendsID = "friends.get";
        public static string GetFriends = "friends.getFriends"; 
        public static string AreFriend = "friends.areFriends";
        public static string GetAppFriends = "friends.getAppFriends";
        public static string UploadPhoto = "photos.upload";
		public static string GetInfo = "users.getInfo";

        public static string GetFeed = "feed.get";  //获取新鲜事
        public static string GetStatus = "status.get";  //返回用户某条状态，不包含回复内容
        public static string GetPhotos = "photos.get";  //获取照片
        public static string SetStatus = "status.set";  //发布新状态
    }
}
