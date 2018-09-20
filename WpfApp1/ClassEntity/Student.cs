using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using WpfApp1.Annotations;

namespace WpfApp1.ClassEntity
{
    public class Student : MarkupExtension
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }
    }

    public class Lable 
    {

        public string Name { get; set; }
        public int Age { get; set; }

    }

    public class ListLable : INotifyPropertyChanged
    {
        public string labelDesc { get; set; }
        public List<Lable> lables { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "lables")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
