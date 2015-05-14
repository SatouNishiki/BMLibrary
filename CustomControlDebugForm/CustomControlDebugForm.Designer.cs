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
            this.exChangeList1 = new ExchangeListBox.ExChangeList();
            this.exChangeList2 = new ExchangeListBox.ExChangeList();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exChangeList1
            // 
            this.exChangeList1.FormattingEnabled = true;
            this.exChangeList1.ItemHeight = 12;
            this.exChangeList1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.exChangeList1.Location = new System.Drawing.Point(36, 29);
            this.exChangeList1.Name = "exChangeList1";
            this.exChangeList1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.exChangeList1.Size = new System.Drawing.Size(120, 88);
            this.exChangeList1.TabIndex = 0;
            // 
            // exChangeList2
            // 
            this.exChangeList2.FormattingEnabled = true;
            this.exChangeList2.ItemHeight = 12;
            this.exChangeList2.Items.AddRange(new object[] {
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.exChangeList2.Location = new System.Drawing.Point(229, 29);
            this.exChangeList2.Name = "exChangeList2";
            this.exChangeList2.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.exChangeList2.Size = new System.Drawing.Size(120, 88);
            this.exChangeList2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(392, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CustomControlDebugForm
            // 
            this.ClientSize = new System.Drawing.Size(716, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.exChangeList2);
            this.Controls.Add(this.exChangeList1);
            this.Name = "CustomControlDebugForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ExchangeListBox.ExChangeList exChangeList1;
        private ExchangeListBox.ExChangeList exChangeList2;
        private System.Windows.Forms.Button button1;









    }
}

