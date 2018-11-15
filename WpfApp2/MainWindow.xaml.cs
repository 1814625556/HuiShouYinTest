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

namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.txtB.PageDown();
        }

        private void DefaultButton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("DEFAULT");
        }

        private void DefaultButton1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("aaaaaaaaaaa");
        }

        private void lstchang(object sender, SelectionChangedEventArgs e)
        {
            if (lst.SelectedItem == null) return;
            var control = lst.SelectedItem;
            
           
        }

        //private void ceshi(object sender, RoutedEventArgs e)
        //{
        //    this.txtRepeat.Text += "B";
        //}
    }
}
