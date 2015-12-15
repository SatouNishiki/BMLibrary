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
        public Bitmap OffImage { get; set; }
        public Bitmap OnImage { get; set; }
        public Image DefaultImage
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        public PictureButton()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (OnImage != null)
            {
                this.pictureBox1.Image = OnImage;
            }
            else
            {
                this.pictureBox1.Image = null;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.OffImage != null)
            {
                this.pictureBox1.Image = OffImage;
            }
            else
            {
                this.pictureBox1.Image = null;
            }
        }

    }
}
