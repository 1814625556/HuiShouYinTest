using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxText
{
    public class Event4
    {
        public static void TimerTest()
        {
            //var polling =
            //    Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(1))
            //        .Select<object>(_ => watchTarget.Value)
            //        .DistinctUntilChanged(); // 只有在值发生变化时才引发事件(polling)


            // FileSystemWatcher的Changed事件
            // 发生一次变化，会触发多个事件
            var watcher =
                new FileSystemWatcher("C:\\", "test.txt")
                    { EnableRaisingEvents = true };

            // "对于1秒内连续发生的事件，进行过滤，只处理最后一个"
            // 变成一个相对更容易处理的对象
            var changed =
                Observable.FromEventPattern<FileSystemEventArgs>(
                        watcher, "Changed")
                    .Throttle(TimeSpan.FromSeconds(1)); // Throttle方法是只允许通过指定时间和指定值的内容（顾名思义：阀门）
        }
    }
}
