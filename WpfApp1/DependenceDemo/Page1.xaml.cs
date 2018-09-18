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

using System.Windows.Shapes;

namespace WpfApp1.DependenceDemo
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            Page1_Loaded();
        }
        private void btnFontSize_Click(object sender, RoutedEventArgs e)
        {
            this.FontSize = Convert.ToInt32(drpWinFontSize.Text);
        }
        private void btnTextBlock_Click(object sender, RoutedEventArgs e)
        {
            this.textBlockInherited.FontSize = Convert.ToInt32(drpTxtFontSize.Text);
        }
        private void Page1_Loaded()
        {
            List<int> listFontSize = new List<int>();
            for (int i = 0; i <= 60; i++)
            {
                listFontSize.Add(i + 4);
            }
            drpTxtFontSize.ItemsSource = listFontSize;
            drpWinFontSize.ItemsSource = listFontSize;
        }

    }
}
