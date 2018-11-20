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
using WpfTest2.转换器使用.Entitys;

namespace WpfTest2.转换器使用
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Page1 : Page
    {
        private PersonCC en;
        public Page1()
        {
            InitializeComponent();
            en= new PersonCC()
            {
                Name = "zhangsna",
                Age = 22,
                IsVisual = true
            };
            this.DataContext = en;
        }

        private void ceshi(object sender, RoutedEventArgs e)
        {
            en.IsVisual = false;
            en.Name = "88";
            en.OnPropertyChanged(null);
        }
    }
}
