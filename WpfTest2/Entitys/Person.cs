using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using WpfTest2.Annotations;

namespace WpfTest2.Entitys
{
    public class Person : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Hobby hobby { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        public virtual void OnPropertyChanged(string propertyName=null)//这里传入的名称必须是属性的名称,为null的话就是 全部改变
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Hobby //: INotifyPropertyChanged
    {
        public string HobbyName { get; set; }
        public int Long { get; set; }

        //public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        //public virtual void OnPropertyChanged(string propertyName = null)//这里传入的名称必须是属性的名称,为null的话就是 全部改变
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
