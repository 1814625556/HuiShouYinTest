using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
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

namespace WpfTest2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly NavigationService _ns;      //获取导航控件
        public MainWindow()
        {
            InitializeComponent();
            _ns = Application.Current.Windows.OfType<MainWindow>().Single().Frame.NavigationService;
            //Load();
        }

        private void BtnDaoHangClick(object sender,RoutedEventArgs e)
        {
            // 导航
            //var navigationService = Application.Current.Windows.OfType<MainWindow>().Single().Frame.NavigationService;      //获取导航控件
            //navigationService.Navigate(new Uri("pack://application:,,,/MainPages/Navigation1.xaml"));
            //--------------------------------------------------------------------------------------------------------

            // 用户自定义控件
            this.PopUp.Content = new UserControls.UserControl1();
        }

        public void Load()
        {
            _ns.Navigate(new Uri("pack://application:,,,/MainPages/Navigation1.xaml"));
        }

    }
}
