﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp1.Template
{
    /// <summary>
    /// Page4.xaml 的交互逻辑
    /// </summary>
    public partial class Page4 : Page
    {
        ObservableCollection<Page3.StudentNotify> persons = new ObservableCollection<Page3.StudentNotify>()
        {
            new Page3.StudentNotify() { Name ="LearningHard", Age=25},
            new Page3.StudentNotify() { Name ="HelloWorld", Age=22}
        };
        public Page4()
        {
            InitializeComponent();
            lstPerson.ItemsSource = persons;
        }
    }
}
