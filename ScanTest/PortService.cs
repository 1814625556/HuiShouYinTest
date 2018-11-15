using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reactive.Linq;
using System.Text;

namespace ScanTest
{
    public class DataReceiveEventArgs : EventArgs
    {
        public DataReceiveEventArgs(string data)
        {
            Data = data;
        }
        public string Data { get; set; }
    }
    class PortService
    {
        public class DataBuffer
        {
            public readonly string[] Delimiter = { "\r\n", "\r", "\n" };
            private readonly StringBuilder _buffer = new StringBuilder();

            public List<string> Read(string data)
            {
                if (!Delimiter.Any(data.Contains))
                {
                    _buffer.Append(data);
                    return null;
                }
                var finish = Delimiter.Any(data.EndsWith);
                var datas = data.Split(Delimiter, StringSplitOptions.RemoveEmptyEntries);
                if (!datas.Any()) return null;
                datas[0] = _buffer.Append(datas[0]).ToString();
                _buffer.Clear();
                if (finish) return datas.ToList();
                _buffer.Append(datas.Last());
                return datas.Take(datas.Length - 1).ToList();
            }

            public void Flush() => _buffer.Clear();
        }

        private readonly SerialPort _serialPort = new SerialPort();
        public IList<string> GetAllPortNames() => SerialPort.GetPortNames();
        private readonly DataBuffer _buffer = new DataBuffer();
        public bool IsOpen => _serialPort.IsOpen;
        public void Open(PortConfig config)
        {
            if (string.IsNullOrEmpty(config.Name))
                throw new Exception("端口名称未设置，请先到设置页面设置端口信息", null);

            _serialPort.PortName = config.Name;

            _serialPort.BaudRate = config.BaudRate;
            _serialPort.DataBits = config.DataBits;
            _serialPort.StopBits = config.StopBits;
            _serialPort.Parity = config.Parity;
            _serialPort.Handshake = config.HandShake;

            _serialPort.Open();
            // 端口打开后先清除buffer
            _serialPort.DiscardInBuffer();
            _serialPort.BaseStream.Flush();
            _buffer.Flush();
            _serialPort.DataReceived += _serialPort_DataReceived;
          
        }

        public event EventHandler<DataReceiveEventArgs> DataReceive;

        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (_serialPort.BytesToRead == 0) return;
            var length = _serialPort.BytesToRead;
            var datas = new byte[length];
            _serialPort.Read(datas, 0, length);
            var code = Encoding.UTF8.GetString(datas);
            _buffer.Read(code)?.ForEach(p => DataReceive?.Invoke(this, new DataReceiveEventArgs(p)));
        }

        public void Close()
        {
            _serialPort.Close();
            _serialPort.DataReceived -= _serialPort_DataReceived;
            //_logger.Info($"{_serialPort.PortName} is code");
        }
    }
}
