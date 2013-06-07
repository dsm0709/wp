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
using Microsoft.Phone.Tasks;

namespace SmsTemplate
{
    public partial class qksend : PhoneApplicationPage
    {
        App app = Application.Current as App;

        List<string> numberlist = new List<string>();

        public qksend()
        {
            InitializeComponent();
            smsSender = new SmsComposeTask();
            textBox1.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        }

        SmsComposeTask smsSender;

        private void textBox1_Loaded(object sender, RoutedEventArgs e)
        {
            App app = Application.Current as App;
            textBox1.Text = app.Sms_Text;
            app.Sms_Text = "";
            textBlock2.Text = "0";
    
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
             ListBoxItem item = (this.listBox1.ItemContainerGenerator.ContainerFromItem((sender as CheckBox).DataContext) as ListBoxItem);
             numberlist.Add((item.DataContext as people). number+";");
             textBlock2.Text = (Convert.ToInt32(textBlock2.Text) + 1).ToString();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = (this.listBox1.ItemContainerGenerator.ContainerFromItem((sender as CheckBox).DataContext) as ListBoxItem);
            numberlist.Remove((item.DataContext as people).number + ";");
            textBlock2.Text = (Convert.ToInt32(textBlock2.Text) - 1).ToString();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ////smsSender.To = textBox2.Text;
            smsSender.Body = textBox1.Text;
            foreach(string str in numberlist)
            smsSender.To += str;
            numberlist.Clear();
            textBox1.Text = "";
            smsSender.Show();
           
        }

        private void listBox1_Loaded(object sender, RoutedEventArgs e)
        {
            listBox1.ItemsSource = app.peoplelist.PeoplesCollection;
        }

        /// <summary>
        /// ///////////字体颜色美化
        /// </summary>

        private void textBox1_LostFocus(object sender, RoutedEventArgs e)
        {
            textBox1.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        }

        private void textBox1_GotFocus(object sender, RoutedEventArgs e)
        {
            var bgColor = Application.Current.Resources["PhoneBackgroundColor"].ToString();
            if (bgColor == "#FF000000")
            textBox1.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
        }





    }
}