using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ClassEntity;

namespace WpfApp1.Template
{
    /// <summary>
    /// Page3.xaml 的交互逻辑
    /// </summary>
    public partial class Page3 : Page
    {
        ObservableCollection<StudentNotify> persons = new ObservableCollection<StudentNotify>()
        {
            new StudentNotify() { Name ="LearningHard", Age=25},
            new StudentNotify() { Name ="HelloWorld", Age=22}
        };
        public Page3()
        {
            InitializeComponent();
            lstPerson.ItemsSource = persons;
        }
        public class StudentNotify : INotifyPropertyChanged
        {
            public string ID { get { return Guid.NewGuid().ToString(); } }

            public string Name { get; set; }

            public int Age { get; set; }


            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, e);
            }
        }
    }
}
