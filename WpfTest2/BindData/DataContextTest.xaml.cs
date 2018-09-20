using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfTest2.Entitys;

namespace WpfTest2.BindData
{
    /// <summary>
    /// DataContextTest.xaml 的交互逻辑
    /// </summary>
    public partial class DataContextTest : Page
    {
        Person per = new Person(){Name = "zhangsan",Age = 26};
        List<Person> perlist = new List<Person>();
        public DataContextTest()
        {
            InitializeComponent();
            InitialData();
        }

        public void InitialData()
        {
            this.DockPanel1.DataContext = per;
            for (int i = 0; i < 5; i++)
            {
                perlist.Add(new Person()
                {
                    Name = $"AAA{i}",
                    Age = i+20
                });
            }
            this.ListBox1.ItemsSource = perlist;
        }

        private void BtnChangePersonInfo(object sender, RoutedEventArgs e)
        {
            per.Name = "lisi";
            per.Age = 77;
            per.OnPropertyChanged();

            perlist[1].Name = "zhangsan";
            perlist[1].Age = 33;
            perlist[1].OnPropertyChanged();
        }
    }
}
