﻿#pragma checksum "C:\Users\July\Desktop\xinghoxiaozu\xinghoxiaozu\RenrenSDKLibrary\Pages\UploadPhotoPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0CFA95E7906F70B0805B5817BF682117"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.233
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace RenrenSDKLibrary {
    
    
    public partial class UploadPhotoPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel logoPanel;
        
        internal System.Windows.Controls.StackPanel ProgressPanel;
        
        internal Microsoft.Phone.Controls.PerformanceProgressBar uploadingBar;
        
        internal System.Windows.Controls.TextBlock tb_uploading;
        
        internal System.Windows.Controls.StackPanel userPanel;
        
        internal System.Windows.Controls.Image img_head_border;
        
        internal System.Windows.Controls.Image img_head;
        
        internal System.Windows.Controls.TextBlock tb_id;
        
        internal System.Windows.Controls.StackPanel countPanel;
        
        internal System.Windows.Controls.TextBlock tb_count;
        
        internal System.Windows.Controls.TextBox tbx_caption;
        
        internal System.Windows.Controls.Grid imgPanel;
        
        internal System.Windows.Controls.Border outborder;
        
        internal System.Windows.Controls.Border middleborder;
        
        internal System.Windows.Controls.Border innerborder;
        
        internal System.Windows.Controls.Image img_pic;
        
        internal System.Windows.Controls.StackPanel btnPanel;
        
        internal System.Windows.Controls.Button btn_upload;
        
        internal System.Windows.Controls.Button btn_cancel;
        
        internal System.Windows.Shapes.Rectangle disableRect;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/RenrenSDKLibrary;component/Pages/UploadPhotoPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.logoPanel = ((System.Windows.Controls.StackPanel)(this.FindName("logoPanel")));
            this.ProgressPanel = ((System.Windows.Controls.StackPanel)(this.FindName("ProgressPanel")));
            this.uploadingBar = ((Microsoft.Phone.Controls.PerformanceProgressBar)(this.FindName("uploadingBar")));
            this.tb_uploading = ((System.Windows.Controls.TextBlock)(this.FindName("tb_uploading")));
            this.userPanel = ((System.Windows.Controls.StackPanel)(this.FindName("userPanel")));
            this.img_head_border = ((System.Windows.Controls.Image)(this.FindName("img_head_border")));
            this.img_head = ((System.Windows.Controls.Image)(this.FindName("img_head")));
            this.tb_id = ((System.Windows.Controls.TextBlock)(this.FindName("tb_id")));
            this.countPanel = ((System.Windows.Controls.StackPanel)(this.FindName("countPanel")));
            this.tb_count = ((System.Windows.Controls.TextBlock)(this.FindName("tb_count")));
            this.tbx_caption = ((System.Windows.Controls.TextBox)(this.FindName("tbx_caption")));
            this.imgPanel = ((System.Windows.Controls.Grid)(this.FindName("imgPanel")));
            this.outborder = ((System.Windows.Controls.Border)(this.FindName("outborder")));
            this.middleborder = ((System.Windows.Controls.Border)(this.FindName("middleborder")));
            this.innerborder = ((System.Windows.Controls.Border)(this.FindName("innerborder")));
            this.img_pic = ((System.Windows.Controls.Image)(this.FindName("img_pic")));
            this.btnPanel = ((System.Windows.Controls.StackPanel)(this.FindName("btnPanel")));
            this.btn_upload = ((System.Windows.Controls.Button)(this.FindName("btn_upload")));
            this.btn_cancel = ((System.Windows.Controls.Button)(this.FindName("btn_cancel")));
            this.disableRect = ((System.Windows.Shapes.Rectangle)(this.FindName("disableRect")));
        }
    }
}

