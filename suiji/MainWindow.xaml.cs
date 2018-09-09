using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace suiji
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
        CancellationTokenSource cts = new CancellationTokenSource();
        private void btn_calc(object sender, RoutedEventArgs e)
        {
            this.btn_Calc.IsEnabled = false;
            cts = new CancellationTokenSource();
            var mainThread = Thread.CurrentThread;
            int currentThreadId = mainThread.ManagedThreadId;//获取当前线程id
            var subThreadId = 0;
            var rd = new Random();
            Observable.Interval(TimeSpan.FromMilliseconds(1000)).
                SubscribeOn(new DispatcherScheduler(Dispatcher.FromThread(mainThread))).
                Select(i =>
                {
                    this.txt_value.Text = "chencang";
                    subThreadId = Thread.CurrentThread.ManagedThreadId;
                    return 0;
                }).
                ObserveOn(DispatcherScheduler.Current).
                Subscribe(
                i=>
                {
                    //int threadid = Thread.CurrentThread.ManagedThreadId;
                    //this.txt_value.Text = rd.Next(1, 100).ToString();
                    this.txt_value.Text = $"{currentThreadId}--{subThreadId}";
                }, cts.Token);
        }

        private void btn_stop(object sender, RoutedEventArgs e)
        {
            this.btn_Calc.IsEnabled = true;
            cts.Cancel();
            cts.Dispose();
        }
    }
}
