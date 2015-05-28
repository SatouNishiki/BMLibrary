using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragDropPictureBox
{
    public partial class DragDropBox : PictureBox
    {
        public List<LocationBitmap> LocationBitmapList { get; set; }

        //マウスの押された位置
        private Point mouseDownPoint = Point.Empty;

        public DragDropBox()
        {
            InitializeComponent();

            //MSさんのバグでプロパティに表示されてないので動的に設定
            this.AllowDrop = true;

            LocationBitmapList = new List<LocationBitmap>();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Graphics g = pe.Graphics;

            foreach (var l in LocationBitmapList)
            {
                g.DrawImage(l.Graphics, l.Location);
               
                if (l.Graphics.Tag != null && l.Graphics.Tag.GetType() == typeof(string))
                {
                    g.DrawString(
                        (string)l.Graphics.Tag,
                        new Font("MS UI Gothic", 10), 
                        Brushes.Black, 
                        new Point(l.Location.X, l.Location.Y - 10)
                        );
                }
            }

        }

        private void DragDropBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (GetLocationBitmapFromPoint(new Point(e.X, e.Y)) != null)
                    mouseDownPoint = new Point(e.X, e.Y);
            }
            else
            {
                mouseDownPoint = Point.Empty;
            }
        }

        private void DragDropBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownPoint = Point.Empty;
        }

        private void DragDropBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownPoint != Point.Empty)
            {
                //ドラッグとしないマウスの移動範囲を取得する
                Rectangle moveRect = new Rectangle(
                    mouseDownPoint.X - SystemInformation.DragSize.Width / 2,
                    mouseDownPoint.Y - SystemInformation.DragSize.Height / 2,
                    SystemInformation.DragSize.Width,
                    SystemInformation.DragSize.Height);

                //ドラッグとする移動範囲を超えたか調べる
                if (!moveRect.Contains(e.X, e.Y))
                {
                    //ドラッグの準備
                    DragDropBox ddb = (DragDropBox)sender;

                    //ドラッグするアイテムの内容を取得する
                    LocationBitmap l = GetLocationBitmapFromPoint(mouseDownPoint);
                    Bitmap data = l.Graphics;

                    //ドラッグ&ドロップ処理を開始する
                    DragDropEffects dde =
                        ddb.DoDragDrop(data,
                            DragDropEffects.All);

                    //ドロップ効果がMoveの時はもとのアイテムを削除する
                    if (dde == DragDropEffects.Move)
                    {
                        ddb.Remove(l);
                        Refresh();
                    }

                    mouseDownPoint = Point.Empty;
                }
            }
        }

        public LocationBitmap GetLocationBitmapFromPoint(Point p)
        {
            foreach (var l in LocationBitmapList)
            {
                if(p.X >= l.Location.X && p.X <= l.Location.X + l.Graphics.Size.Width
                    && p.Y >= l.Location.Y && p.Y <= l.Location.Y + l.Graphics.Size.Height)
                {
                    return l;
                }
            }

            return null;
        }

        public void Remove(LocationBitmap l)
        {
            LocationBitmapList.RemoveAll(l2 => l2.Graphics == l.Graphics && l2.Location == l.Location);
        }

        private void DragDropBox_DragEnter(object sender, DragEventArgs e)
        {
            //ドラッグされているデータがBitmap型か調べ、
            //そうであればドロップ効果をMoveにする
            if (e.Data.GetDataPresent(typeof(Bitmap)))
                e.Effect = DragDropEffects.Move;
            else
                //string型でなければ受け入れない
                e.Effect = DragDropEffects.None;
        }

        private void DragDropBox_DragDrop(object sender, DragEventArgs e)
        {
            //ドロップされたデータがstring型か調べる
            if (e.Data.GetDataPresent(typeof(Bitmap)))
            {
                DragDropBox target = (DragDropBox)sender;

                //ドロップされたデータ(string型)を取得
                Bitmap b =
                    (Bitmap)e.Data.GetData(typeof(Bitmap));

               target.LocationBitmapList.Add(new LocationBitmap
                   (b, target.FindForm().PointToClient(new Point(e.X - target.Location.X, e.Y - target.Location.Y))));

                Refresh();
            }
        }

    }
}
