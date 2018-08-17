using System;
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
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using System.Reactive.Concurrency;
using WpfApp1.Pages;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Observable.FromEventPattern<object, RoutedEventArgs>(btn_1, "Click").ObserveOnDispatcher().Subscribe(_ => {
                this.txt_Box.Text += "OnNext";
            },
            ex => this.txt_Box.Text += "OnError",
            ()=> this.txt_Box.Text += "Complete"
            );

            Observable.FromEventPattern<object, RoutedEventArgs>(btn_2, "Click").Subscribe(_ =>
            {
                Uri str = new Uri("./Pages/Page1.xaml");
                this.Frame.NavigationService.Navigate(new Uri("./Pages/Page1.xaml"), UriKind.Relative);
            });
        }

    }
}
