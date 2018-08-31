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
using SpeechLib;
using WpfApp1.Pages;
using System.Windows.Controls.Primitives;

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
            //InitializeCC();
            InitialNoReflection();
        }

        private void Btn_Audio(object sender, RoutedEventArgs e)
        {
           

        }
        /// <summary>
        /// 这种方式会用到反射 ， 不是太好 下面的方法才是最好的 
        /// </summary>
        private void InitializeCC()
        {
            IObservable<RoutedEventArgs> ccTest = Observable.FromEventPattern<RoutedEventArgs>(this.btn_test, "Click")
                .Select(x => x.EventArgs);
            ccTest.Subscribe(x => MessageBox.Show(x.ToString()));
        }

        private void InitialNoReflection()
        {
            btn_test.ClickAsObservable().Subscribe(
                x =>
                {
                   var type = x.GetType();
                   MessageBox.Show("no Reflection ");
                });
        }

        

    }
    public static class ButtonBaseExtensions
    {
        public static IObservable<RoutedEventArgs> ClickAsObservable(this ButtonBase button)
        {
            return Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(
                    h => h.Invoke,
                    h => button.Click += h, h => button.Click -= h)
                .Select(x => x.EventArgs);
        }
    }
}
