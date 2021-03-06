﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomCntrol
{
    /// <summary>
    /// デフォルトコントロールボタンのクソ邪魔な枠線が無い、画像のみボタンを作成できるクラス
    /// </summary>
    public partial class CustomButton : Button
    {
        private System.Reflection.Assembly myAssembly =
                 System.Reflection.Assembly.GetExecutingAssembly();

        private bool isMouseDown;

        /// <summary>
        /// クリックされていないときのボタンイメージがある場所
        /// </summary>
        [
        Category("表示"),
        Description("クリックされていないときのボタンイメージの実行アセンブリからの相対パスです。")
        ]
        public string DefaultImgPass { get; set; }

        /// <summary>
        /// クリックされているときのボタンイメージがある場所
        /// </summary>
        [
        Category("表示"),
        Description("クリックされているときのボタンイメージの実行アセンブリからの相対パスです。")
        ]
        public string MouseDownImgPass { get; set; }


        public CustomButton()
        {
            InitializeComponent();
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Bitmap img;
            if (!isMouseDown)
            {
                try
                {
                    img = new Bitmap(Application.StartupPath + "\\" + DefaultImgPass);

                    pe.Graphics.DrawImage(img, 0, 0, this.Width, this.Height);
                    pe.Dispose();
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                try
                {
                    img = new Bitmap(Application.StartupPath + "\\" + MouseDownImgPass);

                    pe.Graphics.DrawImage(img, 0, 0, this.Width, this.Height);
                    pe.Dispose();
                }
                catch (Exception ex)
                {
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            isMouseDown = true;
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            isMouseDown = false;
            this.Refresh();

        }
    }
}
