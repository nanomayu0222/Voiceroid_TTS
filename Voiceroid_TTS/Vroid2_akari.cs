using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows.NativeStandardControls;

namespace Voiceroid_TTS
{
    //サンプルコードをお借りしました。
    //https://hgotoh.jp/wiki/doku.php/documents/voiceroid/tips/tips-003

    class Vroid2_akari
    {
        static public void Vroid2_Speak(string inputedText)
        {
            talk(GetVoiceroid2hWnd(), inputedText);
        }

        // VOICEROID2 EDITOR ウインドウハンドル検索
        static IntPtr GetVoiceroid2hWnd()
        {
            IntPtr hWnd = IntPtr.Zero;

            string winTitle1 = "VOICEROID2";
            string winTitle2 = winTitle1 + "*";
            int RetryCount = 3;
            int RetryWaitms = 1000;

            for (int i = 0; i < RetryCount; i++)
            {
                Process[] ps = Process.GetProcesses();

                foreach (Process pitem in ps)
                {
                    if ((pitem.MainWindowHandle != IntPtr.Zero) &&
                           ((pitem.MainWindowTitle.Equals(winTitle1)) || (pitem.MainWindowTitle.Equals(winTitle2))))
                    {
                        hWnd = pitem.MainWindowHandle;
                    }
                }
                if (hWnd != IntPtr.Zero) break;
                if (i < (RetryCount - 1)) Thread.Sleep(RetryWaitms);
            }

            return hWnd;
        }

        // テキスト転記と再生ボタン押下
        static void talk(IntPtr hWnd, string talkText)
        {
            if (hWnd == IntPtr.Zero) return;

            //参照されたハンドルから、AutomationElementオブジェクトを取得
            AutomationElement ae = AutomationElement.FromHandle(hWnd);
            TreeScope ts1 = TreeScope.Descendants | TreeScope.Element;
            TreeScope ts2 = TreeScope.Descendants;

            // アプリケーションウインドウ
            AutomationElement editorWindow = ae.FindFirst(ts1, new PropertyCondition(AutomationElement.ClassNameProperty, "Window"));

            // 再生ボタン、テキストボックスが配置されているコンテナの名前は“c”
            AutomationElement customC = ae.FindFirst(ts1, new PropertyCondition(AutomationElement.AutomationIdProperty, "c"));

            // テキストボックスにテキストを転記
            AutomationElement textBox = customC.FindFirst(ts2, new PropertyCondition(AutomationElement.AutomationIdProperty, "TextBox"));
            ValuePattern elem1 = textBox.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            elem1.SetValue(talkText);

            // 再生ボタンを押す。再生ボタンはボタンのコレクション5番目(Index=4)
            AutomationElementCollection buttons = customC.FindAll(ts2, new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "ボタン"));
            InvokePattern elem2 = buttons[4].GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            elem2.Invoke();
        }
    }
}