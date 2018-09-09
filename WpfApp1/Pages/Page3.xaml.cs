﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ClassEntity;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Page3.xaml 的交互逻辑
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
            this.DataContext = new Student()
            {
                Name = "xiaozhu",
                Age = 26
            };
            //this.stackPanel.DataContext = new Student()
            //{
            //    Name = "chenchang",
            //    Age = 26
            //};
        }
    }
}