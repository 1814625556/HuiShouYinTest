using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<Person> perlist = new ObservableCollection<Person>();//ObservableCollection 集合 对增删改查都会有反应
        public DataContextTest()
        {
            InitializeComponent();
            InitialData();
        }

        public void InitialData()
        {
            this.DockPanel1.DataContext = per;
            for (int i = 0; i < 3; i++)
            {
                perlist.Add(new Person()
                {
                    Name = $"AAA{i}",
                    Age = i+20,
                    hobby = new Hobby()
                    {
                        HobbyName = $"pingbang{i}"
                    }
                });
            }
            this.ListBox1.ItemsSource = perlist;
        }

        private void BtnChangePersonInfo(object sender, RoutedEventArgs e)
        {
            //per.Name = "lisi";
            //per.Age = 77;
            //per.OnPropertyChanged();

            //perlist[1].Name = "zhangsan";
            //perlist[1].Age = 33;
            //perlist[1].OnPropertyChanged();


            //perlist.Add(new Person(){Name = "BBBB",Age = 11});  //这是增加操作
            //perlist.Remove(perlist[0]);
            perlist[1].Name = "ChenChang";
            perlist[1].hobby = new Hobby(){HobbyName = "pingpang"};
            perlist[1].OnPropertyChanged();// 就算是 Hobby没有实现 INotifyPropertyChanged接口 也不影响了
        }
    }
}
