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
using System.Management;

namespace TestPrinter
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

        private void GetAllPrints(object sender, RoutedEventArgs e)
        {
            ManagementObjectCollection _allPrinterManagement;
            PrintsTxt.Text="";
            try
            {
                ManagementScope scope = new ManagementScope(@"\root\cimv2");
                scope.Connect();
                // Select Printers from WMI Object Collections
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
                _allPrinterManagement = searcher.Get();

                PrintsTxt.Text += "WorkOffline false \r\n";
                foreach (var printer in _allPrinterManagement)
                {
                    if (printer["WorkOffline"].ToString().ToLower().Equals("false"))
                        //lt.Add(printer["Name"]?.ToString());
                        PrintsTxt.Text += printer["Name"]?.ToString() + "\r\n";
                }
                PrintsTxt.Text += "WorkOffline all \r\n";
                foreach (var printer in _allPrinterManagement)
                {
                    //if (printer["WorkOffline"].ToString().ToLower().Equals("false"))
                        //lt.Add(printer["Name"]?.ToString());
                        PrintsTxt.Text += printer["Name"]?.ToString() + "\r\n";
                }

            }
            catch (Exception ex)
            {
                throw new Exception("获取打印机管理列表出错", ex);
            }
        }
    }
}
