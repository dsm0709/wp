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
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Shell;
using ImageTools;
using ImageTools.Controls;
using ImageTools.IO;
using ImageTools.IO.Gif;
using System.Windows.Threading;
using RenrenSDKLibrary;
using System.IO;
using Microsoft.Xna.Framework.Media;
namespace daomeidan
{
    public partial class MainPage : PhoneApplicationPage
    {
        RenrenAPI api = App.api;

        App app = Application.Current as App;

        int col = 1;

        int remember = -1;

        string str = "哈哈你倒霉了！准备接受惩罚吧~";

        string str2 = "大家一起来看看~猜猜谁是倒霉蛋~";

        string tishi_str1 = "在菜单栏里选择相册或拍照以添加好友图片~~";

        string tishi_str2 = "您还没有选择照片或拍照哦~请在菜单栏里选择添加好友照片^-^";

        string dmd_gif1 = "Images/02.gif";
       
        string time_1 = "1...";
       
        string[] gif_arr = new string[5] { "Images/0.gif", "Images/1.gif", "Images/2.gif", "Images/3.gif", "Images/4.gif"};
        
        //CameraCaptureTask camera;

        PhotoChooserTask photochooser;

        Image[] photo = new Image[5];

        AnimatedImage[] animated_gif = new AnimatedImage[5];

        AnimatedImage btnClickgif = new AnimatedImage();

        ExtendedImage dmdgif = new ExtendedImage();

        DispatcherTimer timer1 = new DispatcherTimer();
        DispatcherTimer timer2 = new DispatcherTimer();
        DispatcherTimer timer3 = new DispatcherTimer();
        
        public MainPage()
        {
            InitializeComponent();

           // camera = new CameraCaptureTask();
            photochooser = new PhotoChooserTask();
            timer1.Interval = TimeSpan.FromSeconds(1);
            timer2.Interval = timer3.Interval = timer1.Interval;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer2.Tick += new EventHandler(timer2_Tick);
            timer3.Tick += new EventHandler(timer3_Tick);
            photochooser.Completed += new EventHandler<PhotoResult>(photochooser_Completed);
            //camera.Completed +=new EventHandler<PhotoResult>(photochooser_Completed);
            Loaded += new RoutedEventHandler(MainPage_Loaded);
            
            



            LayoutRoot.Children.Remove(daomeidan);
            
        }



        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {

                content.Text = tishi_str1;

                Decoders.AddDecoder<GifDecoder>();

                dmdgif.UriSource = new Uri(dmd_gif1, UriKind.Relative);


                for (int i = 0; i < 5; i++)
                {


                    //////////
                    photo[i] = new Image();
                    string img = string.Format(@"<Image  
                                xmlns='http://schemas.microsoft.com/client/2007'
                                xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
                                Height='95' Width='95' Stretch='Fill' 
                                Grid.Column='{0}' Grid.Row='{1}'>
                                <Image.Clip>
                                <RectangleGeometry  Rect='0, 0, 95, 95' RadiusX='20' RadiusY='20'/>
                                </Image.Clip>
                                </Image>", col, i * 2 + 1);

                    Image bmp = XamlReader.Load(img) as Image;

                    photo[i] = bmp;
                    //////////////
                    animated_gif[i] = new AnimatedImage();

                    string gif1 = string.Format(@"<it:AnimatedImage Name='igif'
                                xmlns='http://schemas.microsoft.com/client/2007'
                                xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
                                xmlns:it='clr-namespace:ImageTools.Controls;assembly=ImageTools.Controls'
                                Height='95' Width='95' Stretch='Fill' 
                                Grid.Column= '1' Grid.Row='{0}'/>
                                ", i * 2 + 1);
                    AnimatedImage animated_GIF = XamlReader.Load(gif1) as AnimatedImage;
                    ExtendedImage image = new ExtendedImage();
                    image.UriSource = new Uri(gif_arr[i], UriKind.Relative);
                    animated_GIF.Source = image;
                    animated_gif[i] = animated_GIF;
                    ////////////
                }
                if (app.RRF_head_picture != null && app.RRF_navigate_name != null)
                {
                    ++app.t_num;
                    app.row += 2;
                    BitmapImage rec = new BitmapImage();
                    rec.UriSource = new Uri(app.RRF_head_picture, UriKind.Absolute);
                    app.all_name[app.t_num - 1] = app.RRF_navigate_name;
                    app.RRF_head_picture = null;
                    app.RRF_navigate_name = null;
                    app.SavingImage[app.row / 2] = rec;
                    
                    for (int q = 0; q < app.t_num; q++)
                    {
                        photo[q].Source = app.SavingImage[q];
                        photolist.Children.Add(photo[q]);
                        switch (q)
                        {
                            case 0: textBlock1.Text = app.all_name[0]; break;
                            case 1: textBlock2.Text = app.all_name[1]; break;
                            case 2: textBlock3.Text = app.all_name[2]; break;
                            case 3: textBlock4.Text = app.all_name[3]; break;
                            case 4: textBlock5.Text = app.all_name[4]; break;
                        }
                    }
                }

                if (app.row == 9 && col == 1)
                {
                    ((ApplicationBarIconButton)this.ApplicationBar.Buttons[0]).IsEnabled = false;
                    ((ApplicationBarIconButton)this.ApplicationBar.Buttons[1]).IsEnabled = false;
                }
            
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //if (app.RRF_head_picture != null && app.RRF_navigate_name != null)
            //{
            //    ++t_num;
            //    row += 2;
            //    BitmapImage img = new BitmapImage();
            //    img.UriSource = new Uri(app.RRF_head_picture, UriKind.Absolute);
            //    app.RRF_head_picture = null;
            //    app.RRF_navigate_name = null;
            //    photo[row / 2].Source = img;
            //    photolist.Children.Add(photo[row / 2]);
            //}
        }

        void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();
            int[] allnum = new int[app.t_num];
            app.t_num = Convert.ToInt32((app.row + 1) / 2);
            if (app.t_num != 0)
            {

                rand(allnum);
                Random sui = new Random();
                int[] sui_xiabiao = new int[app.t_num];
                int r = app.t_num;
                for (int t = 0; t < sui_xiabiao.Length; sui_xiabiao[t] = 0, t++) ;
                for (int i = 0; i < app.t_num; i++)
                {
                    if (allnum[i] == -1)
                    {
                        remember = i;
                        btnClickgif = animated_gif[i];
                        btnClickgif.Source = dmdgif;

                        daomeidan.Source = photo[i].Source;
                        dmd_name.Text = app.all_name[i];
                        LayoutRoot.Children.Add(daomeidan);
                        photolist.Children.Add(btnClickgif);
                        photolist.Children.Remove(photo[i]);
                        continue;
                    }
                    else
                    {

                        photolist.Children.Add(animated_gif[i]);
                        photolist.Children.Remove(photo[i]);
                    }
                }



                ((ApplicationBarIconButton)this.ApplicationBar.Buttons[2]).IsEnabled = true;
                ((ApplicationBarIconButton)this.ApplicationBar.Buttons[3]).IsEnabled = true;
                content.Text = str;

            }
        }

        void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            content.Text += "3...";
            timer3.Start();
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            content.Text += "2...";
            timer2.Start();
        }

        void photochooser_Completed(object sender, PhotoResult e)
        {
            
            if (content.Text != str2) content.Text = str2;
            
            if (e.TaskResult == TaskResult.OK)
            {
                app.row += 2;
                ++app.t_num;
                BitmapImage bitmap = new BitmapImage();
                bitmap.SetSource(e.ChosenPhoto);
                add_photo(col, app.row, bitmap);
                app.SavingImage[app.row / 2] = bitmap;
            }
            if (app.row == 9 && col == 1)
            {
                ((ApplicationBarIconButton)this.ApplicationBar.Buttons[0]).IsEnabled = false;
                ((ApplicationBarIconButton)this.ApplicationBar.Buttons[1]).IsEnabled = false;
            }
        }

        void add_photo(int col, int row, BitmapImage bitmap)
        {
            photo[row / 2].Source = bitmap;
            photolist.Children.Add(photo[row/2]);
        }

        void rand(int[] allnum)
        {
            
            Random rand = new Random();
            int i = 0;
            for (i = 0; i < allnum.Length; i++)
            {
                allnum[i] = rand.Next(1, 100);
                for (int k = 0; k < allnum.Length; k++)
                {
                    while (true)
                    {
                        if (allnum[k] == allnum[i] && k != i)
                        {
                            allnum[i] = rand.Next(1, 100);
                            k = 0;
                        }
                        else break;
                    }
                }
            }
            int x = allnum.Max();
            for ( i = 0; allnum[i] != x; i++) ;
            allnum[i] = -1;

        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {

            NavigationService.Navigate(new Uri("/RenRenFriendList.xaml", UriKind.Relative));

        }

        private void CaptureScreen(UIElement tag)
        {
            App app = Application.Current as App;
            
            WriteableBitmap bmp = new WriteableBitmap(480,700);	
            bmp.Render(tag, null);	
            bmp.Invalidate();		

            MemoryStream stream = new MemoryStream();	
            bmp.SaveJpeg(stream, bmp.PixelWidth, bmp.PixelHeight, 0, 80);	
            stream.Seek(0, SeekOrigin.Begin);	

            MediaLibrary library = new MediaLibrary();	
            string fileName = "ScreenShot_" + DateTime.Now.ToString("yyyy-mm-dd_hh:mm:ss");
            library.SavePicture(fileName, stream);	
            stream.Close();	
            if (MessageBox.Show("上传至人人网，让大家为你作证吧？", "保存成功", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                Login_in();
            }
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {

             

            photochooser.ShowCamera = true;
            photochooser.Show();
        }

        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
            for (int i = 0; i < app.t_num; i++)
            {
                if (photolist.Children.Contains(animated_gif[i]))
                    photolist.Children.Remove(animated_gif[i]);
                if (photolist.Children.Contains(photo[i])==false)
                photolist.Children.Add(photo[i]);

            }
            LayoutRoot.Children.Remove(daomeidan);
            photolist.Children.Remove(btnClickgif);
            dmd_name.Text = "";
            if (remember != -1)
            {
                ExtendedImage image = new ExtendedImage();
                image.UriSource = new Uri(gif_arr[remember], UriKind.Relative);
                animated_gif[remember].Source = image;
            }
            remember = -1;

            ((HyperlinkButton)this.hyperlinkButton1).IsEnabled = true;
            content.Text = tishi_str1;
            ((ApplicationBarIconButton)this.ApplicationBar.Buttons[0]).IsEnabled = true;
            ((ApplicationBarIconButton)this.ApplicationBar.Buttons[1]).IsEnabled = true;

        }

        private void hyperlinkButton1_Click(object sender, RoutedEventArgs e)
        {

            if (app.t_num != 0)
            {
                ((HyperlinkButton)this.hyperlinkButton1).IsEnabled = false;
                content.Text = time_1;
                timer1.Start();
                ((ApplicationBarIconButton)this.ApplicationBar.Buttons[0]).IsEnabled = false;
                ((ApplicationBarIconButton)this.ApplicationBar.Buttons[1]).IsEnabled = false;
                ((ApplicationBarIconButton)this.ApplicationBar.Buttons[2]).IsEnabled = false;
                ((ApplicationBarIconButton)this.ApplicationBar.Buttons[3]).IsEnabled = false;
            }
            else
                MessageBox.Show(tishi_str2, "提示", MessageBoxButton.OK);

        }

        private void ApplicationBarIconButton_Click_3(object sender, EventArgs e)
        {
            for (int i = 0; i < app.t_num; i++)
            {
                if(photolist.Children.Contains(photo[i]))
                photolist.Children.Remove(photo[i]);
                if (photolist.Children.Contains(animated_gif[i]))
                    photolist.Children.Remove(animated_gif[i]);
                photo[i].Source = null;
            }
            LayoutRoot.Children.Remove(daomeidan);
            photolist.Children.Remove(btnClickgif);
            dmd_name.Text = "";
            content.Text = str2;
            app.t_num = 0;
            app.row = -1;
            textBlock1.Text = textBlock2.Text = textBlock3.Text = textBlock4.Text = textBlock5.Text = "";


            if (remember != -1)
            {
                ExtendedImage image = new ExtendedImage();
                image.UriSource = new Uri(gif_arr[remember], UriKind.Relative);
                animated_gif[remember].Source = image;
            }
            remember = -1;
            ((ApplicationBarIconButton)this.ApplicationBar.Buttons[0]).IsEnabled = true;
            ((ApplicationBarIconButton)this.ApplicationBar.Buttons[1]).IsEnabled = true;

            ((HyperlinkButton)this.hyperlinkButton1).IsEnabled = true;

            content.Text = tishi_str1;

        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void ApplicationBarMenuItem_Click_1(object sender, EventArgs e)
        {
            Login_in();
        }

        public void Login_in()
        {
            if (api.IsAccessTokenValid())
            {
                NavigationService.Navigate(new Uri("/Default.xaml", UriKind.Relative));
            }
            else
            {
                NavigationService.Navigate(new Uri("/Login_renren.xaml", UriKind.Relative));
            }
        }

        private void ApplicationBarMenuItem_Click_2(object sender, EventArgs e)
        {
            CaptureScreen(phonepage);
        }

        private void ApplicationBarMenuItem_Click_3(object sender, EventArgs e)
        {
            api.IsAccessTokenValid(-1);
        }
    }
}