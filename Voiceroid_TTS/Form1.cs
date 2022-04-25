using System;
using System.Drawing;//LabelコンポーネントのForeColorを変更するのに必要
using System.Windows.Forms;
using Voiceroid2_Driver;//外部ファイルのクラスを使用するときに使用？？

namespace Voiceroid_TTS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Label_IsSpeakingStatus.Text = "Speaking";
            Label_IsSpeakingStatus.ForeColor = Color.Red;
            string inputedText = txtBox_waitingTxt.Text;

            //Vroid2_akari.Vroid2_Speak(inputedText);

            //再生開始・終了の判別を再生ボタンの画像の内容で行う
            //https://hgotoh.jp/wiki/doku.php/documents/voiceroid/assistantseika/assistantseika-093
            VR2_Driver driver = new VR2_Driver();
            if (driver.Play(inputedText) == -1.0)
            {
                Lavel_VR2_Status.Text = "Not runnning";
                Lavel_VR2_Status.ForeColor = Color.Red;
            }

            txtBox_waitingTxt.Text = "";
            Label_IsSpeakingStatus.Text = "Ready";
            Label_IsSpeakingStatus.ForeColor = Color.Green;

            //TODO
            //デザイン向上
            //自動起動
            //Voiceroid本体の起動確認←Windowsトーストでできない？（そもそもC#？）
        }
    }    
}
