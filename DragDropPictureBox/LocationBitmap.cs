﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Utility;

namespace DragDropPictureBox
{
    [Serializable]
    public class LocationBitmap
    {
        /// <summary>
        /// 描画に使う画像
        /// </summary>
        public Bitmap Graphics { get; set; }

        /// <summary>
        /// 描画位置
        /// </summary>
        public Point Location { get; set; }

        /// <summary>
        /// この画像を動かせるかどうか
        /// </summary>
        public bool CanMove { get; set; }

        public LocationBitmap()
        {
            Graphics = null; ;
            Location = new Point();
            CanMove = true;
        }

        public LocationBitmap(Bitmap b, Point p)
        {
            Graphics = b;
            Location = p;
            CanMove = true;
        }

        public LocationBitmap CloneDeep()
        {
            return Util.CloneDeep<LocationBitmap>(this);
        }
    }
}
