﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DragDropPictureBox;

namespace CustomControlDebugForm
{
    public partial class CustomControlDebugForm : Form
    {
        public CustomControlDebugForm()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            exChangeList1.ExchangeSelectedItem(exChangeList2);
        }

        private void customButton1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
