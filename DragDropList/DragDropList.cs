using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DandDList
{
    /// <summary>
    /// ドラッグアンドドロップで項目の入れ替えが可能なListBoxを提供するクラス
    /// 使用の際はListItemTypeプロパティを変更すること
    /// </summary>
    public partial class DragDropList : ListBox
    {
        /// <summary>
        /// マウスの押された位置を覚える変数
        /// </summary>
        private Point mouseDownPoint = Point.Empty;

        /// <summary>
        /// listに入れるアイテムの型
        /// </summary>
        public Type ListItemType { get; set; }

        public DragDropList()
        {
            InitializeComponent();

            this.ListItemType = typeof(int);

            this.MouseMove += new MouseEventHandler(onMouseMove);
            this.MouseUp += new MouseEventHandler(onMouseUp);
            this.MouseDown += new MouseEventHandler(onMouseDown);
            this.DragEnter += new DragEventHandler(onDragEnter);
            this.DragDrop += new DragEventHandler(onDragDrop);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public override bool AllowDrop
        {
            get
            {
                return true;
            }
            set
            {
                base.AllowDrop = value;
            }
        }

        /// <summary>
        /// マウスが動いたときの処理
        /// 一定範囲まで動いたらドラッグアンドドロップを行う
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void onMouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownPoint != Point.Empty)
            {
                //ドラッグと判定しないマウスの位置の範囲
                Rectangle moveRect = new Rectangle(
                    mouseDownPoint.X - SystemInformation.DragSize.Width / 2,
                    mouseDownPoint.Y - SystemInformation.DragSize.Height / 2,
                    SystemInformation.DragSize.Width,
                    SystemInformation.DragSize.Height);

                if (!moveRect.Contains(e.X, e.Y))
                {
                    ListBox lbx = (ListBox)sender;

                    //ドラッグするアイテムのインデックス
                    int itemIndex = lbx.IndexFromPoint(mouseDownPoint);

                    if (itemIndex < 0)
                    {
                        return;
                    }

                    //ドラッグするアイテムを取得
                    var item = Convert.ChangeType(lbx.Items[itemIndex], ListItemType);
                 
                    //ドラッグアンドドロップ処理開始
                    DragDropEffects dde = lbx.DoDragDrop(item, DragDropEffects.All | DragDropEffects.Link);

                    if (dde == DragDropEffects.Move)
                    {
                        lbx.Items.RemoveAt(itemIndex);
                    }

                    mouseDownPoint = Point.Empty;
                }
            }
        }

        /// <summary>
        /// マウスを離したときの処理
        /// </summary>
        public virtual void onMouseUp(object sender, MouseEventArgs e)
        {
            mouseDownPoint = Point.Empty;
        }

        /// <summary>
        /// マウスを押したときの処理
        /// 押した位置記録
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void onMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ListBox lbx = (ListBox)sender;

                if (lbx.IndexFromPoint(e.X, e.Y) >= 0)
                {
                    mouseDownPoint = new Point(e.X, e.Y);
                }
                else
                {
                    mouseDownPoint = Point.Empty;
                }
            }
        }

        /// <summary>
        /// アイテムがドラッグされたときに呼び出される
        /// アイテム型を判定して受け入れるかどうか分岐
        /// virtual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void onDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(ListItemType))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// アイテムがドロップされたときの処理
        /// アイテムの型があっていればlistboxに追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void onDragDrop(object sender, DragEventArgs e)
        {
            ListBox target = (ListBox)sender;

            var item = e.Data.GetData(ListItemType);

            target.Items.Add(item);

        }

    }
}
