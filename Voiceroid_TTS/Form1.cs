using System;
using System.Windows.Forms;

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
            string inputedText = txtBox_waitingTxt.Text;
            //Vroid2_akari.Vroid2_Speak(inputedText);

            //再生開始・終了の判別を行う
            //https://hgotoh.jp/wiki/doku.php/documents/voiceroid/assistantseika/assistantseika-093
            VR2_Driver driver = new VR2_Driver();
            driver.Play(inputedText);

            txtBox_waitingTxt.Text = "";

            //TODO
            //ステータス表示のラベル変更プログラムを書く
            //デザイン向上
            //自動起動
        }
    }    
}
