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
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }
    }
    public class StudentService

    {

        public List<Student> GetStudentList()

        {

            Student liang = new Student();

            liang.Age = "18";

            liang.Name = "梁丘";

            liang.Birthday = "1990-02-03";

            liang.Country = "中国";

            Student zuo = new Student();

            zuo.Age = "22";

            zuo.Name = "左丘";

            zuo.Birthday = "1992-02-03";

            zuo.Country = "中国";

            Student diwu = new Student();

            diwu.Age = "32";

            diwu.Name = "第五言";

            diwu.Birthday = "1982-11-03";

            diwu.Country = "中国";

            Student yang = new Student();

            yang.Age = "12";

            yang.Name = "羊舌微";

            yang.Birthday = "2002-11-13";

            yang.Country = "中国";

            List<Student> personList = new List<Student>();

            personList.Add(liang);

            personList.Add(zuo);

            personList.Add(diwu);

            personList.Add(yang);

            return personList;

        }



    }
    public class Student : DependencyObject

    {

        //声明一个静态只读的DependencyProperty字段

        public static readonly DependencyProperty NameProperty;

        public static readonly DependencyProperty AgeProperty;

        public static readonly DependencyProperty BirthdayProperty;

        public static readonly DependencyProperty CountryProperty;

        static Student()

        {

            //注册我们定义的依赖属性Name,Age,birthday,Country

            NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(Student),

                new PropertyMetadata("名称", OnValueChanged));

            AgeProperty = DependencyProperty.Register("Age", typeof(string), typeof(Student),

                new PropertyMetadata("年龄", OnValueChanged));

            BirthdayProperty = DependencyProperty.Register("Birthday", typeof(string), typeof(Student),

                new PropertyMetadata("出生日期", OnValueChanged));

            CountryProperty = DependencyProperty.Register("Country", typeof(string), typeof(Student),

                new PropertyMetadata("国家", OnValueChanged));

        }



        private static void OnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)

        {

            //当值改变时，我们可以在此做一些逻辑处理

        }



        //属性包装器，通过它来读取和设置我们刚才注册的依赖属性

        public string Name

        {

            get { return (string)GetValue(NameProperty); }

            set { SetValue(NameProperty, value); }

        }

        public string Age

        {

            get { return (string)GetValue(AgeProperty); }

            set { SetValue(AgeProperty, value); }

        }



        public string Birthday

        {

            get { return (string)GetValue(BirthdayProperty); }

            set { SetValue(BirthdayProperty, value); }

        }



        public string Country

        {

            get { return (string)GetValue(CountryProperty); }

            set { SetValue(CountryProperty, value); }

        }


    }
}
