using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace RxText.SubjecTest
{
    public enum AnimalEnum
    {
        Cat,
        Dog,
        Tortoise
    }
    public class Animal
    {
        private readonly ISubject<AnimalEnum> _subject = new Subject<AnimalEnum>();
        public void Start()
        {
            _subject.Subscribe(
                p => {
                    int mun = 10 / (int)p;
                    Console.WriteLine(p.ToString());
                },
                ex => Console.WriteLine(ex.Message),
                () =>Console.WriteLine("complete ...  ")
                );
            //_subject.Where(single => single == AnimalEnum.Cat).Subscribe(_ => Console.WriteLine("cat .... "));
            //_subject.Subscribe(p => {
            //    Console.WriteLine(p);
            //});
        }
        public void MethodTest()
        {
            _subject.OnError(new Exception("ceshi"));
            _subject.OnNext(AnimalEnum.Dog);
            _subject.OnNext(AnimalEnum.Tortoise);
        }
    }
    public class Emploment
    {
        public string Name { get; set; }
        public string PhoneNum { get; set; }
        public int Age { get; set; }

    }
    public class TianYu_test
    {
        ISubject<Emploment> _subject = new Subject<Emploment>();
        public void Start()
        {
            _subject.Subscribe(p => Console.WriteLine(p.Name));
        }
        public void MethodTest()
        {
            _subject.OnNext(new Emploment() { Name="zhangsan",Age=22,PhoneNum="15721527020"});
        }
    }
}
