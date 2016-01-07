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
        private Bitmap offpicture;

        public Bitmap DefaultImage
        {
            get { return this.offpicture; }
            set
            {
                this.offpicture = value;
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
        public PictureButton()
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
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

    }
}
