using System;
using System.Diagnostics;
using System.Threading;
using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows.NativeStandardControls;
using RM.Friendly.WPFStandardControls;

namespace Voiceroid2_Driver
{
    public class VR2_Driver
    {
        //private readonly string DrvName = "Voiceroid2.Driver@echoseika.hgotoh.jp";
        //private readonly string DrvVersion = "20200430/c";
        //private readonly string DrvProdName = "VOICEROID2";
        //private readonly int CidBase = 2000;

        public SemaphoreSlim Semaphore = new SemaphoreSlim(1, 1);

        private WindowsAppFriend _app = null;
        private WindowControl uiTreeTop = null;
        private WPFTextBox    TalkTextBox = null;
        private WPFButtonBase PlayButton = null;

        //public void Voiceroid2_search()
        //{
        //    Process p = GetVoiceroidEditorProcess();

        //    if (p != null)
        //    {
        //        try
        //        {
        //            _app = new WindowsAppFriend(p);
        //            //uiTreeTop = WindowControl.FromZTop(_app);

        //            ////判明しているGUI要素特定
        //            //var tabs = uiTreeTop.GetFromTypeFullName("AI.Framework.Wpf.Controls.TitledTabControl");
        //            //VoicePresetTab = new WPFTabControl(tabs[0]);  // ボイス（プリセット）のタブコントロール
        //            //TuneTab = new WPFTabControl(tabs[1]);  // チューニングのタブコントロール


        //            ////標準タブにいる各話者毎のGUI要素データを取得
        //            //TuneTab.EmulateChangeSelectedIndex(1);
        //            //VoicePresetTab.EmulateChangeSelectedIndex(0);
        //            //AvatorListView_std = new WPFListView(uiTreeTop.GetFromTypeFullName("System.Windows.Controls.ListView")[0]);
        //            //ScanPreset(AvatorListView_std, 0, 0);

        //            ////ユーザータブにいる各話者プリセット毎のGUI要素データを取得
        //            //TuneTab.EmulateChangeSelectedIndex(1);
        //            //VoicePresetTab.EmulateChangeSelectedIndex(1);
        //            //AvatorListView_usr = new WPFListView(uiTreeTop.GetFromTypeFullName("System.Windows.Controls.ListView")[1]);
        //            //ScanPreset(AvatorListView_usr, AvatorListView_std.ItemCount, 1);
        //        }
        //        catch /*(Exception e)*/
        //        {
        //            //
        //        }
        //    }
        //}


        /// <summary>
        /// Voiceroid2のプロセスを取得
        /// </summary>
        /// <returns>プロセス</returns>
        private Process GetVoiceroidEditorProcess()
        {
            string winTitle1 = "VOICEROID2";
            string winTitle2 = winTitle1 + "*";

            int RetryCount = 3;
            int RetryWaitms = 500;
            Process p = null;

            for (int i = 0; i < 3; i++)
            {
                Process[] ps = Process.GetProcesses();

                foreach (Process pitem in ps)
                {
                    if ((pitem.MainWindowHandle != IntPtr.Zero) &&
                         ((pitem.MainWindowTitle.Equals(winTitle1)) || (pitem.MainWindowTitle.Equals(winTitle2))))
                    {
                        p = pitem;
                        break;
                    }
                }
                if (p != null) break;
                if (i < (RetryCount - 1)) Thread.Sleep(RetryWaitms);
            }

            return p;
        }

        /// <summary>
        /// 指定話者で指定テキストで発声
        /// </summary>
        /// <param name="cid">話者CID</param>
        /// <param name="talkText">発声させるテキスト</param>
        /// <returns>発声にかかった時間（ミリ秒）</returns>
        public double Play(string talkText)
        {
            Process p = GetVoiceroidEditorProcess();

            if (p != null)
            {
                try
                {
                    _app = new WindowsAppFriend(p);
                    uiTreeTop = WindowControl.FromZTop(_app);

                    var editUis = uiTreeTop.GetFromTypeFullName("AI.Talk.Editor.TextEditView")[0].LogicalTree();
                    TalkTextBox = new WPFTextBox(editUis[4]);     // テキストボックス
                    PlayButton = new WPFButtonBase(editUis[6]);  // 再生ボタン

                    // 最後の確認ダイアログを殺し切れていなかった時のための処理
                    var infoOldDlgs = WindowControl.GetFromWindowText(_app, "情報");
                    try
                    {
                        if ((infoOldDlgs.Length != 0) && (infoOldDlgs[0].WindowClassName == "#32770"))
                        {
                            //OKボタンを押す
                            NativeButton btn = new NativeButton(infoOldDlgs[0].IdentifyFromWindowClass("Button"));
                            btn.EmulateClick(new Async());
                            Thread.Sleep(10);
                        }
                    }
                    catch (Exception)
                    {
                        //
                    }

                }
                catch
                {
                    return 0.00 ;
                }
            }

            if(p == null) return -1.0;

            Semaphore.Wait();

            Stopwatch sw = new Stopwatch();
            bool iconFind = false;
            //int avatorIndex = ConvertAvatorIndex(cid);



            if (PlayButton == null) return 0.0;
            if (TalkTextBox == null) return 0.0;

            //TuneTab.EmulateChangeSelectedIndex(1);

            // 話者切り替え
            //AvatorSelect(avatorIndex);

            // 音声保存ボタンを使った再生終了判定を止めて、再生ボタンのアイコンの状態で判定する方法に変更する。
            var items01 = PlayButton.LogicalTree(TreeRunDirection.Descendants).ByType("System.Windows.Controls.Image");
            dynamic playButtonImage1 = items01[0].Dynamic(); // 再生アイコン。このアイコンが有効時？の判定はまだないな...
            dynamic playButtonImage2 = items01[1].Dynamic(); // 停止アイコン。処理ではこのアイコンのプロパティを持ている

            //ApplyEffectParameters(avatorIndex);
            //ApplyEmotionParameters(avatorIndex);

            // 再生中なので再生終了を待つ
            // ※再生ボタンのアイコンが再生アイコンに切り替わるのを待つ
            iconFind = playButtonImage2.IsVisible;
            if (iconFind)
            {
                while (iconFind)
                {
                    Thread.Sleep(10);
                    iconFind = playButtonImage2.IsVisible;
                }
            }

            TalkTextBox.EmulateChangeText(talkText);
            Thread.Sleep(10);

            sw.Start();

            PlayButton.EmulateClick();

            // 再生開始を待つ
            // 再生ボタンのアイコンが停止アイコンに切り替わるのを待つ
            iconFind = playButtonImage2.IsVisible;
            if (!iconFind)
            {
                while (!iconFind)
                {
                    Thread.Sleep(10);
                    iconFind = playButtonImage2.IsVisible;
                }
            }

            // 再生終了を待つ
            // 再生ボタンのアイコンが再生アイコンに切り替わるのを待つ
            iconFind = playButtonImage2.IsVisible;
            if (iconFind)
            {
                while (iconFind)
                {
                    Thread.Sleep(10);
                    iconFind = playButtonImage2.IsVisible;
                }
            }

            sw.Stop();
            Semaphore.Release();

            return sw.ElapsedMilliseconds;
        }
    }
}