using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpfshutdownTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShutDown(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMoTai(object sender, RoutedEventArgs e)
        {
            Form frm1 = new Form();
            frm1.Title = "我是模态窗口!";
            frm1.ShowDialog();//打开模态窗口（对话框）  
        }

        private void BtnNoMoTai(object sender, RoutedEventArgs e)
        {
            Form frm2 = new Form();
            frm2.Title = "我是非模态窗口!";
            frm2.Show();//打开非模态窗口（对话框） 
        }
    }
}
