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
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using System.Reactive.Concurrency;
using SpeechLib;
using WpfApp1.Pages;

namespace WpfApp1
{
    /// <inheritdoc />
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Audio(object sender, RoutedEventArgs e)
        {
            //StringToVoice("到账消费15元");
            //SpeachCC.instance().AnalyseSpeak("消费15元");
            SpRecognition.instance().BeginRec("你好");
            SpRecognition.instance().CloseRec();
        }

        /// <summary>
        /// 把字符串转换成声音
        /// </summary>
        /// <param name="str">要朗读的字符串</param>
        private void StringToVoice(string str)
        {
            if (str.Trim().Length <= 0) return;
            var svc = new SpVoiceClass();
            svc.Voice = svc.GetVoices(string.Empty, string.Empty).Item(0);
            const SpeechVoiceSpeakFlags spFlags = SpeechVoiceSpeakFlags.SVSFlagsAsync;
            svc.Speak(str, spFlags);
        }
        public class SpeachCC

        {

            private static SpeachCC _Instance = null;

            private SpeechLib.SpVoiceClass voice = null;

            private SpeachCC()

            {

                BuildSpeach();

            }

            public static SpeachCC instance()

            {

                if (_Instance == null)

                    _Instance = new SpeachCC();

                return _Instance;

            }

            private void SetChinaVoice()

            {

                voice.Voice = voice.GetVoices(string.Empty, string.Empty).Item(0);

            }

            private void SetEnglishVoice()

            {

                voice.Voice = voice.GetVoices(string.Empty, string.Empty).Item(1);


            }

            private void SpeakChina(string strSpeak)

            {

                SetChinaVoice();

                Speak(strSpeak);

            }

            private void SpeakEnglishi(string strSpeak)

            {

                SetEnglishVoice();

                Speak(strSpeak);

            }

            public void AnalyseSpeak(string strSpeak)

            {

                int iCbeg = 0;

                int iEbeg = 0;

                bool IsChina = true;

                for (int i = 0; i < strSpeak.Length; i++)

                {

                    char chr = strSpeak[i];

                    if (IsChina)

                    {

                        if (chr <= 122 && chr >= 65)

                        {

                            int iLen = i - iCbeg;



                            string strValue = strSpeak.Substring(iCbeg, iLen);

                            SpeakChina(strValue);

                            iEbeg = i;

                            IsChina = false;

                        }

                    }

                    else

                    {

                        if (chr > 122 || chr < 65)

                        {

                            int iLen = i - iEbeg;

                            string strValue = strSpeak.Substring(iEbeg, iLen);

                            this.SpeakEnglishi(strValue);

                            iCbeg = i;

                            IsChina = true;

                        }

                    }

                }//end for

                if (IsChina)

                {

                    int iLen = strSpeak.Length - iCbeg;

                    string strValue = strSpeak.Substring(iCbeg, iLen);

                    SpeakChina(strValue);

                }



                else

                {

                    int iLen = strSpeak.Length - iEbeg;

                    string strValue = strSpeak.Substring(iEbeg, iLen);

                    SpeakEnglishi(strValue);

                }

            }

            private void BuildSpeach()

            {

                if (voice == null)

                    voice = new SpVoiceClass();

            }

            public int Volume

            {

                get

                {

                    return voice.Volume;

                }

                set

                {

                    voice.SetVolume((ushort)(value));

                }

            }



            public int Rate

            {

                get

                {

                    return voice.Rate;

                }

                set

                {

                    voice.SetRate(value);

                }

            }

            private void Speak(string strSpeack)

            {

                try

                {

                    voice.Speak(strSpeack, SpeechVoiceSpeakFlags.SVSFlagsAsync);

                }

                catch (Exception err)

                {

                    throw (new Exception("发生一个错误：" + err.Message));

                }

            }

            public void Stop()



            {

                voice.Speak(string.Empty, SpeechLib.SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak);

            }

            public void Pause()

            {

                voice.Pause();

            }

            public void Continue()

            {

                voice.Resume();

            }

        }//end class

        public class SpRecognition
        {
            private static SpRecognition _Instance = null;
            private SpeechLib.ISpeechRecoGrammar isrg;
            private SpeechLib.SpSharedRecoContextClass ssrContex = null;
            string cDisplay;

            private SpRecognition()
            {
                ssrContex = new SpSharedRecoContextClass();
                isrg = ssrContex.CreateGrammar(1);
                SpeechLib._ISpeechRecoContextEvents_RecognitionEventHandler recHandle =
                    new _ISpeechRecoContextEvents_RecognitionEventHandler(ContexRecognition);
                ssrContex.Recognition += recHandle;
            }

            public void BeginRec(string tbResult)
            {
                isrg.DictationSetState(SpeechRuleState.SGDSActive);
                cDisplay = tbResult;
            }
            public static SpRecognition instance()
            {
                if (_Instance == null)
                    _Instance = new SpRecognition();
                return _Instance;
            }
            public void CloseRec()
            {
                isrg.DictationSetState(SpeechRuleState.SGDSInactive);
            }
            private void ContexRecognition(int iIndex, object obj, SpeechLib.SpeechRecognitionType type, SpeechLib.ISpeechRecoResult result)

            {
                cDisplay += result.PhraseInfo.GetText(0, -1, true);
            }

        
        }

    }
}
