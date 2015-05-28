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
            this.customButton1 = new CustomCntrol.CustomButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // customButton1
            // 
            this.customButton1.DefaultImgPass = "CustomCntrol.Picture.SampleButton.png";
            this.customButton1.Location = new System.Drawing.Point(12, 93);
            this.customButton1.MouseDawnImgPass = "CustomCntrol.Picture.SampleButton2.png";
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
            // CustomControlDebugForm
            // 
            this.ClientSize = new System.Drawing.Size(301, 280);
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









    }
}

