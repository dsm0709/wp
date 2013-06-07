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
using System.IO.IsolatedStorage;
using System.IO;

namespace SmsTemplate
{
    public partial class Demo : PhoneApplicationPage
    {
        App app = Application.Current as App;

        string rec = "";

        public Demo()
        {
            InitializeComponent();
        }
        
       
        
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (app.modify_sms != "")
                textBox1.Text = app.modify_sms;
            else 
            textBox1.Text = "";
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
         if (textBox1.Text.Trim() != "")
         {
             app.settings[textBox1.Text.Trim()] = "_Q_W_E_R_T_Y";
             if (rec != "" && textBox1.Text.Trim() != app.modify_sms)
                 app.settings.Remove(app.modify_sms);
             app.settings.Save();
             app.modify_sms = "";
             rec = "";
         }
         NavigationService.GoBack();
            
        }

       
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
           
            if (app.modify_sms == "")
                textBlock1.Text = "添加";
            else
            {
                textBlock1.Text = "修改";
                rec = app.modify_sms.Trim();
                textBox1.Text = rec;
            }

            
        }

        private void textBox1_LostFocus(object sender, RoutedEventArgs e)
        {
            textBox1.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        }

        private void textBox1_GotFocus(object sender, RoutedEventArgs e)
        {
            var bgColor = Application.Current.Resources["PhoneBackgroundColor"].ToString();
            if (bgColor == "#FF000000")
            textBox1.Foreground = new SolidColorBrush(Color.FromArgb(255, 0,0,0));
        }

    }
}