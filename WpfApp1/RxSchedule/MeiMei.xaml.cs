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
            var btn_rxObservable = Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(
                h => btn_rx.Click += h,
                h => btn_rx.Click -= h
            ).Select(b => b.EventArgs);
            btn_rxObservable.Subscribe(e =>
            {
                this.txt_box.Text = e.Source.ToString();
                this.block_text.Text = "ceshi";
            });

            try
            {
                Thread thread = Thread.CurrentThread;
                //Observable.Interval(TimeSpan.FromMilliseconds(200)).ObserveOnDispatcher().Do(i => this.txt_box.Text = i.ToString()).Subscribe();
                Observable.Interval(TimeSpan.FromMilliseconds(200)).SubscribeOn(Dispatcher.FromThread(thread)).Do(i => this.txt_box.Text = i.ToString()).Select(
                    x => x).Do(i=>this.txt_box2.Text=i.ToString()).
                    Subscribe(
                    _=>this.block_text.Text=$"{_}"
                    );
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}
