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
    public partial class PictureButton : UserControl
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
        /* public Image DefaultImage
         {
             get { return pictureBox1.Image; }
             set { pictureBox1.Image = value; }
         }
         */

        public PictureBoxSizeMode SizeMode
        {
            get { return this.pictureBox1.SizeMode; }
            set { this.pictureBox1.SizeMode = value; } }

        public PictureButton()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseDownImage != null)
            {
                pictureBox1.Image = MouseDownImage;
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
