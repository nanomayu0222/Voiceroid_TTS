
namespace Voiceroid_TTS
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtBox_waitingTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Label_IsSpeakingStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Lavel_VR2_Status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(567, 70);
            this.button1.TabIndex = 0;
            this.button1.Text = "ｱｶﾘﾁｬﾝｶﾜｲｲﾔｯﾀｰ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBox_waitingTxt
            // 
            this.txtBox_waitingTxt.Location = new System.Drawing.Point(12, 12);
            this.txtBox_waitingTxt.Multiline = true;
            this.txtBox_waitingTxt.Name = "txtBox_waitingTxt";
            this.txtBox_waitingTxt.Size = new System.Drawing.Size(567, 226);
            this.txtBox_waitingTxt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.label1.Location = new System.Drawing.Point(20, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Status:";
            // 
            // Label_IsSpeakingStatus
            // 
            this.Label_IsSpeakingStatus.AutoSize = true;
            this.Label_IsSpeakingStatus.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.Label_IsSpeakingStatus.ForeColor = System.Drawing.Color.Green;
            this.Label_IsSpeakingStatus.Location = new System.Drawing.Point(128, 331);
            this.Label_IsSpeakingStatus.Name = "Label_IsSpeakingStatus";
            this.Label_IsSpeakingStatus.Size = new System.Drawing.Size(117, 28);
            this.Label_IsSpeakingStatus.TabIndex = 2;
            this.Label_IsSpeakingStatus.Text = "<Status>";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.label3.Location = new System.Drawing.Point(21, 375);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Voiceroid2 Status:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Lavel_VR2_Status
            // 
            this.Lavel_VR2_Status.AutoSize = true;
            this.Lavel_VR2_Status.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.Lavel_VR2_Status.Location = new System.Drawing.Point(189, 375);
            this.Lavel_VR2_Status.Name = "Lavel_VR2_Status";
            this.Lavel_VR2_Status.Size = new System.Drawing.Size(84, 20);
            this.Lavel_VR2_Status.TabIndex = 3;
            this.Lavel_VR2_Status.Text = "<Status>";
            this.Lavel_VR2_Status.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 424);
            this.Controls.Add(this.Lavel_VR2_Status);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Label_IsSpeakingStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBox_waitingTxt);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtBox_waitingTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Label_IsSpeakingStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Lavel_VR2_Status;
    }
}

