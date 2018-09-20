using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
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
using System.Windows.Threading;
using System.Threading;

namespace WpfApp1.RxSchedule
{
    /// <summary>
    /// MeiMei.xaml 的交互逻辑
    /// </summary>
    public partial class MeiMei : Page
    {
        public MeiMei()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            var btnRxObservable = Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(
                h => btn_rx.Click += h,
                h => btn_rx.Click -= h
            ).Select(b => b.EventArgs);
            btnRxObservable.Subscribe(e =>
            {
                this.txt_box.Text = e.Source.ToString();
                this.block_text.Text = "ceshi";
            });

            try
            {
                //ObserveOn:包装源序列，以便在与当前线程关联的调度程序上运行其观察者回调。观察者在指定的线程上面观察Observable 并且执行操作
                //SubscribeOn:包装源序列，以便在指定的调度程序上运行其订阅和取消订阅逻辑。在指定的线程上面创建 Observable
                Thread thread = Thread.CurrentThread;

                //Observable.Interval(TimeSpan.FromMilliseconds(200)).ObserveOnDispatcher().Do(i => this.txt_box.Text = i.ToString()).Subscribe();

                //Observable.Interval(TimeSpan.FromMilliseconds(200)).ObserveOn(Dispatcher.FromThread(thread)).Do(i => this.txt_box.Text = i.ToString()).Select(
                //    x => x).Do(i=>this.txt_box2.Text=i.ToString()).
                //    Subscribe(
                //    _=>this.block_text.Text=$"{_}"
                //    );

                Observable.Interval(TimeSpan.FromMilliseconds(200)).ObserveOn(Dispatcher.FromThread(thread)).Subscribe(i => this.txt_box2.Text = i.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}
