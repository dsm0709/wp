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

namespace SmsTemplate
{
    public class people
    {
        public string name { get; set; }
        public string number { get; set; }
        public people(string name, string number)
        {
            this.name = name;
            this.number = number;
        }
        public people()
        { 
        
        }

    }
}
