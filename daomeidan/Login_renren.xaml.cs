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
using System.Windows.Markup;

namespace daomeidan
{
    public partial class Login_renren : PhoneApplicationPage
    {
        private int back_key ;
        public Login_renren()
        {
            InitializeComponent();
            back_key = 1;
            oauthControl.Scope = "read_user_blog+read_user_checkin+read_user_feed+read_user_guestbook+read_user_invitation+read_user_like_history+read_user_message+read_user_notification+read_user_photo+read_user_status+read_user_album+read_user_comment+read_user_share+read_user_request+publish_blog+publish_checkin+publish_feed+publish_share+write_guestbook+send_invitation+send_request+send_message+status_update+create_album+publish_comment+operate_like+photo_upload";
            Loaded += new RoutedEventHandler(Login_renren_Loaded);
        }

        void Login_renren_Loaded(object sender, RoutedEventArgs e)
        {
            oauthControl.LoginCompleted += new LoginCompletedHandler(oauthControl_LoginCompleted);
        }

        void oauthControl_LoginCompleted(object sender, LoginCompletedEventArgs e)
        {
            if (e.Error == null && back_key == 1)
                NavigationService.GoBack();
            // NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));



                //{
            //    back_key = -1;
            //    NavigationService.Navigate(new Uri("/Default.xaml?prepage=Login", UriKind.Relative));
            //}
            //if (e.Error == null && back_key == -1)
            //{
            //    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            //}

            else
                MessageBox.Show(e.Error.Message);
        }
    }
}