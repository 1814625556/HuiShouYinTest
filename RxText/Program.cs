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

namespace RxText
{
    class Program
    {
        static void Main(string[] args)
        {
            var request = WebRequest.Create("https://www.baidu.com/");
            //WebRequestExtensions.DownloadStringAsync(request).Subscribe(str=>Console.WriteLine(str.Substring(0,10)),e=>Console.WriteLine(e.Message));
            WebRequestExtensions.DownLoadTask(request).Subscribe(Console.WriteLine,e=>Console.WriteLine(e.Message));
            //Console.WriteLine(str);
            Console.WriteLine("this is  main funtion");
            Console.ReadKey();
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
            /// <summary>
            /// 这是调用Task.Factory.FromAsync实现的异步调用
            /// </summary>
            /// <param name="request"></param>
            /// <returns></returns>
            public static IObservable<string> DownLoadTask(WebRequest request)
            {
                return  Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, 
                    request.EndGetResponse, new object(),
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
}
