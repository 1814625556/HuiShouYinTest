using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Subjects;

namespace RxText
{
    /// <summary>
    /// 操作分离，使用教程
    /// </summary>
    public class UsingSubject
    {
        private Subject<Student> _subject = new Subject<Student>();
        public void Insert()
        {
            
            Console.WriteLine("Insert Student{Name='chenchang',Age=25}");
            _subject.OnNext(new Student(){Name = "chenchang",Age=25});//这里就是作为被观察者 - emit
        }

        private UsingSubject()
        {
        }

        static UsingSubject()
        {
            Usubject = new UsingSubject();
        }

        public static UsingSubject Usubject;

        public IObservable<Student> GetObservable()
        {
            return _subject;
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
