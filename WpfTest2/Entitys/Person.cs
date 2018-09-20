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
        private string _name;
        public string Name
        {
            get => _name;
           
            set
            {
                if (_name!=value)
                {
                    _name = value;
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));//注意这里 需要引号
                }
            }
        }
        public int Age { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        public virtual void OnPropertyChanged(string propertyName=null)//这里传入的名称必须是属性的名称,为null的话就是 全部改变
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class PerList : INotifyPropertyChanged
    {
        public string Title { get; set; }
        public List<Person> PersonList { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
