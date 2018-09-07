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

namespace WpfApp1.BindingXmals
{
    /// <summary>
    /// BindingPage1.xaml 的交互逻辑
    /// </summary>
    public partial class BindingPage1 : Page
    {
        private string txt_BoxStr = "aaaa";
        public BindingPage1()
        {
            InitializeComponent();
        }

        private void cmd_SetLarge(object sender, RoutedEventArgs e)
        {
            sliderFontSize.Value = 30;
        }

        private void SetBinding()
        {
            Binding binding = new Binding();
            binding.Source = "MMMM";
            //binding.Path = "";
            //tex_box.SetBinding()
        }
    }
}
