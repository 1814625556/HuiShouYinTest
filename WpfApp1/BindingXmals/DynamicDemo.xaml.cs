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
    /// DynamicDemo.xaml 的交互逻辑
    /// </summary>
    public partial class DynamicDemo : Page
    {
        public DynamicDemo()
        {
            InitializeComponent();
        }

        private void ChangeBrushToYellow_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["RedBrush"] = new SolidColorBrush(Colors.Yellow);
        }
    }
}
