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
using Microsoft.Xna.Framework.Media;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Tasks;
using System.IO;
using System.Windows.Threading;

namespace daomeidan
{
    public partial class Default : PhoneApplicationPage
    {
        RenrenAPI api = App.api;

        private UserDetails user ;

        private PhotoChooserTask phototask = new PhotoChooserTask();

        App app = Application.Current as App;

        private BitmapImage image;

        private string fileName;

        public Default()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Default_Loaded);
            phototask.Completed += new EventHandler<PhotoResult>(phototask_Completed);
        }

        private void Choosebtn_Click(object sender, RoutedEventArgs e)
        {
            phototask.Show();
        }

        void phototask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                image = new BitmapImage();
                image.SetSource(e.ChosenPhoto);
                fileName = e.OriginalFileName;
                renrenbitmap.Source = image;
            }
        }

        void Default_Loaded(object sender, RoutedEventArgs e)
        {
            api.GetCurUserInfo(renren_GetCurUserInfoCompletedHandler);
            MessageBox.Show("点击\"选择\"按钮在相册中选择截图上传至人人网吧~");
   
        }

        public void renren_GetCurUserInfoCompletedHandler(object sender, GetUserUidCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                NavigationService.GoBack();
            }
            else
            {
               user = new UserDetails();
                user = e.Result;

                BitmapImage img = new BitmapImage();
                img.UriSource = new Uri(user.tinyurl, UriKind.Absolute);
                photo.Source = img;
                UserDetials.Text = user.name;
            }
        }

        private void Publishbtn_Click(object sender, RoutedEventArgs e)
        {
            api.PublishPhoto(image, fileName, UphotPhoto_DownloadStringCompleted,
         descriptbox.Text);
        }

        private void UphotPhoto_DownloadStringCompleted(object sender,RenrenSDKLibrary.UploadPhotoCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                MessageBox.Show("上传成功");
            }

        }

        private void descriptbox_GotFocus(object sender, RoutedEventArgs e)
        {
            descriptbox.Text = "";
        }

        private void descriptbox_LostFocus(object sender, RoutedEventArgs e)
        {
           
        }
    }
}