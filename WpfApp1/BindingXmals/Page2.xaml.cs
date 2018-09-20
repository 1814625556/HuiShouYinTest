using System;
using System.Collections.Generic;
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
using System.Reactive;
using System.Reactive.Linq;

namespace WpfApp1.BindingXmals
{
    /// <summary>
    /// 数据绑定
    /// </summary>
    public partial class Page2 : Page
    {
        public ListLable ListLableContext;

        public Page2()
        {
            SetListLabel();
            InitializeComponent();
            this.DataContext = ListLableContext;
            Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(
                h => BtnAdd.Click += h,
                h => BtnAdd.Click -= h
            ).Subscribe(e => ListLableContext.lables.Add(new Lable()
                {
                    Name = "chenchang"
                })
            );
        }

        public void SetListLabel()
        {
            ListLableContext = new ListLable();
            ListLableContext.labelDesc = "ceshi";
            ListLableContext.lables = new List<Lable>()
            {
                new Lable(){Name = "aaaa",Age = 1},
                new Lable(){Name = "bbbb",Age = 2},
                new Lable(){Name = "ffff",Age = 3},
                new Lable(){Name = "hhhh",Age = 4},
                new Lable(){Name = "eeee",Age = 5},
            };
        }
    }
}
