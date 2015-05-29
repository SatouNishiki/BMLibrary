namespace CustomControlDebugForm
{
    partial class CustomControlDebugForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
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
            this.components = new System.ComponentModel.Container();
            this.customButton1 = new CustomCntrol.CustomButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.customButton2 = new CustomCntrol.CustomButton();
            this.SuspendLayout();
            // 
            // customButton1
            // 
            this.customButton1.DefaultImgPass = "CustomControlDebugForm.Picture.SampleButton.png";
            this.customButton1.Location = new System.Drawing.Point(12, 93);
            this.customButton1.MouseDawnImgPass = "CustomControlDebugForm.Picture.SampleButton2.png";
            this.customButton1.Name = "customButton1";
            this.customButton1.Size = new System.Drawing.Size(277, 175);
            this.customButton1.TabIndex = 3;
            this.customButton1.Text = "customButton1";
            this.customButton1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 13);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(277, 74);
            this.textBox1.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // customButton2
            // 
            this.customButton2.DefaultImgPass = "CustomControlDebugForm.Picture.SampleButton.png";
            this.customButton2.Location = new System.Drawing.Point(393, 69);
            this.customButton2.MouseDawnImgPass = "CustomControlDebugForm.Picture.SampleButton2.png";
            this.customButton2.Name = "customButton2";
            this.customButton2.Size = new System.Drawing.Size(584, 117);
            this.customButton2.TabIndex = 5;
            this.customButton2.Text = "customButton2";
            this.customButton2.UseVisualStyleBackColor = true;
            // 
            // CustomControlDebugForm
            // 
            this.ClientSize = new System.Drawing.Size(1068, 280);
            this.Controls.Add(this.customButton2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.customButton1);
            this.Name = "CustomControlDebugForm";
            this.Text = "DebugForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomCntrol.CustomButton customButton1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private CustomCntrol.CustomButton customButton2;









    }
}

