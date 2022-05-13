
namespace Voiceroid_TTS
{
    partial class Form_Voiceroid_TTS
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_VR2_Play = new System.Windows.Forms.Button();
            this.txtBox_waitingTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Btn_VR2_Play
            // 
            this.Btn_VR2_Play.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_VR2_Play.Location = new System.Drawing.Point(12, 244);
            this.Btn_VR2_Play.Name = "Btn_VR2_Play";
            this.Btn_VR2_Play.Size = new System.Drawing.Size(450, 79);
            this.Btn_VR2_Play.TabIndex = 0;
            this.Btn_VR2_Play.Text = "ｱｶﾘﾁｬﾝｶﾜｲｲﾔｯﾀｰ";
            this.Btn_VR2_Play.UseVisualStyleBackColor = true;
            this.Btn_VR2_Play.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBox_waitingTxt
            // 
            this.txtBox_waitingTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBox_waitingTxt.Location = new System.Drawing.Point(12, 12);
            this.txtBox_waitingTxt.Multiline = true;
            this.txtBox_waitingTxt.Name = "txtBox_waitingTxt";
            this.txtBox_waitingTxt.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtBox_waitingTxt.Size = new System.Drawing.Size(447, 223);
            this.txtBox_waitingTxt.TabIndex = 1;
            this.txtBox_waitingTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBox_waitingTxt_KeyDown);
            // 
            // Form_Voiceroid_TTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 333);
            this.Controls.Add(this.txtBox_waitingTxt);
            this.Controls.Add(this.Btn_VR2_Play);
            this.Name = "Form_Voiceroid_TTS";
            this.Text = "Voiceroid_TTS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_VR2_Play;
        private System.Windows.Forms.TextBox txtBox_waitingTxt;
    }
}

