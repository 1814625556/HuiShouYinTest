using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ScanTest
{
    class Program
    {
        static void Main(string[] args)
        {
            PortConfig config = new PortConfig()
            {
                Name = "COM3",
                BaudRate = 9600,
                DataBits = 8,
                StopBits = StopBits.One,
                Parity = Parity.None,
                HandShake = Handshake.None
            };
            var portService = new PortService();

            portService.Open(config);
            IObservable<string> _codeOb = Observable.FromEventPattern<DataReceiveEventArgs>(
                h => portService.DataReceive += h,
                h => portService.DataReceive -= h
            ).Select(p => p.EventArgs.Data);
            _codeOb.Take(1).Do(_ => portService.Close()).Subscribe(Console.WriteLine);


            //var ports = portService.GetAllPortNames();
            //portService.DataReceive += _portService_DataReceive;
            //portService.Open(config);
            Console.WriteLine("主线程 等待中~~~");
            Console.ReadKey();
        }
        public static void  _portService_DataReceive(object sender, DataReceiveEventArgs e)
        {
            Console.WriteLine(e.Data);
        }
    }
}
