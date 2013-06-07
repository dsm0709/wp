using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using RenrenSDKLibrary;
using System.Collections;

namespace daomeidan
{
    public partial class RenRenFriendList : PhoneApplicationPage
    {
        RenrenAPI api = App.api;

        App app = Application.Current as App;

        int Back_Key = 1;

        public RenRenFriendList()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(RenRenFriendList_Loaded);
        }

        void RenRenFriendList_Loaded(object sender, RoutedEventArgs e)
        {
            if (!api.IsAccessTokenValid() && Back_Key == 1)
            {
                Back_Key = -1;
                NavigationService.Navigate(new Uri("/Login_renren.xaml", UriKind.Relative));
            }
            else if (!api.IsAccessTokenValid() && Back_Key == -1) ;

            else
                api.GetFriends(renren_GetFriendsCompletedHandler);
            
        }

        public void renren_GetFriendsCompletedHandler(object sender, GetFriendsCompletedEventArgs e)
        {

            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                NavigationService.GoBack();
            }
            else
                FriendList_LBox.ItemsSource = e.Result;
        }

        private void FriendList_LBox_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if(FriendList_LBox.SelectedValue != null)
            {
                app.RRF_head_picture = (FriendList_LBox.SelectedItem as Friend).headurl;
                app.RRF_navigate_name = (FriendList_LBox.SelectedItem as Friend).name;
                MessageBox.Show("添加成功！");
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }
    }
}