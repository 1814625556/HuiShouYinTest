using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RxText
{
    class Program
    {
        static void Main(string[] args)
        {
            Observable.Start<int>(() => 70).Subscribe(x => Console.WriteLine($"OnNext:{x}"));
            //var entity = new SubjecTest.Animal();
            //entity.Start();
            //entity.MethodTest();

            //var entity = new SubjecTest.TianYu_test();
            //entity.Start();
            //entity.MethodTest();

            //Observable.Return<int>(22).Subscribe(
            //    x => Console.WriteLine($"OnNext: {x}"),
            //    ex => Console.WriteLine($"OnError: {ex}"),
            //    () => Console.WriteLine("OnCompleted")
            //    );

            //var sequence = GetIntervalObservable();
            //sequence.Subscribe
            //(
            //    x => Console.WriteLine($"OnNext: {x}"),
            //    ex => Console.WriteLine($"OnError: {ex}"),
            //    () => Console.WriteLine("OnCompleted")
            //);
            Thread.Sleep(4000);
            Console.ReadKey();
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
