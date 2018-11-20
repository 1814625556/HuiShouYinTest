using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfTest2.Annotations;

namespace WpfTest2.转换器使用.Entitys
{
    public class PersonCC : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsVisual { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        public virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
