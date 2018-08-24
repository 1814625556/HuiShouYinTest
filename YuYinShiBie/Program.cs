using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Recognition;//引用系统的Speech的识别
using System.Speech.Synthesis; //引用语音合成
using System.Speech;
using System.Threading;


namespace YuYinShiBie
{
    class Program
    {
        private static SpeechSynthesizer speech;
        /// <summary>
        /// 音量
        /// </summary>
        private static int value = 100;
        /// <summary>
        /// 语速
        /// </summary>
        private static int rate;
        static void Main(string[] args)
        {
            //speech = new SpeechSynthesizer();

            //new Thread(Speak).Start();
            var synth = new SpeechSynthesizer();
           
            //foreach (var iv in synth.GetInstalledVoices())
            //{
            //    Console.WriteLine(iv.VoiceInfo.Name);
            //}
            synth.SelectVoice("Microsoft Simplified Chinese");
            synth.SelectVoiceByHints(VoiceGender.Neutral,VoiceAge.Teen);
            synth.Volume = 100;
            synth.Rate = 0;
            //根据Voice的name属性确定要使用的Voice
            //synth.SelectVoice("Microsoft Sam");
            //根据文字内容合成语音
            var deskNo = 22;
            synth.Speak($"{deskNo}号桌消费15.9元");
            Console.ReadKey();

        }

        private static void Speak()
        {

            speech.Rate = rate;
            speech.SelectVoice("Microsoft Lili");//设置播音员（中文）
            //speech.SelectVoice("Microsoft Anna"); //英文
            speech.Volume = value;
            speech.SpeakAsync("你好");//语音阅读方法
            //speech.SpeakCompleted += speech_SpeakCompleted;//绑定事件
        }

    }
}
