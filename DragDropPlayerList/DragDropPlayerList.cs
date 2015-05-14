using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DandDList;
using BMErrorLibrary;

namespace DandDPlayerList
{
    /// <summary>
    /// ドラッグアンドドロップが可能なリストボックスを継承したリスト
    /// チームを区別してドラッグアンドドロップができるように拡張
    /// 使用の際はListItemTypeプロパティを変更すること
    /// </summary>
    public partial class DragDropPlayerList : DragDropList
    {
        //自分のチームかどうか true:自チーム false:相手チーム
        public bool isMyTeam { get; set; }

        //ドラッグ元のlistboxのisnMyTeamを記憶
        private bool dragDropSourseTeam = true;

        public DragDropPlayerList()
        {
            InitializeComponent();
            this.isMyTeam = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public override void onMouseDown(object sender, MouseEventArgs e)
        {
            base.onMouseDown(sender, e);

            try
            {
                Convert.ChangeType(sender, typeof(DragDropPlayerList));

            }
            catch (Exception)
            {
                BMError.ErrorMessageOutput("移動元のListboxがDragDropPlayerと互換性がない恐れ");
            }

            //ドラッグ元のlistboxを格納
            dragDropSourseTeam = ((DragDropPlayerList)sender).isMyTeam;

      
        }

        public override void onMouseMove(object sender, MouseEventArgs e)
        {
            base.onMouseMove(sender, e);

            
        }

        public override void onDragEnter(object sender, DragEventArgs e)
        {

            bool b = false;

            try
            {
                Convert.ChangeType(sender, typeof(DragDropPlayerList));

            }
            catch (Exception)
            {
                BMError.ErrorMessageOutput("移動先のListboxがDragDropPlayerと互換性がない恐れ");
            }

            //そのデータに記載されているチームと同じチームのリストにドラッグしているのか判定
            if (dragDropSourseTeam == ((DragDropPlayerList)sender).isMyTeam)
                b = true;

            if (e.Data.GetDataPresent(ListItemType) && b)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

    }
}
