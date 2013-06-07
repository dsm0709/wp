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
    public partial class peo : PhoneApplicationPage
    {

        App app = Application.Current as App;

        Boolean modify_break = false;
        people modify_temp = new people();
        public peo()
        {
            InitializeComponent();
            phonenumberchooser = new PhoneNumberChooserTask();
            phonenumberchooser.Completed += new EventHandler<PhoneNumberResult>(phonenumberchooser_Completed);
               
        }

        PhoneNumberChooserTask phonenumberchooser;



        void phonenumberchooser_Completed(object sender, PhoneNumberResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                textBox1.Text = e.PhoneNumber;
                textBox2.Text = e.DisplayName;
                textBox1.Foreground = textBox2.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }
        }

        private void modify_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = (this.listBox1.ItemContainerGenerator.ContainerFromItem((sender as MenuItem).DataContext) as ListBoxItem);
            people rec = item.DataContext as people;
            textBox2.Text = rec.name;
            textBox1.Text = rec.number;            
            textBox1.Foreground = textBox2.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            modify_break = true;
            modify_temp = item.DataContext as people;
        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = (this.listBox1.ItemContainerGenerator.ContainerFromItem((sender as MenuItem).DataContext) as ListBoxItem);
            string rec = (item.DataContext as people).number.ToString();
            modify_temp = item.DataContext as people;
            app.peoplelist.PeoplesCollection.Remove(item.DataContext as people);
            app.settings.Remove(rec);
            app.settings.Save();
        }

        private void button2_Click(object sender, RoutedEventArgs e)//确定
        {
            

            if (textBox1.Text.Trim() != "")
            {
                Boolean k = true;
                if (textBox2.Text == "")
                    textBox2.Text = textBox1.Text;
                foreach (string str in app.settings.Keys)
                    if (textBox1.Text == str && modify_break != true)
                    { MessageBox.Show("该号码已存在。"); k = false; break; }
                if (k && modify_break != true)
                {
                    app.settings[textBox1.Text] = textBox2.Text;
                    app.peoplelist.PeoplesCollection.Add(new people(textBox2.Text, textBox1.Text));
                    textBox1.Text = textBox2.Text = "";
                    app.settings.Save();
                    MessageBox.Show("添加成功", "", MessageBoxButton.OK);
                }
                else if (k && modify_break == true)
                {
                    app.settings.Remove(modify_temp.number);
                    app.peoplelist.PeoplesCollection.Remove(modify_temp);
                    app.settings[textBox1.Text] = textBox2.Text;
                    app.peoplelist.PeoplesCollection.Add(new people(textBox2.Text, textBox1.Text));
                    textBox1.Text = textBox2.Text = "";
                    app.settings.Save();
                    MessageBox.Show("修改成功", "", MessageBoxButton.OK);
                }
            }
            else
                MessageBox.Show("号码不能为空！");
        }




        private void button1_Click(object sender, RoutedEventArgs e)
        {
            phonenumberchooser.Show();
        }

       

        private void ListBox_Loaded(object sender, RoutedEventArgs e)
        {
            listBox1.ItemsSource = app.peoplelist.PeoplesCollection;
        }


        /// <summary>
        /// ///////////字体颜色优化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_LostFocus(object sender, RoutedEventArgs e)
        {
            textBox2.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

        }
        private void textbox1_LostFocus(object sender, RoutedEventArgs e)
        {
            textBox1.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        }
        private void textBox2_GotFocus(object sender, RoutedEventArgs e)
        {
            var bgColor = Application.Current.Resources["PhoneBackgroundColor"].ToString();
            if (bgColor == "#FF000000")
            textBox2.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        }

        private void textBox1_GotFocus(object sender, RoutedEventArgs e)
        {

            var bgColor = Application.Current.Resources["PhoneBackgroundColor"].ToString();
            if (bgColor == "#FF000000")
            textBox1.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
        }


    }
}