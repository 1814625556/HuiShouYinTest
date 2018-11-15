using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace ScanTest
{
    public class PortConfig
    {
        /// <summary>
        /// 串口名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 波特率：发送数据的速度
        /// </summary>
        public int BaudRate { get; set; } = 9600;

        /// <summary>
        /// 数据帧中所含的数据位
        /// </summary>
        public int DataBits { get; set; } = 8;

        /// <summary>
        /// 数据帧中的停止位
        /// </summary>
        public StopBits StopBits { get; set; } = StopBits.None;

        /// <summary>
        /// 数据帧中的奇偶校验位
        /// </summary>
        public Parity Parity { get; set; } = Parity.None;

        /// <summary>
        /// 串口通讯的握手：当传输的数据量过大时会用到
        /// </summary>
        public Handshake HandShake { get; set; } = Handshake.None;
    }

    public class cc
    {
        /// <summary>
        /// 串口名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 波特率：发送数据的速度
        /// </summary>
        public int BaudRate { get; set; } = 9600;

        /// <summary>
        /// 数据帧中所含的数据位
        /// </summary>
        public int DataBits { get; set; } = 8;

        /// <summary>
        /// 数据帧中的停止位
        /// </summary>
        public StopBits StopBits { get; set; } = StopBits.None;

        /// <summary>
        /// 数据帧中的奇偶校验位
        /// </summary>
        public Parity Parity { get; set; } = Parity.None;

        /// <summary>
        /// 串口通讯的握手：当传输的数据量过大时会用到
        /// </summary>
        public Handshake HandShake { get; set; } = Handshake.None;
    }
}
