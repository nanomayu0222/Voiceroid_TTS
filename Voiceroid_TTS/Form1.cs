using System;
using System.Drawing;//LabelコンポーネントのForeColorを変更するのに必要
using System.Windows.Forms;
using Voiceroid2_Driver;//外部ファイルのクラスを使用するときに使用？？
using Microsoft.Toolkit.Uwp.Notifications;

namespace Voiceroid_TTS
{
    public partial class Form_Voiceroid_TTS : Form
    {
        public Form_Voiceroid_TTS()
        {
            InitializeComponent();
            //Size = new Size(300, 190);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Btn_VR2_Play.Enabled = false;

            string inputedText = txtBox_waitingTxt.Text;

            //Vroid2_akari.Vroid2_Speak(inputedText);

            //再生開始・終了の判別を再生ボタンの画像の内容で行う
            //https://hgotoh.jp/wiki/doku.php/documents/voiceroid/assistantseika/assistantseika-093
            VR2_Driver driver = new VR2_Driver();
            if (driver.Play(inputedText) == -1.0)
            {
                // Requires Microsoft.Toolkit.Uwp.Notifications NuGet package version 7.0 or greater
                new ToastContentBuilder()
                    .AddArgument("action", "viewConversation")
                    .AddArgument("conversationId", 9813)
                    .AddText("Voiceroid2が起動していません。")
                    .AddText("Notifcation Visualiser")
                    .Show(); // Not seeing the Show() method? Make sure you have version 7.0, and if you're using .NET 5, your TFM must be net5.0-windows10.0.17763.0 or greater
            
            }

            txtBox_waitingTxt.Text = "";

            Btn_VR2_Play.Enabled = true;
            //TODO
            //デザイン向上
            //自動起動
        }

        private void txtBox_waitingTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (e.Shift)
                {
                    
                }
                else
                {
                    string inputedText = txtBox_waitingTxt.Text;

                    //Vroid2_akari.Vroid2_Speak(inputedText);

                    //再生開始・終了の判別を再生ボタンの画像の内容で行う
                    //https://hgotoh.jp/wiki/doku.php/documents/voiceroid/assistantseika/assistantseika-093
                    VR2_Driver driver = new VR2_Driver();
                    if (driver.Play(inputedText) == -1.0)
                    {
                        // Requires Microsoft.Toolkit.Uwp.Notifications NuGet package version 7.0 or greater
                        new ToastContentBuilder()
                            .AddArgument("action", "viewConversation")
                            .AddArgument("conversationId", 9813)
                            .AddText("Voiceroid2が起動していません。")
                            .AddText("Notifcation Visualiser")
                            .Show(); // Not seeing the Show() method? Make sure you have version 7.0, and if you're using .NET 5, your TFM must be net5.0-windows10.0.17763.0 or greater
                    }
                }
            }

            txtBox_waitingTxt.Text = "";
        }
    }    
}
