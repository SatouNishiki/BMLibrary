﻿namespace DragDropPictureBox
{
    partial class DragDropBox
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // DragDropBox
            // 
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDropBox_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragDropBox_DragEnter);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragDropBox_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DragDropBox_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DragDropBox_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
