using System;
using System.Collections.Generic;
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

namespace WpfApp1.Pages
{
    /// <summary>
    /// Page5.xaml 的交互逻辑
    /// </summary>
    public partial class Page5 : Page
    {
        public Page5()
        {
            InitializeComponent();
        }

        private Student p1 = new Student();

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            grid.DataContext = p1; //绑定数据
            p1.Name = "李四";
            p1.Hobby = "篮球";
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            p1.Age = p1.Age + 1;
            p1.Hobby = "足球";
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Hobby { get; set; }
    }

    public class Person : INotifyPropertyChanged
    {
        private String _name = "张三";
        private int _age = 24;
        private String _hobby = "篮球";

        public String Name
        {
            set
            {
                _name = value;
                if (PropertyChanged != null)//有改变
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));//对Name进行监听
                }
            }
            get
            {
                return _name;
            }
        }

        public int Age
        {
            set
            {
                _age = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Age"));//对Age进行监听
                }
            }
            get
            {
                return _age;
            }
        }
        public String Hobby//没有对Hobby进行监听
        {
            get { return _hobby; }
            set { _hobby = value; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

}
