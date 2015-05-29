using System;
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
    public partial class CustomButton : Button
    {
        private System.Reflection.Assembly myAssembly =
                 System.Reflection.Assembly.GetExecutingAssembly();

        private bool isMouseDown;

        /// <summary>
        /// クリックされていないときのボタンイメージ
        /// </summary>
        [
        Category("表示"),
        Description("クリックされていないときのボタンイメージの実行アセンブリからの相対パスです。")
        ]
        public string DefaultImgPass { get; set; }

        /// <summary>
        /// クリックされているときのボタンイメージ
        /// </summary>
        [
        Category("表示"),
        Description("クリックされているときのボタンイメージの実行アセンブリからの相対パスです。")
        ]
        public string MouseDawnImgPass { get; set; }


        public CustomButton()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Bitmap img;
            if (!isMouseDown)
            {
                try
                {
                    img = new Bitmap(myAssembly.GetManifestResourceStream
                            (DefaultImgPass));

                    pe.Graphics.DrawImage(img, 0, 0, this.Width, this.Height);
                    pe.Dispose();
                }
                catch (Exception ex)
                {
                    BMErrorLibrary.BMError.ErrorMessageOutput(ex.Message);
                }
            }
            else
            {
                try
                {
                    img = new Bitmap(myAssembly.GetManifestResourceStream
                            (MouseDawnImgPass));

                    pe.Graphics.DrawImage(img, 0, 0, this.Width, this.Height);
                    pe.Dispose();
                }
                catch (Exception ex)
                {

                    BMErrorLibrary.BMError.ErrorMessageOutput(ex.Message);
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
