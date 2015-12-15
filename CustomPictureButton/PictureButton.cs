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
        public Bitmap OffPicture { get; set; }
        public Bitmap OnPicture { get; set; }

        public PictureButton()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (OnPicture != null)
            {
                this.pictureBox1.Image = OffPicture;
            }
            else
            {
                this.pictureBox1.Image = null;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.OnPicture != null)
            {
                this.pictureBox1.Image = OnPicture;
            }
            else
            {
                this.pictureBox1.Image = null;
            }
        }

    }
}
