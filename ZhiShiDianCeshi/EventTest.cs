using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZhiShiDianCeshi
{
    public delegate string PropertyChanged(string propertyName);
    /// <summary>
    /// 事件使用
    /// </summary>
    public class Teacher
    {
        private string name;
        public string Name
        {
            get => name;
            set
            {
                Console.WriteLine("Set ThreadId: " + Thread.CurrentThread.ManagedThreadId);
                peoChanged?.Invoke(value);
                name = value;
            }
        }
        public int Age { get; set; }
        public event PropertyChanged peoChanged;
    }
}
