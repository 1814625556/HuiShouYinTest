using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using FluffIt;

namespace RxText
{
    class Program
    {
        static void Main(string[] args)
        {
            //Observable.Interval(TimeSpan.FromMilliseconds(200)).Buffer()
            Console.WriteLine("this is  main funtion");
            Console.ReadKey();
        }
        /// <summary>
        /// defer 等到调用subscribe方法的时候才会执行 defer里面的函数，start直接执行
        /// </summary>
        static void TestDeferStart()
        {
            var defer = Observable.Defer<int>(() =>
                {
                    Console.WriteLine("defer....");
                    return Observable.Return(1);
                }
            );
            var start = Observable.Start(() =>
                {
                    Console.WriteLine("start...");
                    return 0;
                }
            );
            var normal = Observable.Return(2);
            start.Subscribe();
            defer.Subscribe();
        }

        /// <summary>
        /// selectMany, 将可观察序列的每个元素投影到可观察序列，并将得到的可观察序列合并为一个可观察序列
        /// </summary>
        public static void TestSelectMany()
        {
            Observable.Range(1, 3)
                .SelectMany(x => Observable.Range(10, x))
                .Subscribe(Console.WriteLine);
        }
        /// <summary>
        /// 每次发出一个对象就会 执行Do方法紧着着执行所有订阅的方法，！！每发出一个都会这样
        /// </summary>
        static void TestSelectNew()
        {
            var selectList = Observable.Range(1, 10).Select(i => new
            {
                Name = $"aaa{i}",
                Age = i
            }).Do(Console.WriteLine);
            //selectList.Subscribe(Console.WriteLine);
            selectList.Subscribe(en => Console.WriteLine("welcome to unit..."));
        }

        /// <summary>
        /// 可连接-普通Obserable：可连接的Observable的只有当调用Connect()方法的时候才发射
        /// </summary>
        public void TestPublishRefCount()
        {
            var testObservabel = Observable.Interval(TimeSpan.FromSeconds(1)).Publish();//转化成可连接的Observable

            testObservabel.Subscribe(Console.WriteLine);
            //testObservabel.Connect();//必须这样才会发射
            testObservabel.Select(i => new { Name = $"AAA{i}" }).Subscribe(Console.WriteLine);
            testObservabel.RefCount().Subscribe(i => Console.WriteLine($"SSSS{i}"));//等着最后一个观察者完成才会断开连接
        }

        /// <summary>
        /// return 将指定的类型转化成Observable并emit出来
        /// </summary>
        static void TestReturn()
        {
            List<string> list = new List<string>()
            {
                "aa",
                "bb",
                "cc",
                "dd"
            };
            //Observable.Interval(TimeSpan.FromMilliseconds(100)).Select(i=>$"aaa{i}").Throttle(TimeSpan.FromSeconds(1)).Subscribe(Console.WriteLine);
            Observable.Return<List<string>>(list).Subscribe(l => l.ForEach(Console.WriteLine));
        }

        /// <summary>
        /// retry:遇到错误返回 从新emit希望不要产生错误。throttle 阀门，当Observable不在emit数据后一段时间将最后产生的Observable发送出去
        /// </summary>
        static void RetryThrottleTest()
        {
            Observable.Range(1, 10).Throttle(TimeSpan.FromSeconds(1)).Do(i =>
            {
                if (i == 5) throw new Exception("i==5");
            }).Retry().Subscribe(Console.WriteLine);
        }

        

        public static void TestSelect()
        {
            Observable.Range(1, 3)
                .Select(x => Enumerable.Range(10, x))
                .Subscribe(
                 l=>l.ForEach(Console.WriteLine)
                );

        }

        public static void TestAsyncDown()
        {
            var request = WebRequest.Create("https://www.baidu.com/");
            //WebRequestExtensions.DownloadStringAsync(request).Subscribe(str=>Console.WriteLine(str.Substring(0,10)),e=>Console.WriteLine(e.Message));
            WebRequestExtensions.DownLoadTask(request).Subscribe(Console.WriteLine, e => Console.WriteLine(e.Message));
            //Console.WriteLine(str);
        }

        public static class WebRequestExtensions
        {
            // 利用 Rx 可以通过扩展方法来分离处理的主体，代码更加简洁
            
            public static IObservable<string> DownloadStringAsync(WebRequest request)
            {
                return Observable.FromAsyncPattern<WebResponse>(request.BeginGetResponse, request.EndGetResponse)()
                    .Select(res =>
                    {
                        using (var stream = res.GetResponseStream())
                        using (var sr = new StreamReader(stream))
                        {
                            string responseStr = sr.ReadToEnd();
                            Console.WriteLine("reactivex....");
                            return responseStr;
                        }
                    });
            }

            public static IObservable<string> DownLoadTask(WebRequest request)
            {
                return  Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, new object(),
                    TaskCreationOptions.None).ToObservable().Select(res=>
                    {
                        using (var stream = res.GetResponseStream())
                        using (var sr = new StreamReader(stream ?? throw new InvalidOperationException()))
                        {
                            var responseStr = sr.ReadToEnd();
                            Console.WriteLine("reactivex....");
                            return responseStr;
                        }
                    });
            }
        }



        public class cc : IDisposable
        {
            public string Name = "chenchang";
            public int Age = 16;
            public void Dispose()
            {
                Console.WriteLine("释放了资源。。。");
            }
        }

        private void test1()
        {
            Observable.Start<int>(() => 70).Subscribe(x => Console.WriteLine($"OnNext:{x}"));
            var entity = new SubjecTest.Animal();
            entity.Start();
            entity.MethodTest();

            //var entity = new SubjecTest.TianYu_test();
            //entity.Start();
            //entity.MethodTest();

            Observable.Return<int>(22).Subscribe(
                x => Console.WriteLine($"OnNext: {x}"),
                ex => Console.WriteLine($"OnError: {ex}"),
                () => Console.WriteLine("OnCompleted")
                );

            var sequence = GetIntervalObservable();
            sequence.Subscribe
            (
                x => Console.WriteLine($"OnNext: {x}"),
                ex => Console.WriteLine($"OnError: {ex}"),
                () => Console.WriteLine("OnCompleted")
            );
        }


        private static List<string> ObserverFun(IObservable<List<string>> list)
        {
            return list as List<string>;
        }

        private static IObservable<int> GetSimpleObservable()
        {
            return Observable.Return(42);
        }

        private static IObservable<int> GetThrowObservable()
        {
            return Observable.Throw<int>(new ArgumentException("Error in observable"));
        }

        private static IObservable<int> GetEmptyObservable()
        {
            return Observable.Empty<int>();
        }

        private static IObservable<int> GetTaskObservable()
        {
            return GetTask().ToObservable();
        }

        private static async Task<int> GetTask()
        {
            return 42;
        }

        private static IObservable<int> GetRangeObservable()
        {
            return Observable.Range(2, 10);
        }

        private static IObservable<long> GetIntervalObservable()
        {
            return Observable.Interval(TimeSpan.FromMilliseconds(200));
        }

        private static IObservable<int> GetCreateObservable()
        {
            return Observable.Create<int>(observer =>
            {
                observer.OnNext(1);
                observer.OnNext(2);
                observer.OnNext(3);
                observer.OnNext(4);
                observer.OnCompleted();
                return Disposable.Empty;
            });
        }

        private static IObservable<int> GetGenerateObservable()
        {
            return Observable.Generate(
                1,
                x => x < 5,
                x => x + 1,
                x => x
            );
        }
        
    }
    public class DisposeCC:IDisposable
    {
        public string Name { get; set; }

        public void Dispose()
        {
            Console.WriteLine("dispal");
        }
    }
}
