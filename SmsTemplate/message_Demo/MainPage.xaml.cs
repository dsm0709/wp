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

namespace SmsTemplate
{
    public partial class MainPage : PhoneApplicationPage
    {
        App app = Application.Current as App;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            foreach (string str in app.settings.Keys)
            {
                string rec = app.settings[str].ToString();
                if (rec != "_Q_W_E_R_T_Y")
                    app.peoplelist.PeoplesCollection.Add(new people(app.settings[str].ToString(), str));
            }
        }
        

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Demo.xaml", UriKind.Relative));
        }

        private void ListBox_Loaded(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();
            foreach (string str in app.settings.Keys)
            {
                string rec = app.settings[str].ToString();
                if (rec == "_Q_W_E_R_T_Y")
                    listBox1.Items.Add(str);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/peo.xaml", UriKind.Relative));
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
                app.Sms_Text = listBox1.SelectedItem.ToString();
            NavigationService.Navigate(new Uri("/qksend.xaml", UriKind.Relative));
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            string rec = (this.listBox1.ItemContainerGenerator.ContainerFromItem((sender as MenuItem).DataContext) as ListBoxItem).DataContext.ToString().Trim();
            app.Sms_Text= rec;
            NavigationService.Navigate(new Uri("/qksend.xaml", UriKind.Relative));
            
        }

        private void modify_Click(object sender, RoutedEventArgs e)
        {         
            string rec = (this.listBox1.ItemContainerGenerator.ContainerFromItem((sender as MenuItem).DataContext) as ListBoxItem).DataContext.ToString().Trim();
            app.modify_sms = rec;
            NavigationService.Navigate(new Uri("/Demo.xaml", UriKind.Relative));
        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {
            string rec = (this.listBox1.ItemContainerGenerator.ContainerFromItem((sender as MenuItem).DataContext) as ListBoxItem).DataContext.ToString().Trim();
            listBox1.Items.Remove(rec);
            app.settings.Remove(rec);
        }

        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/peo.xaml", UriKind.Relative));
        }

        private void TextBlock_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string rec = (this.listBox1.ItemContainerGenerator.ContainerFromItem((sender as TextBlock).DataContext) as ListBoxItem).DataContext.ToString().Trim();
            app.Sms_Text = rec;
            NavigationService.Navigate(new Uri("/qksend.xaml", UriKind.Relative));
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Help.xaml", UriKind.Relative));
        }





    }
}