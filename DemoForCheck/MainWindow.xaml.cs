using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Management;
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

namespace DemoForCheck
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
        private ManagementObjectCollection _allPrinterManagement;
        private void btn_clickPrint(object sender, RoutedEventArgs e)
        {
            GetAllPrinterManager();
            this.block_text.Text = "";
            foreach (var printer in _allPrinterManagement)
            {
                if (printer["WorkOffline"].ToString().ToLower().Equals("false"))
                    this.block_text.Text+=$"\r\n{printer["Name"]?.ToString()}";
            }
        }
        private void GetAllPrinterManager()
        {
            try
            {
                ManagementScope scope = new ManagementScope(@"\root\cimv2");
                scope.Connect();
                // Select Printers from WMI Object Collections
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
                _allPrinterManagement = searcher.Get();
            }
            catch (Exception ex)
            {
                throw new Exception("获取打印机管理列表出错", ex);
            }
        }

        private void GetAllPrinter2(object sender, RoutedEventArgs e)
        {
            this.block_text.Text = "";
            PrintDocument print = new PrintDocument();
            string sDefault = print.PrinterSettings.PrinterName;//默认打印机名
            foreach (string sPrint in PrinterSettings.InstalledPrinters)//获取所有打印机名称
            {
                this.block_text.Text += $"列表打印机：{sPrint}\r\n";
            }
        }

        private void GetAllPrinter3(object sender, RoutedEventArgs e)
        {
            GetAllPrinterManager();
            this.block_text.Text = "";
            foreach (var printer in _allPrinterManagement)
            {
                this.block_text.Text += $"\r\n{printer["Name"]?.ToString()}";
            }
        }
    }
}
