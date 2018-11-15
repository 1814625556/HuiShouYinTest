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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTest2.WpfAnimal
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    //实例化一个DoubleAnimation类。
        //    DoubleAnimation doubleAnimation = new DoubleAnimation();
        //    //设置From属性。
        //    doubleAnimation.From = btn1.Width;
        //    //设置To属性。
        //    doubleAnimation.To = 250;
        //    //设置Duration属性。
        //    doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
        //    //为元素设置BeginAnimation方法。
        //    btn1.BeginAnimation(Button.WidthProperty, doubleAnimation);

        //    //实例化一个DoubleAnimation动画，用于设置元素的高。
        //    DoubleAnimation doubleAnimationHeight = new DoubleAnimation();
        //    //设置Form属性。
        //    doubleAnimationHeight.From = btn1.Height;
        //    //设置To属性的值。
        //    doubleAnimationHeight.By = 70;
        //    //设置时间。
        //    doubleAnimationHeight.Duration = new Duration(TimeSpan.FromSeconds(3));
        //    //开始动画。
        //    btn1.BeginAnimation(Button.HeightProperty, doubleAnimationHeight);
        //}
    }
}
