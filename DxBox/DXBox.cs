using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DxLibDLL;

namespace DxBox
{
    public partial class DXBox : PictureBox
    {

        public DXBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// DxLibが参照するハンドル
        /// </summary>
        public IntPtr DXHandle;

        /// <summary>
        /// 初期化イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void onShown(object sender, EventArgs e)
        {
            DX.SetUserWindow(DXHandle);// ハンドル変更
            DX.SetUseDirectInputFlag(DX.FALSE);// DirectInput初期化を行わない
            //    DX.SetNotWinFlag( DX.TRUE );// 何も表示しなくなっちゃう
            //    DX.ChangeWindowMode( DX.TRUE );// あんまり意味ない？スクリーンの挙動かどうか検証
            DX.DxLib_Init();
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);
        }

        /// <summary>
        /// 終了イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void onClose(object sender, EventArgs e)
        {
            DX.DxLib_End();
        }
    }
}
