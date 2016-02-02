using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomPictureButton
{
    public partial class PictureButton_Stretch : UserControl
    {
        private Bitmap DefaultPicture;

        public Bitmap DefaultImage
        {
            get { return this.DefaultPicture; }
            set
            {
                this.DefaultPicture = value;
                this.pictureBox1.Image = value;
            }

        }
        public Bitmap MouseDownImage { get; set; }

        public PictureButton_Stretch()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseDownImage != null)
            {
                this.pictureBox1.Image = MouseDownImage;
            }
            else
            {
                this.pictureBox1.Image = null;
            }

            this.OnMouseDown(e);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (DefaultImage != null)
            {
                this.pictureBox1.Image = DefaultImage;
            }
            else
            {
                this.pictureBox1.Image = null;
            }

            this.OnMouseUp(e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
    }
}
